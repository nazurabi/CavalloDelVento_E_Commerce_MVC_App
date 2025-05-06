namespace FormForDataModel
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.lbl_welcomeTitle = new System.Windows.Forms.Label();
            this.tmr_welcomeTitle = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_editBrands = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_addBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_editBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_editCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_addCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_editCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_editProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_addProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_editProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_seperator = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_editSendToSubDealers = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_editLevelIntegration = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_createLevelIntegration = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_acceptEditLevelIntegration = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_listLevelIntegration = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_listBrands = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_listCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Products = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_listProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_sendProductListToSubDealer = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_settingMainDealer = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_settingMainUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_settingSubDealers = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_settingDiscount = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_logOut = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_close = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_info = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_welcomeTitle
            // 
            this.lbl_welcomeTitle.AutoSize = true;
            this.lbl_welcomeTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcomeTitle.Location = new System.Drawing.Point(830, 466);
            this.lbl_welcomeTitle.Name = "lbl_welcomeTitle";
            this.lbl_welcomeTitle.Size = new System.Drawing.Size(240, 49);
            this.lbl_welcomeTitle.TabIndex = 1;
            this.lbl_welcomeTitle.Text = "Welcome Tag";
            this.lbl_welcomeTitle.Visible = false;
            // 
            // tmr_welcomeTitle
            // 
            this.tmr_welcomeTitle.Interval = 1000;
            this.tmr_welcomeTitle.Tick += new System.EventHandler(this.tmr_welcomeTitle_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.listToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.otherToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1900, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_editBrands,
            this.TSMI_editCategories,
            this.TSMI_editProducts,
            this.TSMI_seperator,
            this.TSMI_editSendToSubDealers,
            this.TSMI_editLevelIntegration});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // TSMI_editBrands
            // 
            this.TSMI_editBrands.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_addBrand,
            this.TSMI_editBrand});
            this.TSMI_editBrands.Name = "TSMI_editBrands";
            this.TSMI_editBrands.Size = new System.Drawing.Size(251, 26);
            this.TSMI_editBrands.Text = "Brands";
            // 
            // TSMI_addBrand
            // 
            this.TSMI_addBrand.Name = "TSMI_addBrand";
            this.TSMI_addBrand.Size = new System.Drawing.Size(120, 26);
            this.TSMI_addBrand.Text = "Add";
            this.TSMI_addBrand.Click += new System.EventHandler(this.TSMI_addBrand_Click);
            // 
            // TSMI_editBrand
            // 
            this.TSMI_editBrand.Name = "TSMI_editBrand";
            this.TSMI_editBrand.Size = new System.Drawing.Size(120, 26);
            this.TSMI_editBrand.Text = "Edit";
            this.TSMI_editBrand.Click += new System.EventHandler(this.TSMI_editBrand_Click);
            // 
            // TSMI_editCategories
            // 
            this.TSMI_editCategories.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_addCategory,
            this.TSMI_editCategory});
            this.TSMI_editCategories.Name = "TSMI_editCategories";
            this.TSMI_editCategories.Size = new System.Drawing.Size(251, 26);
            this.TSMI_editCategories.Text = "Categories";
            // 
            // TSMI_addCategory
            // 
            this.TSMI_addCategory.Name = "TSMI_addCategory";
            this.TSMI_addCategory.Size = new System.Drawing.Size(120, 26);
            this.TSMI_addCategory.Text = "Add";
            this.TSMI_addCategory.Click += new System.EventHandler(this.TSMI_addCategory_Click);
            // 
            // TSMI_editCategory
            // 
            this.TSMI_editCategory.Name = "TSMI_editCategory";
            this.TSMI_editCategory.Size = new System.Drawing.Size(120, 26);
            this.TSMI_editCategory.Text = "Edit";
            this.TSMI_editCategory.Click += new System.EventHandler(this.TSMI_editCategory_Click);
            // 
            // TSMI_editProducts
            // 
            this.TSMI_editProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_addProduct,
            this.TSMI_editProduct});
            this.TSMI_editProducts.Name = "TSMI_editProducts";
            this.TSMI_editProducts.Size = new System.Drawing.Size(251, 26);
            this.TSMI_editProducts.Text = "Products";
            // 
            // TSMI_addProduct
            // 
            this.TSMI_addProduct.Name = "TSMI_addProduct";
            this.TSMI_addProduct.Size = new System.Drawing.Size(120, 26);
            this.TSMI_addProduct.Text = "Add";
            this.TSMI_addProduct.Click += new System.EventHandler(this.TSMI_addProduct_Click);
            // 
            // TSMI_editProduct
            // 
            this.TSMI_editProduct.Name = "TSMI_editProduct";
            this.TSMI_editProduct.Size = new System.Drawing.Size(120, 26);
            this.TSMI_editProduct.Text = "Edit";
            this.TSMI_editProduct.Click += new System.EventHandler(this.TSMI_editProduct_Click);
            // 
            // TSMI_seperator
            // 
            this.TSMI_seperator.Name = "TSMI_seperator";
            this.TSMI_seperator.Size = new System.Drawing.Size(248, 6);
            // 
            // TSMI_editSendToSubDealers
            // 
            this.TSMI_editSendToSubDealers.Name = "TSMI_editSendToSubDealers";
            this.TSMI_editSendToSubDealers.Size = new System.Drawing.Size(251, 26);
            this.TSMI_editSendToSubDealers.Text = "Send To Subdealers";
            this.TSMI_editSendToSubDealers.Click += new System.EventHandler(this.TSMI_editSendToSubDealers_Click);
            // 
            // TSMI_editLevelIntegration
            // 
            this.TSMI_editLevelIntegration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_createLevelIntegration,
            this.TSMI_acceptEditLevelIntegration,
            this.TSMI_listLevelIntegration});
            this.TSMI_editLevelIntegration.Name = "TSMI_editLevelIntegration";
            this.TSMI_editLevelIntegration.Size = new System.Drawing.Size(251, 26);
            this.TSMI_editLevelIntegration.Text = "Level Integration Orders";
            this.TSMI_editLevelIntegration.Visible = false;
            // 
            // TSMI_createLevelIntegration
            // 
            this.TSMI_createLevelIntegration.Name = "TSMI_createLevelIntegration";
            this.TSMI_createLevelIntegration.Size = new System.Drawing.Size(220, 26);
            this.TSMI_createLevelIntegration.Text = "Create Order";
            this.TSMI_createLevelIntegration.Click += new System.EventHandler(this.TSMI_createLevelIntegration_Click);
            // 
            // TSMI_acceptEditLevelIntegration
            // 
            this.TSMI_acceptEditLevelIntegration.Name = "TSMI_acceptEditLevelIntegration";
            this.TSMI_acceptEditLevelIntegration.Size = new System.Drawing.Size(220, 26);
            this.TSMI_acceptEditLevelIntegration.Text = "Accept / Edit Order";
            // 
            // TSMI_listLevelIntegration
            // 
            this.TSMI_listLevelIntegration.Name = "TSMI_listLevelIntegration";
            this.TSMI_listLevelIntegration.Size = new System.Drawing.Size(220, 26);
            this.TSMI_listLevelIntegration.Text = "List Order";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_listBrands,
            this.TSMI_listCategories,
            this.TSMI_Products});
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(45, 24);
            this.listToolStripMenuItem.Text = "List";
            // 
            // TSMI_listBrands
            // 
            this.TSMI_listBrands.Name = "TSMI_listBrands";
            this.TSMI_listBrands.Size = new System.Drawing.Size(189, 26);
            this.TSMI_listBrands.Text = "Brands List";
            this.TSMI_listBrands.Click += new System.EventHandler(this.TSMI_listBrands_Click);
            // 
            // TSMI_listCategories
            // 
            this.TSMI_listCategories.Name = "TSMI_listCategories";
            this.TSMI_listCategories.Size = new System.Drawing.Size(189, 26);
            this.TSMI_listCategories.Text = "Categories List";
            this.TSMI_listCategories.Click += new System.EventHandler(this.TSMI_listCategories_Click);
            // 
            // TSMI_Products
            // 
            this.TSMI_Products.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_listProducts,
            this.TSMI_sendProductListToSubDealer});
            this.TSMI_Products.Name = "TSMI_Products";
            this.TSMI_Products.Size = new System.Drawing.Size(189, 26);
            this.TSMI_Products.Text = "Products";
            // 
            // TSMI_listProducts
            // 
            this.TSMI_listProducts.Name = "TSMI_listProducts";
            this.TSMI_listProducts.Size = new System.Drawing.Size(307, 26);
            this.TSMI_listProducts.Text = "Products List";
            this.TSMI_listProducts.Click += new System.EventHandler(this.TSMI_listProducts_Click);
            // 
            // TSMI_sendProductListToSubDealer
            // 
            this.TSMI_sendProductListToSubDealer.Name = "TSMI_sendProductListToSubDealer";
            this.TSMI_sendProductListToSubDealer.Size = new System.Drawing.Size(307, 26);
            this.TSMI_sendProductListToSubDealer.Text = "Send Product List to Sub Dealers";
            this.TSMI_sendProductListToSubDealer.Click += new System.EventHandler(this.TSMI_sendProductListToSubDealer_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_settingMainDealer,
            this.TSMI_settingMainUsers,
            this.TSMI_settingSubDealers,
            this.TSMI_settingDiscount});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // TSMI_settingMainDealer
            // 
            this.TSMI_settingMainDealer.Name = "TSMI_settingMainDealer";
            this.TSMI_settingMainDealer.Size = new System.Drawing.Size(247, 26);
            this.TSMI_settingMainDealer.Text = "Main Dealer Settings";
            this.TSMI_settingMainDealer.Click += new System.EventHandler(this.TSMI_settingMainDealer_Click);
            // 
            // TSMI_settingMainUsers
            // 
            this.TSMI_settingMainUsers.Name = "TSMI_settingMainUsers";
            this.TSMI_settingMainUsers.Size = new System.Drawing.Size(247, 26);
            this.TSMI_settingMainUsers.Text = "User Settings";
            this.TSMI_settingMainUsers.Click += new System.EventHandler(this.TSMI_settingMainUsers_Click);
            // 
            // TSMI_settingSubDealers
            // 
            this.TSMI_settingSubDealers.Name = "TSMI_settingSubDealers";
            this.TSMI_settingSubDealers.Size = new System.Drawing.Size(247, 26);
            this.TSMI_settingSubDealers.Text = "Sub Dealer Settings";
            this.TSMI_settingSubDealers.Click += new System.EventHandler(this.TSMI_settingSubDealers_Click);
            // 
            // TSMI_settingDiscount
            // 
            this.TSMI_settingDiscount.Name = "TSMI_settingDiscount";
            this.TSMI_settingDiscount.Size = new System.Drawing.Size(247, 26);
            this.TSMI_settingDiscount.Text = "Discount Rates Settings";
            this.TSMI_settingDiscount.Click += new System.EventHandler(this.TSMI_settingDiscount_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_logOut,
            this.TSMI_close,
            this.TSMI_info});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // TSMI_logOut
            // 
            this.TSMI_logOut.Name = "TSMI_logOut";
            this.TSMI_logOut.Size = new System.Drawing.Size(145, 26);
            this.TSMI_logOut.Text = "Log Out";
            this.TSMI_logOut.Click += new System.EventHandler(this.TSMI_logOut_Click);
            // 
            // TSMI_close
            // 
            this.TSMI_close.Name = "TSMI_close";
            this.TSMI_close.Size = new System.Drawing.Size(145, 26);
            this.TSMI_close.Text = "Close";
            this.TSMI_close.Click += new System.EventHandler(this.TSMI_close_Click);
            // 
            // TSMI_info
            // 
            this.TSMI_info.Name = "TSMI_info";
            this.TSMI_info.Size = new System.Drawing.Size(145, 26);
            this.TSMI_info.Text = "Info";
            this.TSMI_info.Click += new System.EventHandler(this.TSMI_info_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 959);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1900, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbl_welcomeTitle);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_welcomeTitle;
        private System.Windows.Forms.Timer tmr_welcomeTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_editBrands;
        private System.Windows.Forms.ToolStripMenuItem TSMI_editCategories;
        private System.Windows.Forms.ToolStripMenuItem TSMI_editProducts;
        private System.Windows.Forms.ToolStripMenuItem TSMI_editSendToSubDealers;
        private System.Windows.Forms.ToolStripMenuItem TSMI_editLevelIntegration;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_listBrands;
        private System.Windows.Forms.ToolStripMenuItem TSMI_listCategories;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Products;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_settingMainDealer;
        private System.Windows.Forms.ToolStripMenuItem TSMI_settingSubDealers;
        private System.Windows.Forms.ToolStripMenuItem TSMI_settingMainUsers;
        private System.Windows.Forms.ToolStripMenuItem TSMI_settingDiscount;
        private System.Windows.Forms.ToolStripMenuItem TSMI_addBrand;
        private System.Windows.Forms.ToolStripMenuItem TSMI_editBrand;
        private System.Windows.Forms.ToolStripMenuItem TSMI_addCategory;
        private System.Windows.Forms.ToolStripMenuItem TSMI_editCategory;
        private System.Windows.Forms.ToolStripMenuItem TSMI_addProduct;
        private System.Windows.Forms.ToolStripMenuItem TSMI_editProduct;
        private System.Windows.Forms.ToolStripSeparator TSMI_seperator;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_logOut;
        private System.Windows.Forms.ToolStripMenuItem TSMI_close;
        private System.Windows.Forms.ToolStripMenuItem TSMI_info;
        private System.Windows.Forms.ToolStripMenuItem TSMI_sendProductListToSubDealer;
        private System.Windows.Forms.ToolStripMenuItem TSMI_listProducts;
        private System.Windows.Forms.ToolStripMenuItem TSMI_createLevelIntegration;
        private System.Windows.Forms.ToolStripMenuItem TSMI_acceptEditLevelIntegration;
        private System.Windows.Forms.ToolStripMenuItem TSMI_listLevelIntegration;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}