namespace FormForDataModel
{
    partial class LevelIntegrationOrders
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
            this.lbl_levelIntegrationOrders = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbl_description = new System.Windows.Forms.Label();
            this.lbl_quentityPerUnit = new System.Windows.Forms.Label();
            this.lbl_brandName = new System.Windows.Forms.Label();
            this.pb_productImage = new System.Windows.Forms.PictureBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.tb_reorderLevel = new System.Windows.Forms.TextBox();
            this.tb_unitsInStock = new System.Windows.Forms.TextBox();
            this.tb_quentityPerUnit = new System.Windows.Forms.TextBox();
            this.tb_productName = new System.Windows.Forms.TextBox();
            this.lbl_reorderLevel = new System.Windows.Forms.Label();
            this.lbl_unitsInStock = new System.Windows.Forms.Label();
            this.lbl_productImage = new System.Windows.Forms.Label();
            this.lbl_unitPrice = new System.Windows.Forms.Label();
            this.lbl_productName = new System.Windows.Forms.Label();
            this.lbl_categoryName = new System.Windows.Forms.Label();
            this.dgv_levelIntegrationProduct = new System.Windows.Forms.DataGridView();
            this.gb_addProduct = new System.Windows.Forms.GroupBox();
            this.tb_brandName = new System.Windows.Forms.TextBox();
            this.tb_categoryName = new System.Windows.Forms.TextBox();
            this.tb_unitPrice = new System.Windows.Forms.TextBox();
            this.lb_acceptedAmount = new System.Windows.Forms.Label();
            this.tb_acceptedAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_productImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_levelIntegrationProduct)).BeginInit();
            this.gb_addProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_levelIntegrationOrders
            // 
            this.lbl_levelIntegrationOrders.AutoSize = true;
            this.lbl_levelIntegrationOrders.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_levelIntegrationOrders.Location = new System.Drawing.Point(12, 9);
            this.lbl_levelIntegrationOrders.Name = "lbl_levelIntegrationOrders";
            this.lbl_levelIntegrationOrders.Size = new System.Drawing.Size(294, 35);
            this.lbl_levelIntegrationOrders.TabIndex = 0;
            this.lbl_levelIntegrationOrders.Text = "Level Integration Orders";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_description.Location = new System.Drawing.Point(385, 197);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(118, 28);
            this.lbl_description.TabIndex = 18;
            this.lbl_description.Text = "Description";
            // 
            // lbl_quentityPerUnit
            // 
            this.lbl_quentityPerUnit.AutoSize = true;
            this.lbl_quentityPerUnit.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_quentityPerUnit.Location = new System.Drawing.Point(30, 273);
            this.lbl_quentityPerUnit.Name = "lbl_quentityPerUnit";
            this.lbl_quentityPerUnit.Size = new System.Drawing.Size(174, 28);
            this.lbl_quentityPerUnit.TabIndex = 8;
            this.lbl_quentityPerUnit.Text = "Quantity Per Unit";
            // 
            // lbl_brandName
            // 
            this.lbl_brandName.AutoSize = true;
            this.lbl_brandName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_brandName.Location = new System.Drawing.Point(30, 45);
            this.lbl_brandName.Name = "lbl_brandName";
            this.lbl_brandName.Size = new System.Drawing.Size(128, 28);
            this.lbl_brandName.TabIndex = 2;
            this.lbl_brandName.Text = "Brand Name";
            // 
            // pb_productImage
            // 
            this.pb_productImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_productImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_productImage.Location = new System.Drawing.Point(743, 76);
            this.pb_productImage.Name = "pb_productImage";
            this.pb_productImage.Size = new System.Drawing.Size(339, 339);
            this.pb_productImage.TabIndex = 4;
            this.pb_productImage.TabStop = false;
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(1097, 273);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(221, 36);
            this.btn_save.TabIndex = 20;
            this.btn_save.Text = "Confirm Acceptance";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // tb_description
            // 
            this.tb_description.Enabled = false;
            this.tb_description.Location = new System.Drawing.Point(390, 228);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(326, 188);
            this.tb_description.TabIndex = 19;
            // 
            // tb_reorderLevel
            // 
            this.tb_reorderLevel.Enabled = false;
            this.tb_reorderLevel.Location = new System.Drawing.Point(390, 152);
            this.tb_reorderLevel.Name = "tb_reorderLevel";
            this.tb_reorderLevel.Size = new System.Drawing.Size(326, 36);
            this.tb_reorderLevel.TabIndex = 15;
            // 
            // tb_unitsInStock
            // 
            this.tb_unitsInStock.Enabled = false;
            this.tb_unitsInStock.Location = new System.Drawing.Point(390, 76);
            this.tb_unitsInStock.Name = "tb_unitsInStock";
            this.tb_unitsInStock.Size = new System.Drawing.Size(326, 36);
            this.tb_unitsInStock.TabIndex = 13;
            // 
            // tb_quentityPerUnit
            // 
            this.tb_quentityPerUnit.Enabled = false;
            this.tb_quentityPerUnit.Location = new System.Drawing.Point(35, 304);
            this.tb_quentityPerUnit.Name = "tb_quentityPerUnit";
            this.tb_quentityPerUnit.Size = new System.Drawing.Size(326, 36);
            this.tb_quentityPerUnit.TabIndex = 9;
            // 
            // tb_productName
            // 
            this.tb_productName.Enabled = false;
            this.tb_productName.Location = new System.Drawing.Point(35, 228);
            this.tb_productName.Name = "tb_productName";
            this.tb_productName.Size = new System.Drawing.Size(326, 36);
            this.tb_productName.TabIndex = 7;
            // 
            // lbl_reorderLevel
            // 
            this.lbl_reorderLevel.AutoSize = true;
            this.lbl_reorderLevel.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_reorderLevel.Location = new System.Drawing.Point(385, 121);
            this.lbl_reorderLevel.Name = "lbl_reorderLevel";
            this.lbl_reorderLevel.Size = new System.Drawing.Size(138, 28);
            this.lbl_reorderLevel.TabIndex = 14;
            this.lbl_reorderLevel.Text = "Reorder Level";
            // 
            // lbl_unitsInStock
            // 
            this.lbl_unitsInStock.AutoSize = true;
            this.lbl_unitsInStock.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_unitsInStock.Location = new System.Drawing.Point(385, 45);
            this.lbl_unitsInStock.Name = "lbl_unitsInStock";
            this.lbl_unitsInStock.Size = new System.Drawing.Size(140, 28);
            this.lbl_unitsInStock.TabIndex = 12;
            this.lbl_unitsInStock.Text = "Units In Stock";
            // 
            // lbl_productImage
            // 
            this.lbl_productImage.AutoSize = true;
            this.lbl_productImage.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productImage.Location = new System.Drawing.Point(738, 45);
            this.lbl_productImage.Name = "lbl_productImage";
            this.lbl_productImage.Size = new System.Drawing.Size(162, 28);
            this.lbl_productImage.TabIndex = 20;
            this.lbl_productImage.Text = "Product\'s Image";
            // 
            // lbl_unitPrice
            // 
            this.lbl_unitPrice.AutoSize = true;
            this.lbl_unitPrice.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_unitPrice.Location = new System.Drawing.Point(30, 349);
            this.lbl_unitPrice.Name = "lbl_unitPrice";
            this.lbl_unitPrice.Size = new System.Drawing.Size(103, 28);
            this.lbl_unitPrice.TabIndex = 10;
            this.lbl_unitPrice.Text = "Unit Price";
            // 
            // lbl_productName
            // 
            this.lbl_productName.AutoSize = true;
            this.lbl_productName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productName.Location = new System.Drawing.Point(30, 197);
            this.lbl_productName.Name = "lbl_productName";
            this.lbl_productName.Size = new System.Drawing.Size(146, 28);
            this.lbl_productName.TabIndex = 6;
            this.lbl_productName.Text = "Product Name";
            // 
            // lbl_categoryName
            // 
            this.lbl_categoryName.AutoSize = true;
            this.lbl_categoryName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_categoryName.Location = new System.Drawing.Point(30, 121);
            this.lbl_categoryName.Name = "lbl_categoryName";
            this.lbl_categoryName.Size = new System.Drawing.Size(155, 28);
            this.lbl_categoryName.TabIndex = 4;
            this.lbl_categoryName.Text = "Category Name";
            // 
            // dgv_levelIntegrationProduct
            // 
            this.dgv_levelIntegrationProduct.AllowUserToAddRows = false;
            this.dgv_levelIntegrationProduct.AllowUserToDeleteRows = false;
            this.dgv_levelIntegrationProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_levelIntegrationProduct.Location = new System.Drawing.Point(12, 497);
            this.dgv_levelIntegrationProduct.Name = "dgv_levelIntegrationProduct";
            this.dgv_levelIntegrationProduct.ReadOnly = true;
            this.dgv_levelIntegrationProduct.RowHeadersWidth = 51;
            this.dgv_levelIntegrationProduct.RowTemplate.Height = 24;
            this.dgv_levelIntegrationProduct.Size = new System.Drawing.Size(1863, 428);
            this.dgv_levelIntegrationProduct.TabIndex = 22;
            // 
            // gb_addProduct
            // 
            this.gb_addProduct.Controls.Add(this.lbl_description);
            this.gb_addProduct.Controls.Add(this.lbl_quentityPerUnit);
            this.gb_addProduct.Controls.Add(this.lbl_brandName);
            this.gb_addProduct.Controls.Add(this.pb_productImage);
            this.gb_addProduct.Controls.Add(this.button1);
            this.gb_addProduct.Controls.Add(this.btn_save);
            this.gb_addProduct.Controls.Add(this.tb_description);
            this.gb_addProduct.Controls.Add(this.textBox2);
            this.gb_addProduct.Controls.Add(this.tb_acceptedAmount);
            this.gb_addProduct.Controls.Add(this.tb_reorderLevel);
            this.gb_addProduct.Controls.Add(this.tb_unitsInStock);
            this.gb_addProduct.Controls.Add(this.tb_unitPrice);
            this.gb_addProduct.Controls.Add(this.tb_categoryName);
            this.gb_addProduct.Controls.Add(this.tb_brandName);
            this.gb_addProduct.Controls.Add(this.tb_quentityPerUnit);
            this.gb_addProduct.Controls.Add(this.tb_productName);
            this.gb_addProduct.Controls.Add(this.label3);
            this.gb_addProduct.Controls.Add(this.lb_acceptedAmount);
            this.gb_addProduct.Controls.Add(this.lbl_reorderLevel);
            this.gb_addProduct.Controls.Add(this.lbl_unitsInStock);
            this.gb_addProduct.Controls.Add(this.lbl_productImage);
            this.gb_addProduct.Controls.Add(this.lbl_unitPrice);
            this.gb_addProduct.Controls.Add(this.lbl_productName);
            this.gb_addProduct.Controls.Add(this.lbl_categoryName);
            this.gb_addProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_addProduct.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_addProduct.Location = new System.Drawing.Point(12, 47);
            this.gb_addProduct.Name = "gb_addProduct";
            this.gb_addProduct.Size = new System.Drawing.Size(1863, 444);
            this.gb_addProduct.TabIndex = 1;
            this.gb_addProduct.TabStop = false;
            this.gb_addProduct.Text = "Order Information";
            // 
            // tb_brandName
            // 
            this.tb_brandName.Enabled = false;
            this.tb_brandName.Location = new System.Drawing.Point(35, 76);
            this.tb_brandName.Name = "tb_brandName";
            this.tb_brandName.Size = new System.Drawing.Size(326, 36);
            this.tb_brandName.TabIndex = 3;
            // 
            // tb_categoryName
            // 
            this.tb_categoryName.Enabled = false;
            this.tb_categoryName.Location = new System.Drawing.Point(35, 152);
            this.tb_categoryName.Name = "tb_categoryName";
            this.tb_categoryName.Size = new System.Drawing.Size(326, 36);
            this.tb_categoryName.TabIndex = 5;
            // 
            // tb_unitPrice
            // 
            this.tb_unitPrice.Enabled = false;
            this.tb_unitPrice.Location = new System.Drawing.Point(35, 380);
            this.tb_unitPrice.Name = "tb_unitPrice";
            this.tb_unitPrice.Size = new System.Drawing.Size(326, 36);
            this.tb_unitPrice.TabIndex = 11;
            // 
            // lb_acceptedAmount
            // 
            this.lb_acceptedAmount.AutoSize = true;
            this.lb_acceptedAmount.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lb_acceptedAmount.Location = new System.Drawing.Point(1092, 45);
            this.lb_acceptedAmount.Name = "lb_acceptedAmount";
            this.lb_acceptedAmount.Size = new System.Drawing.Size(152, 28);
            this.lb_acceptedAmount.TabIndex = 16;
            this.lb_acceptedAmount.Text = "Order Quantity";
            // 
            // tb_acceptedAmount
            // 
            this.tb_acceptedAmount.Location = new System.Drawing.Point(1097, 76);
            this.tb_acceptedAmount.Name = "tb_acceptedAmount";
            this.tb_acceptedAmount.Size = new System.Drawing.Size(326, 36);
            this.tb_acceptedAmount.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(408, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "Kodlanacak, henüz kodları yazılmadı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label3.Location = new System.Drawing.Point(1092, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 28);
            this.label3.TabIndex = 16;
            this.label3.Text = "Quantity Completed";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1097, 228);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(326, 36);
            this.textBox2.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1097, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 36);
            this.button1.TabIndex = 20;
            this.button1.Text = "Create Order";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LevelIntegrationOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_levelIntegrationProduct);
            this.Controls.Add(this.gb_addProduct);
            this.Controls.Add(this.lbl_levelIntegrationOrders);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "LevelIntegrationOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Level Integration Orders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pb_productImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_levelIntegrationProduct)).EndInit();
            this.gb_addProduct.ResumeLayout(false);
            this.gb_addProduct.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_levelIntegrationOrders;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.Label lbl_quentityPerUnit;
        private System.Windows.Forms.Label lbl_brandName;
        private System.Windows.Forms.PictureBox pb_productImage;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.TextBox tb_reorderLevel;
        private System.Windows.Forms.TextBox tb_unitsInStock;
        private System.Windows.Forms.TextBox tb_quentityPerUnit;
        private System.Windows.Forms.TextBox tb_productName;
        private System.Windows.Forms.Label lbl_reorderLevel;
        private System.Windows.Forms.Label lbl_unitsInStock;
        private System.Windows.Forms.Label lbl_productImage;
        private System.Windows.Forms.Label lbl_unitPrice;
        private System.Windows.Forms.Label lbl_productName;
        private System.Windows.Forms.Label lbl_categoryName;
        private System.Windows.Forms.DataGridView dgv_levelIntegrationProduct;
        private System.Windows.Forms.GroupBox gb_addProduct;
        private System.Windows.Forms.TextBox tb_acceptedAmount;
        private System.Windows.Forms.TextBox tb_unitPrice;
        private System.Windows.Forms.TextBox tb_categoryName;
        private System.Windows.Forms.TextBox tb_brandName;
        private System.Windows.Forms.Label lb_acceptedAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}