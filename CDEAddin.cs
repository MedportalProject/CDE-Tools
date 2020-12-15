/// THIS FILE IS PART OF CDE TOOLS PROJECT 
/// CDE TOOLS, A TERM SEARCH AND ANNOTATION EXCEL-ADDIN.
///
/// THIS PROGRAM IS FREE SOFTWARE, IS LICENSED UNDER APACHE LICENSE V2.0
/// Copyright 2020 Institute of Basic Medical Sciences, Chinese Academy of Medical Sciences
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///    http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
/// 
/// IN THIS PROGRAM WE USED OTHER OPEN SOURCE PROGRAM AND NCBO BIOPORTAL SERVER REST API:
/// BIOPORTAL REST-API: http://data.bioontology.org/documentation 
/// Based partially an example by ncbo in github project ncbo/ncbo_rest_sample_code[1]:
///    [1]https://github.com/ncbo/ncbo_rest_sample_code
/// ExcelDNA: zLib license, Copyright (C) 2005-2020 Govert van Drimmelen
/// Newtonsoft.Json: The MIT License (MIT), Copyright (c) 2007 James Newton-King
/// npoi: Apache License Version 2.0
/// SEE FILE LICENSE IN LICENSE FOLDER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows;

using ExcelDna.Integration;
using ExcelDna.Integration.CustomUI;

using System.Xml.Linq;

using Excel = Microsoft.Office.Interop.Excel;


namespace CDETools
{
    /// <summary>
    /// Load ExcelDNA
    /// </summary>
    [ComVisible(true)]
    public class CDEAddin : ExcelRibbon
    {
        //记录IRibbon对象
        private static IRibbonUI customRibbon;
        EditExcel ee = new EditExcel();

        /// <summary>
        /// ribbon callback, get IRibbonUI object.
        /// </summary>
        public void ribbonLoaded(IRibbonUI ribbon)
        {
            customRibbon = ribbon;
        }

        public override string GetCustomUI(string RibbonID)
        {
            //首先判断office的版本
            string excel_Version = string.Empty;
            //如果office版本是office 2010
            string office_14 = "14";  
            //如果office版本是office 2007     
            if (((int)ExcelDnaUtil.ExcelVersion) <= 12) ver = "12";      
            string lang = "en";
            int excelLanguageIDUI = 2;                      
            int excellanguage = (ExcelDnaUtil.Application as dynamic).LanguageSettings.LanguageID[excelLanguageIDUI];
            //简体中文
            if (excellanguage == 2052) lang = "cn";       
            //office版本控制
            if (office_14.Equals("14") && lang.Equals("cn"))
                excel_Version = ResourceCustomUI.CustomUI14cn;
            else if (office_14.Equals("12") && lang.Equals("cn"))
            //    excel_Version = ResourceCustomUI.CustomUI12cn;
            return excel_Version;
        }

        /// <summary>
        /// upload XML Template
        /// </summary>
        /// <param name="control"></param>
        [ExcelCommand]
        public void uploadXML(IRibbonControl control)
        {
            //xml文件上传模块
            OpenFileDialog uploadXMLDiaglog = new OpenFileDialog();
            uploadXMLDiaglog.Filter = "Xml文件|*.xml";
            uploadXMLDiaglog.FileName = string.Empty;
            uploadXMLDiaglog.FilterIndex = 1;
            uploadXMLDiaglog.RestoreDirectory = true;
            if (uploadXMLDiaglog.ShowDialog() == DialogResult.OK)
            {
                //test
                MessageBox.Show(uploadXMLDiaglog.FileName);
                string xmlFilePath = uploadXMLDiaglog.FileName;

                //读取XML模板中的数据
                try
                {
                    XElement xe = XElement.Load(@xmlFilePath);
                    var elements = from ele in xe.Elements()
                                   select ele;
                    //引入数据模型接受数据
                    List<DateElement> modulList = new List<DateElement>();

                    //测试
                    //MessageBox.Show(modulList.Count.ToString());

                    //获得xml中所有数据以及其可用性范围
                    //其中值为空时，输出为'',并不是null
                    foreach (var ele in elements)
                    {
                        DateElement de = new DateElement();
                        de.LONGNAME = ele.Element("LONGNAME").Value;
                        de.PreferredQuestionText = ele.Element("PreferredQuestionText").Value;
                        de.Datatype = ele.Element("VALUEDOMAIN").Element("Datatype").Value;
                        de.ValueDomainType = ele.Element("VALUEDOMAIN").Element("ValueDomainType").Value;
                        de.UnitOfMeasure = ele.Element("VALUEDOMAIN").Element("UnitOfMeasure").Value != "" ? ele.Element("VALUEDOMAIN").Element("UnitOfMeasure").Value : null;
                        de.MaximumLength = ele.Element("VALUEDOMAIN").Element("MaximumLength").Value != "" ? Convert.ToInt32(ele.Element("VALUEDOMAIN").Element("MaximumLength").Value) : -1;
                        de.MinimumLength = ele.Element("VALUEDOMAIN").Element("MinimumLength").Value != "" ? Convert.ToInt32(ele.Element("VALUEDOMAIN").Element("MinimumLength").Value) : -1;
                        de.DecimalPlace = ele.Element("VALUEDOMAIN").Element("DecimalPlace").Value != "" ? Convert.ToInt32(ele.Element("VALUEDOMAIN").Element("DecimalPlace").Value) : -1;
                        de.MaximumValue = ele.Element("VALUEDOMAIN").Element("MaximumValue").Value != "" ? Convert.ToInt32(ele.Element("VALUEDOMAIN").Element("MaximumValue").Value) : -1;
                        de.MinimumValue = ele.Element("VALUEDOMAIN").Element("MinimumValue").Value != "" ? Convert.ToInt32(ele.Element("VALUEDOMAIN").Element("MinimumValue").Value) : -1;
                        modulList.Add(de);
                    }
                    //测试
                    MessageBox.Show(modulList.Count.ToString());

                    /**
                     *处理Excel
                     */
                    EditExcel ee = new EditExcel();
                    ee.createWorkbookWithDateElement(StringHelper.getCurrPath(xmlFilePath), modulList);
                    //ee.createWorkbook(sh.getCurrPath(xmlFilePath));
                    EditExcel.openFile(StringHelper.getCurrPath(xmlFilePath));
                }
                catch (Exception e)
                {
                    // english version alt information
                    MessageBox.Show("错误: " + e.Message + "上传的模板编码请设置成UTF-8，提示：另存为，右下角选择编码模式UTF-8");
                }

            }
        }

        /// <summary>
        /// 搜索模块
        /// </summary>
        /// <param name="control"></param>
        [ExcelCommand]
        public void searchTerm(IRibbonControl control)
        {
            //如果用户未创建sheet，将自动创建一个sheet
            if (!EditExcel.IsSheetActive())
            {
                EditExcel.createWorkbook();
            }
            Form sForm = new SearchTermForm();
            sForm.Show();
            
        }

        /// <summary>
        /// 注释模块
        /// </summary>
        /// <param name="control"></param>
        [ExcelCommand]
        public void annotatorTerm(IRibbonControl control)
        {
            //如果用户未创建sheet，将自动创建一个sheet
            if (!EditExcel.IsSheetActive())
            {
                EditExcel.createWorkbook();
            }
            Form aForm = new AnnotatorForm();
            aForm.Show();
        }

    }
}
