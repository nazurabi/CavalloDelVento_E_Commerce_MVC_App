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
    public partial class BrandsEdit : Form
    {
        DataModel dm = new DataModel();
        string brandID = "";
        string imageName = "";
        string imageForEdit = "";
        string selectedImagePath = "";
        string destinationImagePath = "";

        public BrandsEdit()
        {
            InitializeComponent();
        }

        private void BrandsEdit_Load(object sender, EventArgs e)
        {
            BrandsEditLoad();
        }

        private void BrandsEditLoad()
        {
            DataTable dt = dm.brandDataBind();

            #region filePath active here

            DataTable dgvVisualTable = new DataTable();
            dgvVisualTable.Columns.Add("S/N", typeof(string));
            dgvVisualTable.Columns.Add("Brand ID", typeof(int));
            dgvVisualTable.Columns.Add("Brand Name", typeof(string));
            dgvVisualTable.Columns.Add("Is Brand Active For Sale", typeof(string));
            dgvVisualTable.Columns.Add("Brand Image", typeof(Image));
            short sequenceNumber = 0;
            foreach (DataRow row in dt.Rows)
            {
                sequenceNumber++;
                string returnedBrandID = row["BrandID"].ToString();
                string returnedBrandName = row["Brand Name"].ToString();
                string returnedIsActiveForSale = row["Is Brand Active For Sale"].ToString();
                string returnedImage = row["Brand Image"].ToString();
                Image img = null;
                if (File.Exists(returnedImage))
                {
                    img = Image.FromFile(returnedImage);
                }
                dgvVisualTable.Rows.Add(sequenceNumber, returnedBrandID, returnedBrandName, returnedIsActiveForSale, img);
            }
            dgv_editBrand.DataSource = dgvVisualTable;

            foreach (DataGridViewColumn column in dgv_editBrand.Columns)
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

                    if (dgv_editBrand.Columns["Brand Image"] is DataGridViewImageColumn imageCol)
                    {
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.Width = 100;
                        dgv_editBrand.RowTemplate.Height = 100;
                    }
                }
            }
            #endregion
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            string brandName = "";
            //bool isDeleted = false; // In order for the brand to be active, its deleted status must be false.
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
                            dm.editBrand(brandID, brandName, isActive, imageName);
                            destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageName);
                            destinationImagePath = Path.GetFullPath(destinationImagePath);
                            File.Copy(selectedImagePath, destinationImagePath, true);
                            tb_brandName.Text = "";
                            cb_brandActive.Checked = false;
                            imageName = "";
                            pb_brandImage.ImageLocation = "";
                            BrandsEditLoad();
                            //dgv_editBrand.ClearSelection();
                            //dgv_editBrand.CurrentCell = null;
                            tb_brandName.Enabled = false;
                            cb_brandActive.Enabled = false;
                            btn_clear.Enabled = false;
                            btn_selectImage.Enabled = false;
                            btn_save.Enabled = false;
                            // Since the image has changed, the old image was deleted with this line of code;
                            //string oldImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageForEdit);
                            //if (File.Exists(oldImage))
                            //{
                            //    try
                            //    {
                            //        File.Delete(oldImage);
                            //        MessageBox.Show("Eski görsel başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        MessageBox.Show($"Görsel silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    }
                            //}
                        }
                        else
                        {
                            brandName = tb_brandName.Text.ToUpper();
                            isActive = cb_brandActive.Checked;
                            imageName = imageForEdit;
                            dm.editBrand(brandID, brandName, isActive, imageName);
                            tb_brandName.Text = "";
                            cb_brandActive.Checked = false;
                            imageName = "";
                            pb_brandImage.ImageLocation = "";
                            BrandsEditLoad();
                            //dgv_editBrand.ClearSelection();
                            //dgv_editBrand.CurrentCell = null;
                            tb_brandName.Enabled = false;
                            cb_brandActive.Enabled = false;
                            btn_clear.Enabled = false;
                            btn_selectImage.Enabled = false;
                            btn_save.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Brand name too long, it can be max 100 character!");
                    }
                }
                else
                {
                    DialogResult choose = MessageBox.Show("Brand name has already been entered. Are you sure you want to continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (choose == DialogResult.Yes)
                    {
                        if (tb_brandName.Text.Length < 100)
                        {
                            if (!string.IsNullOrEmpty(imageName))
                            {
                                brandName = tb_brandName.Text.ToUpper();
                                isActive = cb_brandActive.Checked;
                                dm.editBrand(brandID, brandName, isActive, imageName);
                                destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageName);
                                destinationImagePath = Path.GetFullPath(destinationImagePath);
                                File.Copy(selectedImagePath, destinationImagePath, true);
                                tb_brandName.Text = "";
                                cb_brandActive.Checked = false;
                                imageName = "";
                                pb_brandImage.ImageLocation = "";
                                BrandsEditLoad();
                                //dgv_editBrand.ClearSelection();
                                //dgv_editBrand.CurrentCell = null;
                                tb_brandName.Enabled = false;
                                cb_brandActive.Enabled = false;
                                btn_clear.Enabled = false;
                                btn_selectImage.Enabled = false;
                                btn_save.Enabled = false;
                                // Since the image has changed, the old image was deleted with this line of code;
                                //string oldImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageForEdit);
                                //oldImage = Path.GetFullPath(oldImage);
                                //if (File.Exists(oldImage))
                                //{
                                //    try
                                //    {
                                //        File.Delete(oldImage);
                                //        MessageBox.Show("Eski görsel başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    }
                                //    catch (Exception ex)
                                //    {
                                //        MessageBox.Show($"Görsel silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    }
                                //}
                            }
                            else
                            {
                                brandName = tb_brandName.Text.ToUpper();
                                isActive = cb_brandActive.Checked;
                                imageName = imageForEdit;
                                dm.editBrand(brandID, brandName, isActive, imageName);
                                tb_brandName.Text = "";
                                cb_brandActive.Checked = false;
                                imageName = "";
                                pb_brandImage.ImageLocation = "";
                                BrandsEditLoad();
                                //dgv_editBrand.ClearSelection();
                                //dgv_editBrand.CurrentCell = null;
                                tb_brandName.Enabled = false;
                                cb_brandActive.Enabled = false;
                                btn_clear.Enabled = false;
                                btn_selectImage.Enabled = false;
                                btn_save.Enabled = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Brand name too long, it can be max 100 character!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Brand name cannot empty!");
            }
        }
        private void dgv_editBrand_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tb_brandName.Enabled = true;
            cb_brandActive.Enabled = true;
            btn_clear.Enabled = true;
            btn_selectImage.Enabled = true;
            btn_save.Enabled = true;

            DataGridViewRow selectedRow = dgv_editBrand.Rows[e.RowIndex];
            tb_brandName.Text = selectedRow.Cells["Brand Name"].Value.ToString();
            cb_brandActive.Checked = selectedRow.Cells["Is Brand Active For Sale"].Value.ToString() == "Yes" ? true : false;
            imageForEdit = dm.listImageForEditBrands(selectedRow.Cells["Brand ID"].Value.ToString());
            brandID = selectedRow.Cells["Brand ID"].Value.ToString();
            pb_brandImage.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages", imageForEdit);
            pb_brandImage.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
