using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DataModelWithADO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormForDataModel
{
    public partial class BrandsAdd : Form
    {
        DataModel dm = new DataModel();
        string imageName = "";
        string selectedImagePath = "";
        string destinationImagePath = "";
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
                if (fi.Extension == ".jpg" || fi.Extension == ".jpeg" || fi.Extension == ".png")
                {
                    pb_brandImage.SizeMode = PictureBoxSizeMode.Zoom;
                    pb_brandImage.ImageLocation = fi.FullName;
                    selectedImagePath = fi.FullName;
                    imageName = Guid.NewGuid().ToString() + fi.Extension;
                }
            }
        }

        private void BrandsAdd_Load(object sender, EventArgs e)
        {
            BrandsAddLoad();
        }

        private void BrandsAddLoad()
        {
            DataTable dt = dm.brandDataBind();

            #region Filestream active here

            //dgv_addBrand.DataSource = dt;
            //foreach (DataGridViewRow row in dgv_addBrand.Rows)
            //{
            //    if (dgv_addBrand.Columns["Brand Image"] is DataGridViewImageColumn imageCol)
            //    {
            //        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            //        imageCol.Width = 100;
            //        dgv_addBrand.RowTemplate.Height = 100;
            //    }
            //}

            #endregion

            #region filePath active here

            dgv_addBrand.DataSource = dt;
            dgv_addBrand.RowHeadersVisible = false;
            dgv_addBrand.Columns["BrandID"].Visible=false;
            dgv_addBrand.Columns["Brand Image Name"].Visible=false;

            foreach (DataGridViewColumn column in dgv_addBrand.Columns)
            {
                if (column.Name == "S/N")
                {
                    column.Width = 50;
                }
                if (column.Name == "Brand Name")
                {
                    column.Width = 200;
                }
                if (column.Name == "Is Brand Active For Sale")
                {
                    column.Width = 150;
                }

                if (column.Name == "Brand Image")
                {

                    if (dgv_addBrand.Columns["Brand Image"] is DataGridViewImageColumn imageCol)
                    {
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.Width = 100;
                        dgv_addBrand.RowTemplate.Height = 100;
                    }
                }
            }
            #endregion

        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            string brandName = "";
            bool isDeleted = false; // In order for the brand to be active, its deleted status must be false.
            bool isActive;
            if (!string.IsNullOrEmpty(tb_brandName.Text))
            {
                byte checkBrandName = dm.listBrands(tb_brandName.Text.ToUpper());
                if (checkBrandName == 0)
                {
                    if (tb_brandName.Text.Length < 100)
                    {
                        if (!string.IsNullOrEmpty(imageName))
                        {
                            brandName = tb_brandName.Text.ToUpper();
                            isActive = cb_brandActive.Checked;
                            dm.addBrand(brandName, isDeleted, isActive, imageName);
                            destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageName);
                            destinationImagePath = Path.GetFullPath(destinationImagePath);
                            File.Copy(selectedImagePath, destinationImagePath, true);
                            tb_brandName.Text = "";
                            cb_brandActive.Checked = false;
                            imageName = "";
                            pb_brandImage.ImageLocation = "";
                            BrandsAddLoad();
                        }
                        else
                        {
                            brandName = tb_brandName.Text.ToUpper();
                            isActive = cb_brandActive.Checked;
                            imageName = "none.jpg";
                            dm.addBrand(brandName, isDeleted, isActive, imageName);
                            tb_brandName.Text = "";
                            cb_brandActive.Checked = false;
                            imageName = "";
                            pb_brandImage.ImageLocation = "";
                            BrandsAddLoad();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Brand name too long, it can be max 100 character!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Brand name has already been entered, please check your information!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Brand name cannot empty!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_brandName.Text = "";
            cb_brandActive.Checked = false;
            imageName = "";
            selectedImagePath = "";
            destinationImagePath = "";
            pb_brandImage.ImageLocation = "";
        }
    }
}
