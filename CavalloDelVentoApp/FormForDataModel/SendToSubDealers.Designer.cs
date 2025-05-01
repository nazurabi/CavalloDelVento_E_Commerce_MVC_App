namespace FormForDataModel
{
    partial class SendToSubDealers
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
            this.lbl_sendToSubDealers = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbl_categoryName = new System.Windows.Forms.Label();
            this.lbl_productName = new System.Windows.Forms.Label();
            this.lbl_subTotalPrice = new System.Windows.Forms.Label();
            this.lbl_subDealerInformation = new System.Windows.Forms.Label();
            this.lbl_subDealerType = new System.Windows.Forms.Label();
            this.lbl_productItemNumber = new System.Windows.Forms.Label();
            this.lbl_subDealerDiscAmount = new System.Windows.Forms.Label();
            this.lbl_productImage = new System.Windows.Forms.Label();
            this.lbl_tax = new System.Windows.Forms.Label();
            this.lbl_totalPrice = new System.Windows.Forms.Label();
            this.tb_sendQuentity = new System.Windows.Forms.TextBox();
            this.tb_tax = new System.Windows.Forms.TextBox();
            this.tb_subTotalPrice = new System.Windows.Forms.TextBox();
            this.tb_subDealerType = new System.Windows.Forms.TextBox();
            this.tb_subDealerDiscAmount = new System.Windows.Forms.TextBox();
            this.tb_productItemNumber = new System.Windows.Forms.TextBox();
            this.tb_totalPrice = new System.Windows.Forms.TextBox();
            this.tb_productDescription = new System.Windows.Forms.TextBox();
            this.tb_shipmentInformation = new System.Windows.Forms.TextBox();
            this.btn_editData = new System.Windows.Forms.Button();
            this.btn_sendProduct = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.pb_productImage = new System.Windows.Forms.PictureBox();
            this.lbl_brandName = new System.Windows.Forms.Label();
            this.lbl_sendQuentity = new System.Windows.Forms.Label();
            this.lbl_productDescription = new System.Windows.Forms.Label();
            this.cbb_brandName = new System.Windows.Forms.ComboBox();
            this.cbb_categoryName = new System.Windows.Forms.ComboBox();
            this.cb_sendDeleted = new System.Windows.Forms.CheckBox();
            this.lbl_deleted = new System.Windows.Forms.Label();
            this.cbb_productName = new System.Windows.Forms.ComboBox();
            this.cbb_subDealerInformation = new System.Windows.Forms.ComboBox();
            this.gb_sendToSubDealers = new System.Windows.Forms.GroupBox();
            this.lbl_shipmentInformation = new System.Windows.Forms.Label();
            this.dgv_sendToSubDealers = new System.Windows.Forms.DataGridView();
            this.tb_unitPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_productImage)).BeginInit();
            this.gb_sendToSubDealers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sendToSubDealers)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_sendToSubDealers
            // 
            this.lbl_sendToSubDealers.AutoSize = true;
            this.lbl_sendToSubDealers.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_sendToSubDealers.Location = new System.Drawing.Point(12, 9);
            this.lbl_sendToSubDealers.Name = "lbl_sendToSubDealers";
            this.lbl_sendToSubDealers.Size = new System.Drawing.Size(248, 35);
            this.lbl_sendToSubDealers.TabIndex = 0;
            this.lbl_sendToSubDealers.Text = "Send To Sub Dealers";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbl_categoryName
            // 
            this.lbl_categoryName.AutoSize = true;
            this.lbl_categoryName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_categoryName.ForeColor = System.Drawing.Color.Red;
            this.lbl_categoryName.Location = new System.Drawing.Point(32, 199);
            this.lbl_categoryName.Name = "lbl_categoryName";
            this.lbl_categoryName.Size = new System.Drawing.Size(155, 28);
            this.lbl_categoryName.TabIndex = 6;
            this.lbl_categoryName.Text = "Category Name";
            // 
            // lbl_productName
            // 
            this.lbl_productName.AutoSize = true;
            this.lbl_productName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productName.ForeColor = System.Drawing.Color.Red;
            this.lbl_productName.Location = new System.Drawing.Point(32, 275);
            this.lbl_productName.Name = "lbl_productName";
            this.lbl_productName.Size = new System.Drawing.Size(146, 28);
            this.lbl_productName.TabIndex = 8;
            this.lbl_productName.Text = "Product Name";
            // 
            // lbl_subTotalPrice
            // 
            this.lbl_subTotalPrice.AutoSize = true;
            this.lbl_subTotalPrice.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_subTotalPrice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_subTotalPrice.Location = new System.Drawing.Point(1014, 123);
            this.lbl_subTotalPrice.Name = "lbl_subTotalPrice";
            this.lbl_subTotalPrice.Size = new System.Drawing.Size(148, 28);
            this.lbl_subTotalPrice.TabIndex = 21;
            this.lbl_subTotalPrice.Text = "Sub Total Price";
            // 
            // lbl_subDealerInformation
            // 
            this.lbl_subDealerInformation.AutoSize = true;
            this.lbl_subDealerInformation.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_subDealerInformation.ForeColor = System.Drawing.Color.Blue;
            this.lbl_subDealerInformation.Location = new System.Drawing.Point(674, 45);
            this.lbl_subDealerInformation.Name = "lbl_subDealerInformation";
            this.lbl_subDealerInformation.Size = new System.Drawing.Size(228, 28);
            this.lbl_subDealerInformation.TabIndex = 13;
            this.lbl_subDealerInformation.Text = "Sub Dealer Information";
            // 
            // lbl_subDealerType
            // 
            this.lbl_subDealerType.AutoSize = true;
            this.lbl_subDealerType.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_subDealerType.ForeColor = System.Drawing.Color.Blue;
            this.lbl_subDealerType.Location = new System.Drawing.Point(674, 123);
            this.lbl_subDealerType.Name = "lbl_subDealerType";
            this.lbl_subDealerType.Size = new System.Drawing.Size(160, 28);
            this.lbl_subDealerType.TabIndex = 15;
            this.lbl_subDealerType.Text = "Sub Dealer Type";
            // 
            // lbl_productItemNumber
            // 
            this.lbl_productItemNumber.AutoSize = true;
            this.lbl_productItemNumber.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productItemNumber.ForeColor = System.Drawing.Color.Red;
            this.lbl_productItemNumber.Location = new System.Drawing.Point(32, 45);
            this.lbl_productItemNumber.Name = "lbl_productItemNumber";
            this.lbl_productItemNumber.Size = new System.Drawing.Size(215, 28);
            this.lbl_productItemNumber.TabIndex = 2;
            this.lbl_productItemNumber.Text = "Product Item Number";
            // 
            // lbl_subDealerDiscAmount
            // 
            this.lbl_subDealerDiscAmount.AutoSize = true;
            this.lbl_subDealerDiscAmount.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_subDealerDiscAmount.ForeColor = System.Drawing.Color.Blue;
            this.lbl_subDealerDiscAmount.Location = new System.Drawing.Point(674, 199);
            this.lbl_subDealerDiscAmount.Name = "lbl_subDealerDiscAmount";
            this.lbl_subDealerDiscAmount.Size = new System.Drawing.Size(279, 28);
            this.lbl_subDealerDiscAmount.TabIndex = 17;
            this.lbl_subDealerDiscAmount.Text = "Sub Dealer Discount Amount";
            // 
            // lbl_productImage
            // 
            this.lbl_productImage.AutoSize = true;
            this.lbl_productImage.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productImage.ForeColor = System.Drawing.Color.Red;
            this.lbl_productImage.Location = new System.Drawing.Point(364, 45);
            this.lbl_productImage.Name = "lbl_productImage";
            this.lbl_productImage.Size = new System.Drawing.Size(252, 28);
            this.lbl_productImage.TabIndex = 10;
            this.lbl_productImage.Text = "Product\'s Image Selection";
            // 
            // lbl_tax
            // 
            this.lbl_tax.AutoSize = true;
            this.lbl_tax.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_tax.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_tax.Location = new System.Drawing.Point(1014, 199);
            this.lbl_tax.Name = "lbl_tax";
            this.lbl_tax.Size = new System.Drawing.Size(42, 28);
            this.lbl_tax.TabIndex = 23;
            this.lbl_tax.Text = "Tax";
            // 
            // lbl_totalPrice
            // 
            this.lbl_totalPrice.AutoSize = true;
            this.lbl_totalPrice.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_totalPrice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_totalPrice.Location = new System.Drawing.Point(1014, 275);
            this.lbl_totalPrice.Name = "lbl_totalPrice";
            this.lbl_totalPrice.Size = new System.Drawing.Size(111, 28);
            this.lbl_totalPrice.TabIndex = 25;
            this.lbl_totalPrice.Text = "Total Price";
            // 
            // tb_sendQuentity
            // 
            this.tb_sendQuentity.Location = new System.Drawing.Point(1019, 76);
            this.tb_sendQuentity.Name = "tb_sendQuentity";
            this.tb_sendQuentity.Size = new System.Drawing.Size(130, 36);
            this.tb_sendQuentity.TabIndex = 20;
            // 
            // tb_tax
            // 
            this.tb_tax.Enabled = false;
            this.tb_tax.Location = new System.Drawing.Point(1019, 230);
            this.tb_tax.Name = "tb_tax";
            this.tb_tax.Size = new System.Drawing.Size(205, 36);
            this.tb_tax.TabIndex = 24;
            // 
            // tb_subTotalPrice
            // 
            this.tb_subTotalPrice.Enabled = false;
            this.tb_subTotalPrice.Location = new System.Drawing.Point(1019, 154);
            this.tb_subTotalPrice.Name = "tb_subTotalPrice";
            this.tb_subTotalPrice.Size = new System.Drawing.Size(205, 36);
            this.tb_subTotalPrice.TabIndex = 22;
            // 
            // tb_subDealerType
            // 
            this.tb_subDealerType.Enabled = false;
            this.tb_subDealerType.Location = new System.Drawing.Point(679, 154);
            this.tb_subDealerType.Name = "tb_subDealerType";
            this.tb_subDealerType.Size = new System.Drawing.Size(205, 36);
            this.tb_subDealerType.TabIndex = 16;
            // 
            // tb_subDealerDiscAmount
            // 
            this.tb_subDealerDiscAmount.Enabled = false;
            this.tb_subDealerDiscAmount.Location = new System.Drawing.Point(679, 230);
            this.tb_subDealerDiscAmount.Name = "tb_subDealerDiscAmount";
            this.tb_subDealerDiscAmount.Size = new System.Drawing.Size(205, 36);
            this.tb_subDealerDiscAmount.TabIndex = 18;
            // 
            // tb_productItemNumber
            // 
            this.tb_productItemNumber.Enabled = false;
            this.tb_productItemNumber.Location = new System.Drawing.Point(37, 76);
            this.tb_productItemNumber.Name = "tb_productItemNumber";
            this.tb_productItemNumber.Size = new System.Drawing.Size(326, 36);
            this.tb_productItemNumber.TabIndex = 3;
            // 
            // tb_totalPrice
            // 
            this.tb_totalPrice.Enabled = false;
            this.tb_totalPrice.Location = new System.Drawing.Point(1019, 306);
            this.tb_totalPrice.Name = "tb_totalPrice";
            this.tb_totalPrice.Size = new System.Drawing.Size(205, 36);
            this.tb_totalPrice.TabIndex = 26;
            // 
            // tb_productDescription
            // 
            this.tb_productDescription.Location = new System.Drawing.Point(369, 230);
            this.tb_productDescription.Multiline = true;
            this.tb_productDescription.Name = "tb_productDescription";
            this.tb_productDescription.ReadOnly = true;
            this.tb_productDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_productDescription.Size = new System.Drawing.Size(266, 112);
            this.tb_productDescription.TabIndex = 12;
            // 
            // tb_shipmentInformation
            // 
            this.tb_shipmentInformation.Enabled = false;
            this.tb_shipmentInformation.Location = new System.Drawing.Point(1313, 154);
            this.tb_shipmentInformation.Multiline = true;
            this.tb_shipmentInformation.Name = "tb_shipmentInformation";
            this.tb_shipmentInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_shipmentInformation.Size = new System.Drawing.Size(444, 127);
            this.tb_shipmentInformation.TabIndex = 28;
            // 
            // btn_editData
            // 
            this.btn_editData.Location = new System.Drawing.Point(1463, 306);
            this.btn_editData.Name = "btn_editData";
            this.btn_editData.Size = new System.Drawing.Size(144, 36);
            this.btn_editData.TabIndex = 30;
            this.btn_editData.Text = "Edit Data";
            this.btn_editData.UseVisualStyleBackColor = true;
            // 
            // btn_sendProduct
            // 
            this.btn_sendProduct.Location = new System.Drawing.Point(1313, 305);
            this.btn_sendProduct.Name = "btn_sendProduct";
            this.btn_sendProduct.Size = new System.Drawing.Size(144, 36);
            this.btn_sendProduct.TabIndex = 29;
            this.btn_sendProduct.Text = "Send";
            this.btn_sendProduct.UseVisualStyleBackColor = true;
            this.btn_sendProduct.Click += new System.EventHandler(this.btn_sendProduct_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(1613, 305);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(144, 36);
            this.btn_clear.TabIndex = 31;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // pb_productImage
            // 
            this.pb_productImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_productImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_productImage.Location = new System.Drawing.Point(369, 76);
            this.pb_productImage.Name = "pb_productImage";
            this.pb_productImage.Size = new System.Drawing.Size(266, 114);
            this.pb_productImage.TabIndex = 4;
            this.pb_productImage.TabStop = false;
            // 
            // lbl_brandName
            // 
            this.lbl_brandName.AutoSize = true;
            this.lbl_brandName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_brandName.ForeColor = System.Drawing.Color.Red;
            this.lbl_brandName.Location = new System.Drawing.Point(32, 123);
            this.lbl_brandName.Name = "lbl_brandName";
            this.lbl_brandName.Size = new System.Drawing.Size(128, 28);
            this.lbl_brandName.TabIndex = 4;
            this.lbl_brandName.Text = "Brand Name";
            // 
            // lbl_sendQuentity
            // 
            this.lbl_sendQuentity.AutoSize = true;
            this.lbl_sendQuentity.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_sendQuentity.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_sendQuentity.Location = new System.Drawing.Point(1014, 45);
            this.lbl_sendQuentity.Name = "lbl_sendQuentity";
            this.lbl_sendQuentity.Size = new System.Drawing.Size(254, 28);
            this.lbl_sendQuentity.TabIndex = 19;
            this.lbl_sendQuentity.Text = "Send Quantity / Unit Price";
            // 
            // lbl_productDescription
            // 
            this.lbl_productDescription.AutoSize = true;
            this.lbl_productDescription.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productDescription.ForeColor = System.Drawing.Color.Red;
            this.lbl_productDescription.Location = new System.Drawing.Point(364, 199);
            this.lbl_productDescription.Name = "lbl_productDescription";
            this.lbl_productDescription.Size = new System.Drawing.Size(197, 28);
            this.lbl_productDescription.TabIndex = 11;
            this.lbl_productDescription.Text = "Product Description";
            // 
            // cbb_brandName
            // 
            this.cbb_brandName.FormattingEnabled = true;
            this.cbb_brandName.Location = new System.Drawing.Point(37, 154);
            this.cbb_brandName.Name = "cbb_brandName";
            this.cbb_brandName.Size = new System.Drawing.Size(326, 36);
            this.cbb_brandName.TabIndex = 5;
            this.cbb_brandName.Text = "---Choose---";
            this.cbb_brandName.SelectedIndexChanged += new System.EventHandler(this.cbb_brandName_SelectedIndexChanged);
            // 
            // cbb_categoryName
            // 
            this.cbb_categoryName.FormattingEnabled = true;
            this.cbb_categoryName.Location = new System.Drawing.Point(37, 230);
            this.cbb_categoryName.Name = "cbb_categoryName";
            this.cbb_categoryName.Size = new System.Drawing.Size(326, 36);
            this.cbb_categoryName.TabIndex = 7;
            this.cbb_categoryName.Text = "---Choose---";
            this.cbb_categoryName.SelectedIndexChanged += new System.EventHandler(this.cbb_categoryName_SelectedIndexChanged);
            // 
            // cb_sendDeleted
            // 
            this.cb_sendDeleted.AutoSize = true;
            this.cb_sendDeleted.Enabled = false;
            this.cb_sendDeleted.ForeColor = System.Drawing.Color.Red;
            this.cb_sendDeleted.Location = new System.Drawing.Point(1739, 52);
            this.cb_sendDeleted.Name = "cb_sendDeleted";
            this.cb_sendDeleted.Size = new System.Drawing.Size(18, 17);
            this.cb_sendDeleted.TabIndex = 33;
            this.cb_sendDeleted.UseVisualStyleBackColor = true;
            // 
            // lbl_deleted
            // 
            this.lbl_deleted.AutoSize = true;
            this.lbl_deleted.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_deleted.ForeColor = System.Drawing.Color.Red;
            this.lbl_deleted.Location = new System.Drawing.Point(1552, 45);
            this.lbl_deleted.Name = "lbl_deleted";
            this.lbl_deleted.Size = new System.Drawing.Size(167, 28);
            this.lbl_deleted.TabIndex = 32;
            this.lbl_deleted.Text = "Cancel Shipment";
            // 
            // cbb_productName
            // 
            this.cbb_productName.FormattingEnabled = true;
            this.cbb_productName.Location = new System.Drawing.Point(37, 306);
            this.cbb_productName.Name = "cbb_productName";
            this.cbb_productName.Size = new System.Drawing.Size(326, 36);
            this.cbb_productName.TabIndex = 9;
            this.cbb_productName.Text = "---Choose---";
            this.cbb_productName.SelectedIndexChanged += new System.EventHandler(this.cbb_productName_SelectedIndexChanged);
            // 
            // cbb_subDealerInformation
            // 
            this.cbb_subDealerInformation.FormattingEnabled = true;
            this.cbb_subDealerInformation.Location = new System.Drawing.Point(679, 76);
            this.cbb_subDealerInformation.Name = "cbb_subDealerInformation";
            this.cbb_subDealerInformation.Size = new System.Drawing.Size(326, 36);
            this.cbb_subDealerInformation.TabIndex = 14;
            this.cbb_subDealerInformation.Text = "---Choose---";
            this.cbb_subDealerInformation.SelectedIndexChanged += new System.EventHandler(this.cbb_subDealerInformation_SelectedIndexChanged);
            // 
            // gb_sendToSubDealers
            // 
            this.gb_sendToSubDealers.Controls.Add(this.cbb_subDealerInformation);
            this.gb_sendToSubDealers.Controls.Add(this.cbb_productName);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_deleted);
            this.gb_sendToSubDealers.Controls.Add(this.cb_sendDeleted);
            this.gb_sendToSubDealers.Controls.Add(this.cbb_categoryName);
            this.gb_sendToSubDealers.Controls.Add(this.cbb_brandName);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_productDescription);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_shipmentInformation);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_sendQuentity);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_brandName);
            this.gb_sendToSubDealers.Controls.Add(this.pb_productImage);
            this.gb_sendToSubDealers.Controls.Add(this.btn_clear);
            this.gb_sendToSubDealers.Controls.Add(this.btn_sendProduct);
            this.gb_sendToSubDealers.Controls.Add(this.btn_editData);
            this.gb_sendToSubDealers.Controls.Add(this.tb_shipmentInformation);
            this.gb_sendToSubDealers.Controls.Add(this.tb_productDescription);
            this.gb_sendToSubDealers.Controls.Add(this.tb_totalPrice);
            this.gb_sendToSubDealers.Controls.Add(this.tb_productItemNumber);
            this.gb_sendToSubDealers.Controls.Add(this.tb_subDealerDiscAmount);
            this.gb_sendToSubDealers.Controls.Add(this.tb_subDealerType);
            this.gb_sendToSubDealers.Controls.Add(this.tb_subTotalPrice);
            this.gb_sendToSubDealers.Controls.Add(this.tb_tax);
            this.gb_sendToSubDealers.Controls.Add(this.tb_unitPrice);
            this.gb_sendToSubDealers.Controls.Add(this.tb_sendQuentity);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_totalPrice);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_tax);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_productImage);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_subDealerDiscAmount);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_productItemNumber);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_subDealerType);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_subDealerInformation);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_subTotalPrice);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_productName);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_categoryName);
            this.gb_sendToSubDealers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_sendToSubDealers.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_sendToSubDealers.Location = new System.Drawing.Point(12, 47);
            this.gb_sendToSubDealers.Name = "gb_sendToSubDealers";
            this.gb_sendToSubDealers.Size = new System.Drawing.Size(1863, 397);
            this.gb_sendToSubDealers.TabIndex = 1;
            this.gb_sendToSubDealers.TabStop = false;
            this.gb_sendToSubDealers.Text = "Products Information";
            // 
            // lbl_shipmentInformation
            // 
            this.lbl_shipmentInformation.AutoSize = true;
            this.lbl_shipmentInformation.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_shipmentInformation.ForeColor = System.Drawing.Color.Black;
            this.lbl_shipmentInformation.Location = new System.Drawing.Point(1313, 123);
            this.lbl_shipmentInformation.Name = "lbl_shipmentInformation";
            this.lbl_shipmentInformation.Size = new System.Drawing.Size(217, 28);
            this.lbl_shipmentInformation.TabIndex = 27;
            this.lbl_shipmentInformation.Text = "Shipment Information";
            // 
            // dgv_sendToSubDealers
            // 
            this.dgv_sendToSubDealers.AllowUserToAddRows = false;
            this.dgv_sendToSubDealers.AllowUserToDeleteRows = false;
            this.dgv_sendToSubDealers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sendToSubDealers.Location = new System.Drawing.Point(12, 450);
            this.dgv_sendToSubDealers.Name = "dgv_sendToSubDealers";
            this.dgv_sendToSubDealers.ReadOnly = true;
            this.dgv_sendToSubDealers.RowHeadersWidth = 51;
            this.dgv_sendToSubDealers.RowTemplate.Height = 24;
            this.dgv_sendToSubDealers.Size = new System.Drawing.Size(1863, 475);
            this.dgv_sendToSubDealers.TabIndex = 33;
            this.dgv_sendToSubDealers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_sendToSubDealers_DataBindingComplete);
            // 
            // tb_unitPrice
            // 
            this.tb_unitPrice.Location = new System.Drawing.Point(1156, 76);
            this.tb_unitPrice.Name = "tb_unitPrice";
            this.tb_unitPrice.Size = new System.Drawing.Size(130, 36);
            this.tb_unitPrice.TabIndex = 20;
            // 
            // SendToSubDealers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.dgv_sendToSubDealers);
            this.Controls.Add(this.lbl_sendToSubDealers);
            this.Controls.Add(this.gb_sendToSubDealers);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "SendToSubDealers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Send To Sub Dealers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SendToSubDealers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_productImage)).EndInit();
            this.gb_sendToSubDealers.ResumeLayout(false);
            this.gb_sendToSubDealers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sendToSubDealers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_sendToSubDealers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbl_categoryName;
        private System.Windows.Forms.Label lbl_productName;
        private System.Windows.Forms.Label lbl_subTotalPrice;
        private System.Windows.Forms.Label lbl_subDealerInformation;
        private System.Windows.Forms.Label lbl_subDealerType;
        private System.Windows.Forms.Label lbl_productItemNumber;
        private System.Windows.Forms.Label lbl_subDealerDiscAmount;
        private System.Windows.Forms.Label lbl_productImage;
        private System.Windows.Forms.Label lbl_tax;
        private System.Windows.Forms.Label lbl_totalPrice;
        private System.Windows.Forms.TextBox tb_sendQuentity;
        private System.Windows.Forms.TextBox tb_tax;
        private System.Windows.Forms.TextBox tb_subTotalPrice;
        private System.Windows.Forms.TextBox tb_subDealerType;
        private System.Windows.Forms.TextBox tb_subDealerDiscAmount;
        private System.Windows.Forms.TextBox tb_productItemNumber;
        private System.Windows.Forms.TextBox tb_totalPrice;
        private System.Windows.Forms.TextBox tb_productDescription;
        private System.Windows.Forms.TextBox tb_shipmentInformation;
        private System.Windows.Forms.Button btn_editData;
        private System.Windows.Forms.Button btn_sendProduct;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.PictureBox pb_productImage;
        private System.Windows.Forms.Label lbl_brandName;
        private System.Windows.Forms.Label lbl_sendQuentity;
        private System.Windows.Forms.Label lbl_productDescription;
        private System.Windows.Forms.ComboBox cbb_brandName;
        private System.Windows.Forms.ComboBox cbb_categoryName;
        private System.Windows.Forms.CheckBox cb_sendDeleted;
        private System.Windows.Forms.Label lbl_deleted;
        private System.Windows.Forms.ComboBox cbb_productName;
        private System.Windows.Forms.ComboBox cbb_subDealerInformation;
        private System.Windows.Forms.GroupBox gb_sendToSubDealers;
        private System.Windows.Forms.DataGridView dgv_sendToSubDealers;
        private System.Windows.Forms.Label lbl_shipmentInformation;
        private System.Windows.Forms.TextBox tb_unitPrice;
    }
}