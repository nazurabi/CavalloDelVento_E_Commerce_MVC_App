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
    public partial class MainDealerSettings : Form
    {
        DataModel dm = new DataModel();

        //public int settingID { get; set; }
        //public string dealerName { get; set; }
        //public string mail { get; set; }
        //public string adress { get; set; }
        //public string city { get; set; }
        //public string postalCode { get; set; }
        //public string country { get; set; }
        //public byte invoiceTaxAmount { get; set; }
        //public string image { get; set; }
        public MainDealerSettings()
        {
            InitializeComponent();
        }

        private void MainDealerSettings_Load(object sender, EventArgs e)
        {
            MainDealerLoad();
        }

        private void MainDealerLoad()
        {
            DataTable dt = dm.subMainDealerDataBind();
            dgv_editMainDealer.DataSource = dt;
            dgv_editMainDealer.Columns["User ID"].Visible = false;



            foreach (DataGridViewColumn column in dgv_editMainDealer.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                if (column.Name == "Image")
                {
                    if (dgv_editMainDealer.Columns["Image"] is DataGridViewImageColumn imageCol)
                    {
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.Width = 100;
                        dgv_editMainDealer.RowTemplate.Height = 100;
                    }
                }
            }
        }

        //PictureBox ayarlamasını yapıyordun ve edit işlemini ayarlayacaksın 





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

           
        }
    }

}
}
