namespace FormForDataModel
{
    partial class ProductsAdd
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
            this.lbl_addProducts = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbl_productActive = new System.Windows.Forms.Label();
            this.lbl_categoryName = new System.Windows.Forms.Label();
            this.lbl_productName = new System.Windows.Forms.Label();
            this.lbl_unitPrice = new System.Windows.Forms.Label();
            this.lbl_productImage = new System.Windows.Forms.Label();
            this.lbl_unitsInStock = new System.Windows.Forms.Label();
            this.cb_productActive = new System.Windows.Forms.CheckBox();
            this.tb_productName = new System.Windows.Forms.TextBox();
            this.tb_quentityPerUnit = new System.Windows.Forms.TextBox();
            this.tb_unitsInStock = new System.Windows.Forms.TextBox();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_selectImage = new System.Windows.Forms.Button();
            this.pb_productImage = new System.Windows.Forms.PictureBox();
            this.lbl_brandName = new System.Windows.Forms.Label();
            this.lbl_quentityPerUnit = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.cbb_brandName = new System.Windows.Forms.ComboBox();
            this.cbb_categoryName = new System.Windows.Forms.ComboBox();
            this.nud_products = new System.Windows.Forms.NumericUpDown();
            this.gb_addProduct = new System.Windows.Forms.GroupBox();
            this.dgv_addProduct = new System.Windows.Forms.DataGridView();
            this.lbl_reorderLevel = new System.Windows.Forms.Label();
            this.tb_reorderLevel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_productImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_products)).BeginInit();
            this.gb_addProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_addProducts
            // 
            this.lbl_addProducts.AutoSize = true;
            this.lbl_addProducts.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_addProducts.Location = new System.Drawing.Point(12, 9);
            this.lbl_addProducts.Name = "lbl_addProducts";
            this.lbl_addProducts.Size = new System.Drawing.Size(171, 35);
            this.lbl_addProducts.TabIndex = 1;
            this.lbl_addProducts.Text = "Add Products";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbl_productActive
            // 
            this.lbl_productActive.AutoSize = true;
            this.lbl_productActive.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productActive.Location = new System.Drawing.Point(30, 278);
            this.lbl_productActive.Name = "lbl_productActive";
            this.lbl_productActive.Size = new System.Drawing.Size(247, 28);
            this.lbl_productActive.TabIndex = 4;
            this.lbl_productActive.Text = "Is Product Active For Sale";
            // 
            // lbl_categoryName
            // 
            this.lbl_categoryName.AutoSize = true;
            this.lbl_categoryName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_categoryName.Location = new System.Drawing.Point(30, 121);
            this.lbl_categoryName.Name = "lbl_categoryName";
            this.lbl_categoryName.Size = new System.Drawing.Size(155, 28);
            this.lbl_categoryName.TabIndex = 2;
            this.lbl_categoryName.Text = "Category Name";
            // 
            // lbl_productName
            // 
            this.lbl_productName.AutoSize = true;
            this.lbl_productName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productName.Location = new System.Drawing.Point(30, 197);
            this.lbl_productName.Name = "lbl_productName";
            this.lbl_productName.Size = new System.Drawing.Size(146, 28);
            this.lbl_productName.TabIndex = 2;
            this.lbl_productName.Text = "Product Name";
            // 
            // lbl_unitPrice
            // 
            this.lbl_unitPrice.AutoSize = true;
            this.lbl_unitPrice.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_unitPrice.Location = new System.Drawing.Point(382, 121);
            this.lbl_unitPrice.Name = "lbl_unitPrice";
            this.lbl_unitPrice.Size = new System.Drawing.Size(103, 28);
            this.lbl_unitPrice.TabIndex = 2;
            this.lbl_unitPrice.Text = "Unit Price";
            // 
            // lbl_productImage
            // 
            this.lbl_productImage.AutoSize = true;
            this.lbl_productImage.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productImage.Location = new System.Drawing.Point(1208, 45);
            this.lbl_productImage.Name = "lbl_productImage";
            this.lbl_productImage.Size = new System.Drawing.Size(252, 28);
            this.lbl_productImage.TabIndex = 7;
            this.lbl_productImage.Text = "Product\'s Image Selection";
            // 
            // lbl_unitsInStock
            // 
            this.lbl_unitsInStock.AutoSize = true;
            this.lbl_unitsInStock.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_unitsInStock.Location = new System.Drawing.Point(382, 197);
            this.lbl_unitsInStock.Name = "lbl_unitsInStock";
            this.lbl_unitsInStock.Size = new System.Drawing.Size(140, 28);
            this.lbl_unitsInStock.TabIndex = 2;
            this.lbl_unitsInStock.Text = "Units In Stock";
            // 
            // cb_productActive
            // 
            this.cb_productActive.AutoSize = true;
            this.cb_productActive.Location = new System.Drawing.Point(319, 285);
            this.cb_productActive.Name = "cb_productActive";
            this.cb_productActive.Size = new System.Drawing.Size(18, 17);
            this.cb_productActive.TabIndex = 5;
            this.cb_productActive.UseVisualStyleBackColor = true;
            // 
            // tb_productName
            // 
            this.tb_productName.Location = new System.Drawing.Point(35, 228);
            this.tb_productName.Name = "tb_productName";
            this.tb_productName.Size = new System.Drawing.Size(326, 36);
            this.tb_productName.TabIndex = 3;
            // 
            // tb_quentityPerUnit
            // 
            this.tb_quentityPerUnit.Location = new System.Drawing.Point(387, 76);
            this.tb_quentityPerUnit.Name = "tb_quentityPerUnit";
            this.tb_quentityPerUnit.Size = new System.Drawing.Size(326, 36);
            this.tb_quentityPerUnit.TabIndex = 3;
            // 
            // tb_unitsInStock
            // 
            this.tb_unitsInStock.Location = new System.Drawing.Point(387, 228);
            this.tb_unitsInStock.Name = "tb_unitsInStock";
            this.tb_unitsInStock.Size = new System.Drawing.Size(326, 36);
            this.tb_unitsInStock.TabIndex = 3;
            // 
            // tb_description
            // 
            this.tb_description.Location = new System.Drawing.Point(733, 76);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(444, 264);
            this.tb_description.TabIndex = 3;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(883, 346);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(144, 36);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(1033, 346);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(144, 36);
            this.btn_clear.TabIndex = 8;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_selectImage
            // 
            this.btn_selectImage.Location = new System.Drawing.Point(733, 346);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(144, 36);
            this.btn_selectImage.TabIndex = 6;
            this.btn_selectImage.Text = "Select Image";
            this.btn_selectImage.UseVisualStyleBackColor = true;
            this.btn_selectImage.Click += new System.EventHandler(this.btn_selectImage_Click);
            // 
            // pb_productImage
            // 
            this.pb_productImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_productImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_productImage.Location = new System.Drawing.Point(1213, 76);
            this.pb_productImage.Name = "pb_productImage";
            this.pb_productImage.Size = new System.Drawing.Size(264, 264);
            this.pb_productImage.TabIndex = 4;
            this.pb_productImage.TabStop = false;
            // 
            // lbl_brandName
            // 
            this.lbl_brandName.AutoSize = true;
            this.lbl_brandName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_brandName.Location = new System.Drawing.Point(30, 45);
            this.lbl_brandName.Name = "lbl_brandName";
            this.lbl_brandName.Size = new System.Drawing.Size(128, 28);
            this.lbl_brandName.TabIndex = 10;
            this.lbl_brandName.Text = "Brand Name";
            // 
            // lbl_quentityPerUnit
            // 
            this.lbl_quentityPerUnit.AutoSize = true;
            this.lbl_quentityPerUnit.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_quentityPerUnit.Location = new System.Drawing.Point(382, 45);
            this.lbl_quentityPerUnit.Name = "lbl_quentityPerUnit";
            this.lbl_quentityPerUnit.Size = new System.Drawing.Size(174, 28);
            this.lbl_quentityPerUnit.TabIndex = 10;
            this.lbl_quentityPerUnit.Text = "Quantity Per Unit";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_description.Location = new System.Drawing.Point(728, 45);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(118, 28);
            this.lbl_description.TabIndex = 10;
            this.lbl_description.Text = "Description";
            // 
            // cbb_brandName
            // 
            this.cbb_brandName.FormattingEnabled = true;
            this.cbb_brandName.Location = new System.Drawing.Point(35, 76);
            this.cbb_brandName.Name = "cbb_brandName";
            this.cbb_brandName.Size = new System.Drawing.Size(326, 36);
            this.cbb_brandName.TabIndex = 12;
            this.cbb_brandName.Text = "---Choose---";
            this.cbb_brandName.SelectedIndexChanged += new System.EventHandler(this.cbb_brandName_SelectedIndexChanged);
            // 
            // cbb_categoryName
            // 
            this.cbb_categoryName.FormattingEnabled = true;
            this.cbb_categoryName.Location = new System.Drawing.Point(35, 152);
            this.cbb_categoryName.Name = "cbb_categoryName";
            this.cbb_categoryName.Size = new System.Drawing.Size(326, 36);
            this.cbb_categoryName.TabIndex = 12;
            this.cbb_categoryName.Text = "---Choose---";
            this.cbb_categoryName.SelectedIndexChanged += new System.EventHandler(this.cbb_categoryName_SelectedIndexChanged);
            // 
            // nud_products
            // 
            this.nud_products.DecimalPlaces = 2;
            this.nud_products.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_products.Location = new System.Drawing.Point(387, 152);
            this.nud_products.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nud_products.Name = "nud_products";
            this.nud_products.Size = new System.Drawing.Size(326, 36);
            this.nud_products.TabIndex = 13;
            this.nud_products.ThousandsSeparator = true;
            this.nud_products.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nud_products_KeyPress);
            // 
            // gb_addProduct
            // 
            this.gb_addProduct.Controls.Add(this.nud_products);
            this.gb_addProduct.Controls.Add(this.cbb_categoryName);
            this.gb_addProduct.Controls.Add(this.cbb_brandName);
            this.gb_addProduct.Controls.Add(this.lbl_description);
            this.gb_addProduct.Controls.Add(this.lbl_quentityPerUnit);
            this.gb_addProduct.Controls.Add(this.lbl_brandName);
            this.gb_addProduct.Controls.Add(this.pb_productImage);
            this.gb_addProduct.Controls.Add(this.btn_selectImage);
            this.gb_addProduct.Controls.Add(this.btn_clear);
            this.gb_addProduct.Controls.Add(this.btn_save);
            this.gb_addProduct.Controls.Add(this.tb_description);
            this.gb_addProduct.Controls.Add(this.tb_reorderLevel);
            this.gb_addProduct.Controls.Add(this.tb_unitsInStock);
            this.gb_addProduct.Controls.Add(this.tb_quentityPerUnit);
            this.gb_addProduct.Controls.Add(this.tb_productName);
            this.gb_addProduct.Controls.Add(this.lbl_reorderLevel);
            this.gb_addProduct.Controls.Add(this.cb_productActive);
            this.gb_addProduct.Controls.Add(this.lbl_unitsInStock);
            this.gb_addProduct.Controls.Add(this.lbl_productImage);
            this.gb_addProduct.Controls.Add(this.lbl_unitPrice);
            this.gb_addProduct.Controls.Add(this.lbl_productName);
            this.gb_addProduct.Controls.Add(this.lbl_categoryName);
            this.gb_addProduct.Controls.Add(this.lbl_productActive);
            this.gb_addProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_addProduct.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_addProduct.Location = new System.Drawing.Point(12, 47);
            this.gb_addProduct.Name = "gb_addProduct";
            this.gb_addProduct.Size = new System.Drawing.Size(1500, 397);
            this.gb_addProduct.TabIndex = 5;
            this.gb_addProduct.TabStop = false;
            this.gb_addProduct.Text = "Products Information";
            // 
            // dgv_addProduct
            // 
            this.dgv_addProduct.AllowUserToAddRows = false;
            this.dgv_addProduct.AllowUserToDeleteRows = false;
            this.dgv_addProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_addProduct.Location = new System.Drawing.Point(12, 450);
            this.dgv_addProduct.Name = "dgv_addProduct";
            this.dgv_addProduct.ReadOnly = true;
            this.dgv_addProduct.RowHeadersWidth = 51;
            this.dgv_addProduct.RowTemplate.Height = 24;
            this.dgv_addProduct.Size = new System.Drawing.Size(1500, 350);
            this.dgv_addProduct.TabIndex = 6;
            // 
            // lbl_reorderLevel
            // 
            this.lbl_reorderLevel.AutoSize = true;
            this.lbl_reorderLevel.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_reorderLevel.Location = new System.Drawing.Point(382, 273);
            this.lbl_reorderLevel.Name = "lbl_reorderLevel";
            this.lbl_reorderLevel.Size = new System.Drawing.Size(138, 28);
            this.lbl_reorderLevel.TabIndex = 2;
            this.lbl_reorderLevel.Text = "Reorder Level";
            // 
            // tb_reorderLevel
            // 
            this.tb_reorderLevel.Location = new System.Drawing.Point(387, 304);
            this.tb_reorderLevel.Name = "tb_reorderLevel";
            this.tb_reorderLevel.Size = new System.Drawing.Size(326, 36);
            this.tb_reorderLevel.TabIndex = 3;
            // 
            // ProductsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 978);
            this.ControlBox = false;
            this.Controls.Add(this.dgv_addProduct);
            this.Controls.Add(this.gb_addProduct);
            this.Controls.Add(this.lbl_addProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1918, 1025);
            this.MinimumSize = new System.Drawing.Size(1918, 1025);
            this.Name = "ProductsAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add Products";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProductsAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_productImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_products)).EndInit();
            this.gb_addProduct.ResumeLayout(false);
            this.gb_addProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_addProducts;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbl_productActive;
        private System.Windows.Forms.Label lbl_categoryName;
        private System.Windows.Forms.Label lbl_productName;
        private System.Windows.Forms.Label lbl_unitPrice;
        private System.Windows.Forms.Label lbl_productImage;
        private System.Windows.Forms.Label lbl_unitsInStock;
        private System.Windows.Forms.CheckBox cb_productActive;
        private System.Windows.Forms.TextBox tb_productName;
        private System.Windows.Forms.TextBox tb_quentityPerUnit;
        private System.Windows.Forms.TextBox tb_unitsInStock;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_selectImage;
        private System.Windows.Forms.PictureBox pb_productImage;
        private System.Windows.Forms.Label lbl_brandName;
        private System.Windows.Forms.Label lbl_quentityPerUnit;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.ComboBox cbb_brandName;
        private System.Windows.Forms.ComboBox cbb_categoryName;
        private System.Windows.Forms.NumericUpDown nud_products;
        private System.Windows.Forms.GroupBox gb_addProduct;
        private System.Windows.Forms.DataGridView dgv_addProduct;
        private System.Windows.Forms.TextBox tb_reorderLevel;
        private System.Windows.Forms.Label lbl_reorderLevel;
    }
}