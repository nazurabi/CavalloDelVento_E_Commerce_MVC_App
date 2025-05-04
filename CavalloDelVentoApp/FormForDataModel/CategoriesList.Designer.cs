namespace FormForDataModel
{
    partial class CategoriesList
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
            this.lbl_listCategories = new System.Windows.Forms.Label();
            this.gb_categoryList = new System.Windows.Forms.GroupBox();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_exportToExcel = new System.Windows.Forms.Button();
            this.btn_exportListToXml = new System.Windows.Forms.Button();
            this.dgv_categoryList = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gb_categoryList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoryList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_listCategories
            // 
            this.lbl_listCategories.AutoSize = true;
            this.lbl_listCategories.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_listCategories.Location = new System.Drawing.Point(12, 9);
            this.lbl_listCategories.Name = "lbl_listCategories";
            this.lbl_listCategories.Size = new System.Drawing.Size(184, 35);
            this.lbl_listCategories.TabIndex = 0;
            this.lbl_listCategories.Text = "Categories List";
            // 
            // gb_categoryList
            // 
            this.gb_categoryList.Controls.Add(this.btn_print);
            this.gb_categoryList.Controls.Add(this.btn_exportToExcel);
            this.gb_categoryList.Controls.Add(this.btn_exportListToXml);
            this.gb_categoryList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_categoryList.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_categoryList.Location = new System.Drawing.Point(12, 47);
            this.gb_categoryList.Name = "gb_categoryList";
            this.gb_categoryList.Size = new System.Drawing.Size(1847, 115);
            this.gb_categoryList.TabIndex = 1;
            this.gb_categoryList.TabStop = false;
            this.gb_categoryList.Text = "Categories Information";
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(348, 65);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(165, 36);
            this.btn_print.TabIndex = 4;
            this.btn_print.Text = "print";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // btn_exportToExcel
            // 
            this.btn_exportToExcel.Location = new System.Drawing.Point(177, 65);
            this.btn_exportToExcel.Name = "btn_exportToExcel";
            this.btn_exportToExcel.Size = new System.Drawing.Size(165, 36);
            this.btn_exportToExcel.TabIndex = 3;
            this.btn_exportToExcel.Text = "export excel";
            this.btn_exportToExcel.UseVisualStyleBackColor = true;
            // 
            // btn_exportListToXml
            // 
            this.btn_exportListToXml.Location = new System.Drawing.Point(6, 65);
            this.btn_exportListToXml.Name = "btn_exportListToXml";
            this.btn_exportListToXml.Size = new System.Drawing.Size(165, 36);
            this.btn_exportListToXml.TabIndex = 2;
            this.btn_exportListToXml.Text = "export xml";
            this.btn_exportListToXml.UseVisualStyleBackColor = true;
            this.btn_exportListToXml.Click += new System.EventHandler(this.btn_exportListToXml_Click);
            // 
            // dgv_categoryList
            // 
            this.dgv_categoryList.AllowUserToAddRows = false;
            this.dgv_categoryList.AllowUserToDeleteRows = false;
            this.dgv_categoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_categoryList.Location = new System.Drawing.Point(12, 168);
            this.dgv_categoryList.Name = "dgv_categoryList";
            this.dgv_categoryList.ReadOnly = true;
            this.dgv_categoryList.RowHeadersWidth = 51;
            this.dgv_categoryList.RowTemplate.Height = 24;
            this.dgv_categoryList.Size = new System.Drawing.Size(1847, 715);
            this.dgv_categoryList.TabIndex = 5;
            this.dgv_categoryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_categoryList_DataBindingComplete);
            // 
            // CategoriesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.gb_categoryList);
            this.Controls.Add(this.dgv_categoryList);
            this.Controls.Add(this.lbl_listCategories);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "CategoriesList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "List Categories";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CategoriesList_Load);
            this.gb_categoryList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_listCategories;
        private System.Windows.Forms.GroupBox gb_categoryList;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_exportToExcel;
        private System.Windows.Forms.Button btn_exportListToXml;
        private System.Windows.Forms.DataGridView dgv_categoryList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}