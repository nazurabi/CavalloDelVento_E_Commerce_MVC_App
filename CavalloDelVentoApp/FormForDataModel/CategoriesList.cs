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
    public partial class CategoriesList : Form
    {
        DataModel dm = new DataModel();
        List<Categories> listOfCategory = new List<Categories>();
        public CategoriesList()
        {
            InitializeComponent();
        }

        private void CategoriesList_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void CategoryList()
        {
            DataTable dt = dm.categoryDataBind();
            CatList(dt);
            dgv_categoryList.DataSource = dt;
            dgv_categoryList.RowHeadersVisible = false;
            dgv_categoryList.Columns["BrandIDFK"].Visible = false;
            dgv_categoryList.Columns["Category Image Name"].Visible = false;

            foreach (DataGridViewColumn column in dgv_categoryList.Columns)
            {
                if (column.Name == "S/N")
                {
                    column.Width = 50;
                }
                if (column.Name == "Category Image")
                {
                    DataGridViewImageColumn imageCol = (DataGridViewImageColumn)column;
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 100;
                    dgv_categoryList.RowTemplate.Height = 100;
                }
            }
        }

        private void CatList(DataTable sendDataInfo)
        {
            foreach (DataRow dr in sendDataInfo.Rows)
            {
                Categories cat = new Categories();
                cat.categoryID = Convert.ToInt32(dr["CategoryID"]);
                cat.categoryName = dr["Category Name"].ToString();
                cat.description = dr["Description"].ToString();
                cat.isDeleted = Convert.ToBoolean((dr["Is Deleted"]) == "Yes" ? true : false);
                cat.isActive = Convert.ToBoolean((dr["Is Category Active For Sale"]) == "Yes" ? true : false);
                cat.image = dr["Category Image Name"].ToString();
                listOfCategory.Add(cat);
            }
        }

        private void dgv_categoryList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_categoryList.Rows)
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
                        XmlSerializer sralz = new XmlSerializer(typeof(List<Categories>));
                        sralz.Serialize(swr, listOfCategory);
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
