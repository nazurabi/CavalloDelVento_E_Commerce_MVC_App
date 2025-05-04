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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;

namespace FormForDataModel
{
    public partial class ProductsEdit : Form
    {
        DataModel dm = new DataModel();
        string productID = "";
        string brandIDFK = "";
        string categoryIDFK = "";
        string imageName = "";
        string imageForEdit = "";
        string selectedImagePath = "";
        string destinationImagePath = "";
        int selectedBrandID = -1;
        int selectedCategoryID = -1;
        public ProductsEdit()
        {
            InitializeComponent();
        }

        private void ProductsEdit_Load(object sender, EventArgs e)
        {
            ProductsEditLoad();
            comboBoxBrandsLoad();
            comboBoxCategoriesLoad();
        }

        private void comboBoxBrandsLoad()
        {
            List<Brands> brands = dm.getBrandsForProducts();
            brands.Insert(0, new Brands { brandID = 0, brandName = "---Choose---" });
            cbb_brandName.DataSource = brands;
            cbb_brandName.DisplayMember = "brandName";
            cbb_brandName.ValueMember = "brandID";
            cbb_brandName.SelectedIndex = 0;
        }

        private void comboBoxCategoriesLoad()
        {
            List<Categories> categories = dm.getCategoriesForProducts(selectedBrandID.ToString());
            categories.Insert(0, new Categories { categoryID = 0, categoryName = "---Choose---" });
            cbb_categoryName.DataSource = categories;
            cbb_categoryName.DisplayMember = "categoryName";
            cbb_categoryName.ValueMember = "categoryID";
            cbb_categoryName.SelectedIndex = 0;
        }

        private void ProductsEditLoad()
        {
            DataTable dt = dm.productsDataBind();
            dgv_editProduct.DataSource = dt;
            dgv_editProduct.Columns["ProductID"].Visible = false;
            dgv_editProduct.Columns["BrandIDFK"].Visible = false;
            dgv_editProduct.Columns["CategoryIDFK"].Visible = false;
            dgv_editProduct.Columns["ProductID"].Visible = false;
            dgv_editProduct.Columns["Product Image Name"].Visible = false;
            dgv_editProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            #region Image Column and Sequence Number Settings

            int dgvaddBrandColumnWidth = dgv_editProduct.Width - dgv_editProduct.RowHeadersWidth - 100; // 100 = Image Column Width
            int otherColumnCount = dgv_editProduct.Columns.Count - 6; // (6 --> S/N, ProductID, BrandIDFK, CategoryIDFK, Image, Image Name Column)
            int columnWidth = dgvaddBrandColumnWidth / otherColumnCount;

            for (int i = 0; i < otherColumnCount; i++)
            {
                dgv_editProduct.Columns[i].Width = columnWidth;
            }
            foreach (DataGridViewColumn column in dgv_editProduct.Columns)
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
                    dgv_editProduct.RowTemplate.Height = 100;
                }
            }

