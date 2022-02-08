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
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDETools
{
    class SetDataVali
    {
        /***
         * 设置日期类型数据校验
         */
        public static HSSFDataValidation setDateVali(int colNum, DateElement de)
        {
            NPOI.SS.Util.CellRangeAddressList regionsData = new NPOI.SS.Util.CellRangeAddressList(1, 65535, colNum, colNum);
            DVConstraint constraintData = DVConstraint.CreateDateConstraint(OperatorType.BETWEEN, "1900-01-01", "2999-12-31", "yyyy-MM-dd");
            HSSFDataValidation dataValiDate = new HSSFDataValidation(regionsData, constraintData);
            dataValiDate.CreateErrorBox("Error", "You must input a date format between 1900/01/01-2999/12/31 as 'Year-Month-day'.");
            return dataValiDate;
        }


        /***
         * 设置姓名输入校验
         * 设置输入字符串的长度大于 MinimumLength 小于 MaximumLength
         */
        public static HSSFDataValidation setNameLengthVali(int colNum, DateElement de)
        {
            NPOI.SS.Util.CellRangeAddressList regionsName = new NPOI.SS.Util.CellRangeAddressList(1, 65535, colNum, colNum);
            DVConstraint constraintName = DVConstraint.CreateNumericConstraint(ValidationType.TEXT_LENGTH, OperatorType.BETWEEN, Convert.ToString(de.MinimumLength), Convert.ToString(de.MaximumLength));
            HSSFDataValidation dataValiName = new HSSFDataValidation(regionsName, constraintName);
            dataValiName.CreateErrorBox("Error", "Name length is more than " + de.MaximumLength);
            return dataValiName;
        }


        /***
         *设置年龄输入校验
         */
        public static HSSFDataValidation setAgeLengthVali(int colNum, DateElement de)
        {
            NPOI.SS.Util.CellRangeAddressList regionsName = new NPOI.SS.Util.CellRangeAddressList(1, 65535, colNum, colNum);
            DVConstraint constraintAge = DVConstraint.CreateNumericConstraint(ValidationType.TEXT_LENGTH, OperatorType.BETWEEN, Convert.ToString(de.MinimumLength), Convert.ToString(de.MaximumLength));
            HSSFDataValidation dataValiAge = new HSSFDataValidation(regionsName, constraintAge);
            dataValiAge.CreateErrorBox("Error", "Name length is more than " + de.MaximumLength);
            return dataValiAge;
        }


        /***
        * 设置字符串长度输入校验
        * 设置输入字符串的长度大于 MinimumLength 小于 MaximumLength
        */
        public static HSSFDataValidation setLengthVali(int colNum, DateElement de)
        {
            NPOI.SS.Util.CellRangeAddressList regionsLength = new NPOI.SS.Util.CellRangeAddressList(1, 65535, colNum, colNum);
            DVConstraint constraintLength = DVConstraint.CreateNumericConstraint(ValidationType.TEXT_LENGTH, OperatorType.BETWEEN, Convert.ToString(de.MinimumLength), Convert.ToString(de.MaximumLength));
            HSSFDataValidation dataValiLength = new HSSFDataValidation(regionsLength, constraintLength);
            dataValiLength.CreateErrorBox("Error", "length is more than " + de.MaximumLength);
            return dataValiLength;
        }


        /***
        * 设置字符串大小输入校验
        * 设置输入字符串的长度大于 MinimumLength 小于 MaximumLength
        */
        public static HSSFDataValidation setValueVali(int colNum, DateElement de)
        {
            NPOI.SS.Util.CellRangeAddressList regionsValue = new NPOI.SS.Util.CellRangeAddressList(1, 65535, colNum, colNum);
            DVConstraint constraintLength = DVConstraint.CreateNumericConstraint(ValidationType.INTEGER, OperatorType.BETWEEN, Convert.ToString(de.MinimumValue), Convert.ToString(de.MaximumValue));
            
            HSSFDataValidation dataValiValue = new HSSFDataValidation(regionsValue, constraintLength);
            dataValiValue.CreateErrorBox("Error", "You must input a numer between" + de.MinimumValue + " and " + de.MaximumValue);
            return dataValiValue;
        }


        /***
         *设置性别验证
         */
        public static HSSFDataValidation setGenderVali(int colNum, DateElement de)
        {
            NPOI.SS.Util.CellRangeAddressList regionsValue = new NPOI.SS.Util.CellRangeAddressList(1, 65535, colNum, colNum);
            DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(new string[] { "1", "2", "0", "9" });
            HSSFDataValidation dataValiGender = new HSSFDataValidation(regionsValue, constraint);
            dataValiGender.CreateErrorBox("Error","请从下拉框中选择！");
            return dataValiGender;
        }


        /***
         *设置是数字输入
         */
        public static HSSFDataValidation setNumericVali(int colNum, DateElement de)
        {
            NPOI.SS.Util.CellRangeAddressList regionsValue = new NPOI.SS.Util.CellRangeAddressList(1, 65535, colNum, colNum);
            DVConstraint constraint = DVConstraint.CreateNumericConstraint(ValidationType.INTEGER, OperatorType.BETWEEN, "0", Convert.ToString(int.MaxValue));
            HSSFDataValidation dataValiNum = new HSSFDataValidation(regionsValue, constraint);
            dataValiNum.CreateErrorBox("Error", "please input num");
            return dataValiNum;
        }


        /***
         *设置小数点位数校验
         */
        public static void setDecimalPlaceVali(int colNum, DateElement de)
        {
            //todo
        }


    }
}
