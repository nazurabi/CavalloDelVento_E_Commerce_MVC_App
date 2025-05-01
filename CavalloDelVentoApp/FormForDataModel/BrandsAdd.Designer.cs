namespace FormForDataModel
{
    partial class BrandsAdd
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
            this.lbl_addBrand = new System.Windows.Forms.Label();
            this.lbl_brandName = new System.Windows.Forms.Label();
            this.lbl_brandActive = new System.Windows.Forms.Label();
            this.gb_addBrand = new System.Windows.Forms.GroupBox();
            this.pb_brandImage = new System.Windows.Forms.PictureBox();
            this.btn_selectImage = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_brandName = new System.Windows.Forms.TextBox();
            this.cb_brandActive = new System.Windows.Forms.CheckBox();
            this.lbl_brandImage = new System.Windows.Forms.Label();
            this.dgv_addBrand = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gb_addBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_brandImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_addBrand
            // 
            this.lbl_addBrand.AutoSize = true;
            this.lbl_addBrand.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_addBrand.Location = new System.Drawing.Point(12, 9);
            this.lbl_addBrand.Name = "lbl_addBrand";
            this.lbl_addBrand.Size = new System.Drawing.Size(137, 35);
            this.lbl_addBrand.TabIndex = 0;
            this.lbl_addBrand.Text = "Add Brand";
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
            // lbl_brandActive
            // 
            this.lbl_brandActive.AutoSize = true;
            this.lbl_brandActive.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_brandActive.Location = new System.Drawing.Point(30, 142);
            this.lbl_brandActive.Name = "lbl_brandActive";
            this.lbl_brandActive.Size = new System.Drawing.Size(229, 28);
            this.lbl_brandActive.TabIndex = 4;
            this.lbl_brandActive.Text = "Is Brand Active For Sale";
            // 
            // gb_addBrand
            // 
            this.gb_addBrand.Controls.Add(this.pb_brandImage);
            this.gb_addBrand.Controls.Add(this.btn_selectImage);
            this.gb_addBrand.Controls.Add(this.btn_clear);
            this.gb_addBrand.Controls.Add(this.btn_save);
            this.gb_addBrand.Controls.Add(this.tb_brandName);
            this.gb_addBrand.Controls.Add(this.cb_brandActive);
            this.gb_addBrand.Controls.Add(this.lbl_brandImage);
            this.gb_addBrand.Controls.Add(this.lbl_brandName);
            this.gb_addBrand.Controls.Add(this.lbl_brandActive);
            this.gb_addBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_addBrand.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_addBrand.Location = new System.Drawing.Point(12, 47);
            this.gb_addBrand.Name = "gb_addBrand";
            this.gb_addBrand.Size = new System.Drawing.Size(1500, 330);
            this.gb_addBrand.TabIndex = 1;
            this.gb_addBrand.TabStop = false;
            this.gb_addBrand.Text = "Brands Information";
            // 
            // pb_brandImage
            // 
            this.pb_brandImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_brandImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_brandImage.Location = new System.Drawing.Point(400, 76);
            this.pb_brandImage.Name = "pb_brandImage";
            this.pb_brandImage.Size = new System.Drawing.Size(230, 230);
            this.pb_brandImage.TabIndex = 4;
            this.pb_brandImage.TabStop = false;
            // 
            // btn_selectImage
            // 
            this.btn_selectImage.Location = new System.Drawing.Point(198, 216);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(165, 42);
            this.btn_selectImage.TabIndex = 9;
            this.btn_selectImage.Text = "Select Image";
            this.btn_selectImage.UseVisualStyleBackColor = true;
            this.btn_selectImage.Click += new System.EventHandler(this.btn_selectImage_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(27, 216);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(165, 42);
            this.btn_clear.TabIndex = 8;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(27, 264);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(336, 42);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_brandName
            // 
            this.tb_brandName.Location = new System.Drawing.Point(35, 89);
            this.tb_brandName.Name = "tb_brandName";
            this.tb_brandName.Size = new System.Drawing.Size(350, 36);
            this.tb_brandName.TabIndex = 3;
            // 
            // cb_brandActive
            // 
            this.cb_brandActive.AutoSize = true;
            this.cb_brandActive.Location = new System.Drawing.Point(345, 149);
            this.cb_brandActive.Name = "cb_brandActive";
            this.cb_brandActive.Size = new System.Drawing.Size(18, 17);
            this.cb_brandActive.TabIndex = 5;
            this.cb_brandActive.UseVisualStyleBackColor = true;
            // 
            // lbl_brandImage
            // 
            this.lbl_brandImage.AutoSize = true;
            this.lbl_brandImage.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_brandImage.Location = new System.Drawing.Point(395, 45);
            this.lbl_brandImage.Name = "lbl_brandImage";
            this.lbl_brandImage.Size = new System.Drawing.Size(234, 28);
            this.lbl_brandImage.TabIndex = 6;
            this.lbl_brandImage.Text = "Brand\'s Image Selection";
            // 
            // dgv_addBrand
            // 
            this.dgv_addBrand.AllowUserToAddRows = false;
            this.dgv_addBrand.AllowUserToDeleteRows = false;
            this.dgv_addBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_addBrand.Location = new System.Drawing.Point(12, 383);
            this.dgv_addBrand.Name = "dgv_addBrand";
            this.dgv_addBrand.ReadOnly = true;
            this.dgv_addBrand.RowHeadersWidth = 51;
            this.dgv_addBrand.RowTemplate.Height = 24;
            this.dgv_addBrand.Size = new System.Drawing.Size(1500, 500);
            this.dgv_addBrand.TabIndex = 11;
            this.dgv_addBrand.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_addBrand_DataBindingComplete);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BrandsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.dgv_addBrand);
            this.Controls.Add(this.gb_addBrand);
            this.Controls.Add(this.lbl_addBrand);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "BrandsAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add Brand";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BrandsAdd_Load);
            this.gb_addBrand.ResumeLayout(false);
            this.gb_addBrand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_brandImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addBrand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_addBrand;
        private System.Windows.Forms.Label lbl_brandName;
        private System.Windows.Forms.Label lbl_brandActive;
        private System.Windows.Forms.GroupBox gb_addBrand;
        private System.Windows.Forms.CheckBox cb_brandActive;
        private System.Windows.Forms.TextBox tb_brandName;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.PictureBox pb_brandImage;
        private System.Windows.Forms.Label lbl_brandImage;
        private System.Windows.Forms.Button btn_selectImage;
        private System.Windows.Forms.DataGridView dgv_addBrand;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}