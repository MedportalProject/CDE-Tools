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
using CDETools.Entity.MedportalDataTypes;
using CDETools.Entity.OLSDataTypes;
using Microsoft.Office.Interop.Excel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CDETools
{
    public partial class SearchTermForm : Form
    {
        public static Worksheet activSheet;
        
        public SearchTermForm()
        {
            /*
            if (EditExcel.IsSheetActive())
            {
                MessageBox.Show("get");
                activSheet = EditExcel.getActivSheet();
            }
            else
            {
                MessageBox.Show("None");
                activSheet = EditExcel.createCustomWorkbook();
            }*/
            activSheet = EditExcel.getActivSheet();
            
            InitializeComponent();
        }

        public class SearchResultItem
        {
            public int Num { get; set; }
            public string Onto { get; set; }
            public string Term { get; set; }
            public string IRI { get; set; }
        }

        private List<SearchResultItem> Search()
        {
            var result = new List<SearchResultItem>();

            //result.Add(new SearchResultItem() { ID = "ID1", Term = "Term1" });
            //result.Add(new SearchResultItem() { ID = "ID2", Term = "Term2" });
            string searchText = textBoxSearchTerm.Text.Trim();
            //MessageBox.Show(groupBoxSource.Controls.Count.ToString());
            if (!searchText.Equals(""))
            {
                foreach (Control c in groupBoxSource.Controls)
                {
                    if ((c is RadioButton) && (c as RadioButton).Checked)
                    {
                        // MessageBox.Show("checked : " + c.Text);
                        String r = "";
                        if (c.Text.Equals("BioPortal"))
                        {
                            List<BioportalPageCollection> searchResultFromBP = SearchOntoTerm.searchBioporalTerm(searchText);
                            if (searchResultFromBP == null)
                            {
                                MessageBox.Show("没有找到相应的本体术语，请重新输入!", "ERROR");
                            }
                            else
                            {
                                //foreach (PageCollection collection in searchResultFromBP)
                                for (int i = 0; i < searchResultFromBP.Count; i++)
                                {
                                    //MessageBox.Show(collection.ID + collection.Links + collection.PrefLabel + collection.SemanticType);
                                    //MessageBox.Show(searchResultFromBP[i].Onto);
                                    result.Add(new SearchResultItem() { Num = i+1, Onto = StringHelper.getOntoName(searchResultFromBP[i].Links.ontology), Term = searchResultFromBP[i].PrefLabel, IRI = searchResultFromBP[i].ID });
                                }
                            }
                        }
                        //search terms in OLS
                        if (c.Text.Equals("OLS"))
                        {
                            List<OLSDoc> searchResultFromOLS = SearchOntoTerm.SearchOLS(searchText);
                            if (searchResultFromOLS == null)
                            {
                                MessageBox.Show("没有找到相应的本体术语，请重新输入!", "ERROR");
                            }
                            else
                            {
                                //foreach (PageCollection collection in searchResultFromBP)
                                for (int i = 0; i < searchResultFromOLS.Count; i++)
                                {
                                    //MessageBox.Show(collection.ID + collection.Links + collection.PrefLabel + collection.SemanticType);
                                    //MessageBox.Show(searchResultFromBP[i].Onto);
                                    result.Add(new SearchResultItem() { Num = i+1, Onto = StringHelper.getOntoName(searchResultFromOLS[i].Ontology_name), Term = searchResultFromOLS[i].Label, IRI = searchResultFromOLS[i].IRI });
                                }
                            }
                        }
                        if (c.Text.Equals("MedPortal"))
                        {
                            List<MedportalPageCollection> searchResultFromMP = SearchOntoTerm.SearchMedporal(searchText);
                            if (searchResultFromMP == null)
                            {
                                MessageBox.Show("没有找到相应的本体术语，请重新输入!", "ERROR");
                            }
                            else
                            {
                                //foreach (PageCollection collection in searchResultFromBP)
                                for (int i = 0; i < searchResultFromMP.Count; i++)
                                {
                                    //MessageBox.Show(collection.ID + collection.Links + collection.PrefLabel + collection.SemanticType);
                                    //MessageBox.Show(searchResultFromBP[i].Onto);
                                    result.Add(new SearchResultItem() { Num = i + 1, Onto = StringHelper.getOntoName(searchResultFromMP[i].Links.ontology), Term = searchResultFromMP[i].PrefLabel, IRI = searchResultFromMP[i].ID });
                                }
                            }
                        }
                        if (c.Text.Equals("All"))
                        {
                            List<BioportalPageCollection> searchResultFromBP = SearchOntoTerm.searchBioporalTerm(searchText);
                            List<OLSDoc> searchResultFromOLS = SearchOntoTerm.SearchOLS(searchText);
                            List<MedportalPageCollection> searchResultFromMP = SearchOntoTerm.SearchMedporal(searchText);

                            result.Add(new SearchResultItem { Num = 0, Onto = "Bioporal", Term = "",IRI = "" });
                            for (int i = 0; i < searchResultFromBP.Count; i++)
                            {
                                //MessageBox.Show(collection.ID + collection.Links + collection.PrefLabel + collection.SemanticType);
                                //MessageBox.Show(searchResultFromBP[i].Onto);
                                result.Add(new SearchResultItem() { Num = i+1, Onto = StringHelper.getOntoName(searchResultFromBP[i].Links.ontology), Term = searchResultFromBP[i].PrefLabel, IRI = searchResultFromBP[i].ID });
                            }
                            result.Add(new SearchResultItem { Num = 0, Onto = "OLS", Term = "",IRI = "" });
                            for (int i = 0; i < searchResultFromOLS.Count; i++)
                            {
                                //MessageBox.Show(collection.ID + collection.Links + collection.PrefLabel + collection.SemanticType);
                                //MessageBox.Show(searchResultFromBP[i].Onto);
                                result.Add(new SearchResultItem() { Num = i+1, Onto = StringHelper.getOntoName(searchResultFromOLS[i].Ontology_name), Term = searchResultFromOLS[i].Label, IRI = searchResultFromOLS[i].IRI });
                            }
                            result.Add(new SearchResultItem { Num = 0, Onto = "Medporal", Term="", IRI = "" });
                            for (int i = 0; i < searchResultFromMP.Count; i++)
                            {
                                //MessageBox.Show(collection.ID + collection.Links + collection.PrefLabel + collection.SemanticType);
                                //MessageBox.Show(searchResultFromBP[i].Onto);
                                result.Add(new SearchResultItem() { Num = i + 1, Onto = StringHelper.getOntoName(searchResultFromMP[i].Links.ontology), Term = searchResultFromMP[i].PrefLabel, IRI = searchResultFromMP[i].ID });
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入要查询的术语！", "ERROR");
            }
            return result;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = Search();
            dataGridViewResult.DataSource = searchTerm;
            textBoxSearchTerm.Text = "";
        }

        private void ButtonInsertSearchItem_Click(object sender, EventArgs e)
        {
            //判断机制需要更加智能 2019.10.21
            if (this.dataGridViewResult.DataSource != null && this.dataGridViewResult.Rows.Count >0)
            {
                if (this.dataGridViewResult.Rows.Count == 0)
                {
                    MessageBox.Show("未查询到相应数据！");
                }
                else
                { 
                    //int seletedHandle = this.dataGridViewResult.CurrentRow.Index;
                    //MessageBox.Show(dataGridViewResult.CurrentRow.Cells[3].Value.ToString());
                    //获得选中行的值
                    //EditExcel.getActivCell().Value = dataGridViewResult.CurrentRow.Cells[3].Value.ToString();
                    EditExcel.getActivCell().Value = StringHelper.insert2Excel(dataGridViewResult.CurrentRow.Cells[2].Value.ToString(), dataGridViewResult.CurrentRow.Cells[3].Value.ToString());
                    //MessageBox.Show(this.gridView1.GetRowCellValue(seletedHandle, "IRI").ToString());
                    //Insert2Excel.insert2Excel(this.gridView1.GetRowCellValue(seletedHandle, "Term").ToString(), this.gridView1.GetRowCellValue(seletedHandle, "IRI").ToString(), sheetControl);
                }
            }
            else
            {
                MessageBox.Show("请先搜索本体术语", "ERROR");
            }
        }

        private void TableLayoutPanelSearchTerm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
