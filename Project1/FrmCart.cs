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
    public partial class FrmCart : Form
    {
        private string user;
        private int bill;
        private bool hasItem = false;
        private bool hasAccount = false;

        public FrmCart(string user_id, int bill_id)
        {
            InitializeComponent();
            user = user_id;
            bill = bill_id;
        }

        private void FrmCart_Load(object sender, EventArgs e)
        {
            loadCart();
            loadAccounts();
            if (hasItem && hasAccount)
            {
                btnPay.Enabled = true;
            }
        }

        private void loadAccounts()
        {
            List<RadioButton> radbs = panel2.Controls.OfType<RadioButton>().ToList();
            foreach (RadioButton rb in radbs)
            {
                panel4.Controls.Remove(rb);
                rb.Dispose();
            }

            List<string> accounts = new List<string>();
            DB db = new DB();
            accounts = db.DbGetAccounts(user);

            if (accounts.Count == 0)
            {
                btnAdd.Visible = true;
                hasAccount = false;
            }
            else
            {
                hasAccount = true;
                RadioButton[] rbs = new RadioButton[accounts.Count];
                btnAdd.Visible = false;
                for (int i = 0; i < accounts.Count; i++)
                {
                    RadioButton rad = new RadioButton();
                    rad.Dock = DockStyle.Top;
                    rad.Height = 30;
                    rad.Text = accounts[i];
                    rad.Name = "rad" + i;
                    rad.TabStop = false;
                    panel4.Controls.Add(rad);
                    rbs[i] = rad;
                }

                for (int i = accounts.Count - 1; i >= 0; i--)
                {
                    panel4.Controls.Add(rbs[i]);
                }
                rbs[0].Checked = true;
            }
        }

        private void loadCart()
        {
            List<Panel> panels = panel3.Controls.OfType<Panel>().ToList();
            foreach (Panel pnl in panels)
            {
                panel3.Controls.Remove(pnl);
                pnl.Dispose();
            }
            string cart = "";
            DB db = new DB();
            cart = db.DbGetCart(bill);
            string[] values = cart.Split('|');

            if (values.Length == 1)
            {
                labelNoItem.Visible = true;
                labelTotal.Visible = false;
                hasItem = false;
            }
            else
            {
                hasItem = true;
                labelNoItem.Visible = false;
                labelTotal.Visible = true;
                labelTotal.Text = "Total: $" + values[0];
                Panel pnlColumn = new Panel();               
                Label lName = new Label();
                Label lQuantity = new Label();
                Label lPrice = new Label();

                lName.Text = "Name";
                lName.Font = new Font("Tahoma", (float)10);
                lName.AutoSize = true;
                lName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                lName.Location = new Point(10, 10);
                lQuantity.Text = "Quantity";
                lQuantity.Font = new Font("Tahoma", (float)10);
                lQuantity.AutoSize = true;
                lQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                lQuantity.Location = new Point(200, 10);
                lPrice.Text = "Price";
                lPrice.Font = new Font("Tahoma", (float)10);
                lPrice.AutoSize = true;
                lPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                lPrice.Location = new Point(300, 10);

                pnlColumn.Dock = DockStyle.Top;
                pnlColumn.AutoSize = true;
                pnlColumn.TabStop = false;
                pnlColumn.Controls.Add(lName);
                pnlColumn.Controls.Add(lQuantity);
                pnlColumn.Controls.Add(lPrice);

                for (int i = 1; i < values.Length ; i++)
                {
                    string[] item = values[i].Split(',');
                    string product_id = item[0];
                    string name = item[1];
                    string price = item[2];
                    string quantity = item[3];
                    Panel pnlProduct = new Panel();
                    Label productName = new Label();
                    Label productQuantity = new Label();
                    Label productPrice = new Label();
                    LinkLabel remove = new LinkLabel();

                    productName.Text = name;
                    productName.Font = new Font("Tahoma", (float)10);
                    productName.AutoSize = true;
                    productName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    productName.Location = new Point(10, 10);
                    productQuantity.Text = quantity;
                    productQuantity.Font = new Font("Tahoma", (float)10);
                    productQuantity.AutoSize = true;
                    productQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    productQuantity.Location = new Point(200, 10);
                    productPrice.Text = "$" + price;
                    productPrice.Font = new Font("Tahoma", (float)10);
                    productPrice.AutoSize = true;
                    productPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    productPrice.Location = new Point(300, 10);
                    remove.Text = "Remove";
                    remove.Font = new Font("Tahoma", (float)10);
                    remove.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    remove.Location = new Point(350, 10);
                    remove.Name = product_id + "," + quantity + "," + price;
                    remove.LinkClicked += new LinkLabelLinkClickedEventHandler(remove_click);

                    pnlProduct.Dock = DockStyle.Top;
                    pnlProduct.AutoSize = true;
                    pnlProduct.TabStop = false;
                    pnlProduct.Controls.Add(productName);
                    pnlProduct.Controls.Add(productQuantity);
                    pnlProduct.Controls.Add(productPrice);
                    pnlProduct.Controls.Add(remove);

                    panel3.Controls.Add(pnlProduct);
                }
                panel3.Controls.Add(pnlColumn);
            }
        }

        private void remove_click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel label = sender as LinkLabel;
            string[] values = label.Name.Split(',');
            int product_id = Convert.ToInt32(values[0]);
            int quantity = Convert.ToInt32(values[1]);
            decimal price = Convert.ToDecimal(values[2]);

            DB db = new DB();
            db.DbRemoveFromCart(bill, product_id, quantity);

            Control parent = label.Parent;
            Control control = parent.Parent;
            control.Controls.Remove(parent);

            List<Panel> pnls = panel3.Controls.OfType<Panel>().ToList();
            if (pnls.Count == 1)
            {
                panel3.Controls.Remove(pnls[0]);
                labelTotal.Visible = false;
                labelNoItem.Visible = true;
            }
            else
            {
                decimal old = Convert.ToDecimal(labelTotal.Text.Replace("Total: $", ""));
                decimal new_total = old - quantity * price;
                labelTotal.Text = "Total: $" + new_total.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAccount frmAccount = new FrmAccount(user);
            frmAccount.ShowDialog();

            loadAccounts();
            if (hasItem && hasAccount)
            {
                btnPay.Enabled = true;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            var checkedButton = panel4.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            string text = checkedButton.Text;
            string[] accountInfo = text.Split(',');
            string number = accountInfo[0].Replace("Account Number: ", "");
            int account = Convert.ToInt32(number);

            DB db = new DB();
            db.DbInsertSettle(bill, account);
            MessageBox.Show("Payment is completed.");

            bill = db.DbInsertBill(user);
            FrmMain main = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            main.setBill(bill);
            loadCart();
        }
    }
}
