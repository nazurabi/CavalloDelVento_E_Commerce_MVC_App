namespace FormForDataModel
{
    partial class SubDealerSettings
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
            this.lbl_subDealerSettings = new System.Windows.Forms.Label();
            this.gb_addSubDealers = new System.Windows.Forms.GroupBox();
            this.cbb_subDealers = new System.Windows.Forms.ComboBox();
            this.btn_cancelEdit = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_dealerCountry = new System.Windows.Forms.TextBox();
            this.tb_dealerPostalCode = new System.Windows.Forms.TextBox();
            this.tb_dealerCity = new System.Windows.Forms.TextBox();
            this.tb_dealerAdress = new System.Windows.Forms.TextBox();
            this.tb_dealerMail = new System.Windows.Forms.TextBox();
            this.tb_dealerName = new System.Windows.Forms.TextBox();
            this.tb_subDealerUserID = new System.Windows.Forms.TextBox();
            this.cb_subDealerUser = new System.Windows.Forms.CheckBox();
            this.lbl_dealerCountry = new System.Windows.Forms.Label();
            this.lbl_dealerPostalCode = new System.Windows.Forms.Label();
            this.lbl_dealerCity = new System.Windows.Forms.Label();
            this.lbl_dealerAdress = new System.Windows.Forms.Label();
            this.lbl_discountAmountType = new System.Windows.Forms.Label();
            this.lbl_dealerMail = new System.Windows.Forms.Label();
            this.lbl_dealerName = new System.Windows.Forms.Label();
            this.lbl_dealerUserID = new System.Windows.Forms.Label();
            this.lbl_brandDelete = new System.Windows.Forms.Label();
            this.btn_editSubDealers = new System.Windows.Forms.Button();
            this.dgv_editSubDealers = new System.Windows.Forms.DataGridView();
            this.gb_addSubDealers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_editSubDealers)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_subDealerSettings
            // 
            this.lbl_subDealerSettings.AutoSize = true;
            this.lbl_subDealerSettings.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_subDealerSettings.Location = new System.Drawing.Point(12, 9);
            this.lbl_subDealerSettings.Name = "lbl_subDealerSettings";
            this.lbl_subDealerSettings.Size = new System.Drawing.Size(238, 35);
            this.lbl_subDealerSettings.TabIndex = 3;
            this.lbl_subDealerSettings.Text = "Sub Dealer Settings";
            // 
            // gb_addSubDealers
            // 
            this.gb_addSubDealers.Controls.Add(this.cbb_subDealers);
            this.gb_addSubDealers.Controls.Add(this.btn_cancelEdit);
            this.gb_addSubDealers.Controls.Add(this.btn_clear);
            this.gb_addSubDealers.Controls.Add(this.btn_save);
            this.gb_addSubDealers.Controls.Add(this.tb_dealerCountry);
            this.gb_addSubDealers.Controls.Add(this.tb_dealerPostalCode);
            this.gb_addSubDealers.Controls.Add(this.tb_dealerCity);
            this.gb_addSubDealers.Controls.Add(this.tb_dealerAdress);
            this.gb_addSubDealers.Controls.Add(this.tb_dealerMail);
            this.gb_addSubDealers.Controls.Add(this.tb_dealerName);
            this.gb_addSubDealers.Controls.Add(this.tb_subDealerUserID);
            this.gb_addSubDealers.Controls.Add(this.cb_subDealerUser);
            this.gb_addSubDealers.Controls.Add(this.lbl_dealerCountry);
            this.gb_addSubDealers.Controls.Add(this.lbl_dealerPostalCode);
            this.gb_addSubDealers.Controls.Add(this.lbl_dealerCity);
            this.gb_addSubDealers.Controls.Add(this.lbl_dealerAdress);
            this.gb_addSubDealers.Controls.Add(this.lbl_discountAmountType);
            this.gb_addSubDealers.Controls.Add(this.lbl_dealerMail);
            this.gb_addSubDealers.Controls.Add(this.lbl_dealerName);
            this.gb_addSubDealers.Controls.Add(this.lbl_dealerUserID);
            this.gb_addSubDealers.Controls.Add(this.lbl_brandDelete);
            this.gb_addSubDealers.Controls.Add(this.btn_editSubDealers);
            this.gb_addSubDealers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_addSubDealers.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_addSubDealers.Location = new System.Drawing.Point(12, 47);
            this.gb_addSubDealers.Name = "gb_addSubDealers";
            this.gb_addSubDealers.Size = new System.Drawing.Size(1546, 273);
            this.gb_addSubDealers.TabIndex = 7;
            this.gb_addSubDealers.TabStop = false;
            this.gb_addSubDealers.Text = "Sub Dealers Information";
            // 
            // cbb_subDealers
            // 
            this.cbb_subDealers.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbb_subDealers.FormattingEnabled = true;
            this.cbb_subDealers.Location = new System.Drawing.Point(486, 89);
            this.cbb_subDealers.Name = "cbb_subDealers";
            this.cbb_subDealers.Size = new System.Drawing.Size(161, 32);
            this.cbb_subDealers.TabIndex = 10;
            this.cbb_subDealers.SelectedIndexChanged += new System.EventHandler(this.cbb_subDealers_SelectedIndexChanged);
            // 
            // btn_cancelEdit
            // 
            this.btn_cancelEdit.Location = new System.Drawing.Point(320, 225);
            this.btn_cancelEdit.Name = "btn_cancelEdit";
            this.btn_cancelEdit.Size = new System.Drawing.Size(142, 42);
            this.btn_cancelEdit.TabIndex = 8;
            this.btn_cancelEdit.Text = "Cancel Edit";
            this.btn_cancelEdit.UseVisualStyleBackColor = true;
            this.btn_cancelEdit.Click += new System.EventHandler(this.btn_cancelEdit_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(463, 225);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(142, 42);
            this.btn_clear.TabIndex = 8;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(34, 225);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(142, 42);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Add";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_dealerCountry
            // 
            this.tb_dealerCountry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_dealerCountry.Location = new System.Drawing.Point(1236, 89);
            this.tb_dealerCountry.Name = "tb_dealerCountry";
            this.tb_dealerCountry.Size = new System.Drawing.Size(161, 32);
            this.tb_dealerCountry.TabIndex = 3;
            // 
            // tb_dealerPostalCode
            // 
            this.tb_dealerPostalCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_dealerPostalCode.Location = new System.Drawing.Point(1069, 89);
            this.tb_dealerPostalCode.Name = "tb_dealerPostalCode";
            this.tb_dealerPostalCode.Size = new System.Drawing.Size(161, 32);
            this.tb_dealerPostalCode.TabIndex = 3;
            // 
            // tb_dealerCity
            // 
            this.tb_dealerCity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_dealerCity.Location = new System.Drawing.Point(902, 89);
            this.tb_dealerCity.Name = "tb_dealerCity";
            this.tb_dealerCity.Size = new System.Drawing.Size(161, 32);
            this.tb_dealerCity.TabIndex = 3;
            // 
            // tb_dealerAdress
            // 
            this.tb_dealerAdress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_dealerAdress.Location = new System.Drawing.Point(653, 89);
            this.tb_dealerAdress.Multiline = true;
            this.tb_dealerAdress.Name = "tb_dealerAdress";
            this.tb_dealerAdress.Size = new System.Drawing.Size(243, 32);
            this.tb_dealerAdress.TabIndex = 3;
            // 
            // tb_dealerMail
            // 
            this.tb_dealerMail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_dealerMail.Location = new System.Drawing.Point(319, 89);
            this.tb_dealerMail.Name = "tb_dealerMail";
            this.tb_dealerMail.Size = new System.Drawing.Size(161, 32);
            this.tb_dealerMail.TabIndex = 3;
            // 
            // tb_dealerName
            // 
            this.tb_dealerName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_dealerName.Location = new System.Drawing.Point(152, 89);
            this.tb_dealerName.MinimumSize = new System.Drawing.Size(161, 36);
            this.tb_dealerName.Name = "tb_dealerName";
            this.tb_dealerName.Size = new System.Drawing.Size(161, 32);
            this.tb_dealerName.TabIndex = 3;
            // 
            // tb_subDealerUserID
            // 
            this.tb_subDealerUserID.Enabled = false;
            this.tb_subDealerUserID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_subDealerUserID.Location = new System.Drawing.Point(34, 89);
            this.tb_subDealerUserID.Name = "tb_subDealerUserID";
            this.tb_subDealerUserID.Size = new System.Drawing.Size(112, 32);
            this.tb_subDealerUserID.TabIndex = 3;
            // 
            // cb_subDealerUser
            // 
            this.cb_subDealerUser.AutoSize = true;
            this.cb_subDealerUser.Location = new System.Drawing.Point(128, 175);
            this.cb_subDealerUser.Name = "cb_subDealerUser";
            this.cb_subDealerUser.Size = new System.Drawing.Size(18, 17);
            this.cb_subDealerUser.TabIndex = 5;
            this.cb_subDealerUser.UseVisualStyleBackColor = true;
            // 
            // lbl_dealerCountry
            // 
            this.lbl_dealerCountry.AutoSize = true;
            this.lbl_dealerCountry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerCountry.Location = new System.Drawing.Point(1232, 45);
            this.lbl_dealerCountry.Name = "lbl_dealerCountry";
            this.lbl_dealerCountry.Size = new System.Drawing.Size(136, 24);
            this.lbl_dealerCountry.TabIndex = 2;
            this.lbl_dealerCountry.Text = "Dealer Country";
            // 
            // lbl_dealerPostalCode
            // 
            this.lbl_dealerPostalCode.AutoSize = true;
            this.lbl_dealerPostalCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerPostalCode.Location = new System.Drawing.Point(1065, 45);
            this.lbl_dealerPostalCode.Name = "lbl_dealerPostalCode";
            this.lbl_dealerPostalCode.Size = new System.Drawing.Size(124, 24);
            this.lbl_dealerPostalCode.TabIndex = 2;
            this.lbl_dealerPostalCode.Text = "Dealer P.Code";
            // 
            // lbl_dealerCity
            // 
            this.lbl_dealerCity.AutoSize = true;
            this.lbl_dealerCity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerCity.Location = new System.Drawing.Point(898, 45);
            this.lbl_dealerCity.Name = "lbl_dealerCity";
            this.lbl_dealerCity.Size = new System.Drawing.Size(101, 24);
            this.lbl_dealerCity.TabIndex = 2;
            this.lbl_dealerCity.Text = "Dealer City";
            // 
            // lbl_dealerAdress
            // 
            this.lbl_dealerAdress.AutoSize = true;
            this.lbl_dealerAdress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerAdress.Location = new System.Drawing.Point(649, 45);
            this.lbl_dealerAdress.Name = "lbl_dealerAdress";
            this.lbl_dealerAdress.Size = new System.Drawing.Size(136, 24);
            this.lbl_dealerAdress.TabIndex = 2;
            this.lbl_dealerAdress.Text = "Dealer Address";
            // 
            // lbl_discountAmountType
            // 
            this.lbl_discountAmountType.AutoSize = true;
            this.lbl_discountAmountType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_discountAmountType.Location = new System.Drawing.Point(482, 45);
            this.lbl_discountAmountType.Name = "lbl_discountAmountType";
            this.lbl_discountAmountType.Size = new System.Drawing.Size(127, 24);
            this.lbl_discountAmountType.TabIndex = 2;
            this.lbl_discountAmountType.Text = "Discount Type";
            // 
            // lbl_dealerMail
            // 
            this.lbl_dealerMail.AutoSize = true;
            this.lbl_dealerMail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerMail.Location = new System.Drawing.Point(315, 45);
            this.lbl_dealerMail.Name = "lbl_dealerMail";
            this.lbl_dealerMail.Size = new System.Drawing.Size(106, 24);
            this.lbl_dealerMail.TabIndex = 2;
            this.lbl_dealerMail.Text = "Dealer Mail";
            // 
            // lbl_dealerName
            // 
            this.lbl_dealerName.AutoSize = true;
            this.lbl_dealerName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerName.Location = new System.Drawing.Point(148, 45);
            this.lbl_dealerName.Name = "lbl_dealerName";
            this.lbl_dealerName.Size = new System.Drawing.Size(118, 24);
            this.lbl_dealerName.TabIndex = 2;
            this.lbl_dealerName.Text = "Dealer Name";
            // 
            // lbl_dealerUserID
            // 
            this.lbl_dealerUserID.AutoSize = true;
            this.lbl_dealerUserID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerUserID.Location = new System.Drawing.Point(30, 45);
            this.lbl_dealerUserID.Name = "lbl_dealerUserID";
            this.lbl_dealerUserID.Size = new System.Drawing.Size(70, 24);
            this.lbl_dealerUserID.TabIndex = 2;
            this.lbl_dealerUserID.Text = "User ID";
            // 
            // lbl_brandDelete
            // 
            this.lbl_brandDelete.AutoSize = true;
            this.lbl_brandDelete.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_brandDelete.ForeColor = System.Drawing.Color.Red;
            this.lbl_brandDelete.Location = new System.Drawing.Point(33, 168);
            this.lbl_brandDelete.Name = "lbl_brandDelete";
            this.lbl_brandDelete.Size = new System.Drawing.Size(72, 28);
            this.lbl_brandDelete.TabIndex = 4;
            this.lbl_brandDelete.Text = "Delete";
            // 
            // btn_editSubDealers
            // 
            this.btn_editSubDealers.Location = new System.Drawing.Point(177, 225);
            this.btn_editSubDealers.Name = "btn_editSubDealers";
            this.btn_editSubDealers.Size = new System.Drawing.Size(142, 42);
            this.btn_editSubDealers.TabIndex = 9;
            this.btn_editSubDealers.Text = "Edit";
            this.btn_editSubDealers.UseVisualStyleBackColor = true;
            this.btn_editSubDealers.Click += new System.EventHandler(this.btn_editSubDealers_Click);
            // 
            // dgv_editSubDealers
            // 
            this.dgv_editSubDealers.AllowUserToAddRows = false;
            this.dgv_editSubDealers.AllowUserToDeleteRows = false;
            this.dgv_editSubDealers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_editSubDealers.Location = new System.Drawing.Point(12, 326);
            this.dgv_editSubDealers.Name = "dgv_editSubDealers";
            this.dgv_editSubDealers.ReadOnly = true;
            this.dgv_editSubDealers.RowHeadersWidth = 51;
            this.dgv_editSubDealers.RowTemplate.Height = 24;
            this.dgv_editSubDealers.Size = new System.Drawing.Size(1546, 557);
            this.dgv_editSubDealers.TabIndex = 8;
            this.dgv_editSubDealers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_editSubDealers_DataBindingComplete);
            this.dgv_editSubDealers.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_editSubDealers_RowHeaderMouseClick);
            // 
            // SubDealerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_subDealerSettings);
            this.Controls.Add(this.gb_addSubDealers);
            this.Controls.Add(this.dgv_editSubDealers);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "SubDealerSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sub Dealer Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SubDealerSettings_Load);
            this.gb_addSubDealers.ResumeLayout(false);
            this.gb_addSubDealers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_editSubDealers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_subDealerSettings;
        private System.Windows.Forms.GroupBox gb_addSubDealers;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tb_subDealerUserID;
        private System.Windows.Forms.CheckBox cb_subDealerUser;
        private System.Windows.Forms.Label lbl_dealerUserID;
        private System.Windows.Forms.Label lbl_brandDelete;
        private System.Windows.Forms.DataGridView dgv_editSubDealers;
        private System.Windows.Forms.Button btn_editSubDealers;
        private System.Windows.Forms.TextBox tb_dealerCountry;
        private System.Windows.Forms.TextBox tb_dealerPostalCode;
        private System.Windows.Forms.TextBox tb_dealerCity;
        private System.Windows.Forms.TextBox tb_dealerAdress;
        private System.Windows.Forms.TextBox tb_dealerMail;
        private System.Windows.Forms.TextBox tb_dealerName;
        private System.Windows.Forms.Label lbl_dealerCountry;
        private System.Windows.Forms.Label lbl_dealerPostalCode;
        private System.Windows.Forms.Label lbl_dealerCity;
        private System.Windows.Forms.Label lbl_dealerAdress;
        private System.Windows.Forms.Label lbl_discountAmountType;
        private System.Windows.Forms.Label lbl_dealerMail;
        private System.Windows.Forms.Label lbl_dealerName;
        private System.Windows.Forms.Button btn_cancelEdit;
        private System.Windows.Forms.ComboBox cbb_subDealers;
    }
}