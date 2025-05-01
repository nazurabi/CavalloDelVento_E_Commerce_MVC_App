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
    public partial class SendToSubDealers : Form
    {
        DataModel dm = new DataModel();
        string imageName = "";
        string selectedImagePath = "";
        //string destinationImagePath = "";
        string sendID = "";
        string mainUserIDFK = "";
        decimal unitPrice = 0;
        int selectedSubDealerID = 0;
        int selectedBrandID = 0;
        int selectedCategoryID = 0;
        int selectedProductID = 0;
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
        }

        private void SendToSubDealersDataBind()
        {
            DataTable dt = dm.SendToSubDealerDataBind();
            dgv_sendToSubDealers.DataSource = dt;
            dgv_sendToSubDealers.Columns["BrandIDFK"].Visible = false;
            dgv_sendToSubDealers.Columns["CategoryIDFK"].Visible = false;
            dgv_sendToSubDealers.Columns["MainUserIDFK"].Visible = false;
            dgv_sendToSubDealers.Columns["SubDealerIDFK"].Visible = false;
            dgv_sendToSubDealers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            foreach (DataGridViewColumn column in dgv_sendToSubDealers.Columns)
            {
                if (dgv_sendToSubDealers.Columns["Product Image"] is DataGridViewImageColumn imageCol)
                {
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 100;
                    dgv_sendToSubDealers.RowTemplate.Height = 100;
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
                if (int.TryParse(cbb_subDealerInformation.SelectedValue.ToString(), out int id))
                {
                    selectedSubDealerID = id;
                }
            }
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

        private void ComboBoxCategoriesLoad()
        {
            List<Categories> categories = dm.getCategoriesForProducts(selectedBrandID.ToString());
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
            if (cbb_productName.SelectedIndex != 0 && cbb_productName.SelectedValue != null)
            {
                if (int.TryParse(cbb_productName.SelectedValue.ToString(), out int id))
                {
                    selectedProductID = id;
                    imageName = dm.listImageForEditProducts(selectedProductID.ToString());
                    pb_productImage.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages", imageName);
                    pb_productImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dm.clearControls(gb_sendToSubDealers);
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

        private void btn_sendProduct_Click(object sender, EventArgs e)
        {

            if (tb_sendQuentity.Text != "" && tb_unitPrice.Text != "")
            {
                if (cbb_brandName.SelectedIndex != 0 && cbb_categoryName.SelectedIndex != 0 && cbb_productName.SelectedIndex != 0)
                {
                    string brandIDFK = selectedBrandID.ToString();
                    string categoryIDFK = selectedCategoryID.ToString();
                    string productIDFK = selectedProductID.ToString();
                    string mainUserIDFK = selectedSubDealerID.ToString();
                    string subDealerUserIDFK = cbb_subDealerInformation.SelectedValue.ToString();
                    DateTime sendDate = DateTime.Now;
                    short sendQuantity = Convert.ToInt16(tb_sendQuentity.Text);
                    unitPrice = Convert.ToDecimal(tb_unitPrice.Text);
                    decimal subTotalPrice = Convert.ToDecimal(tb_subTotalPrice.Text);
                    decimal tax = Convert.ToDecimal(tb_tax.Text);
                    decimal totalPrice = Convert.ToDecimal(tb_totalPrice.Text);
                    string description = tb_shipmentInformation.Text;
                    bool isDeleted = cb_sendDeleted.Checked;

                    dm.sendToSubDealers(brandIDFK, categoryIDFK, productIDFK, mainUserIDFK, subDealerUserIDFK, sendDate, sendQuantity, unitPrice, subTotalPrice, tax, totalPrice, description, isDeleted);
                    SendToSubDealersDataBind();
                    dm.clearControls(gb_sendToSubDealers);
                    //btn_cancelEdit.Enabled = false;
                    //btn_editSubDealers.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Sub Dealer City/ Sub Dealer Postal Code/ Sub Dealer Country name too long, it can be max 50/20/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("You have entered an incomplete entry, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
