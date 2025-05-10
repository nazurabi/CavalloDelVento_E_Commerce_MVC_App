using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModelWithADO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FormForDataModel
{
    public partial class SubDealerSettings : Form
    {
        DataModel dm = new DataModel();
        int selectedDiscountID = 0;
        string discountIDFK = "";
        string subDealerID = "";
        string nullableControl = "tb_subDealerUserID";

        public SubDealerSettings()
        {
            InitializeComponent();
        }
        private void SubDealerSettings_Load(object sender, EventArgs e)
        {
            SubDealersLoad();
            ComboboxSubDealersLoad();
        }

        private void SubDealersLoad()
        {
            DataTable dt = dm.subDealerDataBind();
            dgv_editSubDealers.DataSource = dt;
            dgv_editSubDealers.Columns["DiscountIDFK"].Visible = false;
            btn_cancelEdit.Enabled = false;
            btn_editSubDealers.Enabled = false;
        }

        private void dgv_editSubDealers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_editSubDealers.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                   rows.Cells["Is Deleted"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void dgv_editSubDealers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dm.enableControls(gb_addSubDealers);

            DataGridViewRow selectedRow = dgv_editSubDealers.Rows[e.RowIndex];
            tb_subDealerUserID.Text = selectedRow.Cells["User ID"].Value.ToString();
            subDealerID = selectedRow.Cells["User ID"].Value.ToString();
            tb_dealerName.Text = selectedRow.Cells["Dealer Name"].Value.ToString();
            tb_dealerMail.Text = selectedRow.Cells["Dealer Mail"].Value.ToString();
            discountIDFK = selectedRow.Cells["DiscountIDFK"].Value.ToString();
            cbb_subDealers.SelectedValue = Convert.ToInt32(selectedRow.Cells["DiscountIDFK"].Value);
            tb_dealerAdress.Text = selectedRow.Cells["Dealer Address"].Value.ToString();
            tb_dealerCity.Text = selectedRow.Cells["Dealer City"].Value.ToString();
            tb_dealerPostalCode.Text = selectedRow.Cells["Dealer Postal Code"].Value.ToString();
            tb_dealerCountry.Text = selectedRow.Cells["Dealer Country"].Value.ToString();
            cb_subDealerUser.Checked = selectedRow.Cells["Is Deleted"].Value.ToString() == "Yes" ? true : false;
            btn_save.Enabled = false;
            btn_cancelEdit.Enabled = true;
            btn_editSubDealers.Enabled = true;
            tb_subDealerUserID.Enabled = false;
        }

        private void ComboboxSubDealersLoad()
        {
            List<DiscountRates> dr = dm.getDiscountRates();
            dr.Insert(0, new DiscountRates { discountID = 0, discountType = "---Choose---" });
            cbb_subDealers.DataSource = dr;
            cbb_subDealers.DisplayMember = "discountType";
            cbb_subDealers.ValueMember = "discountID";
            cbb_subDealers.SelectedIndex = 0;
        }

        private void cbb_subDealers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_subDealers.SelectedIndex != 0 && cbb_subDealers.SelectedValue != null)
            {
                if (int.TryParse(cbb_subDealers.SelectedValue.ToString(), out int id))
                {
                    selectedDiscountID = id;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
            if (!dm.isTextBoxesEmpty(gb_addSubDealers,nullableControl))
            {
                if (cbb_subDealers.SelectedIndex != 0)
                {
                    byte checkSubDealer = dm.listSubDealer(tb_dealerName.Text, tb_dealerMail.Text);
                    if (checkSubDealer == 0)
                    {
                        string subDealerName = "";
                        string subDealerMail = "";
                        string selectedDiscountIDFK = selectedDiscountID.ToString();
                        string subDealerAdress = "";
                        string subDealerCity = "";
                        string subDealerPostalCode = "";
                        string subDealerCountry = "";
                        bool isDeleted = false;
                        if (tb_dealerName.Text.Length < 50 && tb_dealerMail.Text.Length < 50)
                        {
                            if (tb_dealerCity.Text.Length < 50 && tb_dealerPostalCode.Text.Length < 20 && tb_dealerCountry.Text.Length < 50)
                            {
                                subDealerName = tb_dealerName.Text;
                                subDealerMail = tb_dealerMail.Text;
                                subDealerAdress = tb_dealerAdress.Text;
                                subDealerCity = tb_dealerCity.Text;
                                subDealerPostalCode = tb_dealerPostalCode.Text;
                                subDealerCountry = tb_dealerCountry.Text;
                                isDeleted = cb_subDealerUser.Checked;
                                dm.addSubDealers(subDealerName, subDealerMail, subDealerAdress, subDealerCity, subDealerPostalCode, subDealerCountry, selectedDiscountIDFK, isDeleted);
                                SubDealersLoad();
                                dm.clearControls(gb_addSubDealers);
                                btn_cancelEdit.Enabled = false;
                                btn_editSubDealers.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Sub Dealer City/ Sub Dealer Postal Code/ Sub Dealer Country name too long, it can be max 50/20/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Sub Dealer Mail or Sub Dealer Name too long, it can be max 50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sub Dealer has already been entered, please check your information!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select Discount Type!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have entered an incomplete entry, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editSubDealers_Click(object sender, EventArgs e)
        {
            if (!dm.isTextBoxesEmpty(gb_addSubDealers,nullableControl))
            {
                if (cbb_subDealers.SelectedIndex != 0)
                {
                    byte checkSubDealer = dm.listSubDealer(tb_dealerName.Text, tb_dealerMail.Text);
                    if (checkSubDealer == 0)
                    {
                        string subDealerName = "";
                        string subDealerMail = "";
                        string selectedDiscountIDFK = selectedDiscountID.ToString();
                        string subDealerAdress = "";
                        string subDealerCity = "";
                        string subDealerPostalCode = "";
                        string subDealerCountry = "";
                        bool isDeleted = false;
                        if (tb_dealerName.Text.Length < 50 && tb_dealerMail.Text.Length < 50)
                        {
                            if (tb_dealerCity.Text.Length < 50 && tb_dealerPostalCode.Text.Length < 20 && tb_dealerCountry.Text.Length < 50)
                            {
                                subDealerName = tb_dealerName.Text;
                                subDealerMail = tb_dealerMail.Text;
                                subDealerAdress = tb_dealerAdress.Text;
                                subDealerCity = tb_dealerCity.Text;
                                subDealerPostalCode = tb_dealerPostalCode.Text;
                                subDealerCountry = tb_dealerCountry.Text;
                                isDeleted = cb_subDealerUser.Checked;
                                dm.editSubDealers(subDealerID, subDealerName, subDealerMail, subDealerAdress, subDealerCity, subDealerPostalCode, subDealerCountry, selectedDiscountIDFK, isDeleted);
                                SubDealersLoad();
                                dm.clearControls(gb_addSubDealers);
                               
                                btn_cancelEdit.Enabled = false;
                                btn_editSubDealers.Enabled = false;
                                btn_save.Enabled = true;
                                cb_subDealerUser.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Sub Dealer City/ Sub Dealer Postal Code/ Sub Dealer Country name too long, it can be max 50/20/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sub Dealer Mail or Sub Dealer Name too long, it can be max 50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        string selectedDiscountIDFK = selectedDiscountID.ToString();
                        string subDealerAdress = "";
                        string subDealerCity = "";
                        string subDealerPostalCode = "";
                        string subDealerCountry = "";
                        bool isDeleted = false;
                        if (tb_dealerName.Text.Length < 50 && tb_dealerMail.Text.Length < 50)
                        {
                            if (tb_dealerCity.Text.Length < 50 && tb_dealerPostalCode.Text.Length < 20 && tb_dealerCountry.Text.Length < 50)
                            {

                                subDealerAdress = tb_dealerAdress.Text;
                                subDealerCity = tb_dealerCity.Text;
                                subDealerPostalCode = tb_dealerPostalCode.Text;
                                subDealerCountry = tb_dealerCountry.Text;
                                isDeleted = cb_subDealerUser.Checked;
                                dm.editSubDealers(subDealerID, subDealerAdress, subDealerCity, subDealerPostalCode, subDealerCountry, selectedDiscountIDFK, isDeleted);
                                SubDealersLoad();
                                dm.clearControls(gb_addSubDealers);
                             
                                btn_cancelEdit.Enabled = false;
                                btn_editSubDealers.Enabled = false;
                                btn_save.Enabled = true;
                                cb_subDealerUser.Enabled = false;

                            }
                            else
                            {
                                MessageBox.Show("Sub Dealer City/ Sub Dealer Postal Code/ Sub Dealer Country name too long, it can be max 50/20/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Sub Dealer Mail or Sub Dealer Name too long, it can be max 50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select Discount Type!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have entered an incomplete entry, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelEdit_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            btn_cancelEdit.Enabled = false;
            btn_editSubDealers.Enabled = false;
            cb_subDealerUser.Enabled = false;
            SubDealersLoad();
            dm.clearControls(gb_addSubDealers);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dm.clearControls(gb_addSubDealers);
        }

    }
}
