namespace FormForDataModel
{
    partial class MainDealerSettings
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
            this.lbl_mainDealerSettings = new System.Windows.Forms.Label();
            this.dgv_editMainDealer = new System.Windows.Forms.DataGridView();
            this.btn_cancelEdit = new System.Windows.Forms.Button();
            this.btn_selectImage = new System.Windows.Forms.Button();
            this.tb_mainDealerCountry = new System.Windows.Forms.TextBox();
            this.tb_mainDealerPostalCode = new System.Windows.Forms.TextBox();
            this.tb_mainDealerCity = new System.Windows.Forms.TextBox();
            this.tb_mainDealerAdress = new System.Windows.Forms.TextBox();
            this.tb_mainDealerMail = new System.Windows.Forms.TextBox();
            this.lbl_dealerCountry = new System.Windows.Forms.Label();
            this.lbl_dealerPostalCode = new System.Windows.Forms.Label();
            this.lbl_dealerCity = new System.Windows.Forms.Label();
            this.lbl_dealerAdress = new System.Windows.Forms.Label();
            this.lbl_dealerMail = new System.Windows.Forms.Label();
            this.lbl_dealerName = new System.Windows.Forms.Label();
            this.btn_editMainDealer = new System.Windows.Forms.Button();
            this.gb_mainDealer = new System.Windows.Forms.GroupBox();
            this.tb_mainDealerName = new System.Windows.Forms.TextBox();
            this.nud_taxAmount = new System.Windows.Forms.NumericUpDown();
            this.pb_mainDealer = new System.Windows.Forms.PictureBox();
            this.lbl_taxAmount = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_editMainDealer)).BeginInit();
            this.gb_mainDealer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_taxAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mainDealer)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_mainDealerSettings
            // 
            this.lbl_mainDealerSettings.AutoSize = true;
            this.lbl_mainDealerSettings.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_mainDealerSettings.Location = new System.Drawing.Point(12, 9);
            this.lbl_mainDealerSettings.Name = "lbl_mainDealerSettings";
            this.lbl_mainDealerSettings.Size = new System.Drawing.Size(255, 35);
            this.lbl_mainDealerSettings.TabIndex = 0;
            this.lbl_mainDealerSettings.Text = "Main Dealer Settings";
            // 
            // dgv_editMainDealer
            // 
            this.dgv_editMainDealer.AllowUserToAddRows = false;
            this.dgv_editMainDealer.AllowUserToDeleteRows = false;
            this.dgv_editMainDealer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_editMainDealer.Location = new System.Drawing.Point(12, 326);
            this.dgv_editMainDealer.Name = "dgv_editMainDealer";
            this.dgv_editMainDealer.ReadOnly = true;
            this.dgv_editMainDealer.RowHeadersWidth = 51;
            this.dgv_editMainDealer.RowTemplate.Height = 24;
            this.dgv_editMainDealer.Size = new System.Drawing.Size(1500, 557);
            this.dgv_editMainDealer.TabIndex = 20;
            this.dgv_editMainDealer.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_editMainDealer_RowHeaderMouseClick);
            // 
            // btn_cancelEdit
            // 
            this.btn_cancelEdit.Location = new System.Drawing.Point(354, 225);
            this.btn_cancelEdit.Name = "btn_cancelEdit";
            this.btn_cancelEdit.Size = new System.Drawing.Size(154, 42);
            this.btn_cancelEdit.TabIndex = 19;
            this.btn_cancelEdit.Text = "Cancel Edit";
            this.btn_cancelEdit.UseVisualStyleBackColor = true;
            this.btn_cancelEdit.Click += new System.EventHandler(this.btn_cancelEdit_Click);
            // 
            // btn_selectImage
            // 
            this.btn_selectImage.Location = new System.Drawing.Point(194, 225);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(154, 42);
            this.btn_selectImage.TabIndex = 18;
            this.btn_selectImage.Text = "Select Image";
            this.btn_selectImage.UseVisualStyleBackColor = true;
            this.btn_selectImage.Click += new System.EventHandler(this.btn_selectImage_Click);
            // 
            // tb_mainDealerCountry
            // 
            this.tb_mainDealerCountry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_mainDealerCountry.Location = new System.Drawing.Point(951, 89);
            this.tb_mainDealerCountry.Name = "tb_mainDealerCountry";
            this.tb_mainDealerCountry.Size = new System.Drawing.Size(161, 32);
            this.tb_mainDealerCountry.TabIndex = 13;
            // 
            // tb_mainDealerPostalCode
            // 
            this.tb_mainDealerPostalCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_mainDealerPostalCode.Location = new System.Drawing.Point(784, 89);
            this.tb_mainDealerPostalCode.Name = "tb_mainDealerPostalCode";
            this.tb_mainDealerPostalCode.Size = new System.Drawing.Size(161, 32);
            this.tb_mainDealerPostalCode.TabIndex = 11;
            // 
            // tb_mainDealerCity
            // 
            this.tb_mainDealerCity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_mainDealerCity.Location = new System.Drawing.Point(617, 89);
            this.tb_mainDealerCity.Name = "tb_mainDealerCity";
            this.tb_mainDealerCity.Size = new System.Drawing.Size(161, 32);
            this.tb_mainDealerCity.TabIndex = 9;
            // 
            // tb_mainDealerAdress
            // 
            this.tb_mainDealerAdress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_mainDealerAdress.Location = new System.Drawing.Point(368, 89);
            this.tb_mainDealerAdress.Multiline = true;
            this.tb_mainDealerAdress.Name = "tb_mainDealerAdress";
            this.tb_mainDealerAdress.Size = new System.Drawing.Size(243, 32);
            this.tb_mainDealerAdress.TabIndex = 7;
            // 
            // tb_mainDealerMail
            // 
            this.tb_mainDealerMail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_mainDealerMail.Location = new System.Drawing.Point(201, 89);
            this.tb_mainDealerMail.Name = "tb_mainDealerMail";
            this.tb_mainDealerMail.Size = new System.Drawing.Size(161, 32);
            this.tb_mainDealerMail.TabIndex = 5;
            // 
            // lbl_dealerCountry
            // 
            this.lbl_dealerCountry.AutoSize = true;
            this.lbl_dealerCountry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerCountry.Location = new System.Drawing.Point(947, 45);
            this.lbl_dealerCountry.Name = "lbl_dealerCountry";
            this.lbl_dealerCountry.Size = new System.Drawing.Size(136, 24);
            this.lbl_dealerCountry.TabIndex = 12;
            this.lbl_dealerCountry.Text = "Dealer Country";
            // 
            // lbl_dealerPostalCode
            // 
            this.lbl_dealerPostalCode.AutoSize = true;
            this.lbl_dealerPostalCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerPostalCode.Location = new System.Drawing.Point(780, 45);
            this.lbl_dealerPostalCode.Name = "lbl_dealerPostalCode";
            this.lbl_dealerPostalCode.Size = new System.Drawing.Size(124, 24);
            this.lbl_dealerPostalCode.TabIndex = 10;
            this.lbl_dealerPostalCode.Text = "Dealer P.Code";
            // 
            // lbl_dealerCity
            // 
            this.lbl_dealerCity.AutoSize = true;
            this.lbl_dealerCity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerCity.Location = new System.Drawing.Point(613, 45);
            this.lbl_dealerCity.Name = "lbl_dealerCity";
            this.lbl_dealerCity.Size = new System.Drawing.Size(101, 24);
            this.lbl_dealerCity.TabIndex = 8;
            this.lbl_dealerCity.Text = "Dealer City";
            // 
            // lbl_dealerAdress
            // 
            this.lbl_dealerAdress.AutoSize = true;
            this.lbl_dealerAdress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerAdress.Location = new System.Drawing.Point(364, 45);
            this.lbl_dealerAdress.Name = "lbl_dealerAdress";
            this.lbl_dealerAdress.Size = new System.Drawing.Size(136, 24);
            this.lbl_dealerAdress.TabIndex = 6;
            this.lbl_dealerAdress.Text = "Dealer Address";
            // 
            // lbl_dealerMail
            // 
            this.lbl_dealerMail.AutoSize = true;
            this.lbl_dealerMail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerMail.Location = new System.Drawing.Point(197, 45);
            this.lbl_dealerMail.Name = "lbl_dealerMail";
            this.lbl_dealerMail.Size = new System.Drawing.Size(106, 24);
            this.lbl_dealerMail.TabIndex = 4;
            this.lbl_dealerMail.Text = "Dealer Mail";
            // 
            // lbl_dealerName
            // 
            this.lbl_dealerName.AutoSize = true;
            this.lbl_dealerName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dealerName.Location = new System.Drawing.Point(30, 45);
            this.lbl_dealerName.Name = "lbl_dealerName";
            this.lbl_dealerName.Size = new System.Drawing.Size(118, 24);
            this.lbl_dealerName.TabIndex = 2;
            this.lbl_dealerName.Text = "Dealer Name";
            // 
            // btn_editMainDealer
            // 
            this.btn_editMainDealer.Location = new System.Drawing.Point(34, 225);
            this.btn_editMainDealer.Name = "btn_editMainDealer";
            this.btn_editMainDealer.Size = new System.Drawing.Size(154, 42);
            this.btn_editMainDealer.TabIndex = 17;
            this.btn_editMainDealer.Text = "Edit";
            this.btn_editMainDealer.UseVisualStyleBackColor = true;
            this.btn_editMainDealer.Click += new System.EventHandler(this.btn_editMainDealer_Click);
            // 
            // gb_mainDealer
            // 
            this.gb_mainDealer.Controls.Add(this.tb_mainDealerName);
            this.gb_mainDealer.Controls.Add(this.lbl_dealerName);
            this.gb_mainDealer.Controls.Add(this.nud_taxAmount);
            this.gb_mainDealer.Controls.Add(this.pb_mainDealer);
            this.gb_mainDealer.Controls.Add(this.btn_cancelEdit);
            this.gb_mainDealer.Controls.Add(this.btn_selectImage);
            this.gb_mainDealer.Controls.Add(this.tb_mainDealerCountry);
            this.gb_mainDealer.Controls.Add(this.tb_mainDealerPostalCode);
            this.gb_mainDealer.Controls.Add(this.tb_mainDealerCity);
            this.gb_mainDealer.Controls.Add(this.tb_mainDealerAdress);
            this.gb_mainDealer.Controls.Add(this.tb_mainDealerMail);
            this.gb_mainDealer.Controls.Add(this.lbl_taxAmount);
            this.gb_mainDealer.Controls.Add(this.lbl_dealerCountry);
            this.gb_mainDealer.Controls.Add(this.lbl_dealerPostalCode);
            this.gb_mainDealer.Controls.Add(this.lbl_dealerCity);
            this.gb_mainDealer.Controls.Add(this.lbl_dealerAdress);
            this.gb_mainDealer.Controls.Add(this.lbl_dealerMail);
            this.gb_mainDealer.Controls.Add(this.btn_editMainDealer);
            this.gb_mainDealer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_mainDealer.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_mainDealer.Location = new System.Drawing.Point(12, 47);
            this.gb_mainDealer.Name = "gb_mainDealer";
            this.gb_mainDealer.Size = new System.Drawing.Size(1500, 273);
            this.gb_mainDealer.TabIndex = 1;
            this.gb_mainDealer.TabStop = false;
            this.gb_mainDealer.Text = "Main Dealers Information";
            // 
            // tb_mainDealerName
            // 
            this.tb_mainDealerName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_mainDealerName.Location = new System.Drawing.Point(34, 89);
            this.tb_mainDealerName.Name = "tb_mainDealerName";
            this.tb_mainDealerName.Size = new System.Drawing.Size(161, 32);
            this.tb_mainDealerName.TabIndex = 3;
            // 
            // nud_taxAmount
            // 
            this.nud_taxAmount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nud_taxAmount.Location = new System.Drawing.Point(1119, 89);
            this.nud_taxAmount.Name = "nud_taxAmount";
            this.nud_taxAmount.Size = new System.Drawing.Size(161, 32);
            this.nud_taxAmount.TabIndex = 15;
            this.nud_taxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nud_taxAmount_KeyPress);
            // 
            // pb_mainDealer
            // 
            this.pb_mainDealer.Location = new System.Drawing.Point(1286, 45);
            this.pb_mainDealer.Name = "pb_mainDealer";
            this.pb_mainDealer.Size = new System.Drawing.Size(200, 200);
            this.pb_mainDealer.TabIndex = 10;
            this.pb_mainDealer.TabStop = false;
            // 
            // lbl_taxAmount
            // 
            this.lbl_taxAmount.AutoSize = true;
            this.lbl_taxAmount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_taxAmount.Location = new System.Drawing.Point(1114, 45);
            this.lbl_taxAmount.Name = "lbl_taxAmount";
            this.lbl_taxAmount.Size = new System.Drawing.Size(110, 24);
            this.lbl_taxAmount.TabIndex = 14;
            this.lbl_taxAmount.Text = "Tax Amount";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainDealerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.dgv_editMainDealer);
            this.Controls.Add(this.gb_mainDealer);
            this.Controls.Add(this.lbl_mainDealerSettings);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "MainDealerSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main Dealer Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainDealerSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_editMainDealer)).EndInit();
            this.gb_mainDealer.ResumeLayout(false);
            this.gb_mainDealer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_taxAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mainDealer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_mainDealerSettings;
        private System.Windows.Forms.DataGridView dgv_editMainDealer;
        private System.Windows.Forms.Button btn_cancelEdit;
        private System.Windows.Forms.Button btn_selectImage;
        private System.Windows.Forms.TextBox tb_mainDealerCountry;
        private System.Windows.Forms.TextBox tb_mainDealerPostalCode;
        private System.Windows.Forms.TextBox tb_mainDealerCity;
        private System.Windows.Forms.TextBox tb_mainDealerAdress;
        private System.Windows.Forms.TextBox tb_mainDealerMail;
        private System.Windows.Forms.Label lbl_dealerCountry;
        private System.Windows.Forms.Label lbl_dealerPostalCode;
        private System.Windows.Forms.Label lbl_dealerCity;
        private System.Windows.Forms.Label lbl_dealerAdress;
        private System.Windows.Forms.Label lbl_dealerMail;
        private System.Windows.Forms.Label lbl_dealerName;
        private System.Windows.Forms.Button btn_editMainDealer;
        private System.Windows.Forms.GroupBox gb_mainDealer;
        private System.Windows.Forms.TextBox tb_mainDealerName;
        private System.Windows.Forms.PictureBox pb_mainDealer;
        private System.Windows.Forms.Label lbl_taxAmount;
        private System.Windows.Forms.NumericUpDown nud_taxAmount;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}