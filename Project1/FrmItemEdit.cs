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
    public partial class FrmItemEdit : Form
    {
        private int id;
        private string price;
        private string quantity;

        public FrmItemEdit(int product_id, string strPrice, string strQuantity)
        {
            InitializeComponent();
            this.CenterToScreen();
            id = product_id;
            price = strPrice;
            quantity = strQuantity;
        }

        private void FrmItemEdit_Load(object sender, EventArgs e)
        {
            txtPrice.Text = price;
            txtQuantity.Text = quantity;
            labelError.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtPrice.Text == "" || txtQuantity.Text == "")
            {
                labelError.Visible = true;
                return;
            }
            DB db = new DB();
            decimal new_price = decimal.Parse(txtPrice.Text);
            int new_quantity = Convert.ToInt32(txtQuantity.Text);
            db.DbUpdateProductSupp(id, new_price, new_quantity);
            MessageBox.Show("The values are updated.");
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
