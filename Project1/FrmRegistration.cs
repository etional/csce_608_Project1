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
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void radCustomer_Click(object sender, EventArgs e)
        {
            if (!radCustomer.Checked)
            {
                radCustomer.Checked = true;
                radSupplier.Checked = false;
            }
        }

        private void radSupplier_Click(object sender, EventArgs e)
        {
            if (!radSupplier.Checked)
            {
                radSupplier.Checked = true;
                radCustomer.Checked = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!validation())
            {
                labelError.Visible = true;
                return;
            }

            DB db = new DB();
            string email = txtEmail.Text;
            bool dup = false;
            if (radCustomer.Checked)
            {
                dup = db.DbCustomerDuplicate(email);
                if (dup)
                {
                    DialogResult d;
                    d = MessageBox.Show("Email is already in use. Please use other email address.", "Message", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                dup = db.DbSupplierDuplicate(email);
                if (dup)
                {
                    DialogResult d;
                    d = MessageBox.Show("Email is already in use. Please use other email address.", "Message", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string pw = txtPW.Text;
            string name = txtName.Text;
            string address = txtStreet.Text + " " + txtCity.Text + ", " + txtState.Text + ", " + txtZip.Text;
            string phone = txtPhone.Text;

            if (radCustomer.Checked)
            {
                db.DbInsertCustomer(email, pw, name, address, phone);
            }
            else
            {
                db.DbInsertSupplier(email, pw, name, address, phone);
            }
            DialogResult finish;
            finish = MessageBox.Show("Congraturation! Your account is created successfully.", "Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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
            if (txtStreet.Text == "")
            {
                pass = false;
            }
            if (txtCity.Text == "")
            {
                pass = false;
            }
            if (txtState.Text == "")
            {
                pass = false;
            }
            if (txtZip.Text == "")
            {
                pass = false;
            }
            return pass;
        }

        private void FrmRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmLogin frmLogin = Application.OpenForms.OfType<FrmLogin>().FirstOrDefault();
            frmLogin.Show();
        }
    }
}
