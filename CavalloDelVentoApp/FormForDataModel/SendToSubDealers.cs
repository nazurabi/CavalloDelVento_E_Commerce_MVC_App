using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModelWithADO;

namespace FormForDataModel
{
    public partial class SendToSubDealers : Form
    {
        DataModel dm = new DataModel();
        string sendID = "";
        string brandIDFK = "";
        string categoryIDFK = "";
        string productIDFK = "";
        string productItemNumber = "";
        string mainUserIDFK = "1";
        string subDealerUserIDFK = "";
        string description = "";
        string imageName = "";
        short sendQuantity = 0;
        short unitsInStock = 0;
        decimal unitPrice = 0;
        decimal subTotalPrice;
        decimal tax = 0;
        decimal totalPrice = 0;
        decimal discountedPrice = 0;
        decimal discountPercent = 0;
        int selectedSubDealerID = 0;
        int selectedBrandID = 0;
        int selectedCategoryID = 0;
        int selectedProductID = 0;
        bool isDeleted;

        public SendToSubDealers()
        {
            InitializeComponent();
        }

        private void SendToSubDealers_Load(object sender, EventArgs e)
        {
            SendToSubDealersDataBind();
            ComboBoxSubDealersLoad();
            ComboBoxBrandsLoad();
            ComboBoxCategoriesLoad();
            ComboBoxProductsLoad();
            tax = dm.getTax("1") / 100;
            tb_tax.Text = tax.ToString();
            btn_editData.Enabled = false;

        }

        private void SendToSubDealersDataBind()
        {
            DataTable dt = dm.SendToSubDealerDataBind();
            dgv_sendToSubDealers.DataSource = dt;
            dgv_sendToSubDealers.Columns["BrandIDFK"].Visible = false;
            dgv_sendToSubDealers.Columns["CategoryIDFK"].Visible = false;
            dgv_sendToSubDealers.Columns["ProductIDFK"].Visible = false;
            dgv_sendToSubDealers.Columns["MainUserIDFK"].Visible = false;
            dgv_sendToSubDealers.Columns["SubDealerIDFK"].Visible = false;
            dgv_sendToSubDealers.Columns["Sub Dealer Discount Amount"].Visible = false;
            dgv_sendToSubDealers.Columns["ImageFileName"].Visible = false;

            dgv_sendToSubDealers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            foreach (DataGridViewColumn column in dgv_sendToSubDealers.Columns)
            {
                if (column.Name == "Product Description")
                {
                    column.Width = 150;
                }
                if (dgv_sendToSubDealers.Columns["Product Image"] is DataGridViewImageColumn imageCol)
                {
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 100;
                    dgv_sendToSubDealers.RowTemplate.Height = 100;
                }
            }
        }

        private void dgv_sendToSubDealers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_sendToSubDealers.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                    rows.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void dgv_sendToSubDealers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow selectedRow = dgv_sendToSubDealers.Rows[e.RowIndex];
            sendID = selectedRow.Cells["Shipment Number"].Value.ToString();
            tb_productItemNumber.Text = selectedRow.Cells["Product Item Number"].Value.ToString();
            cbb_brandName.SelectedValue = Convert.ToInt32(selectedRow.Cells["BrandIDFK"].Value);
            cbb_categoryName.SelectedValue = Convert.ToInt32(selectedRow.Cells["CategoryIDFK"].Value);
            cbb_productName.SelectedValue = Convert.ToInt32(selectedRow.Cells["ProductIDFK"].Value);
            tb_unitsInStock.Text = selectedRow.Cells["Product Units In Stock"].Value.ToString();
            tb_quantityPerUnit.Text = selectedRow.Cells["Product Quantity Per Unit"].Value.ToString();
            imageName = dm.listImageForEditProducts(selectedRow.Cells["ProductIDFK"].Value.ToString());
            pb_productImage.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages", imageName);
            pb_productImage.SizeMode = PictureBoxSizeMode.Zoom;
            tb_productDescription.Text = selectedRow.Cells["Product Description"].Value.ToString();
            cbb_subDealerInformation.SelectedValue = Convert.ToInt32(selectedRow.Cells["SubDealerIDFK"].Value);
            tb_sendQuentity.Text = selectedRow.Cells["Send Quantity"].Value.ToString();
            tb_unitPrice.Text = selectedRow.Cells["Unit Price"].Value.ToString();
            tb_shipmentInformation.Text = selectedRow.Cells["Description"].Value.ToString();
            cb_sendDeleted.Checked = selectedRow.Cells["Is Deleted"].Value.ToString() == "Yes" ? true : false;
            cb_sendDeleted.Enabled = true;
            btn_editData.Enabled = true;
            btn_cancelEdit.Enabled = true;
            btn_sendProduct.Enabled = false;
        }

