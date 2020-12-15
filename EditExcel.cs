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
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;
using ExcelDna.Integration;
using NPOI.HSSF.Model;
using NPOI.HSSF.UserModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using Microsoft.Office.Interop.Excel;

//使用NPOI

namespace CDETools
{
    class EditExcel
    {
        #region
        //creat new worksheet
        public static void CreateSheet(String filePath)
        {
            //获取当前活动的Excel
            Excel.Application application = (Excel.Application)Marshal.GetActiveObject("Excel.Application"); ;
            Excel.Workbook activWorkBook = (Excel.Workbook)application.ActiveWorkbook;
            application.Visible = true;
            if (!string.IsNullOrEmpty(filePath))
            {
                Excel.Workbooks wbks = application.Workbooks;
                //Excel._Workbook wbk = wbks.Add(filePath);
                activWorkBook = wbks.Add(filePath);
            }
        }
        #endregion

        /// <summary>
        /// 判断该页是否是活动页
        /// </summary>
        /// <returns>boolean</returns>
        public static Boolean IsSheetActive()
        {
            bool flag = false;
            Excel.Application application = (Excel.Application)Marshal.GetActiveObject("Excel.Application"); ;
            Excel.Workbook activWorkBook = (Excel.Workbook)application.ActiveWorkbook;

            if (activWorkBook!=null)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 获得活动的页面
        /// </summary>
        /// <returns>boolean</returns>
        public static Worksheet getActivSheet()
        {
            Excel.Application application = (Excel.Application)Marshal.GetActiveObject("Excel.Application"); ;
            Excel.Workbook activWorkBook = (Excel.Workbook)application.ActiveWorkbook;
            Worksheet ws = activWorkBook.ActiveSheet;
            Excel.Range rng = application.ActiveCell;
            //ISheet ist = (ISheet)activWorkBook.ActiveSheet;
            //MessageBox.Show(ws.Name);
            //MessageBox.Show(ist.SheetName);
            return ws;
            //MessageBox.Show(activWorkBook.Sheets.Item[1]);
            //return activWorkBook.Sheets.Item[1];
        }


        /// <summary>
        /// 获得Activcell
        /// </summary>
        /// <returns></returns>
        public static Excel.Range getActivCell()
        {
            Excel.Application application = (Excel.Application)Marshal.GetActiveObject("Excel.Application"); ;   
            Excel.Range rng = application.ActiveCell;
            return rng;
        }


        /// <summary>
        /// 创建Worksheet
        /// </summary>
        /// <returns></returns>
        public static Worksheet createCustomWorkbook()
        {
            string cpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\cdetool-Template.xls";
            //MessageBox.Show(cpath);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = hssfworkbook.CreateSheet("Data");
            FileStream file = new FileStream(@cpath, FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
            openFile(cpath);
            return (Worksheet)sheet;
        }


        /// <summary>
        /// 创建sheet
        /// </summary>
        /// <returns></returns>
        public static ISheet createWorkbook()
        {
            string cpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\cdetool-Template.xls";
            //MessageBox.Show(cpath);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = hssfworkbook.CreateSheet("Data");
            FileStream file = new FileStream(@cpath, FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
            openFile(cpath);
            return sheet;
        }


        /// <summary>
        /// 打开excel文件
        /// </summary>
        /// <param name="filePath"></param>
        public static void openFile(string filePath) 
        {
            //获取当前活动的Excel
            Excel.Application application = (Excel.Application)Marshal.GetActiveObject("Excel.Application"); ;
            Excel.Workbook activWorkBook = (Excel.Workbook)application.ActiveWorkbook;
            application.Visible = true;
            if (!string.IsNullOrEmpty(filePath))
            {
                Excel.Workbooks wbks = application.Workbooks;
                //Excel._Workbook wbk = wbks.Add(filePath);
                activWorkBook = wbks.Add(filePath);
            }
        }


        /// <summary>
        /// 设置单元格格式
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="cell"></param>
        private static HSSFCellStyle SetCellStyle(HSSFWorkbook workBook)
        {
            HSSFCellStyle cellStyle = (HSSFCellStyle)workBook.CreateCellStyle();
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//居中显示
            cellStyle.FillBackgroundColor = 244;
            //cellStyle.FillPattern = FillPatternType.BRICKS;//填充模式
            cellStyle.IsHidden = false;//单元格是否隐藏
            cellStyle.IsLocked = true;//单元格是否锁定
            cellStyle.VerticalAlignment = VerticalAlignment.Center;//垂直居中
            //单元格边线
            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;

            HSSFCellStyle fCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();
            HSSFFont ffont = (HSSFFont)workBook.CreateFont();
            ffont.Color = 200;
            //ffont.FontHeight = 15 * 15;
            ffont.Boldweight = 1;
            ffont.FontName = "Times New Roman";//设置为Times New Roman
            //ffont.Color = HSSFColor.Red.Index;
            //2007中直接设置就好
            //ffont.Color = 2;
            fCellStyle.SetFont(ffont);
            fCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//垂直对齐
            fCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//水平对齐
            cellStyle.SetFont(ffont);
            return cellStyle;
            //cell.CellStyle = fCellStyle;
        }


        /// <summary>
        /// 设定小数位显示，但是实际效果是：显示格式被更改，但是实际数据并没有被改动
        /// </summary>
        /// <param name="workBook"></param>
        /// <param name="colNum"></param>
        /// <returns></returns>
        public static HSSFCellStyle setDecimalPlaceFormat(HSSFWorkbook workBook, int decimalPlace)
        {
            HSSFCellStyle cellStyle = (HSSFCellStyle)workBook.CreateCellStyle();
            String decimalPlaceLength = "0.";
            for (int i = 0; i < decimalPlace; i++)
            {
                decimalPlaceLength += '0';
            }
            IDataFormat dataformat = workBook.CreateDataFormat();
            cellStyle.DataFormat = dataformat.GetFormat("0.0000");
            //cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat(decimalPlaceLength);
            //cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.0000");

            //HSSFCellStyle fCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();
            //HSSFFont ffont = (HSSFFont)workBook.CreateFont();
            //ffont.Color = HSSFColor.Red.Index;
            //cellStyle.SetFont(ffont);
            MessageBox.Show(decimalPlaceLength);
            return cellStyle;
        }


        /// <summary>
        /// 使用模板数据创建sheet
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="modulList"></param>
        public void createWorkbookWithDateElement(string filePath, List<DateElement> modulList)
        {
            //SetDataVali sdv = new SetDataVali();
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = hssfworkbook.CreateSheet("Data");
            HSSFCellStyle hcstyle = SetCellStyle(hssfworkbook);

            IRow ir = sheet.CreateRow(0);
            for (int i = 0; i < modulList.Count(); i++)
            {
                //待提高，增加验证规则的智能化
                //根据Metadata设置每列
                //ir.CreateCell(i).SetCellValue(modulList[i].PreferredQuestionText);
                ICell ic = ir.CreateCell(i);
                ic.CellStyle = hcstyle;
                ic.SetCellValue(modulList[i].PreferredQuestionText);
                //ICell ic = ir.CreateCell(i);
                //ic.SetCellValue(modulList[i].PreferredQuestionText);
                //ic.CellStyle = cellStyle;
                if (modulList[i].PreferredQuestionText.Contains("Date"))
                {
                    sheet.AddValidationData(SetDataVali.setDateVali(i, modulList[i]));
                }
                
                if (modulList[i].PreferredQuestionText.Contains("Name"))
                {
                    sheet.AddValidationData(SetDataVali.setLengthVali(i, modulList[i]));
                }

                if (modulList[i].PreferredQuestionText.Contains("Age"))
                {
                    //bug:同一行不能设置两种约束
                    //sheet.AddValidationData(SetDataVali.setLengthVali(i,modulList[i]));
                    sheet.AddValidationData(SetDataVali.setValueVali(i, modulList[i]));
                }

                if (modulList[i].PreferredQuestionText.Contains("Gender"))
                {
                    sheet.AddValidationData(SetDataVali.setGenderVali(i, modulList[i]));
                }

                if (modulList[i].PreferredQuestionText.Contains("WBC"))
                {
                    sheet.AddValidationData(SetDataVali.setNumericVali(i, modulList[i]));
                }

                //设置整列的默认单元格样式
                if (modulList[i].PreferredQuestionText.Contains("Height"))
                {
                    //sheet.SetDefaultColumnStyle(i, setDecimalPlaceFormat(hssfworkbook,5));
                }           
            }
            //设置冷冻行
            sheet.CreateFreezePane(0, 1, 0, 1);
            hssfworkbook.CreateSheet("Metadata");
            FileStream file = new FileStream(@filePath, FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }

    }
}
