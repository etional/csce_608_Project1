using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project1
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reset();
            this.Hide();
            FrmRegistration frmRegistration = new FrmRegistration();
            frmRegistration.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;

            string email = txtID.Text;
            string pw = txtPW.Text;

            if (email == "" || pw == "")
            {
                labelError.Visible = true;
                return;
            }
            
            DB db = new DB();
            bool success = false;
            if (radCustomer.Checked)
            {
                success = db.DbCustExist(email, pw);
            }
            else
            {
                success = db.DbSuppExist(email, pw);
            }

            if (!success)
            {
                labelError.Visible = true;
                return;
            }

            reset();
            this.Hide();
            if (radCustomer.Checked)
            {
                FrmMain frmMain = new FrmMain(email, 0);
                frmMain.ShowDialog();
            }
            else
            {
                FrmMain frmMain = new FrmMain(email, 1);
                frmMain.ShowDialog();
            }
        }

        private void reset()
        {
            txtID.Text = "";
            txtPW.Text = "";
            labelError.Visible = false;
        }
    }
}
