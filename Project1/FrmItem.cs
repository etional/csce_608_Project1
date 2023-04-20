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
    public partial class FrmItem : Form
    {
        private int bill_id;
        private int product_id;
        private int mode;
        private decimal item_price;

        public FrmItem(int bill, int product, int type)
        {
            InitializeComponent();
            bill_id = bill;
            product_id = product;
            mode = type;
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            string name = "";
            string price = "";
            int quantity = 0;
            string supplier_name = "";
            string review = "";
            db.DbGetProduct(product_id, ref name, ref price, ref quantity, ref supplier_name, ref review);
            labelName.Text = name;
            labelPrice.Text += price;
            item_price = Convert.ToDecimal(price);
            labelSupplier.Text += supplier_name;
            labelReview.Text += review;

            if (mode == 0)
            {
                for (int i = 1; i <= quantity; i++)
                {
                    cbQuantity.Items.Add(i);
                }
                btnDelete.Visible = false;
                if (quantity == 0)
                {
                    btnAdd.Enabled = false;
                }
                else
                {
                    cbQuantity.SelectedIndex = 0;
                }
            }
            else
            {
                cbQuantity.Items.Add(quantity);
                pnlDescription.Visible = false;
                btnAdd.Text = "Edit";
                cbQuantity.SelectedIndex = 0;
            }
        }
    
        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMain main = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            main.backList();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int bill = bill_id;
            int product = product_id;
            int quantity = Convert.ToInt32(cbQuantity.Text);

            DB db = new DB();
            if (mode == 0)
            {
                db.DbInsertCarries(bill, product, quantity);
                db.DbUpdateProduct(product, quantity);
                decimal amount = Decimal.Round(quantity * item_price, 2);
                db.DbUpdateBill(bill, amount);
                MessageBox.Show("Item is added to cart.");

                int old = cbQuantity.Items.Count - 1;
                int new_quantity = old - quantity;
                cbQuantity.Items.Clear();
                for (int i = 1; i <= new_quantity; i++)
                {
                    cbQuantity.Items.Add(i);
                }

                if (new_quantity == 0)
                {
                    btnAdd.Enabled = false;
                }
                else
                {
                    cbQuantity.SelectedIndex = 0;
                }
            }
            else
            {
                string price = labelPrice.Text.Replace("$", "");
                FrmItemEdit frmItemEdit = new FrmItemEdit(product, price, quantity.ToString());
                frmItemEdit.ShowDialog();

                string name = "";
                price = "";
                quantity = 0;
                string supplier_name = "";
                string review = "";

                db.DbGetProduct(product_id, ref name, ref price, ref quantity, ref supplier_name, ref review);
                labelPrice.Text = "$" + price;
                cbQuantity.Items.Clear();
                cbQuantity.Items.Add(quantity);
                cbQuantity.SelectedIndex = 0;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.DbDeleteProduct(product_id);
            MessageBox.Show("The product is deleted.");
            FrmMain main = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            main.update();
            btnBack_Click(btnBack, new EventArgs());
        }
    }
}
