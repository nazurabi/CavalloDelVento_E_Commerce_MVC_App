namespace FormForDataModel
{
    partial class CategoriesEdit
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
            this.lbl_editCategories = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cb_categoryActive = new System.Windows.Forms.CheckBox();
            this.gb_addCategory = new System.Windows.Forms.GroupBox();
            this.cbb_brandName = new System.Windows.Forms.ComboBox();
            this.lbl_brandName = new System.Windows.Forms.Label();
            this.pb_categoryImage = new System.Windows.Forms.PictureBox();
            this.btn_selectImage = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.tb_categoryName = new System.Windows.Forms.TextBox();
            this.lbl_categoryImage = new System.Windows.Forms.Label();
            this.lbl_categoryName = new System.Windows.Forms.Label();
            this.lbl_categoryActive = new System.Windows.Forms.Label();
            this.dgv_editCategory = new System.Windows.Forms.DataGridView();
            this.gb_addCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_categoryImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_editCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_editCategories
            // 
            this.lbl_editCategories.AutoSize = true;
            this.lbl_editCategories.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_editCategories.Location = new System.Drawing.Point(12, 9);
            this.lbl_editCategories.Name = "lbl_editCategories";
            this.lbl_editCategories.Size = new System.Drawing.Size(190, 35);
            this.lbl_editCategories.TabIndex = 1;
            this.lbl_editCategories.Text = "Edit Categories";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cb_categoryActive
            // 
            this.cb_categoryActive.AutoSize = true;
            this.cb_categoryActive.Enabled = false;
            this.cb_categoryActive.Location = new System.Drawing.Point(319, 149);
            this.cb_categoryActive.Name = "cb_categoryActive";
            this.cb_categoryActive.Size = new System.Drawing.Size(18, 17);
            this.cb_categoryActive.TabIndex = 5;
            this.cb_categoryActive.UseVisualStyleBackColor = true;
            // 
            // gb_addCategory
            // 
            this.gb_addCategory.Controls.Add(this.cbb_brandName);
            this.gb_addCategory.Controls.Add(this.lbl_brandName);
            this.gb_addCategory.Controls.Add(this.pb_categoryImage);
            this.gb_addCategory.Controls.Add(this.btn_selectImage);
            this.gb_addCategory.Controls.Add(this.btn_clear);
            this.gb_addCategory.Controls.Add(this.btn_save);
            this.gb_addCategory.Controls.Add(this.tb_description);
            this.gb_addCategory.Controls.Add(this.tb_categoryName);
            this.gb_addCategory.Controls.Add(this.cb_categoryActive);
            this.gb_addCategory.Controls.Add(this.lbl_categoryImage);
            this.gb_addCategory.Controls.Add(this.lbl_categoryName);
            this.gb_addCategory.Controls.Add(this.lbl_categoryActive);
            this.gb_addCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_addCategory.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_addCategory.Location = new System.Drawing.Point(12, 47);
            this.gb_addCategory.Name = "gb_addCategory";
            this.gb_addCategory.Size = new System.Drawing.Size(1500, 330);
            this.gb_addCategory.TabIndex = 5;
            this.gb_addCategory.TabStop = false;
            this.gb_addCategory.Text = "Categories Information";
            // 
            // cbb_brandName
            // 
            this.cbb_brandName.Enabled = false;
            this.cbb_brandName.FormattingEnabled = true;
            this.cbb_brandName.Location = new System.Drawing.Point(35, 89);
            this.cbb_brandName.Name = "cbb_brandName";
            this.cbb_brandName.Size = new System.Drawing.Size(326, 36);
            this.cbb_brandName.TabIndex = 12;
            this.cbb_brandName.Text = "---Choose---";
            this.cbb_brandName.SelectedIndexChanged += new System.EventHandler(this.cbb_brandName_SelectedIndexChanged);
            // 
            // lbl_brandName
            // 
            this.lbl_brandName.AutoSize = true;
            this.lbl_brandName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_brandName.Location = new System.Drawing.Point(30, 45);
            this.lbl_brandName.Name = "lbl_brandName";
            this.lbl_brandName.Size = new System.Drawing.Size(128, 28);
            this.lbl_brandName.TabIndex = 10;
            this.lbl_brandName.Text = "Brand Name";
            // 
            // pb_categoryImage
            // 
            this.pb_categoryImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_categoryImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_categoryImage.Location = new System.Drawing.Point(732, 76);
            this.pb_categoryImage.Name = "pb_categoryImage";
            this.pb_categoryImage.Size = new System.Drawing.Size(230, 230);
            this.pb_categoryImage.TabIndex = 4;
            this.pb_categoryImage.TabStop = false;
            // 
            // btn_selectImage
            // 
            this.btn_selectImage.Enabled = false;
            this.btn_selectImage.Location = new System.Drawing.Point(199, 216);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(162, 42);
            this.btn_selectImage.TabIndex = 6;
            this.btn_selectImage.Text = "Select Image";
            this.btn_selectImage.UseVisualStyleBackColor = true;
            this.btn_selectImage.Click += new System.EventHandler(this.btn_selectImage_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Enabled = false;
            this.btn_clear.Location = new System.Drawing.Point(35, 216);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(162, 42);
            this.btn_clear.TabIndex = 8;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(35, 264);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(326, 42);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Edit Data";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_description
            // 
            this.tb_description.Enabled = false;
            this.tb_description.Location = new System.Drawing.Point(367, 134);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(350, 172);
            this.tb_description.TabIndex = 3;
            // 
            // tb_categoryName
            // 
            this.tb_categoryName.Enabled = false;
            this.tb_categoryName.Location = new System.Drawing.Point(367, 89);
            this.tb_categoryName.Name = "tb_categoryName";
            this.tb_categoryName.Size = new System.Drawing.Size(350, 36);
            this.tb_categoryName.TabIndex = 3;
            // 
            // lbl_categoryImage
            // 
            this.lbl_categoryImage.AutoSize = true;
            this.lbl_categoryImage.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_categoryImage.Location = new System.Drawing.Point(727, 45);
            this.lbl_categoryImage.Name = "lbl_categoryImage";
            this.lbl_categoryImage.Size = new System.Drawing.Size(266, 28);
            this.lbl_categoryImage.TabIndex = 7;
            this.lbl_categoryImage.Text = "Categoriy\'s Image Selection";
            // 
            // lbl_categoryName
            // 
            this.lbl_categoryName.AutoSize = true;
            this.lbl_categoryName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_categoryName.Location = new System.Drawing.Point(362, 45);
            this.lbl_categoryName.Name = "lbl_categoryName";
            this.lbl_categoryName.Size = new System.Drawing.Size(155, 28);
            this.lbl_categoryName.TabIndex = 2;
            this.lbl_categoryName.Text = "Category Name";
            // 
            // lbl_categoryActive
            // 
            this.lbl_categoryActive.AutoSize = true;
            this.lbl_categoryActive.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_categoryActive.Location = new System.Drawing.Point(30, 142);
            this.lbl_categoryActive.Name = "lbl_categoryActive";
            this.lbl_categoryActive.Size = new System.Drawing.Size(256, 28);
            this.lbl_categoryActive.TabIndex = 4;
            this.lbl_categoryActive.Text = "Is Category Active For Sale";
            // 
            // dgv_editCategory
            // 
            this.dgv_editCategory.AllowUserToAddRows = false;
            this.dgv_editCategory.AllowUserToDeleteRows = false;
            this.dgv_editCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_editCategory.Location = new System.Drawing.Point(12, 383);
            this.dgv_editCategory.Name = "dgv_editCategory";
            this.dgv_editCategory.ReadOnly = true;
            this.dgv_editCategory.RowHeadersWidth = 51;
            this.dgv_editCategory.RowTemplate.Height = 24;
            this.dgv_editCategory.Size = new System.Drawing.Size(1500, 500);
            this.dgv_editCategory.TabIndex = 6;
            this.dgv_editCategory.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_editCategory_RowHeaderMouseClick);
            // 
            // CategoriesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.gb_addCategory);
            this.Controls.Add(this.dgv_editCategory);
            this.Controls.Add(this.lbl_editCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "CategoriesEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Edit Categories";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CategoriesEdit_Load);
            this.gb_addCategory.ResumeLayout(false);
            this.gb_addCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_categoryImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_editCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_editCategories;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cb_categoryActive;
        private System.Windows.Forms.GroupBox gb_addCategory;
        private System.Windows.Forms.ComboBox cbb_brandName;
        private System.Windows.Forms.Label lbl_brandName;
        private System.Windows.Forms.PictureBox pb_categoryImage;
        private System.Windows.Forms.Button btn_selectImage;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.TextBox tb_categoryName;
        private System.Windows.Forms.Label lbl_categoryImage;
        private System.Windows.Forms.Label lbl_categoryName;
        private System.Windows.Forms.Label lbl_categoryActive;
        private System.Windows.Forms.DataGridView dgv_editCategory;
    }
}