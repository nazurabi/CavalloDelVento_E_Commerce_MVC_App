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
            if (LoginUser.loginUser.userType == "User")
            {
                btn_save.Enabled = false;
                cb_userIsDelete.Enabled = false;
                cb_seeDataInformation.Enabled = false;
            }
        }

        private void UserDataBind()
        {
            DataTable dt = dm.userDataBind();
            dgv_userInformation.DataSource = dt;
            btn_cancelEdit.Enabled = false;
            btn_editUser.Enabled = false;


        }

        private void dgv_userInformation_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_userInformation.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                   rows.Cells["Is Deleted"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void dgv_userInformation_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btn_editUser.Enabled = false;
            tb_userName.Enabled = false;
            tb_userPassword.Enabled = false;
            cb_userIsDelete.Enabled = (LoginUser.loginUser.userType == "Admin") ? true : false;

            DataGridViewRow selectedRow = dgv_userInformation.Rows[e.RowIndex];
            selectedUserID = selectedRow.Cells["User ID"].Value.ToString();
            tb_userID.Text = selectedRow.Cells["User ID"].Value.ToString();
            tb_userName.Text = selectedRow.Cells["User Name"].Value.ToString();
            string dgvUserName = selectedRow.Cells["User Name"].Value.ToString();
            cbb_userType.SelectedValue = (selectedRow.Cells["User Type"].Value.ToString()) == "Admin" ? 2 : 1;
            string dgvUserType = selectedRow.Cells["User Type"].Value.ToString();

            if (LoginUser.loginUser.userType == "Admin" && dgvUserType == "User")
            {
                tb_userPassword.Text = selectedRow.Cells["User Password"].Value.ToString();
                tb_userName.Enabled = true;
                tb_userPassword.Enabled = true;
                btn_editUser.Enabled = true;
            }
            else if (LoginUser.loginUser.userType == "User" && dgvUserName == LoginUser.loginUser.userName.ToString())
            {
                tb_userPassword.Text = selectedRow.Cells["User Password"].Value.ToString();
                tb_userName.Enabled = true;
                tb_userPassword.Enabled = true;
                btn_editUser.Enabled = true;
            }
            else if (LoginUser.loginUser.userType == "Admin" && dgvUserName == LoginUser.loginUser.userName)
            {
                tb_userPassword.Text = selectedRow.Cells["User Password"].Value.ToString();
                tb_userName.Enabled = true;
                tb_userPassword.Enabled = true;
                btn_editUser.Enabled = true;
            }
            else
            {
                string encryptIt = new string('*', selectedRow.Cells["User Password"].Value.ToString().Length);
                tb_userPassword.Text = encryptIt;
            }

            if (LoginUser.loginUser.userType == "Admin")
            {
                btn_editUser.Enabled = true;
            }
            cb_userIsDelete.Checked = selectedRow.Cells["Is Deleted"].Value.ToString() == "Yes" ? true : false;
            btn_save.Enabled = false;
            btn_cancelEdit.Enabled = true;
        }

        private void ComboboxUserLoad()
        {
            List<MainUser> mu = new List<MainUser>();

            mu.Insert(0, new MainUser { mainUserID = 0, userName = "---Choose---" });
            mu.Insert(1, new MainUser { mainUserID = 1, userName = "User" });
            mu.Insert(2, new MainUser { mainUserID = 2, userName = "Admin" });
            cbb_userType.DataSource = mu;
            cbb_userType.DisplayMember = "userName";
            cbb_userType.ValueMember = "mainUserID";
            cbb_userType.SelectedIndex = 0;
        }

        private void cbb_userType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_userType.SelectedIndex != 0 && cbb_userType.SelectedValue != null)
            {
                if (int.TryParse(cbb_userType.SelectedValue.ToString(), out int id))
                {
                    selectedUserType = (id == 1 ? "User" : "Admin");
                }
            }
        }

        private void dgv_userInformation_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_userInformation.Columns[e.ColumnIndex].Name == "User Password")
            {
                string userName = dgv_userInformation.Rows[e.RowIndex].Cells["User Name"].Value?.ToString();
                string userType = dgv_userInformation.Rows[e.RowIndex].Cells["User Type"].Value?.ToString();
                if (e.Value != null && LoginUser.loginUser.userType == "Admin")
                {
                    if (!seePass)
                    {
                        e.Value = new string('*', e.Value.ToString().Length);
                    }
                    else
                    {
                        if (userType == "Admin" && userName != LoginUser.loginUser.userName)
                        {
                            e.Value = new string('*', e.Value.ToString().Length);
                        }
                    }
                }
                else
                {
                    e.Value = new string('*', e.Value.ToString().Length);
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
            if (!dm.isTextBoxesEmpty(gb_userInformation, nullableControl) && cbb_userType.SelectedIndex != 0)
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
                        clearControl();
                        UserDataBind();
                        ComboboxUserLoad();

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
            if (!dm.isTextBoxesEmpty(gb_userInformation, nullableControl) && cbb_userType.SelectedIndex != 0)
            {
                byte checkSubDealer = dm.listUser(tb_userName.Text);
                if (checkSubDealer == 0)
                {
                    string userType = selectedUserType;
                    bool isDeleted = false;
                    if (tb_userName.Text.Length < 50 && tb_userPassword.Text.Length < 50)
                    {
                        string userName = tb_userName.Text;
                        string userPassword = tb_userPassword.Text;
                        isDeleted = cb_userIsDelete.Checked;
                        if (isDeleted == false)
                        {
                            dm.editUser(selectedUserID, userName, userPassword, userType, isDeleted);
                            UserDataBind();
                            clearControl();
                            btn_cancelEdit.Enabled = false;
                            btn_cancelEdit.Enabled = false;
                            btn_editUser.Enabled = false;
                            btn_save.Enabled = true;
                            cb_userIsDelete.Enabled = false;
                        }
                        else
                        {
                            if (userType == "Admin")
                            {
                                byte checkAdmin = dm.checkAdmin();
                                if (checkAdmin > 1)
                                {
                                    dm.editUser(selectedUserID, userName, userPassword, userType, isDeleted);
                                    UserDataBind();
                                    clearControl();
                                    btn_cancelEdit.Enabled = false;
                                    btn_cancelEdit.Enabled = false;
                                    btn_editUser.Enabled = false;
                                    btn_save.Enabled = true;
                                    cb_userIsDelete.Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show("You can not delete last admin! If you want to delete this admin, you must add new one.");
                                }
                            }
                            else
                            {
                                dm.editUser(selectedUserID, userName, userPassword, userType, isDeleted);
                                UserDataBind();
                                clearControl();
                                btn_cancelEdit.Enabled = false;
                                btn_cancelEdit.Enabled = false;
                                btn_editUser.Enabled = false;
                                btn_save.Enabled = true;
                                cb_userIsDelete.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("User name or password too long, it can be max 50/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Since the user is registered in your system, you can only update the password or user information. Do you want to continue?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        string userPassword = "";
                        string userType = selectedUserType;
                        bool isDeleted = false;
                        if (tb_userName.Text.Length < 50 && tb_userPassword.Text.Length < 50)
                        {
                            userPassword = tb_userPassword.Text;
                            isDeleted = cb_userIsDelete.Checked;
                            if (isDeleted == false)
                            {

                                dm.editUser(selectedUserID, userPassword, userType, isDeleted);
                                UserDataBind();
                                clearControl();
                                btn_cancelEdit.Enabled = false;
                                btn_editUser.Enabled = false;
                                btn_save.Enabled = true;
                                cb_userIsDelete.Enabled = false;
                            }
                            else
                            {
                                if (userType == "Admin")
                                {
                                    byte checkAdmin = dm.checkAdmin();
                                    if (checkAdmin > 1)
                                    {
                                        dm.editUser(selectedUserID, userPassword, userType, isDeleted);
                                        UserDataBind();
                                        clearControl();
                                        btn_cancelEdit.Enabled = false;
                                        btn_editUser.Enabled = false;
                                        btn_save.Enabled = true;
                                        cb_userIsDelete.Enabled = false;
                                    }
                                    else
                                    {
                                        MessageBox.Show("You can not delete last admin! If you want to delete this admin, you must add new one.");
                                    }
                                }
                                else
                                {
                                    dm.editUser(selectedUserID, userPassword, userType, isDeleted);
                                    UserDataBind();
                                    clearControl();
                                    btn_cancelEdit.Enabled = false;
                                    btn_editUser.Enabled = false;
                                    btn_save.Enabled = true;
                                    cb_userIsDelete.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("User name or password too long, it can be max 50/50 characters!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("You have entered an incomplete entry, please enter all data!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelEdit_Click(object sender, EventArgs e)
        {
            if (LoginUser.loginUser.userType == "Admin")
            {
                btn_save.Enabled = true;
            }
            btn_cancelEdit.Enabled = false;
            btn_editUser.Enabled = false;
            cb_userIsDelete.Enabled = false;
            UserDataBind();
            clearControl();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearControl();
        }

        public void clearControl()
        {
            tb_userID.Text = "";
            tb_userName.Text = "";
            tb_userPassword.Text = "";
            cb_seeDataInformation.Checked = false;
            cb_userIsDelete.Checked = false;
            ComboboxUserLoad();
        }

    }
}
