﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModelWithADO;

namespace FormForDataModel
{
    public partial class BrandsEdit : Form
    {
        DataModel dm = new DataModel();
        string brandID = "";
        string imageName = "";
        string imageForEdit = "";
        string selectedImagePath = "";
        string destinationImagePath = "";

        public BrandsEdit()
        {
            InitializeComponent();
        }

        private void BrandsEdit_Load(object sender, EventArgs e)
        {
            BrandsEditLoad();
        }

        private void BrandsEditLoad()
        {
            DataTable dt = dm.brandDataBind();

            dgv_editBrand.DataSource = dt;
            dgv_editBrand.Columns["BrandID"].Visible = false;
            dgv_editBrand.Columns["Brand Image Name"].Visible = false;

            #region Image Column and Sequence Number Settings

            int dgvaddBrandColumnWidth = dgv_editBrand.Width - dgv_editBrand.RowHeadersWidth - 100; // 100 = Image Column Width
            int otherColumnCount = dgv_editBrand.Columns.Count - 2; // (2 --> S/N and Image Column)
            int columnWidth = dgvaddBrandColumnWidth / otherColumnCount;

            for (int i = 0; i < otherColumnCount; i++)
            {
                dgv_editBrand.Columns[i].Width = columnWidth;
            }
            foreach (DataGridViewColumn column in dgv_editBrand.Columns)
            {
                if (column.Name == "S/N")
                {
                    column.Width = 50;
                }
                if (column.Name == "Brand Image")
                {
                    DataGridViewImageColumn imageCol = (DataGridViewImageColumn)column;
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 100;
                    dgv_editBrand.RowTemplate.Height = 100;
                }
            }

            #endregion
        }

        private void dgv_editBrand_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_editBrand.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                    rows.Cells["Is Deleted"].Style.ForeColor = Color.Red;
                }

