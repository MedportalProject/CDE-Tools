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
using System.Threading.Tasks;

namespace CDETools
{
    class StringHelper
    {
        /// <summary>
        /// 返回上传文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string getCurrPath(string path)
        {
            string[] paths = path.Split('.');
            return paths[0] + "-Metadate.xls";
        }

        /*
        public static DateElement getDateElement()
        {

        }
        */

        public static string getOntoName(string item)
        {
            string[] items = item.Split('/');
            return items[items.Count() - 1];
        }

        public static void insert2Excel(string term, string iri, NPOI.SS.UserModel.ICell cell)
        {
            //设置选中单元格的内容和公式
            //excelSheet.SelectedCell.Formula = outputHyperlink(term, iri);
            cell.SetCellValue(outputHyperlink(term, iri));
        }

        //Worksheet
        public static string insert2Excel(string term, string iri)
        {
            //设置选中单元格的内容和公式
            //excelSheet.SelectedCell.Formula = outputHyperlink(term, iri);
            return outputPaiallel(term, iri);
            //cell.SetCellValue(outputHyperlink(term, iri));
        }


        /**
         *输入：Term 和 IRI
         * 输出 =HYPERLINK函数
         * 显示格式  =HYPERLINK("http://purl.obolibrary.org/obo/OGMS_0000031"|"disease")
         */
        private static string outputHyperlink(string term, string iri)
        {
            return "=HYPERLINK(\"" + iri + "\"" + "|\"" + term + "\")";
        }

        /**
         *输入：Term 和 IRI
         * 输出 =HYPERLINK函数
         * 显示格式  ="http://purl.obolibrary.org/obo/OGMS_0000031"|"disease"
         */
        private static string outputPaiallel(string term, string iri)
        {
            return "\"" + iri + "\"|\"" + term + "\"";
        }

        /***
         * 
         */
        
    }
}
