namespace FormForDataModel
{
    partial class ProductsList
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
            this.lbl_listProducts = new System.Windows.Forms.Label();
            this.gb_productList = new System.Windows.Forms.GroupBox();
            this.btn_sendImages = new System.Windows.Forms.Button();
            this.btn_exportToExcel = new System.Windows.Forms.Button();
            this.btn_exportListToXml = new System.Windows.Forms.Button();
            this.dgv_productList = new System.Windows.Forms.DataGridView();
            this.gb_productList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_listProducts
            // 
            this.lbl_listProducts.AutoSize = true;
            this.lbl_listProducts.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_listProducts.Location = new System.Drawing.Point(12, 9);
            this.lbl_listProducts.Name = "lbl_listProducts";
            this.lbl_listProducts.Size = new System.Drawing.Size(170, 35);
            this.lbl_listProducts.TabIndex = 0;
            this.lbl_listProducts.Text = "Products List ";
            // 
            // gb_productList
            // 
            this.gb_productList.Controls.Add(this.btn_sendImages);
            this.gb_productList.Controls.Add(this.btn_exportToExcel);
            this.gb_productList.Controls.Add(this.btn_exportListToXml);
            this.gb_productList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_productList.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_productList.Location = new System.Drawing.Point(12, 47);
            this.gb_productList.Name = "gb_productList";
            this.gb_productList.Size = new System.Drawing.Size(1847, 115);
            this.gb_productList.TabIndex = 1;
            this.gb_productList.TabStop = false;
            this.gb_productList.Text = "Products Information";
            // 
            // btn_sendImages
            // 
            this.btn_sendImages.Location = new System.Drawing.Point(384, 65);
            this.btn_sendImages.Name = "btn_sendImages";
            this.btn_sendImages.Size = new System.Drawing.Size(215, 36);
            this.btn_sendImages.TabIndex = 4;
            this.btn_sendImages.Text = "Export Images Files";
            this.btn_sendImages.UseVisualStyleBackColor = true;
            this.btn_sendImages.Click += new System.EventHandler(this.btn_sendImages_Click);
            // 
            // btn_exportToExcel
            // 
            this.btn_exportToExcel.Location = new System.Drawing.Point(195, 65);
            this.btn_exportToExcel.Name = "btn_exportToExcel";
            this.btn_exportToExcel.Size = new System.Drawing.Size(183, 36);
            this.btn_exportToExcel.TabIndex = 3;
            this.btn_exportToExcel.Text = "Export to Excel";
            this.btn_exportToExcel.UseVisualStyleBackColor = true;
            this.btn_exportToExcel.Click += new System.EventHandler(this.btn_exportToExcel_Click);
            // 
            // btn_exportListToXml
            // 
            this.btn_exportListToXml.Location = new System.Drawing.Point(6, 65);
            this.btn_exportListToXml.Name = "btn_exportListToXml";
            this.btn_exportListToXml.Size = new System.Drawing.Size(183, 36);
            this.btn_exportListToXml.TabIndex = 2;
            this.btn_exportListToXml.Text = "Export To XML";
            this.btn_exportListToXml.UseVisualStyleBackColor = true;
            this.btn_exportListToXml.Click += new System.EventHandler(this.btn_exportListToXml_Click);
            // 
            // dgv_productList
            // 
            this.dgv_productList.AllowUserToAddRows = false;
            this.dgv_productList.AllowUserToDeleteRows = false;
            this.dgv_productList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_productList.Location = new System.Drawing.Point(12, 168);
            this.dgv_productList.Name = "dgv_productList";
            this.dgv_productList.ReadOnly = true;
            this.dgv_productList.RowHeadersWidth = 51;
            this.dgv_productList.RowTemplate.Height = 24;
            this.dgv_productList.Size = new System.Drawing.Size(1847, 715);
            this.dgv_productList.TabIndex = 5;
            this.dgv_productList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_productList_DataBindingComplete);
            // 
            // ProductsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.gb_productList);
            this.Controls.Add(this.dgv_productList);
            this.Controls.Add(this.lbl_listProducts);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "ProductsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Products List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProductsList_Load);
            this.gb_productList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_listProducts;
        private System.Windows.Forms.GroupBox gb_productList;
        private System.Windows.Forms.Button btn_exportToExcel;
        private System.Windows.Forms.Button btn_exportListToXml;
        private System.Windows.Forms.DataGridView dgv_productList;
        private System.Windows.Forms.Button btn_sendImages;
    }
}