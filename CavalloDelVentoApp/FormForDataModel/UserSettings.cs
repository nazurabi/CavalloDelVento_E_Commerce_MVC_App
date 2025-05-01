using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModelWithADO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FormForDataModel
{
    public partial class UserSettings : Form
    {
        DataModel dm = new DataModel();
        string selectedUserType = "";
        string selectedUserID = "";
        bool seePass = false;
        string nullableControl = "tb_userID";

        public UserSettings()
        {
            InitializeComponent();
        }

        private void UserSettings_Load(object sender, EventArgs e)
        {
            UserDataBind();
            ComboboxUserLoad();
        }

        private void ComboboxUserLoad()
        {
            List<MainUser> mu = new List<MainUser>();
            mu.Insert(0, new MainUser { mainUserID = 0, userName = "Admin" });
            mu.Insert(1, new MainUser { mainUserID = 1, userName = "User" });
            cbb_userType.DataSource = mu;
            cbb_userType.DisplayMember = "userName";
            cbb_userType.ValueMember = "mainUserID";
            cbb_userType.SelectedIndex = 1;
        }

        private void UserDataBind()
        {
            DataTable dt = dm.userDataBind();
            dgv_userInformation.DataSource = dt;
            btn_cancelEdit.Enabled = false;
            btn_editUser.Enabled = false;

        }

        private void cbb_userType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbb_userType.SelectedValue.ToString(), out int id))
            {
                selectedUserType = (id == 0 ? "Admin" : "User");
            }
        }

        private void dgv_userInformation_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_userInformation.Columns[e.ColumnIndex].Name == "User Password")
            {
                // login admin's user name and password here
                string userName = dgv_userInformation.Rows[e.RowIndex].Cells["User Name"].Value?.ToString();
                string userType = dgv_userInformation.Rows[e.RowIndex].Cells["User Type"].Value?.ToString();
                if (e.Value != null /*&& loginUserType=="Admin"*/)
                {
                    if (!seePass)
                    {
                        e.Value = new string('*', e.Value.ToString().Length);
                    }
                    //else
                    //{
                    //    if(userType=="Admin" && userName != loginUserName)
                    //    {
                    //        e.Value = new string('*', e.Value.ToString().Length);
                    //    }
                    //}
                }
            }
        }

        private void cb_seeDataInformation_CheckedChanged(object sender, EventArgs e)
        {
            seePass = cb_seeDataInformation.Checked;
            dgv_userInformation.Refresh();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!dm.isTextBoxesEmpty(gb_userInformation, nullableControl))
            {
                byte checkUser = dm.listUser(tb_userName.Text);
                if (checkUser == 0)
                {
                    string userName = "";
                    string userPassword = "";
                    string userType = selectedUserType;
                    bool isDeleted = false;
                    if (tb_userName.Text.Length < 50 && tb_userPassword.Text.Length < 50)
                    {
                        userName = tb_userName.Text;
                        userPassword = tb_userPassword.Text;
                        isDeleted = cb_userIsDelete.Checked;
                        dm.addUser(userName, userPassword, userType, isDeleted);
                        UserDataBind();
                        dm.clearControls(gb_userInformation);
                    }
                    else
                    {
                        MessageBox.Show("User name or password too long, it can be max 50/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("User has already been entered, please check your information!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("You have entered an incomplete entry, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editUser_Click(object sender, EventArgs e)
        {
            if (!dm.isTextBoxesEmpty(gb_userInformation, nullableControl))
            {
                byte checkSubDealer = dm.listUser(tb_userName.Text);
                if (checkSubDealer == 0)
                {
                    string userName = "";
                    string userPassword = "";
                    string userType = selectedUserType;
                    bool isDeleted = false;
                    if (tb_userName.Text.Length < 50 && tb_userPassword.Text.Length < 50)
                    {
                        userName = tb_userName.Text;
                        userPassword = tb_userPassword.Text;
                        isDeleted = cb_userIsDelete.Checked;
                        dm.editUser(selectedUserID, userName, userPassword, userType, isDeleted);
                        UserDataBind();
                        dm.clearControls(gb_userInformation);
                        btn_cancelEdit.Enabled = false;
                        btn_editUser.Enabled = false;
                        btn_save.Enabled = true;

                    }
                    else
                    {
                        MessageBox.Show("User name or password too long, it can be max 50/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    string userPassword = "";
                    string userType = selectedUserType;
                    bool isDeleted = false;
                    if (tb_userName.Text.Length < 50 && tb_userPassword.Text.Length < 50)
                    {
                        userPassword = tb_userPassword.Text;
                        isDeleted = cb_userIsDelete.Checked;
                        dm.editUser(selectedUserID, userPassword, userType, isDeleted);
                        UserDataBind();
                        dm.clearControls(gb_userInformation);
                        btn_cancelEdit.Enabled = false;
                        btn_editUser.Enabled = false;
                        btn_save.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("User name or password too long, it can be max 50/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("You have entered an incomplete entry, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgv_userInformation_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow selectedRow = dgv_userInformation.Rows[e.RowIndex];
            selectedUserID = selectedRow.Cells["User ID"].Value.ToString();
            tb_userName.Text = selectedRow.Cells["User Name"].Value.ToString();
            tb_userPassword.Text = selectedRow.Cells["User Password"].Value.ToString();
            cbb_userType.SelectedValue = (selectedRow.Cells["User Type"].Value.ToString()) == "Admin" ? 0 : 1;
            cb_userIsDelete.Checked = selectedRow.Cells["Is Deleted"].Value.ToString() == "Yes" ? true : false;
            btn_save.Enabled = false;
            btn_editUser.Enabled = true;
            btn_cancelEdit.Enabled = true;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dm.clearControls(gb_userInformation);
        }

        private void btn_cancelEdit_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            btn_cancelEdit.Enabled = false;
            btn_editUser.Enabled = false;
            UserDataBind();
            dm.clearControls(gb_userInformation);
        }

        private void dgv_userInformation_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_userInformation.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                    rows.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}
