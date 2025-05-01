namespace FormForDataModel
{
    partial class UserSettings
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
            this.dgv_userInformation = new System.Windows.Forms.DataGridView();
            this.cbb_userType = new System.Windows.Forms.ComboBox();
            this.btn_cancelEdit = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_userName = new System.Windows.Forms.TextBox();
            this.tb_userPassword = new System.Windows.Forms.TextBox();
            this.tb_userID = new System.Windows.Forms.TextBox();
            this.cb_userIsDelete = new System.Windows.Forms.CheckBox();
            this.lbl_userType = new System.Windows.Forms.Label();
            this.lbl_userPassword = new System.Windows.Forms.Label();
            this.lbl_userName = new System.Windows.Forms.Label();
            this.lbl_userID = new System.Windows.Forms.Label();
            this.lbl_userIsDelete = new System.Windows.Forms.Label();
            this.btn_editUser = new System.Windows.Forms.Button();
            this.lbl_userSettings = new System.Windows.Forms.Label();
            this.gb_userInformation = new System.Windows.Forms.GroupBox();
            this.cb_seeDataInformation = new System.Windows.Forms.CheckBox();
            this.lbl_seeDataInformation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userInformation)).BeginInit();
            this.gb_userInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_userInformation
            // 
            this.dgv_userInformation.AllowUserToAddRows = false;
            this.dgv_userInformation.AllowUserToDeleteRows = false;
            this.dgv_userInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userInformation.Location = new System.Drawing.Point(12, 327);
            this.dgv_userInformation.Name = "dgv_userInformation";
            this.dgv_userInformation.ReadOnly = true;
            this.dgv_userInformation.RowHeadersWidth = 51;
            this.dgv_userInformation.RowTemplate.Height = 24;
            this.dgv_userInformation.Size = new System.Drawing.Size(1546, 557);
            this.dgv_userInformation.TabIndex = 18;
            this.dgv_userInformation.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_userInformation_CellFormatting);
            this.dgv_userInformation.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_userInformation_DataBindingComplete);
            this.dgv_userInformation.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_userInformation_RowHeaderMouseClick);
            // 
            // cbb_userType
            // 
            this.cbb_userType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbb_userType.FormattingEnabled = true;
            this.cbb_userType.Location = new System.Drawing.Point(486, 89);
            this.cbb_userType.Name = "cbb_userType";
            this.cbb_userType.Size = new System.Drawing.Size(161, 32);
            this.cbb_userType.TabIndex = 9;
            this.cbb_userType.SelectedIndexChanged += new System.EventHandler(this.cbb_userType_SelectedIndexChanged);
            // 
            // btn_cancelEdit
            // 
            this.btn_cancelEdit.Location = new System.Drawing.Point(320, 225);
            this.btn_cancelEdit.Name = "btn_cancelEdit";
            this.btn_cancelEdit.Size = new System.Drawing.Size(142, 42);
            this.btn_cancelEdit.TabIndex = 16;
            this.btn_cancelEdit.Text = "Cancel Edit";
            this.btn_cancelEdit.UseVisualStyleBackColor = true;
            this.btn_cancelEdit.Click += new System.EventHandler(this.btn_cancelEdit_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(463, 225);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(142, 42);
            this.btn_clear.TabIndex = 17;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(34, 225);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(142, 42);
            this.btn_save.TabIndex = 14;
            this.btn_save.Text = "Add";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_userName
            // 
            this.tb_userName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_userName.Location = new System.Drawing.Point(152, 89);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(161, 32);
            this.tb_userName.TabIndex = 5;
            // 
            // tb_userPassword
            // 
            this.tb_userPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_userPassword.Location = new System.Drawing.Point(319, 89);
            this.tb_userPassword.Name = "tb_userPassword";
            this.tb_userPassword.Size = new System.Drawing.Size(161, 32);
            this.tb_userPassword.TabIndex = 7;
            // 
            // tb_userID
            // 
            this.tb_userID.Enabled = false;
            this.tb_userID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_userID.Location = new System.Drawing.Point(34, 89);
            this.tb_userID.Name = "tb_userID";
            this.tb_userID.Size = new System.Drawing.Size(112, 32);
            this.tb_userID.TabIndex = 3;
            // 
            // cb_userIsDelete
            // 
            this.cb_userIsDelete.AutoSize = true;
            this.cb_userIsDelete.Enabled = false;
            this.cb_userIsDelete.Location = new System.Drawing.Point(295, 175);
            this.cb_userIsDelete.Name = "cb_userIsDelete";
            this.cb_userIsDelete.Size = new System.Drawing.Size(18, 17);
            this.cb_userIsDelete.TabIndex = 13;
            this.cb_userIsDelete.UseVisualStyleBackColor = true;
            // 
            // lbl_userType
            // 
            this.lbl_userType.AutoSize = true;
            this.lbl_userType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_userType.Location = new System.Drawing.Point(482, 45);
            this.lbl_userType.Name = "lbl_userType";
            this.lbl_userType.Size = new System.Drawing.Size(92, 24);
            this.lbl_userType.TabIndex = 8;
            this.lbl_userType.Text = "User Type";
            // 
            // lbl_userPassword
            // 
            this.lbl_userPassword.AutoSize = true;
            this.lbl_userPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_userPassword.Location = new System.Drawing.Point(315, 45);
            this.lbl_userPassword.Name = "lbl_userPassword";
            this.lbl_userPassword.Size = new System.Drawing.Size(132, 24);
            this.lbl_userPassword.TabIndex = 6;
            this.lbl_userPassword.Text = "User Password";
            // 
            // lbl_userName
            // 
            this.lbl_userName.AutoSize = true;
            this.lbl_userName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_userName.Location = new System.Drawing.Point(148, 45);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(102, 24);
            this.lbl_userName.TabIndex = 4;
            this.lbl_userName.Text = "User Name";
            // 
            // lbl_userID
            // 
            this.lbl_userID.AutoSize = true;
            this.lbl_userID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_userID.Location = new System.Drawing.Point(30, 45);
            this.lbl_userID.Name = "lbl_userID";
            this.lbl_userID.Size = new System.Drawing.Size(70, 24);
            this.lbl_userID.TabIndex = 2;
            this.lbl_userID.Text = "User ID";
            // 
            // lbl_userIsDelete
            // 
            this.lbl_userIsDelete.AutoSize = true;
            this.lbl_userIsDelete.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_userIsDelete.ForeColor = System.Drawing.Color.Red;
            this.lbl_userIsDelete.Location = new System.Drawing.Point(33, 168);
            this.lbl_userIsDelete.Name = "lbl_userIsDelete";
            this.lbl_userIsDelete.Size = new System.Drawing.Size(205, 28);
            this.lbl_userIsDelete.TabIndex = 12;
            this.lbl_userIsDelete.Text = "Delete Selected Data";
            // 
            // btn_editUser
            // 
            this.btn_editUser.Location = new System.Drawing.Point(177, 225);
            this.btn_editUser.Name = "btn_editUser";
            this.btn_editUser.Size = new System.Drawing.Size(142, 42);
            this.btn_editUser.TabIndex = 15;
            this.btn_editUser.Text = "Edit";
            this.btn_editUser.UseVisualStyleBackColor = true;
            this.btn_editUser.Click += new System.EventHandler(this.btn_editUser_Click);
            // 
            // lbl_userSettings
            // 
            this.lbl_userSettings.AutoSize = true;
            this.lbl_userSettings.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_userSettings.Location = new System.Drawing.Point(12, 10);
            this.lbl_userSettings.Name = "lbl_userSettings";
            this.lbl_userSettings.Size = new System.Drawing.Size(165, 35);
            this.lbl_userSettings.TabIndex = 0;
            this.lbl_userSettings.Text = "User Settings";
            // 
            // gb_userInformation
            // 
            this.gb_userInformation.Controls.Add(this.cbb_userType);
            this.gb_userInformation.Controls.Add(this.btn_cancelEdit);
            this.gb_userInformation.Controls.Add(this.btn_clear);
            this.gb_userInformation.Controls.Add(this.btn_save);
            this.gb_userInformation.Controls.Add(this.tb_userName);
            this.gb_userInformation.Controls.Add(this.tb_userPassword);
            this.gb_userInformation.Controls.Add(this.tb_userID);
            this.gb_userInformation.Controls.Add(this.cb_seeDataInformation);
            this.gb_userInformation.Controls.Add(this.cb_userIsDelete);
            this.gb_userInformation.Controls.Add(this.lbl_userType);
            this.gb_userInformation.Controls.Add(this.lbl_userPassword);
            this.gb_userInformation.Controls.Add(this.lbl_userName);
            this.gb_userInformation.Controls.Add(this.lbl_userID);
            this.gb_userInformation.Controls.Add(this.lbl_seeDataInformation);
            this.gb_userInformation.Controls.Add(this.lbl_userIsDelete);
            this.gb_userInformation.Controls.Add(this.btn_editUser);
            this.gb_userInformation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_userInformation.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_userInformation.Location = new System.Drawing.Point(12, 48);
            this.gb_userInformation.Name = "gb_userInformation";
            this.gb_userInformation.Size = new System.Drawing.Size(1546, 273);
            this.gb_userInformation.TabIndex = 1;
            this.gb_userInformation.TabStop = false;
            this.gb_userInformation.Text = "User Information";
            // 
            // cb_seeDataInformation
            // 
            this.cb_seeDataInformation.AutoSize = true;
            this.cb_seeDataInformation.Location = new System.Drawing.Point(295, 147);
            this.cb_seeDataInformation.Name = "cb_seeDataInformation";
            this.cb_seeDataInformation.Size = new System.Drawing.Size(18, 17);
            this.cb_seeDataInformation.TabIndex = 11;
            this.cb_seeDataInformation.UseVisualStyleBackColor = true;
            this.cb_seeDataInformation.CheckedChanged += new System.EventHandler(this.cb_seeDataInformation_CheckedChanged);
            // 
            // lbl_seeDataInformation
            // 
            this.lbl_seeDataInformation.AutoSize = true;
            this.lbl_seeDataInformation.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_seeDataInformation.ForeColor = System.Drawing.Color.Blue;
            this.lbl_seeDataInformation.Location = new System.Drawing.Point(33, 140);
            this.lbl_seeDataInformation.Name = "lbl_seeDataInformation";
            this.lbl_seeDataInformation.Size = new System.Drawing.Size(210, 28);
            this.lbl_seeDataInformation.TabIndex = 10;
            this.lbl_seeDataInformation.Text = "See Data Information";
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.dgv_userInformation);
            this.Controls.Add(this.lbl_userSettings);
            this.Controls.Add(this.gb_userInformation);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "UserSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "User Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userInformation)).EndInit();
            this.gb_userInformation.ResumeLayout(false);
            this.gb_userInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_userInformation;
        private System.Windows.Forms.ComboBox cbb_userType;
        private System.Windows.Forms.Button btn_cancelEdit;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tb_userName;
        private System.Windows.Forms.TextBox tb_userPassword;
        private System.Windows.Forms.TextBox tb_userID;
        private System.Windows.Forms.CheckBox cb_userIsDelete;
        private System.Windows.Forms.Label lbl_userType;
        private System.Windows.Forms.Label lbl_userPassword;
        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.Label lbl_userID;
        private System.Windows.Forms.Label lbl_userIsDelete;
        private System.Windows.Forms.Button btn_editUser;
        private System.Windows.Forms.Label lbl_userSettings;
        private System.Windows.Forms.GroupBox gb_userInformation;
        private System.Windows.Forms.CheckBox cb_seeDataInformation;
        private System.Windows.Forms.Label lbl_seeDataInformation;
    }
}