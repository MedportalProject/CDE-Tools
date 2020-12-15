namespace CDETools
{
    partial class SearchTermForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonInsertSearchItem = new System.Windows.Forms.Button();
            this.tableLayoutPanelSearchTerm = new System.Windows.Forms.TableLayoutPanel();
            this.labelTerm = new System.Windows.Forms.Label();
            this.textBoxSearchTerm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSource = new System.Windows.Forms.GroupBox();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonMedportal = new System.Windows.Forms.RadioButton();
            this.radioButtonOLS = new System.Windows.Forms.RadioButton();
            this.radioButtonBioportal = new System.Windows.Forms.RadioButton();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Onto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Term = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IRI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanelSearchTerm.SuspendLayout();
            this.groupBoxSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSearch.Location = new System.Drawing.Point(3, 71);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(140, 29);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search Term";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // buttonInsertSearchItem
            // 
            this.buttonInsertSearchItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInsertSearchItem.Location = new System.Drawing.Point(149, 71);
            this.buttonInsertSearchItem.Name = "buttonInsertSearchItem";
            this.buttonInsertSearchItem.Size = new System.Drawing.Size(648, 29);
            this.buttonInsertSearchItem.TabIndex = 4;
            this.buttonInsertSearchItem.Text = "Insert to Excel";
            this.buttonInsertSearchItem.UseVisualStyleBackColor = true;
            this.buttonInsertSearchItem.Click += new System.EventHandler(this.ButtonInsertSearchItem_Click);
            // 
            // tableLayoutPanelSearchTerm
            // 
            this.tableLayoutPanelSearchTerm.ColumnCount = 3;
            this.tableLayoutPanelSearchTerm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.875F));
            this.tableLayoutPanelSearchTerm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 654F));
            this.tableLayoutPanelSearchTerm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSearchTerm.Controls.Add(this.labelTerm, 0, 0);
            this.tableLayoutPanelSearchTerm.Controls.Add(this.textBoxSearchTerm, 1, 0);
            this.tableLayoutPanelSearchTerm.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanelSearchTerm.Controls.Add(this.buttonInsertSearchItem, 1, 2);
            this.tableLayoutPanelSearchTerm.Controls.Add(this.buttonSearch, 0, 2);
            this.tableLayoutPanelSearchTerm.Controls.Add(this.groupBoxSource, 1, 1);
            this.tableLayoutPanelSearchTerm.Controls.Add(this.dataGridViewResult, 1, 3);
            this.tableLayoutPanelSearchTerm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSearchTerm.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanelSearchTerm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSearchTerm.Margin = new System.Windows.Forms.Padding(5, 7, 5, 3);
            this.tableLayoutPanelSearchTerm.Name = "tableLayoutPanelSearchTerm";
            this.tableLayoutPanelSearchTerm.RowCount = 4;
            this.tableLayoutPanelSearchTerm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSearchTerm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.68493F));
            this.tableLayoutPanelSearchTerm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelSearchTerm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.tableLayoutPanelSearchTerm.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanelSearchTerm.TabIndex = 0;
            this.tableLayoutPanelSearchTerm.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanelSearchTerm_Paint);
            // 
            // labelTerm
            // 
            this.labelTerm.AutoSize = true;
            this.labelTerm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTerm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTerm.Location = new System.Drawing.Point(3, 7);
            this.labelTerm.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.labelTerm.Name = "labelTerm";
            this.labelTerm.Size = new System.Drawing.Size(140, 20);
            this.labelTerm.TabIndex = 0;
            this.labelTerm.Text = "Search Term";
            // 
            // textBoxSearchTerm
            // 
            this.textBoxSearchTerm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSearchTerm.Location = new System.Drawing.Point(149, 3);
            this.textBoxSearchTerm.Name = "textBoxSearchTerm";
            this.textBoxSearchTerm.Size = new System.Drawing.Size(648, 29);
            this.textBoxSearchTerm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data Sources";
            // 
            // groupBoxSource
            // 
            this.groupBoxSource.Controls.Add(this.radioButtonAll);
            this.groupBoxSource.Controls.Add(this.radioButtonMedportal);
            this.groupBoxSource.Controls.Add(this.radioButtonOLS);
            this.groupBoxSource.Controls.Add(this.radioButtonBioportal);
            this.groupBoxSource.Location = new System.Drawing.Point(149, 37);
            this.groupBoxSource.Name = "groupBoxSource";
            this.groupBoxSource.Size = new System.Drawing.Size(648, 28);
            this.groupBoxSource.TabIndex = 7;
            this.groupBoxSource.TabStop = false;
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(351, -1);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(57, 23);
            this.radioButtonAll.TabIndex = 9;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "All";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedportal
            // 
            this.radioButtonMedportal.AutoSize = true;
            this.radioButtonMedportal.Location = new System.Drawing.Point(214, -1);
            this.radioButtonMedportal.Name = "radioButtonMedportal";
            this.radioButtonMedportal.Size = new System.Drawing.Size(117, 23);
            this.radioButtonMedportal.TabIndex = 8;
            this.radioButtonMedportal.TabStop = true;
            this.radioButtonMedportal.Text = "MedPortal";
            this.radioButtonMedportal.UseVisualStyleBackColor = true;
            // 
            // radioButtonOLS
            // 
            this.radioButtonOLS.AutoSize = true;
            this.radioButtonOLS.Location = new System.Drawing.Point(137, 0);
            this.radioButtonOLS.Name = "radioButtonOLS";
            this.radioButtonOLS.Size = new System.Drawing.Size(57, 23);
            this.radioButtonOLS.TabIndex = 7;
            this.radioButtonOLS.Text = "OLS";
            this.radioButtonOLS.UseVisualStyleBackColor = true;
            // 
            // radioButtonBioportal
            // 
            this.radioButtonBioportal.AutoSize = true;
            this.radioButtonBioportal.Checked = true;
            this.radioButtonBioportal.Location = new System.Drawing.Point(6, 0);
            this.radioButtonBioportal.Name = "radioButtonBioportal";
            this.radioButtonBioportal.Size = new System.Drawing.Size(117, 23);
            this.radioButtonBioportal.TabIndex = 6;
            this.radioButtonBioportal.TabStop = true;
            this.radioButtonBioportal.Text = "BioPortal";
            this.radioButtonBioportal.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Onto,
            this.Term,
            this.IRI});
            this.dataGridViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewResult.Location = new System.Drawing.Point(149, 106);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.RowTemplate.Height = 23;
            this.dataGridViewResult.Size = new System.Drawing.Size(648, 341);
            this.dataGridViewResult.TabIndex = 8;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Num";
            this.ID.FillWeight = 50F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Onto
            // 
            this.Onto.DataPropertyName = "Onto";
            this.Onto.HeaderText = "Ontology";
            this.Onto.Name = "Onto";
            // 
            // Term
            // 
            this.Term.DataPropertyName = "Term";
            this.Term.HeaderText = "Term";
            this.Term.Name = "Term";
            // 
            // IRI
            // 
            this.IRI.DataPropertyName = "IRI";
            this.IRI.FillWeight = 300F;
            this.IRI.HeaderText = "IRI";
            this.IRI.Name = "IRI";
            // 
            // SearchTermForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanelSearchTerm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchTermForm";
            this.Text = "Search Term";
            this.TopMost = true;
            this.tableLayoutPanelSearchTerm.ResumeLayout(false);
            this.tableLayoutPanelSearchTerm.PerformLayout();
            this.groupBoxSource.ResumeLayout(false);
            this.groupBoxSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonInsertSearchItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSearchTerm;
        private System.Windows.Forms.Label labelTerm;
        private System.Windows.Forms.TextBox textBoxSearchTerm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSource;
        private System.Windows.Forms.RadioButton radioButtonBioportal;
        private System.Windows.Forms.RadioButton radioButtonOLS;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Onto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Term;
        private System.Windows.Forms.DataGridViewTextBoxColumn IRI;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButtonMedportal;
    }
}