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
using CDETools.Entity.BioportalDataTypes;
using CDETools.Entity.Medporal;
using CDETools.Entity.MedportalDataTypes;
using CDETools.Entity.OLS;
using CDETools.Entity.OLSDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDETools
{
    /// <summary>
    /// 搜索选中term对应的本体
    /// </summary>
    public static class SearchOntoTerm
    {
        private static string BIOPORAL_BASIC_URL = "http://data.bioontology.org/search?q=";
        private static string OLS_BASIC_URL = "http://www.ebi.ac.uk/ols/api/search?q=";
        //private static string MEDPORAL_BASIC_URL = "http://medportal.bmicc.cn:8080/search?q=";
        private static string MEDPORAL_BASIC_URL = "http://data.medportal.bmicc.cn/search?q=";
        //updata in 2019-11-07，Medportal Server has changed,use IBMS Public account, IBMS, montag@126.com
        private static string MEDPORAL_KEY = "&apikey=28d4797a-96bb-4004-a5ed-444a947af325";

        /// <summary>
        /// 在Bioportal中搜索
        /// </summary>
        /// <param name="searchItem"></param>
        /// <returns></returns>
        public static List<BioportalPageCollection> searchBioporalTerm(string searchItem)
        {
            List<BioportalPageCollection> allCollections = new List<BioportalPageCollection>();
            try
            {
                BioportalPage page = Network.GetResponseAs<BioportalPage>(BIOPORAL_BASIC_URL + searchItem);
            
                foreach (BioportalPageCollection collection in page.Collections)
                {
                    allCollections.Add(collection);
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show("服务器忙，请稍后再试！");
            }
            return allCollections;
        }

        /// <summary>
        /// 在OLS中搜索
        /// </summary>
        /// <param name="searchItem"></param>
        /// <returns></returns>
        public static List<OLSDoc> SearchOLS(string searchItem)
        {
            Response olsr = new Response();
            List<OLSDoc> allDocs = new List<OLSDoc>();
            OLSPage op = OLSNetwork.GetResponseAs<OLSPage>(OLS_BASIC_URL + searchItem);
            olsr = op.Response;

            foreach (OLSDoc olsdoc in olsr.OLSDocs)
            {
                allDocs.Add(olsdoc);
            }
            return allDocs;
            //OLSNetwork.GetJsonResponse(OLS_BASIC_URL + searchItem);
        }

        /// <summary>
        /// 在Medportal中搜索
        /// </summary>
        /// <param name="searchItem"></param>
        /// <returns></returns>
        public static List<MedportalPageCollection> SearchMedporal(string searchItem)
        {
            List<MedportalPageCollection> allCollections = new List<MedportalPageCollection>();
            try
            {
                MedportalPage page = MedporalNetwork.GetResponseAs<MedportalPage>(MEDPORAL_BASIC_URL + searchItem + MEDPORAL_KEY);
                foreach (MedportalPageCollection collection in page.Collections)
                {
                    allCollections.Add(collection);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("服务器忙，请稍后再试！");
            }       
            return allCollections;
        }

    }
}
