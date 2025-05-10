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
            this.tb_subDealerType = new System.Windows.Forms.TextBox();
            this.tb_subDealerDiscAmount = new System.Windows.Forms.TextBox();
            this.tb_productItemNumber = new System.Windows.Forms.TextBox();
            this.tb_productDescription = new System.Windows.Forms.TextBox();
            this.tb_shipmentInformation = new System.Windows.Forms.TextBox();
            this.btn_cancelShipment = new System.Windows.Forms.Button();
            this.btn_sendProduct = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.pb_productImage = new System.Windows.Forms.PictureBox();
            this.lbl_brandName = new System.Windows.Forms.Label();
            this.lbl_sendQuentity = new System.Windows.Forms.Label();
            this.lbl_productDescription = new System.Windows.Forms.Label();
            this.cbb_brandName = new System.Windows.Forms.ComboBox();
            this.cbb_categoryName = new System.Windows.Forms.ComboBox();
            this.cbb_productName = new System.Windows.Forms.ComboBox();
            this.cbb_subDealerInformation = new System.Windows.Forms.ComboBox();
            this.gb_sendToSubDealers = new System.Windows.Forms.GroupBox();
            this.nud_discountedPrice = new System.Windows.Forms.NumericUpDown();
            this.nud_totalPrice = new System.Windows.Forms.NumericUpDown();
            this.nud_subTotalPrice = new System.Windows.Forms.NumericUpDown();
            this.lbl_shipmentInformation = new System.Windows.Forms.Label();
            this.tb_discountedPrice = new System.Windows.Forms.TextBox();
            this.tb_quantityPerUnit = new System.Windows.Forms.TextBox();
            this.tb_unitsInStock = new System.Windows.Forms.TextBox();
            this.tb_unitPrice = new System.Windows.Forms.TextBox();
            this.lbl_discountedPrice = new System.Windows.Forms.Label();
            this.lbl_quantityPerUnit = new System.Windows.Forms.Label();
            this.lbl_unitsInStock = new System.Windows.Forms.Label();
            this.dgv_sendToSubDealers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pb_productImage)).BeginInit();
            this.gb_sendToSubDealers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_discountedPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_totalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_subTotalPrice)).BeginInit();
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
            this.lbl_categoryName.Location = new System.Drawing.Point(32, 185);
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
            this.lbl_productName.Location = new System.Drawing.Point(32, 255);
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
            this.lbl_subTotalPrice.Location = new System.Drawing.Point(1212, 45);
            this.lbl_subTotalPrice.Name = "lbl_subTotalPrice";
            this.lbl_subTotalPrice.Size = new System.Drawing.Size(159, 28);
            this.lbl_subTotalPrice.TabIndex = 24;
            this.lbl_subTotalPrice.Text = "=Sub Total Price";
            // 
            // lbl_subDealerInformation
            // 
            this.lbl_subDealerInformation.AutoSize = true;
            this.lbl_subDealerInformation.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_subDealerInformation.ForeColor = System.Drawing.Color.Blue;
            this.lbl_subDealerInformation.Location = new System.Drawing.Point(674, 45);
            this.lbl_subDealerInformation.Name = "lbl_subDealerInformation";
            this.lbl_subDealerInformation.Size = new System.Drawing.Size(228, 28);
            this.lbl_subDealerInformation.TabIndex = 17;
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
            this.lbl_subDealerType.TabIndex = 19;
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
            this.lbl_subDealerDiscAmount.TabIndex = 21;
            this.lbl_subDealerDiscAmount.Text = "Sub Dealer Discount Amount";
            // 
            // lbl_productImage
            // 
            this.lbl_productImage.AutoSize = true;
            this.lbl_productImage.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productImage.ForeColor = System.Drawing.Color.Red;
            this.lbl_productImage.Location = new System.Drawing.Point(364, 45);
            this.lbl_productImage.Name = "lbl_productImage";
            this.lbl_productImage.Size = new System.Drawing.Size(162, 28);
            this.lbl_productImage.TabIndex = 14;
            this.lbl_productImage.Text = "Product\'s Image";
            // 
            // lbl_tax
            // 
            this.lbl_tax.AutoSize = true;
            this.lbl_tax.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_tax.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_tax.Location = new System.Drawing.Point(1076, 123);
            this.lbl_tax.Name = "lbl_tax";
            this.lbl_tax.Size = new System.Drawing.Size(53, 28);
            this.lbl_tax.TabIndex = 28;
            this.lbl_tax.Text = "+Tax";
            // 
            // lbl_totalPrice
            // 
            this.lbl_totalPrice.AutoSize = true;
            this.lbl_totalPrice.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_totalPrice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_totalPrice.Location = new System.Drawing.Point(1212, 123);
            this.lbl_totalPrice.Name = "lbl_totalPrice";
            this.lbl_totalPrice.Size = new System.Drawing.Size(122, 28);
            this.lbl_totalPrice.TabIndex = 29;
            this.lbl_totalPrice.Text = "=Total Price";
            // 
            // tb_sendQuentity
            // 
            this.tb_sendQuentity.Enabled = false;
            this.tb_sendQuentity.Location = new System.Drawing.Point(944, 76);
            this.tb_sendQuentity.Name = "tb_sendQuentity";
            this.tb_sendQuentity.Size = new System.Drawing.Size(130, 36);
            this.tb_sendQuentity.TabIndex = 25;
            this.tb_sendQuentity.TextChanged += new System.EventHandler(this.tb_sendQuentity_TextChanged);
            this.tb_sendQuentity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_sendQuentity_KeyPress);
            // 
            // tb_tax
            // 
            this.tb_tax.Enabled = false;
            this.tb_tax.Location = new System.Drawing.Point(1081, 154);
            this.tb_tax.Name = "tb_tax";
            this.tb_tax.Size = new System.Drawing.Size(130, 36);
            this.tb_tax.TabIndex = 30;
            // 
            // tb_subDealerType
            // 
            this.tb_subDealerType.Enabled = false;
            this.tb_subDealerType.Location = new System.Drawing.Point(679, 154);
            this.tb_subDealerType.Name = "tb_subDealerType";
            this.tb_subDealerType.Size = new System.Drawing.Size(223, 36);
            this.tb_subDealerType.TabIndex = 20;
            // 
            // tb_subDealerDiscAmount
            // 
            this.tb_subDealerDiscAmount.Enabled = false;
            this.tb_subDealerDiscAmount.Location = new System.Drawing.Point(679, 230);
            this.tb_subDealerDiscAmount.Name = "tb_subDealerDiscAmount";
            this.tb_subDealerDiscAmount.Size = new System.Drawing.Size(223, 36);
            this.tb_subDealerDiscAmount.TabIndex = 22;
            // 
            // tb_productItemNumber
            // 
            this.tb_productItemNumber.Enabled = false;
            this.tb_productItemNumber.Location = new System.Drawing.Point(37, 75);
            this.tb_productItemNumber.Name = "tb_productItemNumber";
            this.tb_productItemNumber.Size = new System.Drawing.Size(326, 36);
            this.tb_productItemNumber.TabIndex = 3;
            // 
            // tb_productDescription
            // 
            this.tb_productDescription.Location = new System.Drawing.Point(369, 286);
            this.tb_productDescription.Multiline = true;
            this.tb_productDescription.Name = "tb_productDescription";
            this.tb_productDescription.ReadOnly = true;
            this.tb_productDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_productDescription.Size = new System.Drawing.Size(266, 174);
            this.tb_productDescription.TabIndex = 16;
            // 
            // tb_shipmentInformation
            // 
            this.tb_shipmentInformation.Enabled = false;
            this.tb_shipmentInformation.Location = new System.Drawing.Point(1456, 76);
            this.tb_shipmentInformation.Multiline = true;
            this.tb_shipmentInformation.Name = "tb_shipmentInformation";
            this.tb_shipmentInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_shipmentInformation.Size = new System.Drawing.Size(367, 190);
            this.tb_shipmentInformation.TabIndex = 35;
            // 
            // btn_cancelShipment
            // 
            this.btn_cancelShipment.ForeColor = System.Drawing.Color.Red;
            this.btn_cancelShipment.Location = new System.Drawing.Point(1106, 286);
            this.btn_cancelShipment.Name = "btn_cancelShipment";
            this.btn_cancelShipment.Size = new System.Drawing.Size(208, 36);
            this.btn_cancelShipment.TabIndex = 39;
            this.btn_cancelShipment.Text = "Cancel Shipment";
            this.btn_cancelShipment.UseVisualStyleBackColor = true;
            this.btn_cancelShipment.Click += new System.EventHandler(this.btn_cancelShipment_Click);
            // 
            // btn_sendProduct
            // 
            this.btn_sendProduct.Location = new System.Drawing.Point(987, 286);
            this.btn_sendProduct.Name = "btn_sendProduct";
            this.btn_sendProduct.Size = new System.Drawing.Size(113, 36);
            this.btn_sendProduct.TabIndex = 38;
            this.btn_sendProduct.Text = "Send";
            this.btn_sendProduct.UseVisualStyleBackColor = true;
            this.btn_sendProduct.Click += new System.EventHandler(this.btn_sendProduct_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(1320, 286);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(113, 36);
            this.btn_clear.TabIndex = 41;
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
            this.pb_productImage.Size = new System.Drawing.Size(266, 176);
            this.pb_productImage.TabIndex = 4;
            this.pb_productImage.TabStop = false;
            // 
            // lbl_brandName
            // 
            this.lbl_brandName.AutoSize = true;
            this.lbl_brandName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_brandName.ForeColor = System.Drawing.Color.Red;
            this.lbl_brandName.Location = new System.Drawing.Point(32, 115);
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
            this.lbl_sendQuentity.Location = new System.Drawing.Point(939, 45);
            this.lbl_sendQuentity.Name = "lbl_sendQuentity";
            this.lbl_sendQuentity.Size = new System.Drawing.Size(257, 28);
            this.lbl_sendQuentity.TabIndex = 23;
            this.lbl_sendQuentity.Text = "Send Quantity X Unit Price";
            // 
            // lbl_productDescription
            // 
            this.lbl_productDescription.AutoSize = true;
            this.lbl_productDescription.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_productDescription.ForeColor = System.Drawing.Color.Red;
            this.lbl_productDescription.Location = new System.Drawing.Point(364, 255);
            this.lbl_productDescription.Name = "lbl_productDescription";
            this.lbl_productDescription.Size = new System.Drawing.Size(197, 28);
            this.lbl_productDescription.TabIndex = 15;
            this.lbl_productDescription.Text = "Product Description";
            // 
            // cbb_brandName
            // 
            this.cbb_brandName.FormattingEnabled = true;
            this.cbb_brandName.Location = new System.Drawing.Point(37, 146);
            this.cbb_brandName.Name = "cbb_brandName";
            this.cbb_brandName.Size = new System.Drawing.Size(326, 36);
            this.cbb_brandName.TabIndex = 5;
            this.cbb_brandName.Text = "---Choose---";
            this.cbb_brandName.SelectedIndexChanged += new System.EventHandler(this.cbb_brandName_SelectedIndexChanged);
            // 
            // cbb_categoryName
            // 
            this.cbb_categoryName.FormattingEnabled = true;
            this.cbb_categoryName.Location = new System.Drawing.Point(37, 216);
            this.cbb_categoryName.Name = "cbb_categoryName";
            this.cbb_categoryName.Size = new System.Drawing.Size(326, 36);
            this.cbb_categoryName.TabIndex = 7;
            this.cbb_categoryName.Text = "---Choose---";
            this.cbb_categoryName.SelectedIndexChanged += new System.EventHandler(this.cbb_categoryName_SelectedIndexChanged);
            // 
            // cbb_productName
            // 
            this.cbb_productName.FormattingEnabled = true;
            this.cbb_productName.Location = new System.Drawing.Point(37, 286);
            this.cbb_productName.Name = "cbb_productName";
            this.cbb_productName.Size = new System.Drawing.Size(326, 36);
            this.cbb_productName.TabIndex = 9;
            this.cbb_productName.Text = "---Choose---";
            this.cbb_productName.SelectedIndexChanged += new System.EventHandler(this.cbb_productName_SelectedIndexChanged);
            // 
            // cbb_subDealerInformation
            // 
            this.cbb_subDealerInformation.Enabled = false;
            this.cbb_subDealerInformation.FormattingEnabled = true;
            this.cbb_subDealerInformation.Location = new System.Drawing.Point(679, 76);
            this.cbb_subDealerInformation.Name = "cbb_subDealerInformation";
            this.cbb_subDealerInformation.Size = new System.Drawing.Size(223, 36);
            this.cbb_subDealerInformation.TabIndex = 18;
            this.cbb_subDealerInformation.Text = "---Choose---";
            this.cbb_subDealerInformation.SelectedIndexChanged += new System.EventHandler(this.cbb_subDealerInformation_SelectedIndexChanged);
            // 
            // gb_sendToSubDealers
            // 
            this.gb_sendToSubDealers.Controls.Add(this.nud_discountedPrice);
            this.gb_sendToSubDealers.Controls.Add(this.nud_totalPrice);
            this.gb_sendToSubDealers.Controls.Add(this.nud_subTotalPrice);
            this.gb_sendToSubDealers.Controls.Add(this.cbb_subDealerInformation);
            this.gb_sendToSubDealers.Controls.Add(this.cbb_productName);
            this.gb_sendToSubDealers.Controls.Add(this.cbb_categoryName);
            this.gb_sendToSubDealers.Controls.Add(this.cbb_brandName);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_productDescription);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_shipmentInformation);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_sendQuentity);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_brandName);
            this.gb_sendToSubDealers.Controls.Add(this.pb_productImage);
            this.gb_sendToSubDealers.Controls.Add(this.btn_clear);
            this.gb_sendToSubDealers.Controls.Add(this.btn_sendProduct);
            this.gb_sendToSubDealers.Controls.Add(this.btn_cancelShipment);
            this.gb_sendToSubDealers.Controls.Add(this.tb_shipmentInformation);
            this.gb_sendToSubDealers.Controls.Add(this.tb_productDescription);
            this.gb_sendToSubDealers.Controls.Add(this.tb_discountedPrice);
            this.gb_sendToSubDealers.Controls.Add(this.tb_quantityPerUnit);
            this.gb_sendToSubDealers.Controls.Add(this.tb_unitsInStock);
            this.gb_sendToSubDealers.Controls.Add(this.tb_productItemNumber);
            this.gb_sendToSubDealers.Controls.Add(this.tb_subDealerDiscAmount);
            this.gb_sendToSubDealers.Controls.Add(this.tb_subDealerType);
            this.gb_sendToSubDealers.Controls.Add(this.tb_tax);
            this.gb_sendToSubDealers.Controls.Add(this.tb_unitPrice);
            this.gb_sendToSubDealers.Controls.Add(this.tb_sendQuentity);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_discountedPrice);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_totalPrice);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_tax);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_quantityPerUnit);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_productImage);
            this.gb_sendToSubDealers.Controls.Add(this.lbl_unitsInStock);
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
            this.gb_sendToSubDealers.Size = new System.Drawing.Size(1863, 493);
            this.gb_sendToSubDealers.TabIndex = 1;
            this.gb_sendToSubDealers.TabStop = false;
            this.gb_sendToSubDealers.Text = "Products Information";
            // 
            // nud_discountedPrice
            // 
            this.nud_discountedPrice.DecimalPlaces = 2;
            this.nud_discountedPrice.Enabled = false;
            this.nud_discountedPrice.Location = new System.Drawing.Point(1217, 230);
            this.nud_discountedPrice.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.nud_discountedPrice.Name = "nud_discountedPrice";
            this.nud_discountedPrice.Size = new System.Drawing.Size(216, 36);
            this.nud_discountedPrice.TabIndex = 33;
            this.nud_discountedPrice.ThousandsSeparator = true;
            this.nud_discountedPrice.Visible = false;
            // 
            // nud_totalPrice
            // 
            this.nud_totalPrice.DecimalPlaces = 2;
            this.nud_totalPrice.Enabled = false;
            this.nud_totalPrice.Location = new System.Drawing.Point(1217, 154);
            this.nud_totalPrice.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.nud_totalPrice.Name = "nud_totalPrice";
            this.nud_totalPrice.Size = new System.Drawing.Size(216, 36);
            this.nud_totalPrice.TabIndex = 31;
            this.nud_totalPrice.ThousandsSeparator = true;
            // 
            // nud_subTotalPrice
            // 
            this.nud_subTotalPrice.DecimalPlaces = 2;
            this.nud_subTotalPrice.Enabled = false;
            this.nud_subTotalPrice.Location = new System.Drawing.Point(1217, 76);
            this.nud_subTotalPrice.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.nud_subTotalPrice.Name = "nud_subTotalPrice";
            this.nud_subTotalPrice.Size = new System.Drawing.Size(216, 36);
            this.nud_subTotalPrice.TabIndex = 27;
            this.nud_subTotalPrice.ThousandsSeparator = true;
            // 
            // lbl_shipmentInformation
            // 
            this.lbl_shipmentInformation.AutoSize = true;
            this.lbl_shipmentInformation.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_shipmentInformation.ForeColor = System.Drawing.Color.Black;
            this.lbl_shipmentInformation.Location = new System.Drawing.Point(1451, 45);
            this.lbl_shipmentInformation.Name = "lbl_shipmentInformation";
            this.lbl_shipmentInformation.Size = new System.Drawing.Size(316, 28);
            this.lbl_shipmentInformation.TabIndex = 34;
            this.lbl_shipmentInformation.Text = "Shipment Information (Optional)";
            // 
            // tb_discountedPrice
            // 
            this.tb_discountedPrice.Enabled = false;
            this.tb_discountedPrice.Location = new System.Drawing.Point(1217, 230);
            this.tb_discountedPrice.Name = "tb_discountedPrice";
            this.tb_discountedPrice.Size = new System.Drawing.Size(216, 36);
            this.tb_discountedPrice.TabIndex = 29;
            this.tb_discountedPrice.Visible = false;
            // 
            // tb_quantityPerUnit
            // 
            this.tb_quantityPerUnit.Enabled = false;
            this.tb_quantityPerUnit.Location = new System.Drawing.Point(37, 424);
            this.tb_quantityPerUnit.Name = "tb_quantityPerUnit";
            this.tb_quantityPerUnit.Size = new System.Drawing.Size(326, 36);
            this.tb_quantityPerUnit.TabIndex = 13;
            // 
            // tb_unitsInStock
            // 
            this.tb_unitsInStock.Enabled = false;
            this.tb_unitsInStock.Location = new System.Drawing.Point(37, 356);
            this.tb_unitsInStock.Name = "tb_unitsInStock";
            this.tb_unitsInStock.Size = new System.Drawing.Size(326, 36);
            this.tb_unitsInStock.TabIndex = 11;
            // 
            // tb_unitPrice
            // 
            this.tb_unitPrice.Enabled = false;
            this.tb_unitPrice.Location = new System.Drawing.Point(1081, 76);
            this.tb_unitPrice.Name = "tb_unitPrice";
            this.tb_unitPrice.Size = new System.Drawing.Size(130, 36);
            this.tb_unitPrice.TabIndex = 26;
            // 
            // lbl_discountedPrice
            // 
            this.lbl_discountedPrice.AutoSize = true;
            this.lbl_discountedPrice.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_discountedPrice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_discountedPrice.Location = new System.Drawing.Point(1212, 199);
            this.lbl_discountedPrice.Name = "lbl_discountedPrice";
            this.lbl_discountedPrice.Size = new System.Drawing.Size(173, 28);
            this.lbl_discountedPrice.TabIndex = 32;
            this.lbl_discountedPrice.Text = "Discounted Price";
            // 
            // lbl_quantityPerUnit
            // 
            this.lbl_quantityPerUnit.AutoSize = true;
            this.lbl_quantityPerUnit.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_quantityPerUnit.ForeColor = System.Drawing.Color.Red;
            this.lbl_quantityPerUnit.Location = new System.Drawing.Point(32, 393);
            this.lbl_quantityPerUnit.Name = "lbl_quantityPerUnit";
            this.lbl_quantityPerUnit.Size = new System.Drawing.Size(174, 28);
            this.lbl_quantityPerUnit.TabIndex = 12;
            this.lbl_quantityPerUnit.Text = "Quantity Per Unit";
            // 
            // lbl_unitsInStock
            // 
            this.lbl_unitsInStock.AutoSize = true;
            this.lbl_unitsInStock.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_unitsInStock.ForeColor = System.Drawing.Color.Red;
            this.lbl_unitsInStock.Location = new System.Drawing.Point(32, 325);
            this.lbl_unitsInStock.Name = "lbl_unitsInStock";
            this.lbl_unitsInStock.Size = new System.Drawing.Size(140, 28);
            this.lbl_unitsInStock.TabIndex = 10;
            this.lbl_unitsInStock.Text = "Units In Stock";
            // 
            // dgv_sendToSubDealers
            // 
            this.dgv_sendToSubDealers.AllowUserToAddRows = false;
            this.dgv_sendToSubDealers.AllowUserToDeleteRows = false;
            this.dgv_sendToSubDealers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sendToSubDealers.Location = new System.Drawing.Point(12, 546);
            this.dgv_sendToSubDealers.Name = "dgv_sendToSubDealers";
            this.dgv_sendToSubDealers.ReadOnly = true;
            this.dgv_sendToSubDealers.RowHeadersWidth = 51;
            this.dgv_sendToSubDealers.RowTemplate.Height = 24;
            this.dgv_sendToSubDealers.Size = new System.Drawing.Size(1863, 342);
            this.dgv_sendToSubDealers.TabIndex = 42;
            //this.dgv_sendToSubDealers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_sendToSubDealers_DataBindingComplete);
            this.dgv_sendToSubDealers.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_sendToSubDealers_RowHeaderMouseClick);
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
            ((System.ComponentModel.ISupportInitialize)(this.nud_discountedPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_totalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_subTotalPrice)).EndInit();
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
        private System.Windows.Forms.TextBox tb_subDealerType;
        private System.Windows.Forms.TextBox tb_subDealerDiscAmount;
        private System.Windows.Forms.TextBox tb_productItemNumber;
        private System.Windows.Forms.TextBox tb_productDescription;
        private System.Windows.Forms.TextBox tb_shipmentInformation;
        private System.Windows.Forms.Button btn_cancelShipment;
        private System.Windows.Forms.Button btn_sendProduct;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.PictureBox pb_productImage;
        private System.Windows.Forms.Label lbl_brandName;
        private System.Windows.Forms.Label lbl_sendQuentity;
        private System.Windows.Forms.Label lbl_productDescription;
        private System.Windows.Forms.ComboBox cbb_brandName;
        private System.Windows.Forms.ComboBox cbb_categoryName;
        private System.Windows.Forms.ComboBox cbb_productName;
        private System.Windows.Forms.ComboBox cbb_subDealerInformation;
        private System.Windows.Forms.GroupBox gb_sendToSubDealers;
        private System.Windows.Forms.DataGridView dgv_sendToSubDealers;
        private System.Windows.Forms.Label lbl_shipmentInformation;
        private System.Windows.Forms.TextBox tb_unitPrice;
        private System.Windows.Forms.TextBox tb_discountedPrice;
        private System.Windows.Forms.Label lbl_discountedPrice;
        private System.Windows.Forms.NumericUpDown nud_discountedPrice;
        private System.Windows.Forms.NumericUpDown nud_totalPrice;
        private System.Windows.Forms.NumericUpDown nud_subTotalPrice;
        private System.Windows.Forms.TextBox tb_quantityPerUnit;
        private System.Windows.Forms.TextBox tb_unitsInStock;
        private System.Windows.Forms.Label lbl_quantityPerUnit;
        private System.Windows.Forms.Label lbl_unitsInStock;
    }
}