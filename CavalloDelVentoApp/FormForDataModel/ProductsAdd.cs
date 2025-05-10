using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DataModelWithADO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;

namespace FormForDataModel
{

    public partial class ProductsAdd : Form
    {
        DataModel dm = new DataModel();
        string imageName = "";
        string selectedImagePath = "";
        string destinationImagePath = "";
        int selectedBrandID = -1;
        int selectedCategoryID = -1;

        public ProductsAdd()
        {
            InitializeComponent();
        }

        private void ProductsAdd_Load(object sender, EventArgs e)
        {
            ProductsAddLoad();
            ComboBoxBrandsLoad();
            ComboBoxCategoriesLoad();

        }

        private void ProductsAddLoad()
        {
            DataTable dt = dm.productsDataBind();
            dgv_addProduct.DataSource = dt;
            dgv_addProduct.RowHeadersVisible = false;
            dgv_addProduct.Columns["ProductID"].Visible = false;
            dgv_addProduct.Columns["BrandIDFK"].Visible = false;
            dgv_addProduct.Columns["CategoryIDFK"].Visible = false;
            dgv_addProduct.Columns["ProductID"].Visible = false;
            dgv_addProduct.Columns["Product Image Name"].Visible = false;

            #region Image Column and Sequence Number Settings

            int dgvaddBrandColumnWidth = dgv_addProduct.Width - 100; // 100 = Image Column Width
            int otherColumnCount = dgv_addProduct.Columns.Count - 6; // (6 --> S/N, ProductID, BrandIDFK, CategoryIDFK, Image, Image Name Column)
            int columnWidth = dgvaddBrandColumnWidth / otherColumnCount;

            for (int i = 0; i < otherColumnCount; i++)
            {
                dgv_addProduct.Columns[i].Width = columnWidth;
            }
            foreach (DataGridViewColumn column in dgv_addProduct.Columns)
            {
                if (column.Name == "S/N")
                {
                    column.Width = 50;
                }
                if (column.Name == "Product Image")
                {
                    DataGridViewImageColumn imageCol = (DataGridViewImageColumn)column;
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 100;
                    dgv_addProduct.RowTemplate.Height = 100;
                }
            }

            #endregion
        }

        private void dgv_addProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_addProduct.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                    rows.Cells["Is Deleted"].Style.ForeColor = Color.Red;
                    //rows.DefaultCellStyle.ForeColor = Color.Red;
                }