        private void tb_sendQuentity_TextChanged(object sender, EventArgs e)
        {

            if (tb_sendQuentity.Text != "" && tb_sendQuentity.Text != "0")
            {
                subTotalPrice = Convert.ToDecimal(tb_sendQuentity.Text) * Convert.ToDecimal(unitPrice);
                totalPrice = subTotalPrice + (subTotalPrice * tax);
                nud_subTotalPrice.Value = subTotalPrice;
                nud_totalPrice.Value = totalPrice;

                if (tb_subDealerDiscAmount.Text != "" && tb_subDealerDiscAmount.Text != "0")
                {
                    nud_discountedPrice.Visible = true;
                    tb_discountedPrice.Visible = false;

                    discountPercent = Convert.ToDecimal(tb_subDealerDiscAmount.Text) / 100;
                    discountedPrice = totalPrice - (totalPrice * discountPercent);
                    nud_discountedPrice.Value = discountedPrice;
                }
                else
                {
                    tb_discountedPrice.Visible = true;
                    nud_discountedPrice.Visible = false;

                    tb_discountedPrice.Text = "Discount not applied.";
                }
            }
            else
            {
                nud_subTotalPrice.Value = 0;
                nud_totalPrice.Value = 0;
                nud_discountedPrice.Value = 0;
            }
        }

        private void ComboBoxBrandsLoad()
        {
            List<Brands> brands = dm.getBrandsForSendToSubDealer();
            brands.Insert(0, new Brands { brandID = 0, brandName = "---Choose---" });
            cbb_brandName.DataSource = brands;
            cbb_brandName.DisplayMember = "brandName";
            cbb_brandName.ValueMember = "brandID";
            cbb_brandName.SelectedIndex = 0;
        }

