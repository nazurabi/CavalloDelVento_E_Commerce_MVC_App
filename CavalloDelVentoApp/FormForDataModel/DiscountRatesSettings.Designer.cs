namespace FormForDataModel
{
    partial class DiscountRatesSettings
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
            this.lbl_discountRates = new System.Windows.Forms.Label();
            this.dgv_discountRates = new System.Windows.Forms.DataGridView();
            this.gb_discountRates = new System.Windows.Forms.GroupBox();
            this.pb_discountRates = new System.Windows.Forms.PictureBox();
            this.nud_discountRates = new System.Windows.Forms.NumericUpDown();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_discountSign = new System.Windows.Forms.Label();
            this.lbl_discountAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_discountRates)).BeginInit();
            this.gb_discountRates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_discountRates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_discountRates)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_discountRates
            // 
            this.lbl_discountRates.AutoSize = true;
            this.lbl_discountRates.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_discountRates.Location = new System.Drawing.Point(12, 9);
            this.lbl_discountRates.Name = "lbl_discountRates";
            this.lbl_discountRates.Size = new System.Drawing.Size(189, 35);
            this.lbl_discountRates.TabIndex = 3;
            this.lbl_discountRates.Text = "Discount Rates";
            // 
            // dgv_discountRates
            // 
            this.dgv_discountRates.AllowUserToAddRows = false;
            this.dgv_discountRates.AllowUserToDeleteRows = false;
            this.dgv_discountRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_discountRates.Location = new System.Drawing.Point(18, 383);
            this.dgv_discountRates.Name = "dgv_discountRates";
            this.dgv_discountRates.ReadOnly = true;
            this.dgv_discountRates.RowHeadersWidth = 51;
            this.dgv_discountRates.RowTemplate.Height = 24;
            this.dgv_discountRates.Size = new System.Drawing.Size(600, 330);
            this.dgv_discountRates.TabIndex = 6;
            this.dgv_discountRates.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_discountRates_RowHeaderMouseClick);
            // 
            // gb_discountRates
            // 
            this.gb_discountRates.Controls.Add(this.pb_discountRates);
            this.gb_discountRates.Controls.Add(this.nud_discountRates);
            this.gb_discountRates.Controls.Add(this.btn_clear);
            this.gb_discountRates.Controls.Add(this.btn_save);
            this.gb_discountRates.Controls.Add(this.lbl_discountSign);
            this.gb_discountRates.Controls.Add(this.lbl_discountAmount);
            this.gb_discountRates.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_discountRates.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_discountRates.Location = new System.Drawing.Point(18, 47);
            this.gb_discountRates.Name = "gb_discountRates";
            this.gb_discountRates.Size = new System.Drawing.Size(600, 330);
            this.gb_discountRates.TabIndex = 5;
            this.gb_discountRates.TabStop = false;
            this.gb_discountRates.Text = "Discount Rates Settings";
            // 
            // pb_discountRates
            // 
            this.pb_discountRates.Location = new System.Drawing.Point(35, 76);
            this.pb_discountRates.Name = "pb_discountRates";
            this.pb_discountRates.Size = new System.Drawing.Size(100, 100);
            this.pb_discountRates.TabIndex = 11;
            this.pb_discountRates.TabStop = false;
            // 
            // nud_discountRates
            // 
            this.nud_discountRates.Enabled = false;
            this.nud_discountRates.Location = new System.Drawing.Point(189, 76);
            this.nud_discountRates.Name = "nud_discountRates";
            this.nud_discountRates.Size = new System.Drawing.Size(120, 36);
            this.nud_discountRates.TabIndex = 10;
            this.nud_discountRates.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nud_discountRates_KeyPress);
            // 
            // btn_clear
            // 
            this.btn_clear.Enabled = false;
            this.btn_clear.Location = new System.Drawing.Point(189, 182);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(149, 42);
            this.btn_clear.TabIndex = 8;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(34, 182);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(149, 42);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_discountSign
            // 
            this.lbl_discountSign.AutoSize = true;
            this.lbl_discountSign.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_discountSign.Location = new System.Drawing.Point(30, 45);
            this.lbl_discountSign.Name = "lbl_discountSign";
            this.lbl_discountSign.Size = new System.Drawing.Size(138, 28);
            this.lbl_discountSign.TabIndex = 7;
            this.lbl_discountSign.Text = "Discount Sign";
            // 
            // lbl_discountAmount
            // 
            this.lbl_discountAmount.AutoSize = true;
            this.lbl_discountAmount.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_discountAmount.Location = new System.Drawing.Point(184, 45);
            this.lbl_discountAmount.Name = "lbl_discountAmount";
            this.lbl_discountAmount.Size = new System.Drawing.Size(150, 28);
            this.lbl_discountAmount.TabIndex = 2;
            this.lbl_discountAmount.Text = "Discount Rates";
            // 
            // DiscountRatesSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.dgv_discountRates);
            this.Controls.Add(this.gb_discountRates);
            this.Controls.Add(this.lbl_discountRates);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "DiscountRatesSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Discount Rates Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DiscountRatesSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_discountRates)).EndInit();
            this.gb_discountRates.ResumeLayout(false);
            this.gb_discountRates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_discountRates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_discountRates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_discountRates;
        private System.Windows.Forms.DataGridView dgv_discountRates;
        private System.Windows.Forms.GroupBox gb_discountRates;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_discountSign;
        private System.Windows.Forms.Label lbl_discountAmount;
        private System.Windows.Forms.NumericUpDown nud_discountRates;
        private System.Windows.Forms.PictureBox pb_discountRates;
    }
}