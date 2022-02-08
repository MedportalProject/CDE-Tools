namespace CDETools
{
    partial class AnnotatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelAnnoTerm = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxAnnoTerm = new System.Windows.Forms.TextBox();
            this.groupBoxOptionGroup = new System.Windows.Forms.GroupBox();
            this.buttonAnnoTextClear = new System.Windows.Forms.Button();
            this.buttonInsertAnnoToExcel = new System.Windows.Forms.Button();
            this.buttonGetAnnotation = new System.Windows.Forms.Button();
            this.buttonInsertSampleText = new System.Windows.Forms.Button();
            this.radioButtonBioPortal = new System.Windows.Forms.RadioButton();
            this.radioButtonMedportal = new System.Windows.Forms.RadioButton();
            this.dataGridViewAnnoText = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnnoClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnnoOntology = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnnoIRI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanelAnnoTerm.SuspendLayout();
            this.groupBoxOptionGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnnoText)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelAnnoTerm
            // 
            this.tableLayoutPanelAnnoTerm.ColumnCount = 1;
            this.tableLayoutPanelAnnoTerm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAnnoTerm.Controls.Add(this.textBoxAnnoTerm, 0, 0);
            this.tableLayoutPanelAnnoTerm.Controls.Add(this.groupBoxOptionGroup, 0, 1);
            this.tableLayoutPanelAnnoTerm.Controls.Add(this.dataGridViewAnnoText, 0, 2);
            this.tableLayoutPanelAnnoTerm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAnnoTerm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelAnnoTerm.Name = "tableLayoutPanelAnnoTerm";
            this.tableLayoutPanelAnnoTerm.RowCount = 3;
            this.tableLayoutPanelAnnoTerm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.39267F));
            this.tableLayoutPanelAnnoTerm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.60733F));
            this.tableLayoutPanelAnnoTerm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tableLayoutPanelAnnoTerm.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanelAnnoTerm.TabIndex = 0;
            // 
            // textBoxAnnoTerm
            // 
            this.textBoxAnnoTerm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAnnoTerm.Location = new System.Drawing.Point(3, 3);
            this.textBoxAnnoTerm.Multiline = true;
            this.textBoxAnnoTerm.Name = "textBoxAnnoTerm";
            this.textBoxAnnoTerm.Size = new System.Drawing.Size(794, 138);
            this.textBoxAnnoTerm.TabIndex = 0;
            // 
            // groupBoxOptionGroup
            // 
            this.groupBoxOptionGroup.Controls.Add(this.buttonAnnoTextClear);
            this.groupBoxOptionGroup.Controls.Add(this.buttonInsertAnnoToExcel);
            this.groupBoxOptionGroup.Controls.Add(this.buttonGetAnnotation);
            this.groupBoxOptionGroup.Controls.Add(this.buttonInsertSampleText);
            this.groupBoxOptionGroup.Controls.Add(this.radioButtonBioPortal);
            this.groupBoxOptionGroup.Controls.Add(this.radioButtonMedportal);
            this.groupBoxOptionGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOptionGroup.Location = new System.Drawing.Point(3, 147);
            this.groupBoxOptionGroup.Name = "groupBoxOptionGroup";
            this.groupBoxOptionGroup.Size = new System.Drawing.Size(794, 41);
            this.groupBoxOptionGroup.TabIndex = 1;
            this.groupBoxOptionGroup.TabStop = false;
            this.groupBoxOptionGroup.Text = "Options";
            // 
            // buttonAnnoTextClear
            // 
            this.buttonAnnoTextClear.Location = new System.Drawing.Point(396, 9);
            this.buttonAnnoTextClear.Name = "buttonAnnoTextClear";
            this.buttonAnnoTextClear.Size = new System.Drawing.Size(80, 29);
            this.buttonAnnoTextClear.TabIndex = 5;
            this.buttonAnnoTextClear.Text = "Clear";
            this.buttonAnnoTextClear.UseVisualStyleBackColor = true;
            this.buttonAnnoTextClear.Click += new System.EventHandler(this.ButtonAnnoTextClear_Click);
            // 
            // buttonInsertAnnoToExcel
            // 
            this.buttonInsertAnnoToExcel.Location = new System.Drawing.Point(662, 9);
            this.buttonInsertAnnoToExcel.Name = "buttonInsertAnnoToExcel";
            this.buttonInsertAnnoToExcel.Size = new System.Drawing.Size(120, 29);
            this.buttonInsertAnnoToExcel.TabIndex = 4;
            this.buttonInsertAnnoToExcel.Text = "Insert to Excel";
            this.buttonInsertAnnoToExcel.UseVisualStyleBackColor = true;
            this.buttonInsertAnnoToExcel.Click += new System.EventHandler(this.ButtonInsertAnnoToExcel_Click);
            // 
            // buttonGetAnnotation
            // 
            this.buttonGetAnnotation.Location = new System.Drawing.Point(509, 9);
            this.buttonGetAnnotation.Name = "buttonGetAnnotation";
            this.buttonGetAnnotation.Size = new System.Drawing.Size(121, 29);
            this.buttonGetAnnotation.TabIndex = 3;
            this.buttonGetAnnotation.Text = "Get Annotations";
            this.buttonGetAnnotation.UseVisualStyleBackColor = true;
            this.buttonGetAnnotation.Click += new System.EventHandler(this.ButtonGetAnnotation_Click);
            // 
            // buttonInsertSampleText
            // 
            this.buttonInsertSampleText.Location = new System.Drawing.Point(219, 9);
            this.buttonInsertSampleText.Name = "buttonInsertSampleText";
            this.buttonInsertSampleText.Size = new System.Drawing.Size(143, 29);
            this.buttonInsertSampleText.TabIndex = 2;
            this.buttonInsertSampleText.Text = "Insert Sample Text";
            this.buttonInsertSampleText.UseVisualStyleBackColor = true;
            this.buttonInsertSampleText.Click += new System.EventHandler(this.ButtonInsertSampleText_Click);
            // 
            // radioButtonBioPortal
            // 
            this.radioButtonBioPortal.AutoSize = true;
            this.radioButtonBioPortal.Location = new System.Drawing.Point(135, 15);
            this.radioButtonBioPortal.Name = "radioButtonBioPortal";
            this.radioButtonBioPortal.Size = new System.Drawing.Size(77, 16);
            this.radioButtonBioPortal.TabIndex = 1;
            this.radioButtonBioPortal.TabStop = true;
            this.radioButtonBioPortal.Text = "BioPortal";
            this.radioButtonBioPortal.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedportal
            // 
            this.radioButtonMedportal.AutoSize = true;
            this.radioButtonMedportal.Checked = true;
            this.radioButtonMedportal.Location = new System.Drawing.Point(43, 15);
            this.radioButtonMedportal.Name = "radioButtonMedportal";
            this.radioButtonMedportal.Size = new System.Drawing.Size(77, 16);
            this.radioButtonMedportal.TabIndex = 0;
            this.radioButtonMedportal.TabStop = true;
            this.radioButtonMedportal.Text = "MedPortal";
            this.radioButtonMedportal.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAnnoText
            // 
            this.dataGridViewAnnoText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnnoText.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.AnnoClassName,
            this.AnnoOntology,
            this.AnnoIRI});
            this.dataGridViewAnnoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAnnoText.Location = new System.Drawing.Point(3, 194);
            this.dataGridViewAnnoText.Name = "dataGridViewAnnoText";
            this.dataGridViewAnnoText.RowTemplate.Height = 23;
            this.dataGridViewAnnoText.Size = new System.Drawing.Size(794, 253);
            this.dataGridViewAnnoText.TabIndex = 2;
            // 
            // Num
            // 
            this.Num.DataPropertyName = "Num";
            this.Num.HeaderText = "Num";
            this.Num.Name = "Num";
            this.Num.Width = 50;
            // 
            // AnnoClassName
            // 
            this.AnnoClassName.DataPropertyName = "Class";
            this.AnnoClassName.HeaderText = "CLASS";
            this.AnnoClassName.Name = "AnnoClassName";
            this.AnnoClassName.Width = 150;
            // 
            // AnnoOntology
            // 
            this.AnnoOntology.DataPropertyName = "Ontology";
            this.AnnoOntology.HeaderText = "ONTOLOGY";
            this.AnnoOntology.Name = "AnnoOntology";
            // 
            // AnnoIRI
            // 
            this.AnnoIRI.DataPropertyName = "IRI";
            this.AnnoIRI.HeaderText = "IRI";
            this.AnnoIRI.Name = "AnnoIRI";
            this.AnnoIRI.Width = 450;
            // 
            // AnnotatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanelAnnoTerm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AnnotatorForm";
            this.Text = "Annotator";
            this.tableLayoutPanelAnnoTerm.ResumeLayout(false);
            this.tableLayoutPanelAnnoTerm.PerformLayout();
            this.groupBoxOptionGroup.ResumeLayout(false);
            this.groupBoxOptionGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnnoText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAnnoTerm;
        private System.Windows.Forms.TextBox textBoxAnnoTerm;
        private System.Windows.Forms.GroupBox groupBoxOptionGroup;
        private System.Windows.Forms.Button buttonInsertAnnoToExcel;
        private System.Windows.Forms.Button buttonGetAnnotation;
        private System.Windows.Forms.Button buttonInsertSampleText;
        private System.Windows.Forms.RadioButton radioButtonBioPortal;
        private System.Windows.Forms.RadioButton radioButtonMedportal;
        private System.Windows.Forms.DataGridView dataGridViewAnnoText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnnoClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnnoOntology;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnnoIRI;
        private System.Windows.Forms.Button buttonAnnoTextClear;
    }
}