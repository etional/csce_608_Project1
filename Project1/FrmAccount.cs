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
    public partial class FrmAccount : Form
    {
        private string user;
        private string account;
        private string bank;

        public FrmAccount(string strUser)
        {
            InitializeComponent();
            this.CenterToScreen();
            user = strUser;
            account = "";
            bank = "";
        }

        public FrmAccount(string strUser, string strAccount, string strBank)
        {
            InitializeComponent();
            this.CenterToScreen();
            user = strUser;
            account = strAccount;
            bank = strBank;
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            if (account != "")
            {
                this.Text = "Edit Bank Account";
                btnCreate.Text = "Edit bank account";
            }
            txtAccount.Text = account;
            txtBank.Text = bank;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;

            if (txtAccount.Text == "" || txtBank.Text == "")
            {
                labelError.Visible = true;
                return;
            }

            DB db = new DB();
            bool dup = false;
            dup = db.DbAccountDuplicate(Convert.ToInt32(txtAccount.Text));
            if (dup && btnCreate.Text == "Add bank account")
            {
                DialogResult d;
                d = MessageBox.Show("Account is already in use. Please use other bank account.", "Message",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult finish;
            if (btnCreate.Text == "Add bank account")
            {
                db.DbInsertAccount(Convert.ToInt32(txtAccount.Text), txtBank.Text, user);
                finish = MessageBox.Show("Congraturation! Your bank account is added successfully.", "Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                db.DbUpdateAccount(Convert.ToInt32(account), Convert.ToInt32(txtAccount.Text), txtBank.Text, user);
                finish = MessageBox.Show("Congraturation! Your bank account is editted successfully.", "Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
