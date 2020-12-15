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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDETools
{
    class AnnotationTextTerm
    {
        //Bioportal data urls
        private static string BIOPORTAL_ANNO_URL = "http://data.bioontology.org";

        //Medportal data urls
        //private static string MEDPORTAL_ANNO_URL = "http://medportal.bmicc.cn:8080";
        private static string MEDPORTAL_ANNO_URL = "http://data.medportal.bmicc.cn";
        # Replace your own APIKEY
        private static string MEDPORAL_KEY = "&apikey=YOUR-OWN-APIKEY";

        public static void AnnoBioportal(string textToAnnotate)
        {
            try
            {
                //PASS
                List<BioportalAnnoDataElement> madeList = new List<BioportalAnnoDataElement>();
                AnnotationResult[] annotationResults = Network.GetResponseAs<AnnotationResult[]>(BIOPORTAL_ANNO_URL + "/annotator?text=" + textToAnnotate);
                foreach (AnnotationResult annotationResult in annotationResults)
                {
                    BioportalAnnoDataElement MADE = new BioportalAnnoDataElement();

                    AnnotatedClass mac = annotationResult.AnnotatedClass;
                    MADE.BioportalAnnoIRI = mac.ID;
                    AnnotationLinks mal = new AnnotationLinks();
                    mal = mac.Link;
                    string[] ontologys = mal.Ontology.Split('/');
                    MADE.BioportalAnnoOntology = ontologys[ontologys.Length - 1];
                    /*
                    MedportalAnnotationPage annotationPage =
                    Network.GetResponseAs<MedportalAnnotationPage>(annotationResult.AnnotatedClass.Link.Self);
                    MADE.MedportalAnnoOntologyName = annotationPage.Links?.Ontology;
                    */
                    Annotation ma = annotationResult.Annotations[0];
                    MADE.BioportalAnnoClass = ma.Text;

                    //int from = ma.From - 1;
                    //int to = ma.To;
                    //MADE.MedportalAnnoContxt = textToAnnotate.Substring(from, to);


                    madeList.Add(MADE);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("服务器维护中，请稍后再试！");
            }
            //MessageBox.Show(result);
           
        }

        public static List<MedportalAnnoDataElement> AnnoMedportal(string textToAnnotate)
        {
            //string result = "";
            List<MedportalAnnoDataElement> madeList = new List<MedportalAnnoDataElement>();
            try
            {
                MedportalAnnotationResult[] annotationResults = MedporalNetwork.GetResponseAs<MedportalAnnotationResult[]>(MEDPORTAL_ANNO_URL + "/annotator?text=" + textToAnnotate + MEDPORAL_KEY);
                foreach (MedportalAnnotationResult annotationResult in annotationResults)
                {
                    MedportalAnnoDataElement MADE = new MedportalAnnoDataElement();

                    MedportalAnnotatedClass mac = annotationResult.AnnotatedClass;
                    MADE.MedportalAnnoIRI = mac.ID;
                    MedportalAnnotationLinks mal = new MedportalAnnotationLinks();
                    mal = mac.Link;
                    string[] ontologys = mal.Ontology.Split('/');
                    MADE.MedportalAnnoOntology = ontologys[ontologys.Length - 1];
                    /*
                    MedportalAnnotationPage annotationPage =
                        Network.GetResponseAs<MedportalAnnotationPage>(annotationResult.AnnotatedClass.Link.Self);
                    MADE.MedportalAnnoOntologyName = annotationPage.Links?.Ontology;
                    */
                    MedportalAnnotation ma = annotationResult.Annotations[0];
                    MADE.MedportalAnnoClass = ma.Text;

                    //int from = ma.From - 1;
                    //int to = ma.To;
                    //MADE.MedportalAnnoContxt = textToAnnotate.Substring(from, to);


                    madeList.Add(MADE);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("服务器维护中，请稍后再试！");
                MessageBox.Show(e.Message + e.StackTrace);
            }
            return madeList;
        }
    }
}
