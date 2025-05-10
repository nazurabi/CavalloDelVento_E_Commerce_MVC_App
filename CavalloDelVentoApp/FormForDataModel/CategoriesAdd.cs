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
    public partial class CategoriesAdd : Form
    {
        DataModel dm = new DataModel();
        string imageName = "";
        string selectedImagePath = "";
        string destinationImagePath = "";
        int selectedBrandID = -1;
        public CategoriesAdd()
        {
            InitializeComponent();
        }
  
        private void CategoriesAdd_Load(object sender, EventArgs e)
        {
            CategoriesAddLoad();
            comboBoxBrandsLoad();
        }

        private void CategoriesAddLoad()
        {
            DataTable dt = dm.categoryDataBind();

            dgv_addCategory.DataSource = dt;
            dgv_addCategory.RowHeadersVisible = false;
            dgv_addCategory.Columns["BrandIDFK"].Visible = false;
            dgv_addCategory.Columns["CategoryID"].Visible = false;
            dgv_addCategory.Columns["Category Image Name"].Visible = false;

            #region Image Column and Sequence Number Settings

            int dgvaddBrandColumnWidth = dgv_addCategory.Width - 100; // 100 = Image Column Width
            int otherColumnCount = dgv_addCategory.Columns.Count - 2; // (2 --> S/N and Image Column)
            int columnWidth = dgvaddBrandColumnWidth / otherColumnCount;

            for (int i = 0; i < otherColumnCount; i++)
            {
                dgv_addCategory.Columns[i].Width = columnWidth;
            }
            foreach (DataGridViewColumn column in dgv_addCategory.Columns)
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
                    dgv_addCategory.RowTemplate.Height = 100;
                }
            }

            #endregion
        }

        private void dgv_addCategory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_addCategory.Rows)
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

        private void comboBoxBrandsLoad()
        {
            List<Brands> brands = dm.getBrandsForCategories();
            brands.Insert(0, new Brands { brandID = 0, brandName = "---Choose---" });
            cbb_brandName.DataSource = brands;
            cbb_brandName.DisplayMember = "BrandName";
            cbb_brandName.ValueMember = "BrandID";
            cbb_brandName.SelectedIndex = 0;
        }

        private void cbb_brandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_brandName.SelectedIndex != 0 && cbb_brandName.SelectedValue != null)
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
            string brandIDFK = "";
            string categoryName = "";
            string description = "";
            bool isDeleted = false; // In order for the categories to be active, its deleted status must be false.
            bool isActive;
            if (selectedBrandID != -1)
            {
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
                                dm.addCategory(brandIDFK, categoryName, isDeleted, isActive, description, imageName);
                                destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\CategoriesImages", imageName);
                                destinationImagePath = Path.GetFullPath(destinationImagePath);
                                File.Copy(selectedImagePath, destinationImagePath, true);
                                tb_categoryName.Text = "";
                                cb_categoryActive.Checked = false;
                                imageName = "";
                                pb_categoryImage.ImageLocation = "";
                                tb_description.Text = "";
                                CategoriesAddLoad();
                            }
                            else
                            {
                                categoryName = tb_categoryName.Text.ToUpper();
                                isActive = cb_categoryActive.Checked;
                                brandIDFK = cbb_brandName.SelectedValue.ToString();
                                description = tb_description.Text;
                                imageName = "none.jpg";
                                dm.addCategory(brandIDFK, categoryName, isDeleted, isActive, description, imageName);
                                tb_categoryName.Text = "";
                                cb_categoryActive.Checked = false;
                                imageName = "";
                                pb_categoryImage.ImageLocation = "";
                                tb_description.Text = "";
                                CategoriesAddLoad();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Category name too long, it can be max 50 character!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Category name has already been entered, please check your information!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Category name cannot empty!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You cannot select Brand, please select Brand!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
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

    }
}
