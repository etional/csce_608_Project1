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
    public partial class FrmAdd : Form
    {
        private string user;

        public FrmAdd(string user_id)
        {
            InitializeComponent();
            this.CenterToScreen();
            user = user_id;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "" || cbCategory.Text == "")
            {
                labelError.Visible = true;
                return;
            }
            string name = txtName.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            string category = cbCategory.Text;

            DB db = new DB();
            db.DbInsertProduct(name, price, quantity, category, user);
            MessageBox.Show("Product is added.");
            FrmMain main = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            main.update();
            Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
