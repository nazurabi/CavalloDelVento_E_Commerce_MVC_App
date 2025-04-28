using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModelWithADO;
namespace FormForDataModel
{
    public partial class DiscountRatesSettings : Form
    {
        DataModel dm = new DataModel();
        string discountID = "";
        byte discountAmount = 0;
        string imageForEdit = "";
        public DiscountRatesSettings()
        {
            InitializeComponent();
        }

        private void nud_discountRates_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DiscountRatesSettings_Load(object sender, EventArgs e)
        {
            DiscountRatesLoad();
        }

        private void DiscountRatesLoad()
        {
            DataTable dt = dm.discountDataBind();
            dgv_discountRates.DataSource = dt;
            dgv_discountRates.Columns["DiscountID"].Visible = false;
            foreach (DataGridViewColumn column in dgv_discountRates.Columns)
            {
                column.Width = 130;
                if (column.Name == "S/N")
                {
                    column.Width = 30;
                }
                if (column.Name == "Discount Image")
                {

                    if (dgv_discountRates.Columns["Discount Image"] is DataGridViewImageColumn imageCol)
                    {
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.Width = 100;
                        dgv_discountRates.RowTemplate.Height = 50;
                    }
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            nud_discountRates.Value = 0;
            pb_discountRates.ImageLocation = "";
            nud_discountRates.Enabled = false;
            btn_clear.Enabled = false;
            btn_save.Enabled = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            discountAmount = Convert.ToByte(nud_discountRates.Value);
            dm.editDiscountRates(discountID, discountAmount);
            DiscountRatesLoad();
        }

        private void dgv_discountRates_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            nud_discountRates.Enabled = true;
            btn_clear.Enabled = true;
            btn_save.Enabled = true;
            DataGridViewRow selectedRow = dgv_discountRates.Rows[e.RowIndex];
            nud_discountRates.Value = Convert.ToDecimal(selectedRow.Cells["Discount Amount"].Value);
            discountID = selectedRow.Cells["DiscountID"].Value.ToString();
            if (1 == Convert.ToByte(selectedRow.Cells["DiscountID"].Value))
            {
                imageForEdit = "Gold.png";
            }
            else if (2 == Convert.ToByte(selectedRow.Cells["DiscountID"].Value))
            {
                imageForEdit = "Silver.png";
            }
            else
            {
                imageForEdit = "Bronze.png";
            }
            pb_discountRates.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ApplicationImages", imageForEdit);
            pb_discountRates.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
