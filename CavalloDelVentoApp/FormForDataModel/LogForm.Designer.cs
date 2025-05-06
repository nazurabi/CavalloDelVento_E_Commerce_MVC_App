namespace FormForDataModel
{
    partial class LogForm
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
            this.gb_log = new System.Windows.Forms.GroupBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_userName = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_userName = new System.Windows.Forms.TextBox();
            this.gb_log.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_log
            // 
            this.gb_log.Controls.Add(this.btn_login);
            this.gb_log.Controls.Add(this.btn_close);
            this.gb_log.Controls.Add(this.lbl_password);
            this.gb_log.Controls.Add(this.lbl_userName);
            this.gb_log.Controls.Add(this.tb_password);
            this.gb_log.Controls.Add(this.tb_userName);
            this.gb_log.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.gb_log.Location = new System.Drawing.Point(12, 11);
            this.gb_log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_log.Name = "gb_log";
            this.gb_log.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_log.Size = new System.Drawing.Size(522, 239);
            this.gb_log.TabIndex = 0;
            this.gb_log.TabStop = false;
            this.gb_log.Text = "User Information";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(195, 158);
            this.btn_login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(120, 36);
            this.btn_login.TabIndex = 5;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(317, 158);
            this.btn_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(120, 36);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(43, 111);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(112, 28);
            this.lbl_password.TabIndex = 3;
            this.lbl_password.Text = "Password :";
            // 
            // lbl_userName
            // 
            this.lbl_userName.AutoSize = true;
            this.lbl_userName.Location = new System.Drawing.Point(29, 64);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(126, 28);
            this.lbl_userName.TabIndex = 1;
            this.lbl_userName.Text = "User Name :";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(195, 111);
            this.tb_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(242, 36);
            this.tb_password.TabIndex = 4;
            // 
            // tb_userName
            // 
            this.tb_userName.Location = new System.Drawing.Point(195, 64);
            this.tb_userName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(242, 36);
            this.tb_userName.TabIndex = 2;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 270);
            this.ControlBox = false;
            this.Controls.Add(this.gb_log);
            this.MaximumSize = new System.Drawing.Size(564, 317);
            this.MinimumSize = new System.Drawing.Size(564, 317);
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogForm_FormClosing);
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.gb_log.ResumeLayout(false);
            this.gb_log.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_log;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_userName;
    }
}