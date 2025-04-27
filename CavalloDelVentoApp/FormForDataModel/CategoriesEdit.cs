using System;
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
    public partial class CategoriesEdit : Form
    {
        DataModel dm = new DataModel();
        string brandIDFK = "";
        string categoryID = "";
        string imageName = "";
        string imageForEdit = "";
        string selectedImagePath = "";
        string destinationImagePath = "";
        int selectedBrandID = -1;
        public CategoriesEdit()
        {
            InitializeComponent();
        }

        private void CategoriesEdit_Load(object sender, EventArgs e)
        {
            CategoriesEditLoad();
            comboBoxBrandsLoad();
        }

        private void comboBoxBrandsLoad()
        {
            List<Brands> brands = dm.getBrandsForCategories();
            cbb_brandName.DataSource = brands;
            cbb_brandName.DisplayMember = "BrandName";
            cbb_brandName.ValueMember = "BrandID";
            cbb_brandName.SelectedIndex = -1;
        }
        private void cbb_brandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_brandName.SelectedIndex != -1 && cbb_brandName.SelectedValue != null)
            {
                if (int.TryParse(cbb_brandName.SelectedValue.ToString(), out int id))
                {
                    selectedBrandID = id;
                }
            }
        }
        private void CategoriesEditLoad()
        {
            DataTable dt = dm.categoryDataBind();
            #region filePath active here

            dgv_editCategory.DataSource = dt;
            dgv_editCategory.Columns["BrandIDFK"].Visible = false;
            dgv_editCategory.Columns["CategoryID"].Visible = false;
            dgv_editCategory.Columns["Category Image Name"].Visible = false;

            foreach (DataGridViewColumn column in dgv_editCategory.Columns)
            {
                if (column.Name == "S/N")
                {
                    column.Width = 50;
                }
                if (column.Name == "Brand Name")
                {
                    column.Width = 200;
                }
                if (column.Name == "Category Name")
                {
                    column.Width = 200;
                }
                if (column.Name == "Is Category Active For Sale")
                {
                    column.Width = 150;
                }

                if (column.Name == "Category Image")
                {

                    if (dgv_editCategory.Columns["Category Image"] is DataGridViewImageColumn imageCol)
                    {
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.Width = 100;
                        dgv_editCategory.RowTemplate.Height = 100;
                    }
                }
            }
            #endregion
        }

        private void dgv_editCategory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tb_categoryName.Enabled = true;
            cbb_brandName.Enabled = true;
            cb_categoryActive.Enabled = true;
            tb_description.Enabled = true;
            btn_clear.Enabled = true;
            btn_selectImage.Enabled = true;
            btn_save.Enabled = true;

            DataGridViewRow selectedRow = dgv_editCategory.Rows[e.RowIndex];
            brandIDFK = selectedRow.Cells["BrandIDFK"].Value.ToString();
            cbb_brandName.SelectedValue = Convert.ToInt32(selectedRow.Cells["BrandIDFK"].Value);
            categoryID = selectedRow.Cells["CategoryID"].Value.ToString();
            tb_categoryName.Text = selectedRow.Cells["Category Name"].Value.ToString();
            cb_categoryActive.Checked = selectedRow.Cells["Is Category Active For Sale"].Value.ToString() == "Yes" ? true : false;
            tb_description.Text = selectedRow.Cells["Description"].Value.ToString();
            imageForEdit = dm.listImageForEditCategories(selectedRow.Cells["CategoryID"].Value.ToString());
            pb_categoryImage.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\CategoriesImages", imageForEdit);
            pb_categoryImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btn_selectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".jpeg" || fi.Extension == ".png")
                {
                    pb_categoryImage.SizeMode = PictureBoxSizeMode.Zoom;
                    pb_categoryImage.ImageLocation = fi.FullName;
                    selectedImagePath = fi.FullName;
                    imageName = Guid.NewGuid().ToString() + fi.Extension;
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_categoryName.Text = "";
            tb_description.Text = "";
            cb_categoryActive.Checked = false;
            imageName = "";
            selectedImagePath = "";
            destinationImagePath = "";
            pb_categoryImage.ImageLocation = "";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string categoryName = "";
            string description = "";
            //bool isDeleted = false; // In order for the categories to be active, its deleted status must be false.
            bool isActive;

            if (!string.IsNullOrEmpty(tb_categoryName.Text))
            {
                byte checkCategoryName = dm.listCategories(tb_categoryName.Text.ToUpper(), cbb_brandName.SelectedValue.ToString());
                if (checkCategoryName == 0)
                {
                    if (tb_categoryName.Text.Length < 50)
                    {
                        if (!string.IsNullOrEmpty(imageName))
                        {
                            categoryName = tb_categoryName.Text.ToUpper();
                            isActive = cb_categoryActive.Checked;
                            brandIDFK = cbb_brandName.SelectedValue.ToString();
                            description = tb_description.Text;
                            dm.editCategory(categoryID, brandIDFK, categoryName, description, isActive, imageName);
                            destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\CategoriesImages", imageName);
                            destinationImagePath = Path.GetFullPath(destinationImagePath);
                            File.Copy(selectedImagePath, destinationImagePath, true);
                            tb_categoryName.Text = "";
                            cb_categoryActive.Checked = false;
                            imageName = "";
                            pb_categoryImage.ImageLocation = "";
                            CategoriesEditLoad();
                            tb_categoryName.Enabled = false;
                            cbb_brandName.Enabled = false;
                            cb_categoryActive.Enabled = false;
                            tb_description.Enabled = false;
                            btn_clear.Enabled = false;
                            btn_selectImage.Enabled = false;
                            btn_save.Enabled = false;
                        }
                        else
                        {
                            categoryName = tb_categoryName.Text.ToUpper();
                            isActive = cb_categoryActive.Checked;
                            brandIDFK = cbb_brandName.SelectedValue.ToString();
                            description = tb_description.Text;
                            imageName = imageForEdit;
                            dm.editCategory(categoryID, brandIDFK, categoryName, description, isActive, imageName);
                            tb_categoryName.Text = "";
                            cb_categoryActive.Checked = false;
                            imageName = "";
                            pb_categoryImage.ImageLocation = "";
                            CategoriesEditLoad();
                            tb_categoryName.Enabled = false;
                            cbb_brandName.Enabled = false;
                            cb_categoryActive.Enabled = false;
                            tb_description.Enabled = false;
                            btn_clear.Enabled = false;
                            btn_selectImage.Enabled = false;
                            btn_save.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Category name too long, it can be max 50 character!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    if (!string.IsNullOrEmpty(imageName))
                    {
               
                        isActive = cb_categoryActive.Checked;
                        brandIDFK = cbb_brandName.SelectedValue.ToString();
                        description = tb_description.Text;
                        dm.editCategory(categoryID, brandIDFK, description, isActive, imageName);
                        destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\CategoriesImages", imageName);
                        destinationImagePath = Path.GetFullPath(destinationImagePath);
                        File.Copy(selectedImagePath, destinationImagePath, true);
                        tb_categoryName.Text = "";
                        cb_categoryActive.Checked = false;
                        imageName = "";
                        pb_categoryImage.ImageLocation = "";
                        CategoriesEditLoad();
                        tb_categoryName.Enabled = false;
                        cbb_brandName.Enabled = false;
                        cb_categoryActive.Enabled = false;
                        tb_description.Enabled = false;
                        btn_clear.Enabled = false;
                        btn_selectImage.Enabled = false;
                        btn_save.Enabled = false;
                    }
                    else
                    {
                     
                        isActive = cb_categoryActive.Checked;
                        brandIDFK = cbb_brandName.SelectedValue.ToString();
                        description = tb_description.Text;
                        imageName = imageForEdit;
                        dm.editCategory(categoryID, brandIDFK, description, isActive, imageName);
                        tb_categoryName.Text = "";
                        cb_categoryActive.Checked = false;
                        imageName = "";
                        pb_categoryImage.ImageLocation = "";
                        CategoriesEditLoad();
                        tb_categoryName.Enabled = false;
                        cbb_brandName.Enabled = false;
                        cb_categoryActive.Enabled = false;
                        tb_description.Enabled = false;
                        btn_clear.Enabled = false;
                        btn_selectImage.Enabled = false;
                        btn_save.Enabled = false;
                    }

                }
            }
            else
            {
                MessageBox.Show("Category name cannot empty!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}