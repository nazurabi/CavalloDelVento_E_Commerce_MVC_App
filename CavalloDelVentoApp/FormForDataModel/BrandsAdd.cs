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
    public partial class BrandsAdd : Form
    {
        DataModel dm = new DataModel();
        public BrandsAdd()
        {
            InitializeComponent();
        }

        private void btn_selectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".jpeg")
                {
                    pb_brandImage.SizeMode = PictureBoxSizeMode.Zoom;
                    pb_brandImage.ImageLocation = fi.FullName;
                }
            }
        }

        private void BrandsAdd_Load(object sender, EventArgs e)
        {
            DataTable dt = dm.brandDataBind();
            dgv_addBrand.DataSource = dt;
            //dgv_addBrand.Columns["Brand Image"].Visible = false;
            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //imageColumn.HeaderText = "Brand Images";
            //imageColumn.Name = "Image";
            //dgv_addBrand.Columns.Add(imageColumn);

            foreach (DataGridViewRow row in dgv_addBrand.Rows)
            {
                //if (row.IsNewRow)
                //    continue;

                //string imagePath = row.Cells["Brand Image"].Value.ToString();

                //    if (File.Exists(imagePath))
                //    {
                //    row.Cells["Image"].Value = Image.FromFile(imagePath);
                //    }
                if (dgv_addBrand.Columns["Brand Image"] is DataGridViewImageColumn imageCol)
                {
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 100;
                    dgv_addBrand.RowTemplate.Height = 100;
                }

            }
        }
    }
}
