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
        string userID = "";
        string selectedImagePath = "";
        string destinationImagePath = "";
        string imageName = "";
        string imageForEdit = "";


        public MainDealerSettings()
        {
            InitializeComponent();
        }

        private void MainDealerSettings_Load(object sender, EventArgs e)
        {
            MainDealerLoad();
            dm.disableControls(gb_mainDealer);
            btn_cancelEdit.Enabled = false;
            btn_editMainDealer.Enabled = false;
            btn_selectImage.Enabled = false;

        }

        private void MainDealerLoad()
        {
            DataTable dt = dm.subMainDealerDataBind();
            dgv_editMainDealer.DataSource = dt;
            dgv_editMainDealer.Columns["User ID"].Visible = false;

            #region Image Column and Sequence Number Settings

            int dgvaddBrandColumnWidth = dgv_editMainDealer.Width - dgv_editMainDealer.RowHeadersWidth - 100; // 100 = Image Column Width
            int otherColumnCount = dgv_editMainDealer.Columns.Count - 2; // (2 --> S/N and Image Column)
            int columnWidth = dgvaddBrandColumnWidth / otherColumnCount;

            for (int i = 0; i < otherColumnCount; i++)
            {
                dgv_editMainDealer.Columns[i].Width = columnWidth;
            }
            foreach (DataGridViewColumn column in dgv_editMainDealer.Columns)
            {
                if (column.Name == "S/N")
                {
                    column.Width = 50;
                }
                if (column.Name == "Image")
                {
                    DataGridViewImageColumn imageCol = (DataGridViewImageColumn)column;
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 100;
                    dgv_editMainDealer.RowTemplate.Height = 100;
                }
            }

            #endregion

                   }

        private void dgv_editMainDealer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dm.enableControls(gb_mainDealer);

            DataGridViewRow selectedRow = dgv_editMainDealer.Rows[e.RowIndex];
            userID = selectedRow.Cells["User ID"].Value.ToString();
            tb_mainDealerName.Text = selectedRow.Cells["Dealer Name"].Value.ToString();
            tb_mainDealerMail.Text = selectedRow.Cells["Dealer Mail"].Value.ToString();
            tb_mainDealerAdress.Text = selectedRow.Cells["Dealer Address"].Value.ToString();
            tb_mainDealerCity.Text = selectedRow.Cells["Dealer City"].Value.ToString();
            tb_mainDealerPostalCode.Text = selectedRow.Cells["Dealer Postal Code"].Value.ToString();
            tb_mainDealerCountry.Text = selectedRow.Cells["Dealer Country"].Value.ToString();
            nud_taxAmount.Value = Convert.ToDecimal(selectedRow.Cells["Invoice Tax Amount"].Value);
            imageForEdit = dm.listImageForEditMainDealer(selectedRow.Cells["User ID"].Value.ToString());
            pb_mainDealer.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ApplicationImages", imageForEdit);
            pb_mainDealer.SizeMode = PictureBoxSizeMode.Zoom;

            btn_cancelEdit.Enabled = true;
            btn_editMainDealer.Enabled = true;
            btn_selectImage.Enabled = true;

        }

        private void nud_taxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void btn_selectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".jpeg" || fi.Extension == ".png")
                {
                    pb_mainDealer.SizeMode = PictureBoxSizeMode.Zoom;
                    pb_mainDealer.ImageLocation = fi.FullName;
                    selectedImagePath = fi.FullName;
                    imageName = Guid.NewGuid().ToString() + fi.Extension;
                }
            }
        }

        private void btn_editMainDealer_Click(object sender, EventArgs e)
        {
            if (!dm.isTextBoxesEmpty(gb_mainDealer))
            {
                string mainDealerName = "";
                string mainDealerMail = "";
                string mainDealerAdress = "";
                string mainDealerCity = "";
                string mianDealerPostalCode = "";
                string mainDealerCountry = "";
                decimal taxAmount = 0;
                if (tb_mainDealerName.Text.Length < 100 && tb_mainDealerMail.Text.Length < 50)
                {
                    if (tb_mainDealerCity.Text.Length < 50 && tb_mainDealerPostalCode.Text.Length < 20 && tb_mainDealerCountry.Text.Length < 50)
                    {
                        if (!string.IsNullOrEmpty(imageName))
                        {
                            mainDealerName = tb_mainDealerName.Text;
                            mainDealerMail = tb_mainDealerMail.Text;
                            mainDealerAdress = tb_mainDealerAdress.Text;
                            mainDealerCity = tb_mainDealerCity.Text;
                            mianDealerPostalCode = tb_mainDealerPostalCode.Text;
                            mainDealerCountry = tb_mainDealerCountry.Text;
                            taxAmount = nud_taxAmount.Value;
                            dm.editMainDealers(userID, mainDealerName, mainDealerMail, mainDealerAdress, mainDealerCity, mianDealerPostalCode, mainDealerCountry, taxAmount, imageName);
                            destinationImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ApplicationImages", imageName);
                            destinationImagePath = Path.GetFullPath(destinationImagePath);
                            File.Copy(selectedImagePath, destinationImagePath, true);
                            MainDealerLoad();
                            dm.clearControls(gb_mainDealer);
                            imageName = "";
                            btn_cancelEdit.Enabled = false;
                            btn_editMainDealer.Enabled = false;
                            btn_selectImage.Enabled = false;
                        }
                        else
                        {
                            mainDealerName = tb_mainDealerName.Text;
                            mainDealerMail = tb_mainDealerMail.Text;
                            mainDealerAdress = tb_mainDealerAdress.Text;
                            mainDealerCity = tb_mainDealerCity.Text;
                            mianDealerPostalCode = tb_mainDealerPostalCode.Text;
                            mainDealerCountry = tb_mainDealerCountry.Text;
                            taxAmount = nud_taxAmount.Value;
                            imageName = imageForEdit;
                            dm.editMainDealers(userID, mainDealerName, mainDealerMail, mainDealerAdress, mainDealerCity, mianDealerPostalCode, mainDealerCountry, taxAmount, imageName);
                            MainDealerLoad();
                            dm.clearControls(gb_mainDealer);
                            imageName = "";
                            btn_cancelEdit.Enabled = false;
                            btn_editMainDealer.Enabled = false;
                            btn_selectImage.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Main Dealer City/ Main Dealer Postal Code/ Main Dealer Country name too long, it can be max 50/20/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Main Dealer Mail or Main Dealer Name too long, it can be max 100/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have entered an incomplete entry, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelEdit_Click(object sender, EventArgs e)
        {
            btn_editMainDealer.Enabled = false;
            btn_cancelEdit.Enabled = false;
            btn_selectImage.Enabled = false;
            dm.clearControls(gb_mainDealer);
            MainDealerLoad();
        }
    }
}