                if (rows.Cells["Is Brand Active For Sale"].Value.ToString() == "No")
                {
                    rows.Cells["Is Brand Active For Sale"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void dgv_editBrand_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tb_brandName.Enabled = true;
            cb_brandActive.Enabled = true;
            cb_brandDelete.Enabled = true;
            btn_clear.Enabled = true;
            btn_selectImage.Enabled = true;
            btn_save.Enabled = true;

            DataGridViewRow selectedRow = dgv_editBrand.Rows[e.RowIndex];
            tb_brandName.Text = selectedRow.Cells["Brand Name"].Value.ToString();
            cb_brandActive.Checked = selectedRow.Cells["Is Brand Active For Sale"].Value.ToString() == "Yes" ? true : false;
            cb_brandDelete.Checked = selectedRow.Cells["Is Deleted"].Value.ToString() == "Yes" ? true : false;
            imageForEdit = dm.listImageForEditBrands(selectedRow.Cells["BrandID"].Value.ToString());
            brandID = selectedRow.Cells["BrandID"].Value.ToString();
            pb_brandImage.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageForEdit);
            pb_brandImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btn_selectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".jpeg" || fi.Extension == ".png")
                {
                    pb_brandImage.SizeMode = PictureBoxSizeMode.Zoom;
                    pb_brandImage.ImageLocation = fi.FullName;
                    selectedImagePath = fi.FullName;
                    imageName = Guid.NewGuid().ToString() + fi.Extension;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string brandName = "";
            bool isDeleted;
            bool isActive;
            if (!string.IsNullOrEmpty(tb_brandName.Text))
            {
                byte checkBrandName = dm.listBrands(tb_brandName.Text.ToUpper());
                if (checkBrandName == 0)
                {
                    if (tb_brandName.Text.Length < 100)
                    {
                        if (!string.IsNullOrEmpty(imageName))
                        {
                            brandName = tb_brandName.Text.ToUpper();
                            isDeleted = cb_brandDelete.Checked;
                            isActive = isDeleted ? false : cb_brandActive.Checked;
                            dm.editBrand(brandID, brandName, isActive, isDeleted, imageName);
                            destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageName);
                            destinationImagePath = Path.GetFullPath(destinationImagePath);
                            File.Copy(selectedImagePath, destinationImagePath, true);
                            tb_brandName.Text = "";
                            cb_brandActive.Checked = false;
                            cb_brandDelete.Checked = false;
                            imageName = "";
                            pb_brandImage.ImageLocation = "";
                            BrandsEditLoad();
                            //dgv_editBrand.ClearSelection();
                            //dgv_editBrand.CurrentCell = null;
                            tb_brandName.Enabled = false;
                            cb_brandActive.Enabled = false;
                            cb_brandDelete.Enabled = false;
                            btn_clear.Enabled = false;
                            btn_selectImage.Enabled = false;
                            btn_save.Enabled = false;
                            // Since the image has changed, the old image was deleted with this line of code;
                            //string oldImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageForEdit);
                            //if (File.Exists(oldImage))
                            //{
                            //    try
                            //    {
                            //        File.Delete(oldImage);
                            //        MessageBox.Show("Eski görsel başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        MessageBox.Show($"Görsel silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    }
                            //}
                        }
                        else
                        {
                            brandName = tb_brandName.Text.ToUpper();
                            isDeleted = cb_brandDelete.Checked;
                            isActive = isDeleted ? false : cb_brandActive.Checked;
                            imageName = imageForEdit;
                            dm.editBrand(brandID, brandName, isActive, isDeleted, imageName);
                            tb_brandName.Text = "";
                            cb_brandActive.Checked = false;
                            cb_brandDelete.Checked = false;
                            imageName = "";
                            pb_brandImage.ImageLocation = "";
                            BrandsEditLoad();
                            //dgv_editBrand.ClearSelection();
                            //dgv_editBrand.CurrentCell = null;
                            tb_brandName.Enabled = false;
                            cb_brandActive.Enabled = false;
                            cb_brandDelete.Enabled = false;
                            btn_clear.Enabled = false;
                            btn_selectImage.Enabled = false;
                            btn_save.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Brand name too long, it can be max 100 character!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(imageName))
                    {
                        isDeleted = cb_brandDelete.Checked;
                        isActive = isDeleted ? false : cb_brandActive.Checked;
                        dm.editBrand(brandID, isActive, isDeleted, imageName);
                        destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageName);
                        destinationImagePath = Path.GetFullPath(destinationImagePath);
                        File.Copy(selectedImagePath, destinationImagePath, true);
                        tb_brandName.Text = "";
                        cb_brandActive.Checked = false;
                        cb_brandDelete.Checked = false;
                        imageName = "";
                        pb_brandImage.ImageLocation = "";
                        BrandsEditLoad();
                        //dgv_editBrand.ClearSelection();
                        //dgv_editBrand.CurrentCell = null;
                        tb_brandName.Enabled = false;
                        cb_brandActive.Enabled = false;
                        cb_brandDelete.Enabled = false;
                        btn_clear.Enabled = false;
                        btn_selectImage.Enabled = false;
                        btn_save.Enabled = false;
                        // Since the image has changed, the old image was deleted with this line of code;
                        //string oldImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageForEdit);
                        //if (File.Exists(oldImage))
                        //{
                        //    try
                        //    {
                        //        File.Delete(oldImage);
                        //        MessageBox.Show("Eski görsel başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        MessageBox.Show($"Görsel silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }
                        //}
                    }
                    else
                    {
                        isDeleted = cb_brandDelete.Checked;
                        isActive = isDeleted ? false : cb_brandActive.Checked;
                        imageName = imageForEdit;
                        dm.editBrand(brandID, isActive, isDeleted, imageName);
                        tb_brandName.Text = "";
                        cb_brandActive.Checked = false;
                        cb_brandDelete.Checked = false;
                        imageName = "";
                        pb_brandImage.ImageLocation = "";
                        BrandsEditLoad();
                        //dgv_editBrand.ClearSelection();
                        //dgv_editBrand.CurrentCell = null;
                        tb_brandName.Enabled = false;
                        cb_brandActive.Enabled = false;
                        cb_brandDelete.Enabled = false;
                        btn_clear.Enabled = false;
                        btn_selectImage.Enabled = false;
                        btn_save.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Brand name cannot empty!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_brandName.Text = "";
            cb_brandActive.Checked = false;
            cb_brandDelete.Checked = false;
            imageName = "";
            selectedImagePath = "";
            destinationImagePath = "";
            pb_brandImage.ImageLocation = "";
        }
    }
}
