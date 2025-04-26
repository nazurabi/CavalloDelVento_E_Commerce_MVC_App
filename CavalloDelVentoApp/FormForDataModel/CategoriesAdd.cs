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
        public CategoriesAdd()
        {
            InitializeComponent();
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
        private void CategoriesAdd_Load(object sender, EventArgs e)
        {
            CategoriesAddLoad();
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
                dgvVisualTable.Rows.Add(sequenceNumber, returnedBrandName,returnedCategoryName, returnedIsActiveForSale, img);
            }
            dgv_addCategory.DataSource = dgvVisualTable;
            dgv_addCategory.RowHeadersVisible = false;

            foreach (DataGridViewColumn column in dgv_addCategory.Columns)
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

                    if (dgv_addCategory.Columns["Category Image"] is DataGridViewImageColumn imageCol)
                    {
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.Width = 100;
                        dgv_addCategory.RowTemplate.Height = 100;
                    }
                }
            }
            #endregion
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_categoryName.Text = "";
            cb_categoryActive.Checked = false;
            imageName = "";
            selectedImagePath = "";
            destinationImagePath = "";
            pb_categoryImage.ImageLocation = "";
        }

        private void btn_save_Click(object sender, EventArgs e) // en son listbox üzerine markaları alıyordun
        {
            string brandName = "";
            string categoryName = "";
            bool isDeleted = false; // In order for the brand to be active, its deleted status must be false.
            bool isActive;
            if (!string.IsNullOrEmpty(tb_categoryName.Text))
            {
                byte checkBrandName = dm.listBrands(tb_categoryName.Text.ToUpper());
                if (checkBrandName == 0)
                {
                    if (tb_categoryName.Text.Length < 50)
                    {
                        if (!string.IsNullOrEmpty(imageName))
                        {
                            categoryName = tb_categoryName.Text.ToUpper();
                            isActive = cb_categoryActive.Checked;
                            dm.addCategory(brandName, isDeleted, isActive, imageName);
                            destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageName);
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
                            imageName = "none.jpg";
                            dm.addCategory(brandName, isDeleted, isActive, imageName);
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
    }
}
