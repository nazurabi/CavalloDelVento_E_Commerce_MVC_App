﻿namespace FormForDataModel
{
    partial class CategoriesAdd
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
            this.lbl_addCategories = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dgv_addCategory = new System.Windows.Forms.DataGridView();
            this.lbl_categoryImage = new System.Windows.Forms.Label();
            this.cb_categoryActive = new System.Windows.Forms.CheckBox();
            this.tb_categoryName = new System.Windows.Forms.TextBox();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_selectImage = new System.Windows.Forms.Button();
            this.pb_categoryImage = new System.Windows.Forms.PictureBox();
            this.lbl_brandName = new System.Windows.Forms.Label();
            this.cbb_brandName = new System.Windows.Forms.ComboBox();
            this.gb_addCategory = new System.Windows.Forms.GroupBox();
            this.lbl_categoryName = new System.Windows.Forms.Label();
            this.lbl_categoryActive = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_categoryImage)).BeginInit();
            this.gb_addCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_addCategories
            // 
            this.lbl_addCategories.AutoSize = true;
            this.lbl_addCategories.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_addCategories.Location = new System.Drawing.Point(12, 9);
            this.lbl_addCategories.Name = "lbl_addCategories";
            this.lbl_addCategories.Size = new System.Drawing.Size(191, 35);
            this.lbl_addCategories.TabIndex = 0;
            this.lbl_addCategories.Text = "Add Categories";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dgv_addCategory
            // 
            this.dgv_addCategory.AllowUserToAddRows = false;
            this.dgv_addCategory.AllowUserToDeleteRows = false;
            this.dgv_addCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_addCategory.Location = new System.Drawing.Point(12, 383);
            this.dgv_addCategory.Name = "dgv_addCategory";
            this.dgv_addCategory.ReadOnly = true;
            this.dgv_addCategory.RowHeadersWidth = 51;
            this.dgv_addCategory.RowTemplate.Height = 24;
            this.dgv_addCategory.Size = new System.Drawing.Size(1500, 500);
            this.dgv_addCategory.TabIndex = 13;
            this.dgv_addCategory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_addCategory_DataBindingComplete);
            // 
            // lbl_categoryImage
            // 
            this.lbl_categoryImage.AutoSize = true;
            this.lbl_categoryImage.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_categoryImage.Location = new System.Drawing.Point(727, 45);
            this.lbl_categoryImage.Name = "lbl_categoryImage";
            this.lbl_categoryImage.Size = new System.Drawing.Size(266, 28);
            this.lbl_categoryImage.TabIndex = 9;
            this.lbl_categoryImage.Text = "Categoriy\'s Image Selection";
            // 
            // cb_categoryActive
            // 
            this.cb_categoryActive.AutoSize = true;
            this.cb_categoryActive.Location = new System.Drawing.Point(319, 149);
            this.cb_categoryActive.Name = "cb_categoryActive";
            this.cb_categoryActive.Size = new System.Drawing.Size(18, 17);
            this.cb_categoryActive.TabIndex = 5;
            this.cb_categoryActive.UseVisualStyleBackColor = true;
            // 
            // tb_categoryName
            // 
            this.tb_categoryName.Location = new System.Drawing.Point(367, 89);
            this.tb_categoryName.Name = "tb_categoryName";
            this.tb_categoryName.Size = new System.Drawing.Size(350, 36);
            this.tb_categoryName.TabIndex = 7;
            // 
            // tb_description
            // 
            this.tb_description.Location = new System.Drawing.Point(367, 134);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(350, 172);
            this.tb_description.TabIndex = 8;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(35, 264);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(326, 42);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(35, 216);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(162, 42);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_selectImage
            // 
            this.btn_selectImage.Location = new System.Drawing.Point(199, 216);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(162, 42);
            this.btn_selectImage.TabIndex = 11;
            this.btn_selectImage.Text = "Select Image";
            this.btn_selectImage.UseVisualStyleBackColor = true;
            this.btn_selectImage.Click += new System.EventHandler(this.btn_selectImage_Click);
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
            // cbb_brandName
            // 
            this.cbb_brandName.FormattingEnabled = true;
            this.cbb_brandName.Location = new System.Drawing.Point(35, 89);
            this.cbb_brandName.Name = "cbb_brandName";
            this.cbb_brandName.Size = new System.Drawing.Size(326, 36);
            this.cbb_brandName.TabIndex = 3;
            this.cbb_brandName.Text = "---Choose---";
            this.cbb_brandName.SelectedIndexChanged += new System.EventHandler(this.cbb_brandName_SelectedIndexChanged);
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
            this.gb_addCategory.TabIndex = 1;
            this.gb_addCategory.TabStop = false;
            this.gb_addCategory.Text = "Categories Information";
            // 
            // lbl_categoryName
            // 
            this.lbl_categoryName.AutoSize = true;
            this.lbl_categoryName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_categoryName.Location = new System.Drawing.Point(347, 45);
            this.lbl_categoryName.Name = "lbl_categoryName";
            this.lbl_categoryName.Size = new System.Drawing.Size(155, 28);
            this.lbl_categoryName.TabIndex = 6;
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
            // CategoriesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.gb_addCategory);
            this.Controls.Add(this.dgv_addCategory);
            this.Controls.Add(this.lbl_addCategories);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "CategoriesAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add Categories";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CategoriesAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_categoryImage)).EndInit();
            this.gb_addCategory.ResumeLayout(false);
            this.gb_addCategory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_addCategories;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgv_addCategory;
        private System.Windows.Forms.Label lbl_categoryImage;
        private System.Windows.Forms.CheckBox cb_categoryActive;
        private System.Windows.Forms.TextBox tb_categoryName;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_selectImage;
        private System.Windows.Forms.PictureBox pb_categoryImage;
        private System.Windows.Forms.Label lbl_brandName;
        private System.Windows.Forms.ComboBox cbb_brandName;
        private System.Windows.Forms.GroupBox gb_addCategory;
        private System.Windows.Forms.Label lbl_categoryName;
        private System.Windows.Forms.Label lbl_categoryActive;
    }
}