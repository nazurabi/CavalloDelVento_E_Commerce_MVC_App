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

        private void CategoriesEditLoad()
        {
            DataTable dt = dm.categoryDataBind();

            dgv_editCategory.DataSource = dt;
            dgv_editCategory.Columns["BrandIDFK"].Visible = false;
            dgv_editCategory.Columns["CategoryID"].Visible = false;
            dgv_editCategory.Columns["Category Image Name"].Visible = false;

            #region Image Column and Sequence Number Settings

            int dgvaddBrandColumnWidth = dgv_editCategory.Width - dgv_editCategory.RowHeadersWidth - 100; // 100 = Image Column Width
            int otherColumnCount = dgv_editCategory.Columns.Count - 2; // (2 --> S/N and Image Column)
            int columnWidth = dgvaddBrandColumnWidth / otherColumnCount;

            for (int i = 0; i < otherColumnCount; i++)
            {
                dgv_editCategory.Columns[i].Width = columnWidth;
            }
            foreach (DataGridViewColumn column in dgv_editCategory.Columns)
            {
                if (column.Name == "S/N")
                {
                    column.Width = 50;
                }
                if (column.Name == "Category Image")
                {
                    DataGridViewImageColumn imageCol = (DataGridViewImageColumn)column;
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 100;
                    dgv_editCategory.RowTemplate.Height = 100;
                }
            }

            #endregion
        }

        private void dgv_editCategory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_editCategory.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                    rows.Cells["Is Deleted"].Style.ForeColor = Color.Red;
                }

                if (rows.Cells["Is Category Active For Sale"].Value.ToString() == "No")
                {
                    rows.Cells["Is Category Active For Sale"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void dgv_editCategory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tb_categoryName.Enabled = true;
            cbb_brandName.Enabled = true;
            cb_categoryActive.Enabled = true;
            cb_categoryDelete.Enabled = true;
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
            cb_categoryDelete.Checked = selectedRow.Cells["Is Deleted"].Value.ToString() == "Yes" ? true : false;
            tb_description.Text = selectedRow.Cells["Description"].Value.ToString();
            imageForEdit = dm.listImageForEditCategories(selectedRow.Cells["CategoryID"].Value.ToString());
            pb_categoryImage.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\CategoriesImages", imageForEdit);
            pb_categoryImage.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            string categoryName = "";
            string description = "";
            bool isDeleted;
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
                            isDeleted = cb_categoryDelete.Checked;
                            isActive = isDeleted ? false : cb_categoryActive.Checked;
                            brandIDFK = cbb_brandName.SelectedValue.ToString();
                            description = tb_description.Text;
                            dm.editCategory(categoryID, brandIDFK, categoryName, description, isActive,isDeleted, imageName);
                            destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\CategoriesImages", imageName);
                            destinationImagePath = Path.GetFullPath(destinationImagePath);
                            File.Copy(selectedImagePath, destinationImagePath, true);
                            tb_categoryName.Text = "";
                            tb_description.Text = "";
                            cb_categoryActive.Checked = false;
                            cb_categoryDelete.Checked = false;
                            imageName = "";
                            pb_categoryImage.ImageLocation = "";
                            CategoriesEditLoad();
                            tb_categoryName.Enabled = false;
                            cbb_brandName.Enabled = false;
                            cb_categoryActive.Enabled = false;
                            cb_categoryDelete.Enabled = false;
                            tb_description.Enabled = false;
                            btn_clear.Enabled = false;
                            btn_selectImage.Enabled = false;
                            btn_save.Enabled = false;
                        }
                        else
                        {
                            categoryName = tb_categoryName.Text.ToUpper();
                            isDeleted = cb_categoryDelete.Checked;
                            isActive = isDeleted ? false : cb_categoryActive.Checked;
                            brandIDFK = cbb_brandName.SelectedValue.ToString();
                            description = tb_description.Text;
                            imageName = imageForEdit;
                            dm.editCategory(categoryID, brandIDFK, categoryName, description, isActive,isDeleted, imageName);
                            tb_categoryName.Text = "";
                            tb_description.Text = "";
                            cb_categoryActive.Checked = false;
                            cb_categoryDelete.Checked = false;
                            imageName = "";
                            pb_categoryImage.ImageLocation = "";
                         
                            CategoriesEditLoad();
                            tb_categoryName.Enabled = false;
                            cbb_brandName.Enabled = false;
                            cb_categoryActive.Enabled = false;
                            cb_categoryDelete.Enabled = false;
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

                        isDeleted = cb_categoryDelete.Checked;
                        isActive = isDeleted ? false : cb_categoryActive.Checked;
                        brandIDFK = cbb_brandName.SelectedValue.ToString();
                        description = tb_description.Text;
                        dm.editCategory(categoryID, brandIDFK, description, isActive,isDeleted, imageName);
                        destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\CategoriesImages", imageName);
                        destinationImagePath = Path.GetFullPath(destinationImagePath);
                        File.Copy(selectedImagePath, destinationImagePath, true);
                        tb_categoryName.Text = "";
                        tb_description.Text = "";
                        cb_categoryActive.Checked = false;
                        cb_categoryDelete.Checked = false;
                        imageName = "";
                        pb_categoryImage.ImageLocation = "";
                        CategoriesEditLoad();
                        tb_categoryName.Enabled = false;
                        cbb_brandName.Enabled = false;
                        cb_categoryActive.Enabled = false;
                        cb_categoryDelete.Enabled = false;
                        tb_description.Enabled = false;
                        btn_clear.Enabled = false;
                        btn_selectImage.Enabled = false;
                        btn_save.Enabled = false;
                    }
                    else
                    {
                        isDeleted = cb_categoryDelete.Checked;
                        isActive = isDeleted ? false : cb_categoryActive.Checked;
                        brandIDFK = cbb_brandName.SelectedValue.ToString();
                        description = tb_description.Text;
                        imageName = imageForEdit;
                        dm.editCategory(categoryID, brandIDFK, description, isActive,isDeleted, imageName);
                        tb_categoryName.Text = "";
                        tb_description.Text = "";
                        cb_categoryActive.Checked = false;
                        cb_categoryDelete.Checked = false;
                        imageName = "";
                        pb_categoryImage.ImageLocation = "";
                        CategoriesEditLoad();
                        tb_categoryName.Enabled = false;
                        cbb_brandName.Enabled = false;
                        cb_categoryActive.Enabled = false;
                        cb_categoryDelete.Enabled = false;
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_categoryName.Text = "";
            tb_description.Text = "";
            cb_categoryActive.Checked = false;
            cb_categoryDelete.Checked = false;
            imageName = "";
            selectedImagePath = "";
            destinationImagePath = "";
            pb_categoryImage.ImageLocation = "";
        }
    }
}