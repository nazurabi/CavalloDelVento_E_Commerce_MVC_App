using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModelWithADO;


namespace FormForDataModel
{
    public partial class MainForm : Form
    {
        DataModel dm = new DataModel();
        int counter = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = dm.FormTitle();
            lbl_welcomeTitle.Text = "Welcome To " + dm.FormTitle();
            lbl_welcomeTitle.Location = new Point(
                (this.ClientSize.Width - lbl_welcomeTitle.Width) / 2, lbl_welcomeTitle.Location.Y);
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(0, 90, 157);
                }
            }
            tmr_welcomeTitle.Start();

        }
        private void tmr_welcomeTitle_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter == 5)
            {
                lbl_welcomeTitle.Visible = false;
                tmr_welcomeTitle.Stop();
            }
        }

        private void TSMI_addBrand_Click(object sender, EventArgs e)
        {
            Form[] openForms = this.MdiChildren;
            bool isOpen = false;
            foreach (var item in openForms)
            {
                if (item.GetType() == typeof(BrandsAdd))
                {
                    isOpen = true;
                    item.Activate();
                }
            }
            if (isOpen == false)
            {
                BrandsAdd brandAdd = new BrandsAdd();
                brandAdd.MdiParent = this;
                brandAdd.Show();
            }
        }

        private void TSMI_editBrand_Click(object sender, EventArgs e)
        {
            Form[] openForms = this.MdiChildren;
            bool isOpen = false;
            foreach (var item in openForms)
            {
                if (item.GetType() == typeof(BrandsEdit))
                {
                    isOpen = true;
                    item.Activate();
                }
            }
            if (isOpen == false)
            {
                BrandsEdit brandEdit = new BrandsEdit();
                brandEdit.MdiParent = this;
                brandEdit.Show();
            }
        }

        private void TSMI_addCategory_Click(object sender, EventArgs e)
        {
            Form[] openForms = this.MdiChildren;
            bool isOpen = false;
            foreach (var item in openForms)
            {
                if (item.GetType() == typeof(CategoriesAdd))
                {
                    isOpen = true;
                    item.Activate();
                }
            }
            if (isOpen == false)
            {
                CategoriesAdd categoriesAdd = new CategoriesAdd();
                categoriesAdd.MdiParent = this;
                categoriesAdd.Show();
            }
        }

        private void TSMI_editCategory_Click(object sender, EventArgs e)
        {
            Form[] openForms = this.MdiChildren;
            bool isOpen = false;
            foreach (var item in openForms)
            {
                if (item.GetType() == typeof(CategoriesEdit))
                {
                    isOpen = true;
                    item.Activate();
                }
            }
            if (isOpen == false)
            {
                CategoriesEdit categoriesEdit = new CategoriesEdit();
                categoriesEdit.MdiParent = this;
                categoriesEdit.Show();
            }
        }

        private void TSMI_addProduct_Click(object sender, EventArgs e)
        {
            Form[] openForms = this.MdiChildren;
            bool isOpen = false;
            foreach (var item in openForms)
            {
                if (item.GetType() == typeof(ProductsAdd))
                {
                    isOpen = true;
                    item.Activate();
                }
            }
            if (isOpen == false)
            {
                ProductsAdd productAdd = new ProductsAdd();
                productAdd.MdiParent = this;
                productAdd.Show();
            }
        }

        private void TSMI_editProduct_Click(object sender, EventArgs e)
        {
            Form[] openForms = this.MdiChildren;
            bool isOpen = false;
            foreach (var item in openForms)
            {
                if (item.GetType() == typeof(ProductsEdit))
                {
                    isOpen = true;
                    item.Activate();
                }
            }
            if (isOpen == false)
            {
                ProductsEdit productEdit = new ProductsEdit();
                productEdit.MdiParent = this;
                productEdit.Show();
            }
        }

        private void TSMI_editSendToSubDealers_Click(object sender, EventArgs e)
        {
            Form[] openForms = this.MdiChildren;
            bool isOpen = false;
            foreach (var item in openForms)
            {
                if (item.GetType() == typeof(SendToSubDealers))
                {
                    isOpen = true;
                    item.Activate();
                }
            }
            if (isOpen == false)
            {
                SendToSubDealers sendToSubDealers = new SendToSubDealers();
                sendToSubDealers.MdiParent = this;
                sendToSubDealers.Show();
            }
        }

        private void TSMI_editLevelIntegration_Click(object sender, EventArgs e)
        {
            Form[] openForms = this.MdiChildren;
            bool isOpen = false;
            foreach (var item in openForms)
            {
                if (item.GetType() == typeof(LevelIntegrationOrders))
                {
                    isOpen = true;
                    item.Activate();
                }
            }
            if (isOpen == false)
            {
                LevelIntegrationOrders levelIntegrationOrders = new LevelIntegrationOrders();
                levelIntegrationOrders.MdiParent = this;
                levelIntegrationOrders.Show();
            }
        }

        private void TSMI_listBrands_Click(object sender, EventArgs e)
        {

        }

        private void TSMI_listCategories_Click(object sender, EventArgs e)
        {

        }

        private void TSMI_listProducts_Click(object sender, EventArgs e)
        {

        }

        private void TSMI_settingMainDealer_Click(object sender, EventArgs e)
        {

        }

        private void TSMI_settingMainUsers_Click(object sender, EventArgs e)
        {

        }

        private void TSMI_settingSubDealers_Click(object sender, EventArgs e)
        {

        }

        private void TSMI_settingDiscount_Click(object sender, EventArgs e)
        {

        }

        private void TSMI_logOut_Click(object sender, EventArgs e)
        {

        }

        private void TSMI_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TSMI_info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ben Yaptım");
        }
    }
}
