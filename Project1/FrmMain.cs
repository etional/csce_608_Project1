using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class FrmMain : Form
    {
        private string user_id;
        private int mode;
        private bool accountOpen = false;
        private bool itemOpen = false;
        private bool cartOpen = false;
        private int bill_id;
        private string search = "";

        public FrmMain(string id, int type)
        {
            InitializeComponent();
            this.CenterToScreen();
            user_id = id;
            mode = type;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cbCategory.SelectedIndex = 0;

            DB db = new DB();
            string name = "";
            if (mode == 0)
            {
                name = db.DbGetCustomerName(user_id);
                btnAccount.Text = btnAccount.Text.Replace("name", name);
                bill_id = db.DbInsertBill(user_id);
                List<string> itemList = new List<string>();
                itemList = db.DbGetFirstProducts();
                loadList(itemList);
            }
            else
            {
                btnCart.Visible = false;
                btnAdd.Visible = true;
                name = db.DbGetSupplierName(user_id);
                btnAccount.Text = btnAccount.Text.Replace("name", name);
                bill_id = -1;
                List<string> itemSupp = new List<string>();
                itemSupp = db.DbGetProductsSupp(user_id, "", "");
                loadList(itemSupp);
            }
        }

        private void loadList(List<string> list)
        {
            List<Button> old = pnlList.Controls.OfType<Button>().ToList();
            foreach (Button var in old)
            {
                var.Click -= new EventHandler(buttonHandler_click);
                pnlList.Controls.Remove(var);
                var.Dispose();
            }
            pnlList.Visible = true;
            if (list.Count == 0)
            {
                labelNoResult.Visible = true;
                return;
            }
            labelNoResult.Visible = false;
            List<Button> btns = new List<Button>();
            foreach (string item in list)
            {
                string[] values = item.Split(',');
                string id = values[0];
                string name = values[1];
                string price = values[2];

                Button button = new Button();
                button.Text = "   " + String.Format("{0,-200}  ${1,6}", name, price);
                button.Font = new Font("Tahoma", (float)10);
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Dock = DockStyle.Top;
                button.Height = 40;
                button.FlatStyle = FlatStyle.Flat;
                button.Name = id;
                button.Click += new EventHandler(buttonHandler_click);
                btns.Add(button);
            }
            btns.Reverse();
            foreach (Button btn in btns)
            {
                pnlList.Controls.Add(btn);
            }
            Panel gap = new Panel();
            gap.Dock = DockStyle.Top;
            gap.Height = 30;
            pnlList.Controls.Add(gap);
            pnlList.VerticalScroll.Value = 0;
            if (mode == 1)
            {
                btnAdd.Visible = true;
            }
        }

        private void buttonHandler_click(object sender, EventArgs e)
        {
            pnlList.Visible = false;
            btnAdd.Visible = false;
            Button button = sender as Button;
            int id = Convert.ToInt32(button.Name);
            if (accountOpen)
            {
                FrmInfo info = Application.OpenForms.OfType<FrmInfo>().FirstOrDefault();
                pnlForms.Controls.Remove(info);
                info.Close();
                accountOpen = false;
            }
            if (itemOpen)
            {
                FrmItem item = Application.OpenForms.OfType<FrmItem>().FirstOrDefault();
                pnlForms.Controls.Remove(item);
                item.Close();
                itemOpen = false;
            }
            if (cartOpen)
            {
                FrmCart cart = Application.OpenForms.OfType<FrmCart>().FirstOrDefault();
                pnlForms.Controls.Remove(cart);
                cart.Close();
                cartOpen = false;
            }

            FrmItem frmItem = new FrmItem(bill_id, id, mode);
            frmItem.MdiParent = this;
            frmItem.TopLevel = false;
            pnlForms.Controls.Add(frmItem);
            frmItem.Dock = DockStyle.Fill;
            frmItem.Show();
            itemOpen = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlCategory.Visible = false;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            pnlCategory.Visible = true;
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            pnlList.Visible = false;
            btnAdd.Visible = false;
            if (itemOpen)
            {
                FrmItem item = Application.OpenForms.OfType<FrmItem>().FirstOrDefault();
                pnlForms.Controls.Remove(item);
                item.Close();
                itemOpen = false;
            }
            if (cartOpen)
            {
                FrmCart cart = Application.OpenForms.OfType<FrmCart>().FirstOrDefault();
                pnlForms.Controls.Remove(cart);
                cart.Close();
                cartOpen = false;
            }
            if (accountOpen)
            {
                FrmInfo info = Application.OpenForms.OfType<FrmInfo>().FirstOrDefault();
                info.infoReset();
            }
            else
            {
                FrmInfo frmInfo = new FrmInfo(user_id, mode);
                frmInfo.MdiParent = this;
                frmInfo.TopLevel = false;
                pnlForms.Controls.Add(frmInfo);
                frmInfo.Dock = DockStyle.Fill;
                frmInfo.Show();
                accountOpen = true;
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            pnlList.Visible = false;
            if (accountOpen)
            {
                FrmInfo info = Application.OpenForms.OfType<FrmInfo>().FirstOrDefault();
                pnlForms.Controls.Remove(info);
                info.Close();
                accountOpen = false;
            }
            if (itemOpen)
            {
                FrmItem item = Application.OpenForms.OfType<FrmItem>().FirstOrDefault();
                pnlForms.Controls.Remove(item);
                item.Close();
                itemOpen = false;
            }
            if (cartOpen)
            {
                return;
            }
            else
            {
                FrmCart frmCart = new FrmCart(user_id, bill_id);
                frmCart.MdiParent = this;
                frmCart.TopLevel = false;
                pnlForms.Controls.Add(frmCart);
                frmCart.Dock = DockStyle.Fill;
                frmCart.Show();
                cartOpen = true;
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DB db = new DB();

            FrmLogin frmLogin = Application.OpenForms.OfType<FrmLogin>().FirstOrDefault();
            frmLogin.Show();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetFirstProducts();
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "", "");
            }
            loadList(itemList);
            txtSearch.Text = "";
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Automotive", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Automotive", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnBeauty_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Beauty, Health", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Beauty, Health", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Books", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Books", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnComp_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Computers", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Computers", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnElec_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Electronics", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Electronics", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Entertainments", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Entertainments", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnFashion_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Fashion", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Fashion", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Food, Grocery", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Food, Grocery", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Home, Garden", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Home, Garden", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Outdoors", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Outdoors", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnPet_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Pet Supplies", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Pet Supplies", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnSmart_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Smart Home", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Smart Home", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnSport_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Sports", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Sports", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnToy_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            List<string> itemList = new List<string>();
            if (mode == 0)
            {
                itemList = db.DbGetProducts("Toy, Kids", search);
            }
            else
            {
                itemList = db.DbGetProductsSupp(user_id, "Toy, Kids", search);
            }
            loadList(itemList);
            if (pnlCategory.Visible)
            {
                txtSearch.Text = "";
            }
            pnlCategory.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int index = cbCategory.SelectedIndex;
            search = txtSearch.Text;
            if (index == 0)
            {
                DB db = new DB();
                List<string> itemList = new List<string>();
                if (mode == 0)
                {
                    itemList = db.DbGetProducts("", search);
                }
                else
                {
                    itemList = db.DbGetProductsSupp(user_id, "", search);
                }
                loadList(itemList);
                pnlCategory.Visible = false;
            }
            else if (index == 1)
            {
                btnAuto_Click(Controls["pnlCategory"].Controls["btnAuto"], new EventArgs());
            }
            else if (index == 2)
            {
                btnBeauty_Click(Controls["pnlCategory"].Controls["btnBeauty"], new EventArgs());
            }
            else if (index == 3)
            {
                btnBook_Click(Controls["pnlCategory"].Controls["btnBook"], new EventArgs());
            }
            else if (index == 4)
            {
                btnComp_Click(Controls["pnlCategory"].Controls["btnComp"], new EventArgs());
            }
            else if (index == 5)
            {
                btnElec_Click(Controls["pnlCategory"].Controls["btnElec"], new EventArgs());
            }
            else if (index == 6)
            {
                btnEnter_Click(Controls["pnlCategory"].Controls["btnEnter"], new EventArgs());
            }
            else if (index == 7)
            {
                btnFashion_Click(Controls["pnlCategory"].Controls["btnFashion"], new EventArgs());
            }
            else if (index == 8)
            {
                btnFood_Click(Controls["pnlCategory"].Controls["btnFood"], new EventArgs());
            }
            else if (index == 9)
            {
                btnHome_Click(Controls["pnlCategory"].Controls["btnHome"], new EventArgs());
            }
            else if (index == 10)
            {
                btnOut_Click(Controls["pnlCategory"].Controls["btnOut"], new EventArgs());
            }
            else if (index == 11)
            {
                btnPet_Click(Controls["pnlCategory"].Controls["btnPet"], new EventArgs());
            }
            else if (index == 12)
            {
                btnSmart_Click(Controls["pnlCategory"].Controls["btnSmart"], new EventArgs());
            }
            else if (index == 13)
            {
                btnSport_Click(Controls["pnlCategory"].Controls["btnSport"], new EventArgs());
            }
            else
            {
                btnToy_Click(Controls["pnlCategory"].Controls["btnToy"], new EventArgs());
            }

            search = "";
        }

        public void backList()
        {
            pnlList.Visible = true;
            if (mode == 1)
            {
                btnAdd.Visible = true;
            }
            pnlList.Dock = DockStyle.Fill;
            itemOpen = false;
        }

        public void setBill(int bill)
        {
            bill_id = bill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAdd frmAdd = new FrmAdd(user_id);
            frmAdd.ShowDialog();
        }

        public void update()
        {
            DB db = new DB();
            List<string> itemSupp = new List<string>();
            itemSupp = db.DbGetProductsSupp(user_id, "", "");
            loadList(itemSupp);
        }
    }
}
