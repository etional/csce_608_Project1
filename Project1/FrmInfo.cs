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
    public partial class FrmInfo : Form
    {
        private string user;
        private string name;
        private string pw;
        private string address;
        private string phone;
        private string review;
        private int mode;

        public FrmInfo(string strUser, int type)
        {
            InitializeComponent();
            user = strUser;
            mode = type;
        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {
            groupInfo.Visible = true;
            groupAccount.Visible = true;
            pnlHistory.Visible = false;

            pw = "";
            name = "";
            phone = "";
            address = "";
            review = "";
            DB db = new DB();
            if (mode == 0)
            {
                db.DbGetCustomer(user, ref pw, ref name, ref address, ref phone);
                loadAccounts();
            }
            else
            {
                db.DbGetSupplier(user, ref pw, ref name, ref address, ref phone, ref review);
                groupAccount.Visible = false;
                btnOrder.Visible = false;
            }
            txtName.Text = name;
            txtEmail.Text = user;
            txtPW.Text = pw;
            txtPhone.Text = phone;
            txtAddress.Text = address;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Edit")
            {
                txtName.Enabled = true;
                txtEmail.Enabled = true;
                txtPW.Enabled = true;
                txtPhone.Enabled = true;
                txtAddress.Enabled = true;
                btnUpdate.Text = "Update";
                btnCancel.Visible = true;
            }
            else
            {
                if (!validation())
                {
                    DialogResult d;
                    d = MessageBox.Show("Please provide all information.", "Message",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DB db = new DB();
                // email update
                string newEmail = "";
                if (user != txtEmail.Text)
                {
                    bool dup = false;
                    if (mode == 0)
                    {
                        dup = db.DbCustomerDuplicate(txtEmail.Text);
                    }
                    else
                    {
                        dup = db.DbSupplierDuplicate(txtEmail.Text);
                    }
                    if (dup)
                    {
                        DialogResult d;
                        d = MessageBox.Show("Email is already in use. Please use other email address.", "Message",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    newEmail = txtEmail.Text;
                }
                if (mode == 0)
                {
                    db.DbUpdateCustomer(user, newEmail, txtPW.Text, txtName.Text, txtAddress.Text, txtPhone.Text);
                }
                else
                {
                    db.DbUpdateSupplier(user, newEmail, txtPW.Text, txtName.Text, txtAddress.Text, txtPhone.Text);
                }

                DialogResult message;
                message = MessageBox.Show("The information is updated successfully.", "Message",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                name = txtName.Text;
                user = txtEmail.Text;
                pw = txtPW.Text;
                phone = txtPhone.Text;
                address = txtAddress.Text;
                txtName.Enabled = false;
                txtEmail.Enabled = false;
                txtPW.Enabled = false;
                txtPhone.Enabled = false;
                txtAddress.Enabled = false;
                btnUpdate.Text = "Edit";
                btnCancel.Visible = false;
            }      
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAccount frmAccount = new FrmAccount(user);
            frmAccount.ShowDialog();

            loadAccounts();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var checkedButton = panel2.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            string text = checkedButton.Text;
            string[] accountInfo = text.Split(',');
            string number = accountInfo[0].Replace("Account Number: ", "");
            int account = Convert.ToInt32(number);

            DB db = new DB();
            db.DbDeleteAccount(account);
            DialogResult message;
            message = MessageBox.Show("The information is deleted successfully.", "Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadAccounts();
        }

        public void infoReset()
        {
            txtName.Text = name;
            txtEmail.Text = user;
            txtPW.Text = pw;
            txtPhone.Text = phone;
            txtAddress.Text = address;
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            txtPW.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            btnUpdate.Text = "Edit";
            btnCancel.Visible = false;
        }

        private bool validation()
        {
            bool pass = true;

            if (txtName.Text == "")
            {
                pass = false;
            }
            if (txtEmail.Text == "")
            {
                pass = false;
            }
            if (txtPW.Text == "")
            {
                pass = false;
            }
            if (txtPhone.Text == "")
            {
                pass = false;
            }
            if (txtAddress.Text == "")
            {
                pass = false;
            }
            return pass;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmail.Text = user;
            txtName.Text = name;
            txtPW.Text = pw;
            txtAddress.Text = address;
            txtPhone.Text = phone;
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            txtPW.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            btnUpdate.Text = "Edit";
            btnCancel.Visible = false;
        }

        private void loadAccounts()
        {
            List<RadioButton> radbs = panel2.Controls.OfType<RadioButton>().ToList();
            foreach (RadioButton rb in radbs)
            {
                panel2.Controls.Remove(rb);
                rb.Dispose();
            }

            List<string> accounts = new List<string>();
            DB db = new DB();
            accounts = db.DbGetAccounts(user);

            if (accounts.Count == 0)
            {
                labelNoAccount.Visible = true;
                btnEdit.Visible = false;
                btnRemove.Visible = false;
            }
            else
            {
                RadioButton[] rbs = new RadioButton[accounts.Count];
                labelNoAccount.Visible = false;
                btnEdit.Visible = true;
                btnRemove.Visible = true;
                for (int i = 0; i < accounts.Count; i++)
                {
                    RadioButton rad = new RadioButton();
                    rad.Dock = DockStyle.Top;
                    rad.Height = 30;
                    rad.Text = accounts[i];
                    rad.Name = "rad" + i;
                    rad.TabStop = false;
                    panel2.Controls.Add(rad);
                    rbs[i] = rad;
                }

                for (int i = accounts.Count - 1; i >= 0; i--)
                {
                    panel2.Controls.Add(rbs[i]);
                }
                rbs[0].Checked = true;
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (groupInfo.Visible)
            {
                return;
            }
            infoReset();
            pnlHistory.Visible = false;

            groupInfo.Visible = true;
            if (mode == 0)
            {
                groupAccount.Visible = true;
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (pnlHistory.Visible)
            {
                return;
            }
            groupInfo.Visible = false;
            groupAccount.Visible = false;
            pnlHistory.Visible = true;

            List<Panel> panels = pnlList.Controls.OfType<Panel>().ToList();
            foreach (Panel pnl in panels)
            {
                pnlList.Controls.Remove(pnl);
                pnl.Dispose();
            }

            List<string> bills = new List<string>();
            DB db = new DB();
            bills = db.DbGetBills(user);

            if (bills.Count == 0)
            {
                labelNoHistory.Visible = true;
            }
            else
            {
                labelNoHistory.Visible = false;
                for (int i = 0; i < bills.Count; i++)
                {
                    string[] values = bills[i].Split('|');
                    string bill_id = values[0];
                    string total = values[1];
                    string[] item = values[2].Split(',');
                    string account_id = item[0];

                    Panel pnlMain = new Panel();
                    Panel pnlLabel = new Panel();
                    Panel pnlColumn = new Panel();
                    Label lBill = new Label();
                    Label lAccount = new Label();
                    Label lTotal = new Label();
                    Label lName = new Label();
                    Label lQuantity = new Label();
                    Label lPrice = new Label();

                    lBill.Text = "Bill ID: " + bill_id;
                    lBill.Font = new Font("Tahoma", (float)10);
                    lBill.AutoSize = true;
                    lBill.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lBill.Location = new Point(10, 10);
                    lAccount.Text = "Account ID: " + account_id;
                    lAccount.Font = new Font("Tahoma", (float)10);
                    lAccount.AutoSize = true;
                    lAccount.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lAccount.Location = new Point(150, 10);
                    lTotal.Text = "Total: $" + total;
                    lTotal.Font = new Font("Tahoma", (float)10);
                    lTotal.AutoSize = true;
                    lTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    lTotal.Location = new Point(300, 10);
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

                    pnlLabel.Dock = DockStyle.Top;
                    pnlLabel.AutoSize = true;
                    pnlLabel.TabStop = false;
                    pnlLabel.Controls.Add(lBill);
                    pnlLabel.Controls.Add(lAccount);
                    pnlLabel.Controls.Add(lTotal);
                    pnlColumn.Dock = DockStyle.Top;
                    pnlColumn.AutoSize = true;
                    pnlColumn.TabStop = false;
                    pnlColumn.Controls.Add(lName);
                    pnlColumn.Controls.Add(lQuantity);
                    pnlColumn.Controls.Add(lPrice);
                    pnlMain.Dock = DockStyle.Top;
                    pnlMain.AutoSize = true;
                    pnlMain.TabStop = false;

                    for (int j = 2; j < values.Length; j++)
                    {
                        string[] product = values[j].Split(',');
                        string name = product[1];
                        string price = product[2];
                        string quantity = product[3];
                        Panel pnlProduct = new Panel();
                        Label productName = new Label();
                        Label productQuantity = new Label();
                        Label productPrice = new Label();

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

                        pnlProduct.Dock = DockStyle.Top;
                        pnlProduct.AutoSize = true;
                        pnlProduct.TabStop = false;
                        pnlProduct.Controls.Add(productName);
                        pnlProduct.Controls.Add(productQuantity);
                        pnlProduct.Controls.Add(productPrice);

                        pnlMain.Controls.Add(pnlProduct);
                    }
                    pnlMain.Controls.Add(pnlColumn);
                    pnlMain.Controls.Add(pnlLabel);
                    pnlList.Controls.Add(pnlMain);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var checkedButton = panel2.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            string text = checkedButton.Text;
            string[] accountInfo = text.Split(',');
            string number = accountInfo[0].Replace("Account Number: ", "");
            string bank = accountInfo[1].Replace(" Bank Name: ", "");
            FrmAccount frmAccount = new FrmAccount(user, number, bank);
            frmAccount.ShowDialog();

            loadAccounts();
        }
    }
}
