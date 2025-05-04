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
using System.Xml.Serialization;
using DataModelWithADO;

namespace FormForDataModel
{
    public partial class BrandsList : Form
    {
        DataModel dm = new DataModel();
        List<Brands> listOfBrands = new List<Brands>();
        public BrandsList()
        {
            InitializeComponent();
        }

        private void BrandsList_Load(object sender, EventArgs e)
        {
            BrandList();
        }

        private void BrandList()
        {
            DataTable dt = dm.brandDataBind();
            BrandList(dt);
            dgv_brandList.DataSource = dt;
            dgv_brandList.RowHeadersVisible = false;
            dgv_brandList.Columns["Brand Image Name"].Visible = false;

            foreach (DataGridViewColumn column in dgv_brandList.Columns)
            {
                if (column.Name == "S/N")
                {
                    column.Width = 50;
                }
                if (column.Name == "Brand Image")
                {
                    DataGridViewImageColumn imageCol = (DataGridViewImageColumn)column;
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 100;
                    dgv_brandList.RowTemplate.Height = 100;
                }
            }
        }

        private void BrandList(DataTable sendDataInfo)
        {
            foreach (DataRow dr in sendDataInfo.Rows)
            {
                Brands brand = new Brands();
                brand.brandID = Convert.ToInt32(dr["BrandID"]);
                brand.brandName = dr["Brand Name"].ToString();
                brand.isActive = Convert.ToBoolean((dr["Is Brand Active For Sale"]) == "Yes" ? true : false);
                brand.isDeleted = Convert.ToBoolean((dr["Is Deleted"]) == "Yes" ? true : false);
                brand.image = dr["Brand Image Name"].ToString();
                listOfBrands.Add(brand);
            }
        }

        private void dgv_brandList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_brandList.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                    rows.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

       
        private void btn_exportListToXml_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save XML File";
            saveFileDialog1.Filter = "XML dosyası (*.xml)|*.xml";
            try
            {
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;
                    using (StreamWriter swr = new StreamWriter(filePath))
                    {
                        XmlSerializer sralz = new XmlSerializer(typeof(List<Brands>));
                        sralz.Serialize(swr, listOfBrands);
                    }
                    MessageBox.Show("Export completed successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Export not completed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exportToExcel_Click(object sender, EventArgs e)
        {

        }

        private void btn_print_Click(object sender, EventArgs e)
        {

        }
    }
}
