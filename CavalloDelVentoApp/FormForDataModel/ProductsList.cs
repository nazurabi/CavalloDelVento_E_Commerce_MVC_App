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
    public partial class ProductsList : Form
    {
        DataModel dm = new DataModel();
        List<Product> listOfProducts = new List<Product>();
        public ProductsList()
        {
            InitializeComponent();
        }

        private void ProductsList_Load(object sender, EventArgs e)
        {
            ProductList();
        }

        private void ProductList()
        {
            DataTable dt = dm.productsDataBind();
            ProList(dt);
            dgv_productList.DataSource = dt;
            dgv_productList.RowHeadersVisible = false;
            dgv_productList.Columns["BrandIDFK"].Visible = false;
            dgv_productList.Columns["CategoryIDFK"].Visible = false;
            dgv_productList.Columns["Product Image Name"].Visible = false;

            #region Image Column and Sequence Number Settings

            int dgvaddBrandColumnWidth = dgv_productList.Width - 100; // 100 = Image Column Width
            int otherColumnCount = dgv_productList.Columns.Count - 6; // (6 --> S/N, ProductID, BrandIDFK, CategoryIDFK, Image, Image Name Column)
            int columnWidth = dgvaddBrandColumnWidth / otherColumnCount;

            for (int i = 0; i < otherColumnCount; i++)
            {
                dgv_productList.Columns[i].Width = columnWidth;
            }
            foreach (DataGridViewColumn column in dgv_productList.Columns)
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
                    dgv_productList.RowTemplate.Height = 100;
                }
            }
            #endregion
        }

        private void ProList(DataTable sendDataInfo)
        {
            foreach (DataRow dr in sendDataInfo.Rows)
            {
                Product prod = new Product();
                prod.productID = Convert.ToInt32(dr["ProductID"]);
                prod.productName = dr["Product Name"].ToString();
                prod.description = dr["Description"].ToString();
                prod.quantityPerUnit = dr["Quantity Per Unit"].ToString();
                prod.unitPrice = Convert.ToDecimal(dr["Unit Price"]);
                prod.unitsInStock = Convert.ToInt16(dr["Units In Stock"]);
                prod.unitsOnOrder = Convert.ToInt16(dr["Units On Order"]);
                prod.reorderLevel = Convert.ToInt16(dr["Reorder Level"]);
                prod.discontinued = Convert.ToBoolean((dr["Discontinued"]) == "Yes" ? true : false);
                prod.isDeleted = Convert.ToBoolean((dr["Is Deleted"]) == "Yes" ? true : false);
                prod.isActive = Convert.ToBoolean((dr["Is Product Active For Sale"]) == "Yes" ? true : false);
                prod.image = dr["Product Image Name"].ToString();
                listOfProducts.Add(prod);
            }
        }

        private void dgv_productList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_productList.Rows)
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
                        XmlSerializer sralz = new XmlSerializer(typeof(List<Product>));
                        sralz.Serialize(swr, listOfProducts);
                    }
                    MessageBox.Show("Export completed successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Export not completed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
