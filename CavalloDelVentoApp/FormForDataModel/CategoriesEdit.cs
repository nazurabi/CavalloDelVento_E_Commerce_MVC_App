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
            CategoriesAddLoad();
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
        private void CategoriesAddLoad()
        {
            DataTable dt = dm.categoryDataBind();
            #region filePath active here

            DataTable dgvVisualTable = new DataTable();
            dgvVisualTable.Columns.Add("S/N", typeof(string));
            dgvVisualTable.Columns.Add("Brand Name", typeof(string));
            dgvVisualTable.Columns.Add("Category Name", typeof(string));
            dgvVisualTable.Columns.Add("Is Category Active For Sale", typeof(string));
            dgvVisualTable.Columns.Add("Category Image", typeof(Image));
            short sequenceNumber = 0;
            foreach (DataRow row in dt.Rows)
            {
                sequenceNumber++;
                string returnedBrandName = row["Brand Name"].ToString();
                string returnedCategoryName = row["Category Name"].ToString();
                string returnedIsActiveForSale = row["Is Category Active For Sale"].ToString();
                string returnedImage = row["Category Image"].ToString();
                Image img = null;
                if (File.Exists(returnedImage))
                {
                    img = Image.FromFile(returnedImage);
                }
                dgvVisualTable.Rows.Add(sequenceNumber, returnedBrandName, returnedCategoryName, returnedIsActiveForSale, img);
            }
            dgv_editCategory.DataSource = dgvVisualTable;
            dgv_editCategory.RowHeadersVisible = false;

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
            btn_clear.Enabled = true;
            btn_selectImage.Enabled = true;
            btn_save.Enabled = true;

            DataGridViewRow selectedRow = dgv_editCategory.Rows[e.RowIndex];
            tb_categoryName.Text = selectedRow.Cells["Category Name"].Value.ToString();
            cb_categoryActive.Checked = selectedRow.Cells["Is Brand Active For Sale"].Value.ToString() == "Yes" ? true : false;
            imageForEdit = dm.listImageForEditCategories(selectedRow.Cells["Category ID"].Value.ToString());
            categoryID = selectedRow.Cells["Category ID"].Value.ToString();
            pb_categoryImage.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageForEdit);
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
            string brandIDFK = "";
            string categoryName = "";
            string description = "";
            bool isDeleted = false; // In order for the brand to be active, its deleted status must be false.
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
                                CategoriesAddLoad();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Category name too long, it can be max 50 character!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Category name has already been entered, please check your information!");
                    }
                }
                else
                {
                    MessageBox.Show("Category name cannot empty!");
                }
            }
            else
            {
                MessageBox.Show("You cannot select Brand, please select Brand!");
            }
        }

       
    }
}