                if (rows.Cells["Is Product Active For Sale"].Value.ToString() == "No")
                {
                    rows.Cells["Is Product Active For Sale"].Style.ForeColor = Color.Red;
                }
            }


        }

        private void ComboBoxCategoriesLoad()
        {
            List<Categories> categories = dm.getCategoriesForProducts(selectedBrandID.ToString());
            categories.Insert(0, new Categories { categoryID = 0, categoryName = "---Choose---" });
            cbb_categoryName.DataSource = categories;
            cbb_categoryName.DisplayMember = "categoryName";
            cbb_categoryName.ValueMember = "categoryID";
            cbb_categoryName.SelectedIndex = 0;
        }

        private void ComboBoxBrandsLoad()
        {
            List<Brands> brands = dm.getBrandsForProducts();
            brands.Insert(0, new Brands { brandID = 0, brandName = "---Choose---" });
            cbb_brandName.DataSource = brands;
            cbb_brandName.DisplayMember = "brandName";
            cbb_brandName.ValueMember = "brandID";
            cbb_brandName.SelectedIndex = 0;
        }

        private void btn_selectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".jpeg" || fi.Extension == ".png")
                {
                    pb_productImage.SizeMode = PictureBoxSizeMode.Zoom;
                    pb_productImage.ImageLocation = fi.FullName;
                    selectedImagePath = fi.FullName;
                    imageName = Guid.NewGuid().ToString() + fi.Extension;
                }
            }
        }

        private void cbb_brandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_brandName.SelectedIndex != 0 && cbb_brandName.SelectedValue != null)
            {
                if (int.TryParse(cbb_brandName.SelectedValue.ToString(), out int id))
                {
                    selectedBrandID = id;
                    ComboBoxCategoriesLoad();
                }
            }
        }

        private void cbb_categoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_categoryName.SelectedIndex != 0 && cbb_categoryName.SelectedValue != null)
            {
                if (int.TryParse(cbb_categoryName.SelectedValue.ToString(), out int id))
                {
                    selectedCategoryID = id;
                }
            }
        }

        private void nud_products_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string brandIDFK = "";
            string categoryIDFK = "";
            string productName = "";
            string quantityPerUnit = "";
            decimal unitPrice = 0;
            string unitInStock = "";
            string unitsOnOrder = "";
            string reorderLevel = "";
            string description = "";
            bool isDeleted = false; // In order for the product to be active, its deleted status must be false.
            bool discontinued = false;//  In order for the product to be active, its discontinued status must be false.
            bool isActive;
            if (selectedBrandID != -1 && selectedCategoryID != -1)
            {
                if (!string.IsNullOrEmpty(tb_productName.Text))
                {
                    byte checkProductName = dm.listProducts(tb_productName.Text.ToUpper(), cbb_brandName.SelectedValue.ToString(), cbb_categoryName.SelectedValue.ToString());
                    if (checkProductName == 0)
                    {
                        if (tb_productName.Text.Length < 50)
                        {
                            if (!string.IsNullOrEmpty(imageName))
                            {
                                productName = tb_productName.Text.ToUpper();
                                quantityPerUnit = tb_quentityPerUnit.Text;
                                unitPrice = nud_products.Value;
                                unitInStock = tb_unitsInStock.Text;
                                reorderLevel = tb_reorderLevel.Text;
                                isActive = cb_productActive.Checked;
                                brandIDFK = cbb_brandName.SelectedValue.ToString();
                                categoryIDFK = cbb_categoryName.SelectedValue.ToString();
                                description = tb_description.Text;
                                dm.addProduct(brandIDFK, categoryIDFK, productName, description, imageName, quantityPerUnit, unitPrice, unitInStock, unitsOnOrder, reorderLevel, discontinued, isDeleted, isActive);
                                destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages", imageName);
                                destinationImagePath = Path.GetFullPath(destinationImagePath);
                                File.Copy(selectedImagePath, destinationImagePath, true);
                                tb_productName.Text = "";
                                tb_quentityPerUnit.Text = "";
                                nud_products.Value = 0;
                                tb_unitsInStock.Text = "";
                                tb_reorderLevel.Text = "";
                                tb_description.Text = "";
                                cb_productActive.Checked = false;
                                imageName = "";
                                pb_productImage.ImageLocation = "";
                                ProductsAddLoad();
                            }
                            else
                            {
                                productName = tb_productName.Text.ToUpper();
                                quantityPerUnit = tb_quentityPerUnit.Text;
                                unitPrice = nud_products.Value;
                                unitInStock = tb_unitsInStock.Text;
                                reorderLevel = tb_reorderLevel.Text;
                                isActive = cb_productActive.Checked;
                                brandIDFK = cbb_brandName.SelectedValue.ToString();
                                categoryIDFK = cbb_categoryName.SelectedValue.ToString();
                                description = tb_description.Text;
                                imageName = "none.jpg";
                                dm.addProduct(brandIDFK, categoryIDFK, productName, description, imageName, quantityPerUnit, unitPrice, unitInStock, unitsOnOrder, reorderLevel, discontinued, isDeleted, isActive);
                                tb_productName.Text = "";
                                tb_quentityPerUnit.Text = "";
                                nud_products.Value = 0;
                                tb_unitsInStock.Text = "";
                                tb_reorderLevel.Text = "";
                                tb_description.Text = "";
                                cb_productActive.Checked = false;
                                imageName = "";
                                pb_productImage.ImageLocation = "";
                                ProductsAddLoad();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Product name too long, it can be max 50 character!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product name has already been entered, please check your information!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Product name cannot empty!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You cannot select Brand or Category, please select them!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_productName.Text = "";
            tb_description.Text = "";
            tb_quentityPerUnit.Text = "";
            tb_unitsInStock.Text = "";
            tb_reorderLevel.Text = "";
            nud_products.Value = 0;
            cb_productActive.Checked = false;
            imageName = "";
            selectedImagePath = "";
            destinationImagePath = "";
            pb_productImage.ImageLocation = "";
        }

        private void tb_unitsInStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void tb_reorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
