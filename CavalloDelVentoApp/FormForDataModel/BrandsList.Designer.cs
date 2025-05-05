namespace FormForDataModel
{
    partial class BrandsList
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
            this.gb_brandList = new System.Windows.Forms.GroupBox();
            this.dgv_brandList = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lbl_listBrand = new System.Windows.Forms.Label();
            this.btn_exportListToXml = new System.Windows.Forms.Button();
            this.btn_exportToExcel = new System.Windows.Forms.Button();
            this.btn_sendImages = new System.Windows.Forms.Button();
            this.gb_brandList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_brandList)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_brandList
            // 
            this.gb_brandList.Controls.Add(this.btn_sendImages);
            this.gb_brandList.Controls.Add(this.btn_exportToExcel);
            this.gb_brandList.Controls.Add(this.btn_exportListToXml);
            this.gb_brandList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_brandList.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_brandList.Location = new System.Drawing.Point(12, 47);
            this.gb_brandList.Name = "gb_brandList";
            this.gb_brandList.Size = new System.Drawing.Size(1847, 115);
            this.gb_brandList.TabIndex = 1;
            this.gb_brandList.TabStop = false;
            this.gb_brandList.Text = "Brands Information";
            // 
            // dgv_brandList
            // 
            this.dgv_brandList.AllowUserToAddRows = false;
            this.dgv_brandList.AllowUserToDeleteRows = false;
            this.dgv_brandList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_brandList.Location = new System.Drawing.Point(12, 168);
            this.dgv_brandList.Name = "dgv_brandList";
            this.dgv_brandList.ReadOnly = true;
            this.dgv_brandList.RowHeadersWidth = 51;
            this.dgv_brandList.RowTemplate.Height = 24;
            this.dgv_brandList.Size = new System.Drawing.Size(1847, 715);
            this.dgv_brandList.TabIndex = 5;
            this.dgv_brandList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_brandList_DataBindingComplete);
            // 
            // lbl_listBrand
            // 
            this.lbl_listBrand.AutoSize = true;
            this.lbl_listBrand.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_listBrand.Location = new System.Drawing.Point(12, 9);
            this.lbl_listBrand.Name = "lbl_listBrand";
            this.lbl_listBrand.Size = new System.Drawing.Size(147, 35);
            this.lbl_listBrand.TabIndex = 0;
            this.lbl_listBrand.Text = "Brands List ";
            // 
            // btn_exportListToXml
            // 
            this.btn_exportListToXml.Location = new System.Drawing.Point(6, 65);
            this.btn_exportListToXml.Name = "btn_exportListToXml";
            this.btn_exportListToXml.Size = new System.Drawing.Size(175, 36);
            this.btn_exportListToXml.TabIndex = 2;
            this.btn_exportListToXml.Text = "Export To XML";
            this.btn_exportListToXml.UseVisualStyleBackColor = true;
            this.btn_exportListToXml.Click += new System.EventHandler(this.btn_exportListToXml_Click);
            // 
            // btn_exportToExcel
            // 
            this.btn_exportToExcel.Location = new System.Drawing.Point(187, 65);
            this.btn_exportToExcel.Name = "btn_exportToExcel";
            this.btn_exportToExcel.Size = new System.Drawing.Size(175, 36);
            this.btn_exportToExcel.TabIndex = 3;
            this.btn_exportToExcel.Text = "Export to Excel";
            this.btn_exportToExcel.UseVisualStyleBackColor = true;
            this.btn_exportToExcel.Click += new System.EventHandler(this.btn_exportToExcel_Click);
            // 
            // btn_sendImages
            // 
            this.btn_sendImages.Location = new System.Drawing.Point(368, 65);
            this.btn_sendImages.Name = "btn_sendImages";
            this.btn_sendImages.Size = new System.Drawing.Size(215, 36);
            this.btn_sendImages.TabIndex = 4;
            this.btn_sendImages.Text = "Export Images Files";
            this.btn_sendImages.UseVisualStyleBackColor = true;
            this.btn_sendImages.Click += new System.EventHandler(this.btn_sendImages_Click);
            // 
            // BrandsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.gb_brandList);
            this.Controls.Add(this.dgv_brandList);
            this.Controls.Add(this.lbl_listBrand);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "BrandsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "List Brands";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BrandsList_Load);
            this.gb_brandList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_brandList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_brandList;
        private System.Windows.Forms.DataGridView dgv_brandList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lbl_listBrand;
        private System.Windows.Forms.Button btn_sendImages;
        private System.Windows.Forms.Button btn_exportToExcel;
        private System.Windows.Forms.Button btn_exportListToXml;
    }
}