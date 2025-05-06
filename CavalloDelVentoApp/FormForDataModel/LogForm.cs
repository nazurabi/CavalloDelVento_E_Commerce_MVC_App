using System;
using System.Drawing;
using System.Windows.Forms;
using DataModelWithADO;

namespace FormForDataModel
{
    public partial class LogForm : Form
    {
        DataModel dm = new DataModel();
        bool isLogin = false;
        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            this.Text = "Welcome to " + dm.FormTitle();
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(0, 90, 157);
                }
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_userName.Text) && !string.IsNullOrEmpty(tb_password.Text))
            {
                MainUser mu = dm.getUserInformation(tb_userName.Text.ToString(), tb_password.Text.ToString());
                if (mu != null && mu.isDeleted == false)
                {
                    LoginUser.loginUser = mu;
                    isLogin = true;
                    MessageBox.Show("Login successfull, welcome to " + dm.FormTitle(), "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User not found, please check your information!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Username or Password is not empty, please check your information!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isLogin == false)
            {
                Application.Exit();
            }
        }
    }
}