        private void cbb_brandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_brandName.SelectedIndex != 0 && cbb_brandName.SelectedValue != null)
            {
                if (int.TryParse(cbb_brandName.SelectedValue.ToString(), out int id))
                {
                    selectedBrandID = id;
                    tb_productItemNumber.Text = "";
                    tb_unitPrice.Text = "";
                    tb_sendQuentity.Text = "";
                    tb_quantityPerUnit.Text = "";
                    tb_unitsInStock.Text = "";
                    ComboBoxCategoriesLoad();
                }
            }
        }

        private void ComboBoxCategoriesLoad()
        {
            List<Categories> categories = dm.getCategoryForSendToSubDealer(selectedBrandID.ToString());
            categories.Insert(0, new Categories { categoryID = 0, categoryName = "---Choose---" });
            cbb_categoryName.DataSource = categories;
            cbb_categoryName.DisplayMember = "categoryName";
            cbb_categoryName.ValueMember = "categoryID";
            cbb_categoryName.SelectedIndex = 0;
        }

        private void cbb_categoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_categoryName.SelectedIndex != 0 && cbb_categoryName.SelectedValue != null)
            {
                if (int.TryParse(cbb_categoryName.SelectedValue.ToString(), out int id))
                {
                    selectedCategoryID = id;
                    tb_productItemNumber.Text = "";
                    tb_unitPrice.Text = "";
                    tb_sendQuentity.Text = "";
                    tb_quantityPerUnit.Text = "";
                    tb_unitsInStock.Text = "";
                    ComboBoxProductsLoad();

                }
            }
        }

        private void ComboBoxProductsLoad()
        {
            List<Product> product = dm.getProductForSendToSubDealers(selectedCategoryID.ToString());
            product.Insert(0, new Product { productID = 0, productName = "---Choose---" });
            cbb_productName.DataSource = product;
            cbb_productName.DisplayMember = "productName";
            cbb_productName.ValueMember = "productID";
            cbb_productName.SelectedIndex = 0;
        }

        private void cbb_productName_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_productItemNumber.Text = "";
            tb_unitPrice.Text = "";
            tb_sendQuentity.Text = "";
            tb_quantityPerUnit.Text = "";
            tb_unitsInStock.Text = "";
            if (cbb_productName.SelectedIndex != 0 && cbb_productName.SelectedValue != null)
            {
                if (int.TryParse(cbb_productName.SelectedValue.ToString(), out int id))
                {
                    selectedProductID = id;
                    imageName = dm.listImageForEditProducts(selectedProductID.ToString());
                    pb_productImage.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages", imageName);
                    pb_productImage.SizeMode = PictureBoxSizeMode.Zoom;
                    tb_productDescription.Text = dm.getProductDescription(selectedProductID.ToString());
                    tb_productItemNumber.Text = "MD" + selectedProductID.ToString();
                    tb_unitPrice.Text = dm.getUnitPrice(selectedProductID.ToString());
                    unitPrice = Convert.ToDecimal(dm.getUnitPrice(selectedProductID.ToString()));
                    tb_unitsInStock.Text = dm.getProductUnitsInStock(selectedProductID.ToString());
                    tb_quantityPerUnit.Text = dm.getProductQuantityPerUnit(selectedProductID.ToString());
                    cbb_subDealerInformation.Enabled = true;

                }
            }
        }

        private void ComboBoxSubDealersLoad()
        {
            List<SubDealer> subDealers = dm.getSubDealers();
            subDealers.Insert(0, new SubDealer { subDealerUserID = 0, subDealerName = "---Choose---" });
            cbb_subDealerInformation.DataSource = subDealers;
            cbb_subDealerInformation.DisplayMember = "subDealerName";
            cbb_subDealerInformation.ValueMember = "subDealerUserID";
            cbb_subDealerInformation.SelectedIndex = 0;
        }

        private void cbb_subDealerInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_subDealerInformation.SelectedIndex != 0 && cbb_subDealerInformation.SelectedValue != null)
            {
                tb_sendQuentity.Enabled = true;
                tb_shipmentInformation.Enabled = true;
                if (int.TryParse(cbb_subDealerInformation.SelectedValue.ToString(), out int id))
                {
                    selectedSubDealerID = id;
                    List<SubDealer> sd = dm.getSubDealers();
                    for (int i = 0; i < sd.Count; i++)
                    {
                        if (sd[i].subDealerUserID == id)
                        {
                            tb_subDealerType.Text = dm.getDiscountType(sd[i].discountIDFK.ToString());
                            tb_subDealerDiscAmount.Text = dm.getDiscountAmount(sd[i].discountIDFK.ToString());
                            if (tb_subDealerDiscAmount.Text != "" && tb_subDealerDiscAmount.Text != "0")
                            {
                                discountPercent = Convert.ToDecimal(tb_subDealerDiscAmount.Text) / 100;
                            }
                        }
                    }
                }
                CalculeteTotalPrice();
            }
        }

        private void CalculeteTotalPrice()
        {
            if (tb_sendQuentity.Text != "" && tb_sendQuentity.Text != "0")
            {
                subTotalPrice = Convert.ToDecimal(tb_sendQuentity.Text) * Convert.ToDecimal(unitPrice);
                totalPrice = subTotalPrice + (subTotalPrice * tax);
                nud_subTotalPrice.Value = subTotalPrice;
                nud_totalPrice.Value = totalPrice;

                if (tb_subDealerDiscAmount.Text != "" && tb_subDealerDiscAmount.Text != "0")
                {
                    nud_discountedPrice.Visible = true;
                    tb_discountedPrice.Visible = false;

                    discountPercent = Convert.ToDecimal(tb_subDealerDiscAmount.Text) / 100;
                    discountedPrice = totalPrice - (totalPrice * discountPercent);
                    nud_discountedPrice.Value = discountedPrice;
                }
                else
                {
                    tb_discountedPrice.Visible = true;
                    nud_discountedPrice.Visible = false;
                    nud_discountedPrice.Value = 0;
                    tb_discountedPrice.Text = "Discount not applied.";
                }
            }
            else
            {
                nud_subTotalPrice.Value = 0;
                nud_totalPrice.Value = 0;
                nud_discountedPrice.Value = 0;
            }


        }

        private void btn_sendProduct_Click(object sender, EventArgs e)
        {

            if (tb_sendQuentity.Text != "" && tb_unitPrice.Text != "")
            {
                if (cbb_brandName.SelectedIndex != 0 && cbb_categoryName.SelectedIndex != 0 && cbb_productName.SelectedIndex != 0)
                {
                    unitsInStock = Convert.ToInt16(tb_unitsInStock.Text);
                    sendQuantity = Convert.ToInt16(tb_sendQuentity.Text);
                    if (unitsInStock >= sendQuantity && unitsInStock != 0 && sendQuantity !=0)
                    {
                        short newStock = (short)(unitsInStock - sendQuantity);
                        brandIDFK = selectedBrandID.ToString();
                        categoryIDFK = selectedCategoryID.ToString();
                        productIDFK = selectedProductID.ToString();
                        productItemNumber = tb_productItemNumber.Text;
                        mainUserIDFK = "1";
                        subDealerUserIDFK = cbb_subDealerInformation.SelectedValue.ToString();
                        DateTime sendDate = DateTime.Now;
                        unitPrice = Convert.ToDecimal(tb_unitPrice.Text);
                        subTotalPrice = nud_subTotalPrice.Value;
                        tax = Convert.ToDecimal(tb_tax.Text);
                        totalPrice = nud_totalPrice.Value;
                        if (nud_discountedPrice.Value == 0)
                        {
                            discountedPrice = 0;
                        }
                        else
                        {
                            discountedPrice = nud_discountedPrice.Value;
                        }
                        description = tb_shipmentInformation.Text;
                        isDeleted = cb_sendDeleted.Checked;

                        dm.sendToSubDealers(brandIDFK, categoryIDFK, productIDFK, productItemNumber, mainUserIDFK, subDealerUserIDFK, sendDate, sendQuantity, unitPrice, subTotalPrice, tax, totalPrice, discountedPrice, description, isDeleted);
                        dm.updateUnitsInStock(productIDFK, newStock);
                        SendToSubDealersDataBind();
                        gbClear();
                    }
                    else
                    {
                        MessageBox.Show("Insufficient stock, shipping not possible!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You cant choose Brand/Category/Product, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have entered an incomplete entry, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_sendQuentity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_editData_Click(object sender, EventArgs e)
        {
            if (cb_sendDeleted.Checked)
            {
                DialogResult answer = MessageBox.Show("Are you sure you want to delete the shipping information? If you delete it, the edits you made will be invalid, you can only view it on the listing screen and cannot edit it!", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (answer == DialogResult.Yes)
                {
                    if (tb_shipmentInformation.Text != "")
                    {
                        unitsInStock = Convert.ToInt16(tb_unitsInStock.Text);
                        sendQuantity = Convert.ToInt16(tb_sendQuentity.Text);
                        if (unitsInStock >= sendQuantity && unitsInStock != 0 && sendQuantity != 0)
                        {
                            short newStock = (short)(unitsInStock - sendQuantity);
                            isDeleted = true;
                            description = tb_shipmentInformation.Text;
                            dm.editSendToSubDealers(sendID, description, isDeleted);
                            dm.updateUnitsInStock(productIDFK, newStock);
                            btn_sendProduct.Enabled = true;
                            btn_cancelEdit.Enabled = false;
                            btn_editData.Enabled = false;
                            cb_sendDeleted.Enabled = false;
                            cbb_subDealerInformation.Enabled = false;
                            SendToSubDealersDataBind();
                            gbClear();
                        }
                        else
                        {
                            MessageBox.Show("Insufficient stock, shipping not possible!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {

                        MessageBox.Show("You must write information when erease all data row from database!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                DialogResult answer = MessageBox.Show("Are you sure you want to change the shipping information? If you confirm the change, you cannot get back the information before the change!", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (answer == DialogResult.Yes)
                {
                    if (tb_sendQuentity.Text != "" && tb_unitPrice.Text != "")
                    {
                        if (cbb_brandName.SelectedIndex != 0 && cbb_categoryName.SelectedIndex != 0 && cbb_productName.SelectedIndex != 0)
                        {
                            unitsInStock = Convert.ToInt16(tb_unitsInStock.Text);
                            sendQuantity = Convert.ToInt16(tb_sendQuentity.Text);
                            if (unitsInStock >= sendQuantity && unitsInStock != 0 && sendQuantity != 0)
                            {
                                short newStock = (short)(unitsInStock - sendQuantity);
                                brandIDFK = selectedBrandID.ToString();
                                categoryIDFK = selectedCategoryID.ToString();
                                productIDFK = selectedProductID.ToString();
                                productItemNumber = tb_productItemNumber.Text;
                                mainUserIDFK = "1";
                                subDealerUserIDFK = cbb_subDealerInformation.SelectedValue.ToString();
                                unitPrice = Convert.ToDecimal(tb_unitPrice.Text);
                                subTotalPrice = nud_subTotalPrice.Value;
                                tax = Convert.ToDecimal(tb_tax.Text);
                                totalPrice = nud_totalPrice.Value;
                                if (nud_discountedPrice.Value == 0)
                                {
                                    discountedPrice = 0;
                                }
                                else
                                {
                                    discountedPrice = nud_discountedPrice.Value;
                                }
                                description = tb_shipmentInformation.Text;

                                dm.editSendToSubDealers(sendID, brandIDFK, categoryIDFK, productIDFK, productItemNumber, mainUserIDFK, subDealerUserIDFK, sendQuantity, unitPrice, subTotalPrice, tax, totalPrice, discountedPrice, description);
                                dm.updateUnitsInStock(productIDFK, newStock);
                                btn_sendProduct.Enabled = true;
                                btn_cancelEdit.Enabled = false;
                                btn_editData.Enabled = false;
                                cb_sendDeleted.Enabled = false;
                                cbb_subDealerInformation.Enabled = false;
                                SendToSubDealersDataBind();
                                gbClear();
                            }
                            else
                            {
                                MessageBox.Show("Insufficient stock, shipping not possible!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("You cant choose Brand/Category/Product, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have entered an incomplete entry, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_cancelEdit_Click(object sender, EventArgs e)
        {
            btn_sendProduct.Enabled = true;
            btn_cancelEdit.Enabled = false;
            btn_editData.Enabled = false;
            cb_sendDeleted.Enabled = false;
            cbb_subDealerInformation.Enabled = false;
            tb_sendQuentity.Enabled = false;
            SendToSubDealersDataBind();
            gbClear();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            gbClear();
        }

        private void gbClear()
        {
            cbb_brandName.SelectedIndex = 0;
            cbb_categoryName.SelectedIndex = 0;
            cbb_productName.SelectedIndex = 0;
            tb_productItemNumber.Text = "";
            pb_productImage.ImageLocation = "";
            tb_productDescription.Text = "";
            cbb_subDealerInformation.SelectedIndex = 0;
            tb_subDealerType.Text = "";
            tb_subDealerDiscAmount.Text = "";
            tb_sendQuentity.Text = "";
            tb_unitPrice.Text = "";
            nud_subTotalPrice.Value = 0;
            nud_totalPrice.Value = 0;
            nud_discountedPrice.Value = 0;
            tb_shipmentInformation.Text = "";
            tb_quantityPerUnit.Text = "";
            tb_unitsInStock.Text = "";
            subTotalPrice = 0;
            totalPrice = 0;
            unitPrice = 0;
            discountPercent = 0;
            discountedPrice = 0;
            nud_discountedPrice.Visible = false;
            tb_discountedPrice.Visible = false;
            tb_sendQuentity.Enabled = false;
            tb_shipmentInformation.Enabled = false;
            cbb_subDealerInformation.Enabled = false;
        }
    }
}