            #endregion
        }

        private void cbb_brandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_brandName.SelectedIndex != 0 && cbb_brandName.SelectedValue != null)
            {
                if (int.TryParse(cbb_brandName.SelectedValue.ToString(), out int id))
                {
                    selectedBrandID = id;
                    comboBoxCategoriesLoad();
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

        private void dgv_addProduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tb_productName.Enabled = true;
            cbb_brandName.Enabled = true;
            cbb_categoryName.Enabled = true;
            cb_productActive.Enabled = true;
            cb_productDiscontinued.Enabled = true;
            cb_productDeleted.Enabled = true;
            tb_quentityPerUnit.Enabled = true;
            nud_products.Enabled = true;
            tb_unitsInStock.Enabled = true;
            tb_reorderLevel.Enabled = true;
            tb_description.Enabled = true;
            btn_clear.Enabled = true;
            btn_selectImage.Enabled = true;
            btn_save.Enabled = true;

            DataGridViewRow selectedRow = dgv_editProduct.Rows[e.RowIndex];
            productID = selectedRow.Cells["ProductID"].Value.ToString();
            brandIDFK = selectedRow.Cells["BrandIDFK"].Value.ToString();
            cbb_brandName.SelectedValue = Convert.ToInt32(selectedRow.Cells["BrandIDFK"].Value);
            categoryIDFK = selectedRow.Cells["CategoryIDFK"].Value.ToString();
            cbb_categoryName.SelectedValue = Convert.ToInt32(selectedRow.Cells["CategoryIDFK"].Value);
            tb_productName.Text = selectedRow.Cells["Product Name"].Value.ToString();
            tb_quentityPerUnit.Text = selectedRow.Cells["Quantity Per Unit"].Value.ToString();
            nud_products.Text = selectedRow.Cells["Unit Price"].Value.ToString();
            tb_unitsInStock.Text = selectedRow.Cells["Units In Stock"].Value.ToString();
            tb_reorderLevel.Text = selectedRow.Cells["Reorder Level"].Value.ToString();
            tb_description.Text = selectedRow.Cells["Description"].Value.ToString();
            cb_productActive.Checked = selectedRow.Cells["Is Product Active For Sale"].Value.ToString() == "Yes" ? true : false;
            cb_productDeleted.Checked = selectedRow.Cells["Is Deleted"].Value.ToString() == "Yes" ? true : false;
            cb_productDiscontinued.Checked = selectedRow.Cells["Discontinued"].Value.ToString() == "Yes" ? true : false;
            imageForEdit = dm.listImageForEditProducts(selectedRow.Cells["ProductID"].Value.ToString());
            pb_productImage.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages", imageForEdit);
            pb_productImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void dgv_editProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_editProduct.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                    rows.DefaultCellStyle.ForeColor = Color.Red;
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
                    pb_productImage.SizeMode = PictureBoxSizeMode.Zoom;
                    pb_productImage.ImageLocation = fi.FullName;
                    selectedImagePath = fi.FullName;
                    imageName = Guid.NewGuid().ToString() + fi.Extension;
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
            string productName = "";
            string quantityPerUnit = "";
            decimal unitPrice = 0;
            string unitInStock = "";
            string reorderLevel = "";
            string description = "";
            bool isDeleted = false; // In order for the product to be active, its deleted status must be false.
            bool discontinued = false;//  In order for the product to be active, its discontinued status must be false.
            bool isActive;

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
                            isDeleted = cb_productDeleted.Checked;
                            isActive = isDeleted ? false : cb_productActive.Checked;
                            discontinued = cb_productDiscontinued.Checked;
                            brandIDFK = cbb_brandName.SelectedValue.ToString();
                            categoryIDFK = cbb_categoryName.SelectedValue.ToString();
                            description = tb_description.Text;
                            dm.editProduct(productID, brandIDFK, categoryIDFK, productName, description, imageName, quantityPerUnit, unitPrice, unitInStock, reorderLevel, discontinued, isDeleted, isActive);
                            destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages", imageName);
                            destinationImagePath = Path.GetFullPath(destinationImagePath);
                            File.Copy(selectedImagePath, destinationImagePath, true);
                            tb_productName.Text = "";
                            cb_productDiscontinued.Checked = false;
                            cb_productDeleted.Checked = false;
                            cb_productActive.Checked = false;
                            tb_quentityPerUnit.Text = "";
                            nud_products.Value = 0;
                            tb_unitsInStock.Text = "";
                            tb_reorderLevel.Text = "";
                            tb_description.Text = "";
                            imageName = "";
                            pb_productImage.ImageLocation = "";
                            ProductsEditLoad();
                            tb_productName.Enabled = false;
                            cbb_brandName.Enabled = false;
                            cbb_categoryName.Enabled = false;
                            cb_productActive.Enabled = false;
                            cb_productDiscontinued.Enabled = false;
                            cb_productDeleted.Enabled = false;
                            tb_quentityPerUnit.Enabled = false;
                            nud_products.Enabled = false;
                            tb_unitsInStock.Enabled = false;
                            tb_reorderLevel.Enabled = false;
                            tb_description.Enabled = false;
                            btn_clear.Enabled = false;
                            btn_selectImage.Enabled = false;
                            btn_save.Enabled = false;

                        }
                        else
                        {
                            productName = tb_productName.Text.ToUpper();
                            quantityPerUnit = tb_quentityPerUnit.Text;
                            unitPrice = nud_products.Value;
                            unitInStock = tb_unitsInStock.Text;
                            reorderLevel = tb_reorderLevel.Text;
                            isDeleted = cb_productDeleted.Checked;
                            isActive = isDeleted ? false : cb_productActive.Checked;
                            discontinued = cb_productDiscontinued.Checked;
                            brandIDFK = cbb_brandName.SelectedValue.ToString();
                            categoryIDFK = cbb_categoryName.SelectedValue.ToString();
                            description = tb_description.Text;
                            imageName = imageForEdit;
                            dm.editProduct(productID, brandIDFK, categoryIDFK, productName, description, imageName, quantityPerUnit, unitPrice, unitInStock, reorderLevel, discontinued, isDeleted, isActive);
                            tb_productName.Text = "";
                            cb_productDiscontinued.Checked = false;
                            cb_productDeleted.Checked = false;
                            cb_productActive.Checked = false;
                            tb_quentityPerUnit.Text = "";
                            nud_products.Value = 0;
                            tb_unitsInStock.Text = "";
                            tb_reorderLevel.Text = "";
                            tb_description.Text = "";
                            imageName = "";
                            pb_productImage.ImageLocation = "";
                            ProductsEditLoad();
                            tb_productName.Enabled = false;
                            cbb_brandName.Enabled = false;
                            cbb_categoryName.Enabled = false;
                            cb_productActive.Enabled = false;
                            cb_productDiscontinued.Enabled = false;
                            cb_productDeleted.Enabled = false;
                            tb_quentityPerUnit.Enabled = false;
                            nud_products.Enabled = false;
                            tb_unitsInStock.Enabled = false;
                            tb_reorderLevel.Enabled = false;
                            tb_description.Enabled = false;
                            btn_clear.Enabled = false;
                            btn_selectImage.Enabled = false;
                            btn_save.Enabled = false;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Product name too long, it can be max 50 character!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(imageName))
                    {
                        quantityPerUnit = tb_quentityPerUnit.Text;
                        unitPrice = nud_products.Value;
                        unitInStock = tb_unitsInStock.Text;
                        reorderLevel = tb_reorderLevel.Text;
                        isDeleted = cb_productDeleted.Checked;
                        isActive = isDeleted ? false : cb_productActive.Checked;
                        discontinued = cb_productDiscontinued.Checked;
                        brandIDFK = cbb_brandName.SelectedValue.ToString();
                        categoryIDFK = cbb_categoryName.SelectedValue.ToString();
                        description = tb_description.Text;
                        dm.editProduct(productID, brandIDFK, categoryIDFK, description, imageName, quantityPerUnit, unitPrice, unitInStock, reorderLevel, discontinued, isDeleted, isActive);
                        destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages", imageName);
                        destinationImagePath = Path.GetFullPath(destinationImagePath);
                        File.Copy(selectedImagePath, destinationImagePath, true);
                        tb_productName.Text = "";
                        cb_productDiscontinued.Checked = false;
                        cb_productDeleted.Checked = false;
                        cb_productActive.Checked = false;
                        tb_quentityPerUnit.Text = "";
                        nud_products.Value = 0;
                        tb_unitsInStock.Text = "";
                        tb_reorderLevel.Text = "";
                        tb_description.Text = "";
                        imageName = "";
                        pb_productImage.ImageLocation = "";
                        ProductsEditLoad();
                        tb_productName.Enabled = false;
                        cbb_brandName.Enabled = false;
                        cbb_categoryName.Enabled = false;
                        cb_productActive.Enabled = false;
                        cb_productDiscontinued.Enabled = false;
                        cb_productDeleted.Enabled = false;
                        tb_quentityPerUnit.Enabled = false;
                        nud_products.Enabled = false;
                        tb_unitsInStock.Enabled = false;
                        tb_reorderLevel.Enabled = false;
                        tb_description.Enabled = false;
                        btn_clear.Enabled = false;
                        btn_selectImage.Enabled = false;
                        btn_save.Enabled = false;
                    }
                    else
                    {
                        quantityPerUnit = tb_quentityPerUnit.Text;
                        unitPrice = nud_products.Value;
                        unitInStock = tb_unitsInStock.Text;
                        reorderLevel = tb_reorderLevel.Text;
                        isDeleted = cb_productDeleted.Checked;
                        isActive = isDeleted ? false : cb_productActive.Checked;
                        discontinued = cb_productDiscontinued.Checked;
                        brandIDFK = cbb_brandName.SelectedValue.ToString();
                        categoryIDFK = cbb_categoryName.SelectedValue.ToString();
                        description = tb_description.Text;
                        imageName = imageForEdit;
                        dm.editProduct(productID, brandIDFK, categoryIDFK, description, imageName, quantityPerUnit, unitPrice, unitInStock, reorderLevel, discontinued, isDeleted, isActive);
                        tb_productName.Text = "";
                        cb_productDiscontinued.Checked = false;
                        cb_productDeleted.Checked = false;
                        cb_productActive.Checked = false;
                        tb_quentityPerUnit.Text = "";
                        nud_products.Value = 0;
                        tb_unitsInStock.Text = "";
                        tb_reorderLevel.Text = "";
                        tb_description.Text = "";
                        imageName = "";
                        pb_productImage.ImageLocation = "";
                        ProductsEditLoad();
                        tb_productName.Enabled = false;
                        cbb_brandName.Enabled = false;
                        cbb_categoryName.Enabled = false;
                        cb_productActive.Enabled = false;
                        cb_productDiscontinued.Enabled = false;
                        cb_productDeleted.Enabled = false;
                        tb_quentityPerUnit.Enabled = false;
                        nud_products.Enabled = false;
                        tb_unitsInStock.Enabled = false;
                        tb_reorderLevel.Enabled = false;
                        tb_description.Enabled = false;
                        btn_clear.Enabled = false;
                        btn_selectImage.Enabled = false;
                        btn_save.Enabled = false;
                    }
                }

            }
            else
            {
                MessageBox.Show("Product name cannot empty!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
