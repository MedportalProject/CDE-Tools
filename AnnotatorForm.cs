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
using CDETools.Entity.MedportalDataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDETools
{
    public partial class AnnotatorForm : Form
    {
        public AnnotatorForm()
        {
            InitializeComponent();
        }

        private void ButtonInsertSampleText_Click(object sender, EventArgs e)
        {
            this.textBoxAnnoTerm.Text = "Melanoma is a malignant tumor of melanocytes which are found predominantly in skin but also in the bowel and the eye.";
        }

        private void ButtonGetAnnotation_Click(object sender, EventArgs e)
        {
            var annoResult = new List<MedportalDataGrid>();
            String annoText = this.textBoxAnnoTerm.Text.Trim();
            if (!annoText.Equals(""))
            {
                foreach (Control c in groupBoxOptionGroup.Controls)
                {
                    if ((c is RadioButton) && (c as RadioButton).Checked)
                    {
                        //MessageBox.Show("checked : " + c.Text);
                        if (c.Text.Equals("MedPortal"))
                        {
                            List<MedportalAnnoDataElement> result = AnnotationTextTerm.AnnoMedportal(annoText);
                            if (result == null)
                            {
                                MessageBox.Show("没有找到相应的本体术语标注，请重新输入!", "ERROR");
                            }
                            else
                            {
                                //foreach (PageCollection collection in searchResultFromBP)
                                for (int i = 0; i < result.Count; i++)
                                {
                                    //MessageBox.Show(collection.ID + collection.Links + collection.PrefLabel + collection.SemanticType);
                                    //MessageBox.Show(searchResultFromBP[i].Onto);
                                    annoResult.Add(new MedportalDataGrid() { Num = i + 1, Class = result[i].MedportalAnnoClass, Ontology = result[i].MedportalAnnoOntology, IRI = result[i].MedportalAnnoIRI });
                                }
                                dataGridViewAnnoText.DataSource = annoResult;
                                //this.textBoxAnnoTerm.Text = "";
                            }
                        }
                        if(c.Text.Equals("BioPortal"))
                        {
                            //PASS
                            
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入要标注的文本！", "ERROR");
            }
        }

        private void ButtonAnnoTextClear_Click(object sender, EventArgs e)
        {
            this.textBoxAnnoTerm.Text = "";
        }

        private void ButtonInsertAnnoToExcel_Click(object sender, EventArgs e)
        {
            //判断机制需要更加智能
            if (this.dataGridViewAnnoText.DataSource != null && this.dataGridViewAnnoText.Rows.Count > 0)
            {
                if (this.dataGridViewAnnoText.Rows.Count == 0)
                {
                    MessageBox.Show("未查询到相应数据！");
                }
                else
                {
                    //int seletedHandle = this.dataGridViewResult.CurrentRow.Index;
                    //MessageBox.Show(dataGridViewResult.CurrentRow.Cells[3].Value.ToString());
                    //获得选中行的值
                    //EditExcel.getActivCell().Value = dataGridViewResult.CurrentRow.Cells[3].Value.ToString();
                    EditExcel.getActivCell().Value = StringHelper.insert2Excel(dataGridViewAnnoText.CurrentRow.Cells[2].Value.ToString(), dataGridViewAnnoText.CurrentRow.Cells[3].Value.ToString());
                    //MessageBox.Show(this.gridView1.GetRowCellValue(seletedHandle, "IRI").ToString());
                    //Insert2Excel.insert2Excel(this.gridView1.GetRowCellValue(seletedHandle, "Term").ToString(), this.gridView1.GetRowCellValue(seletedHandle, "IRI").ToString(), sheetControl);
                }
            }
            else
            {
                MessageBox.Show("请先搜索", "ERROR");
            }
        }
    }
}
