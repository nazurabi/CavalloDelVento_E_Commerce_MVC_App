namespace FormForDataModel
{
    partial class BrandsEdit
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
            this.lbl_editBrand = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.lbl_brandName = new System.Windows.Forms.Label();
            this.lbl_brandActive = new System.Windows.Forms.Label();
            this.gb_addBrand = new System.Windows.Forms.GroupBox();
            this.pb_brandImage = new System.Windows.Forms.PictureBox();
            this.btn_selectImage = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_brandName = new System.Windows.Forms.TextBox();
            this.cb_brandDelete = new System.Windows.Forms.CheckBox();
            this.cb_brandActive = new System.Windows.Forms.CheckBox();
            this.lbl_brandImage = new System.Windows.Forms.Label();
            this.lbl_brandDelete = new System.Windows.Forms.Label();
            this.dgv_editBrand = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gb_addBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_brandImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_editBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_editBrand
            // 
            this.lbl_editBrand.AutoSize = true;
            this.lbl_editBrand.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_editBrand.Location = new System.Drawing.Point(12, 9);
            this.lbl_editBrand.Name = "lbl_editBrand";
            this.lbl_editBrand.Size = new System.Drawing.Size(136, 35);
            this.lbl_editBrand.TabIndex = 0;
            this.lbl_editBrand.Text = "Edit Brand";
            // 
            // btn_clear
            // 
            this.btn_clear.Enabled = false;
            this.btn_clear.Location = new System.Drawing.Point(35, 216);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(162, 42);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
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
            this.lbl_brandActive.TabIndex = 6;
            this.lbl_brandActive.Text = "Is Brand Active For Sale";
            // 
            // gb_addBrand
            // 
            this.gb_addBrand.Controls.Add(this.pb_brandImage);
            this.gb_addBrand.Controls.Add(this.btn_selectImage);
            this.gb_addBrand.Controls.Add(this.btn_clear);
            this.gb_addBrand.Controls.Add(this.btn_save);
            this.gb_addBrand.Controls.Add(this.tb_brandName);
            this.gb_addBrand.Controls.Add(this.cb_brandDelete);
            this.gb_addBrand.Controls.Add(this.cb_brandActive);
            this.gb_addBrand.Controls.Add(this.lbl_brandImage);
            this.gb_addBrand.Controls.Add(this.lbl_brandName);
            this.gb_addBrand.Controls.Add(this.lbl_brandDelete);
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
            this.btn_selectImage.Enabled = false;
            this.btn_selectImage.Location = new System.Drawing.Point(199, 216);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(162, 42);
            this.btn_selectImage.TabIndex = 11;
            this.btn_selectImage.Text = "Select Image";
            this.btn_selectImage.UseVisualStyleBackColor = true;
            this.btn_selectImage.Click += new System.EventHandler(this.btn_selectImage_Click);
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(35, 264);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(326, 42);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "Edit Data";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_brandName
            // 
            this.tb_brandName.Enabled = false;
            this.tb_brandName.Location = new System.Drawing.Point(35, 89);
            this.tb_brandName.Name = "tb_brandName";
            this.tb_brandName.Size = new System.Drawing.Size(326, 36);
            this.tb_brandName.TabIndex = 3;
            // 
            // cb_brandDelete
            // 
            this.cb_brandDelete.AutoSize = true;
            this.cb_brandDelete.Enabled = false;
            this.cb_brandDelete.Location = new System.Drawing.Point(345, 184);
            this.cb_brandDelete.Name = "cb_brandDelete";
            this.cb_brandDelete.Size = new System.Drawing.Size(18, 17);
            this.cb_brandDelete.TabIndex = 9;
            this.cb_brandDelete.UseVisualStyleBackColor = true;
            // 
            // cb_brandActive
            // 
            this.cb_brandActive.AutoSize = true;
            this.cb_brandActive.Enabled = false;
            this.cb_brandActive.Location = new System.Drawing.Point(345, 149);
            this.cb_brandActive.Name = "cb_brandActive";
            this.cb_brandActive.Size = new System.Drawing.Size(18, 17);
            this.cb_brandActive.TabIndex = 7;
            this.cb_brandActive.UseVisualStyleBackColor = true;
            // 
            // lbl_brandImage
            // 
            this.lbl_brandImage.AutoSize = true;
            this.lbl_brandImage.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_brandImage.Location = new System.Drawing.Point(395, 45);
            this.lbl_brandImage.Name = "lbl_brandImage";
            this.lbl_brandImage.Size = new System.Drawing.Size(234, 28);
            this.lbl_brandImage.TabIndex = 4;
            this.lbl_brandImage.Text = "Brand\'s Image Selection";
            // 
            // lbl_brandDelete
            // 
            this.lbl_brandDelete.AutoSize = true;
            this.lbl_brandDelete.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_brandDelete.ForeColor = System.Drawing.Color.Red;
            this.lbl_brandDelete.Location = new System.Drawing.Point(30, 177);
            this.lbl_brandDelete.Name = "lbl_brandDelete";
            this.lbl_brandDelete.Size = new System.Drawing.Size(72, 28);
            this.lbl_brandDelete.TabIndex = 8;
            this.lbl_brandDelete.Text = "Delete";
            // 
            // dgv_editBrand
            // 
            this.dgv_editBrand.AllowUserToAddRows = false;
            this.dgv_editBrand.AllowUserToDeleteRows = false;
            this.dgv_editBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_editBrand.Location = new System.Drawing.Point(12, 383);
            this.dgv_editBrand.Name = "dgv_editBrand";
            this.dgv_editBrand.ReadOnly = true;
            this.dgv_editBrand.RowHeadersWidth = 51;
            this.dgv_editBrand.RowTemplate.Height = 24;
            this.dgv_editBrand.Size = new System.Drawing.Size(1500, 500);
            this.dgv_editBrand.TabIndex = 13;
            this.dgv_editBrand.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_editBrand_DataBindingComplete);
            this.dgv_editBrand.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_editBrand_RowHeaderMouseClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BrandsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.gb_addBrand);
            this.Controls.Add(this.dgv_editBrand);
            this.Controls.Add(this.lbl_editBrand);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "BrandsEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Edit Brand";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BrandsEdit_Load);
            this.gb_addBrand.ResumeLayout(false);
            this.gb_addBrand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_brandImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_editBrand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_editBrand;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label lbl_brandName;
        private System.Windows.Forms.Label lbl_brandActive;
        private System.Windows.Forms.GroupBox gb_addBrand;
        private System.Windows.Forms.PictureBox pb_brandImage;
        private System.Windows.Forms.Button btn_selectImage;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tb_brandName;
        private System.Windows.Forms.CheckBox cb_brandActive;
        private System.Windows.Forms.Label lbl_brandImage;
        private System.Windows.Forms.DataGridView dgv_editBrand;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cb_brandDelete;
        private System.Windows.Forms.Label lbl_brandDelete;
    }
}