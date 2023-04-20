using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Project1
{
    public class DB
    {
        private SqlConnection mDbConn = null;
        private SqlCommand mCmd = null;
        private SqlDataReader mReader = null;
        private SqlDataAdapter mAdapter = null;
        
        public void Connect()
        {
            try
            {
                mDbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Project1.Properties.Settings.ProjectDBConnectionString"].ConnectionString);
                mDbConn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public bool DbCustExist(string strEmail, string strPW)
        {
            bool exist = false;
            Connect();
            string CommandStr = "SELECT * FROM Customers WHERE email = @email AND "
                                + "pw = @pw";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.AddWithValue("@email", strEmail);
            mCmd.Parameters.AddWithValue("@pw", strPW);

            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

            mReader.Read();
            if (mReader.HasRows)
            {
                exist = true;
            }
            mCmd.Dispose();
            Close();

            return exist;
        }

        public bool DbSuppExist(string strEmail, string strPW)
        {
            bool exist = false;
            Connect();
            string CommandStr = "SELECT * FROM Suppliers WHERE email = @email AND "
                                + "pw = @pw";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.AddWithValue("@email", strEmail);
            mCmd.Parameters.AddWithValue("@pw", strPW);

            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

            mReader.Read();
            if (mReader.HasRows)
            {
                exist = true;
            }
            mCmd.Dispose();
            Close();

            return exist;
        }

        public bool DbCustomerDuplicate(string strEmail)
        {
            bool dup = false;
            Connect();
            string CommandStr = "SELECT * FROM Customers WHERE email = @email";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.AddWithValue("@email", strEmail);

            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return true;
            }

            mReader.Read();
            if (mReader.HasRows)
            {
                dup = true;
            }
            mCmd.Dispose();
            Close();
            return dup;
        }

        public bool DbSupplierDuplicate(string strEmail)
        {
            bool dup = false;
            Connect();
            string CommandStr = "SELECT * FROM Suppliers WHERE email = @email";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.AddWithValue("@email", strEmail);

            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return true;
            }

            mReader.Read();
            if (mReader.HasRows)
            {
                dup = true;
            }
            mCmd.Dispose();
            Close();
            return dup;
        }

        public bool DbAccountDuplicate(int account)
        {
            bool dup = false;
            Connect();
            string CommandStr = "SELECT * FROM Accounts WHERE account_number = @account";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@account", SqlDbType.Int);
            mCmd.Parameters["@account"].Value = account;

            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return true;
            }

            mReader.Read();
            if (mReader.HasRows)
            {
                dup = true;
            }
            mCmd.Dispose();
            Close();
            return dup;
        }

        public string DbGetCustomerName(string strEmail)
        {
            string name = "";
            Connect();
            string CommandStr = "SELECT name FROM Customers WHERE email = @email";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.AddWithValue("@email", strEmail);
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return name;
            }
            mReader.Read();

            name = mReader["name"].ToString();
            mCmd.Dispose();
            Close();

            return name;
        }

        public void DbGetCustomer(string strEmail, ref string refPW, ref string refName, ref string refAddress, ref string refPhone)
        {
            Connect();
            string CommandStr = "SELECT * FROM Customers WHERE email = @email";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.AddWithValue("@email", strEmail);
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mReader.Read();

            refPW = mReader["pw"].ToString();
            refName = mReader["name"].ToString();
            refAddress = mReader["address"].ToString();
            refPhone = mReader["phone"].ToString();
            mCmd.Dispose();
            Close();
        }

        public void DbUpdateCustomer(string strEmail, string strNew, string strPW, string strName, string strAddress, string strPhone)
        {
            Connect();
            string CommandStr = "";
            if (strNew == "")
            {
                CommandStr = "UPDATE Customers SET pw = @pw, name = @name, address = @address, phone = @phone "
                             + "WHERE email = @email";
                mCmd = new SqlCommand(CommandStr, mDbConn);
                mCmd.Parameters.Add("@email", SqlDbType.VarChar);
                mCmd.Parameters["@email"].Value = strEmail;
                mCmd.Parameters.Add("@pw", SqlDbType.VarChar);
                mCmd.Parameters["@pw"].Value = strPW;
                mCmd.Parameters.Add("@name", SqlDbType.VarChar);
                mCmd.Parameters["@name"].Value = strName;
                mCmd.Parameters.Add("@address", SqlDbType.VarChar);
                mCmd.Parameters["@address"].Value = strAddress;
                mCmd.Parameters.Add("@phone", SqlDbType.VarChar);
                mCmd.Parameters["@phone"].Value = strPhone;
            }
            else
            {
                CommandStr = "UPDATE Customers SET email = @new, pw = @pw, name = @name, address = @address, phone = @phone "
                             + "WHERE email = @email";
                mCmd = new SqlCommand(CommandStr, mDbConn);
                mCmd.Parameters.Add("@email", SqlDbType.VarChar);
                mCmd.Parameters["@email"].Value = strEmail;
                mCmd.Parameters.Add("@new", SqlDbType.VarChar);
                mCmd.Parameters["@new"].Value = strNew;
                mCmd.Parameters.Add("@pw", SqlDbType.VarChar);
                mCmd.Parameters["@pw"].Value = strPW;
                mCmd.Parameters.Add("@name", SqlDbType.VarChar);
                mCmd.Parameters["@name"].Value = strName;
                mCmd.Parameters.Add("@address", SqlDbType.VarChar);
                mCmd.Parameters["@address"].Value = strAddress;
                mCmd.Parameters.Add("@phone", SqlDbType.VarChar);
                mCmd.Parameters["@phone"].Value = strPhone;
            }
            mAdapter = new SqlDataAdapter();
            mAdapter.UpdateCommand = mCmd;

            try
            {
                mAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mCmd.Dispose();
            Close();
        }

        public void DbUpdateSupplier(string strEmail, string strNew, string strPW, string strName, string strAddress, string strPhone)
        {
            Connect();
            string CommandStr = "";
            if (strNew == "")
            {
                CommandStr = "UPDATE Suppliers SET pw = @pw, name = @name, address = @address, phone = @phone "
                             + "WHERE email = @email";
                mCmd = new SqlCommand(CommandStr, mDbConn);
                mCmd.Parameters.Add("@email", SqlDbType.VarChar);
                mCmd.Parameters["@email"].Value = strEmail;
                mCmd.Parameters.Add("@pw", SqlDbType.VarChar);
                mCmd.Parameters["@pw"].Value = strPW;
                mCmd.Parameters.Add("@name", SqlDbType.VarChar);
                mCmd.Parameters["@name"].Value = strName;
                mCmd.Parameters.Add("@address", SqlDbType.VarChar);
                mCmd.Parameters["@address"].Value = strAddress;
                mCmd.Parameters.Add("@phone", SqlDbType.VarChar);
                mCmd.Parameters["@phone"].Value = strPhone;
            }
            else
            {
                CommandStr = "UPDATE Suppliers SET email = @new, pw = @pw, name = @name, address = @address, phone = @phone "
                             + "WHERE email = @email";
                mCmd = new SqlCommand(CommandStr, mDbConn);
                mCmd.Parameters.Add("@email", SqlDbType.VarChar);
                mCmd.Parameters["@email"].Value = strEmail;
                mCmd.Parameters.Add("@new", SqlDbType.VarChar);
                mCmd.Parameters["@new"].Value = strNew;
                mCmd.Parameters.Add("@pw", SqlDbType.VarChar);
                mCmd.Parameters["@pw"].Value = strPW;
                mCmd.Parameters.Add("@name", SqlDbType.VarChar);
                mCmd.Parameters["@name"].Value = strName;
                mCmd.Parameters.Add("@address", SqlDbType.VarChar);
                mCmd.Parameters["@address"].Value = strAddress;
                mCmd.Parameters.Add("@phone", SqlDbType.VarChar);
                mCmd.Parameters["@phone"].Value = strPhone;
            }
            mAdapter = new SqlDataAdapter();
            mAdapter.UpdateCommand = mCmd;

            try
            {
                mAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mCmd.Dispose();
            Close();
        }

        public string DbGetSupplierName(string strEmail)
        {
            string name = "";
            Connect();
            string CommandStr = "SELECT name FROM Suppliers WHERE email = @email";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.AddWithValue("@email", strEmail);
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return name;
            }
            mReader.Read();

            name = mReader["name"].ToString();
            mCmd.Dispose();
            Close();

            return name;
        }

        public void DbGetSupplier(string strEmail, ref string refPW, ref string refName, ref string refAddress, 
                                  ref string refPhone, ref string refReview)
        {
            Connect();
            string CommandStr = "SELECT * FROM Suppliers WHERE email = @email";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.AddWithValue("@email", strEmail);
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mReader.Read();

            refPW = mReader["pw"].ToString();
            refName = mReader["name"].ToString();
            refAddress = mReader["address"].ToString();
            refPhone = mReader["phone"].ToString();
            refReview = mReader["review"].ToString();
            mCmd.Dispose();
            Close();
        }

        public void DbInsertCustomer(string strEmail, string strPW, string strName, string strAddress, string strPhone)
        {
            Connect();
            string CommandStr = "INSERT INTO Customers (email, pw, name, address, phone) VALUES (@email, @pw, @name, @address, @phone)";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@email", SqlDbType.VarChar);
            mCmd.Parameters["@email"].Value = strEmail;
            mCmd.Parameters.Add("@pw", SqlDbType.VarChar);
            mCmd.Parameters["@pw"].Value = strPW;
            mCmd.Parameters.Add("@name", SqlDbType.VarChar);
            mCmd.Parameters["@name"].Value = strName;
            mCmd.Parameters.Add("@address", SqlDbType.VarChar);
            mCmd.Parameters["@address"].Value = strAddress;
            mCmd.Parameters.Add("@phone", SqlDbType.VarChar);
            mCmd.Parameters["@phone"].Value = strPhone;
            mAdapter = new SqlDataAdapter();
            mAdapter.InsertCommand = mCmd;

            try
            {
                mAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }

            mCmd.Dispose();
            Close();
        }

        public void DbInsertSupplier(string strEmail, string strPW, string strName, string strAddress, string strPhone)
        {
            Connect();
            string CommandStr = "INSERT INTO Suppliers (email, pw, name, address, phone) VALUES (@email, @pw, @name, @address, @phone)";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@email", SqlDbType.VarChar);
            mCmd.Parameters["@email"].Value = strEmail;
            mCmd.Parameters.Add("@pw", SqlDbType.VarChar);
            mCmd.Parameters["@pw"].Value = strPW;
            mCmd.Parameters.Add("@name", SqlDbType.VarChar);
            mCmd.Parameters["@name"].Value = strName;
            mCmd.Parameters.Add("@address", SqlDbType.VarChar);
            mCmd.Parameters["@address"].Value = strAddress;
            mCmd.Parameters.Add("@phone", SqlDbType.VarChar);
            mCmd.Parameters["@phone"].Value = strPhone;
            mAdapter = new SqlDataAdapter();
            mAdapter.InsertCommand = mCmd;

            try
            {
                mAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }

            mCmd.Dispose();
            Close();
        }

        public List<string> DbGetFirstProducts()
        {
            List<string> list = new List<string>();
            Connect();
            string CommandStr = "SELECT TOP 50 id, name, price FROM Products";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            while (mReader.Read())
            {
                string item = mReader["id"].ToString() + "," + mReader["name"].ToString() + ","
                              + mReader["price"].ToString();
                list.Add(item);
            }

            return list;
        }

        public List<string> DbGetProducts(string category, string search)
        {
            List<string> list = new List<string>();
            Connect();
            string CommandStr = "";
            if (category == "")
            {
                if (search == "")
                {
                    CommandStr = "SELECT id, name, price FROM Products";
                    mCmd = new SqlCommand(CommandStr, mDbConn);
                }
                else
                {
                    CommandStr = "SELECT id, name, price FROM Products WHERE name LIKE @keyword";
                    mCmd = new SqlCommand(CommandStr, mDbConn);
                    mCmd.Parameters.AddWithValue("@keyword", "%" + search + "%");
                }
            }
            if (category != "")
            {
                if (search == "")
                {
                    CommandStr = "SELECT id, name, price FROM Products WHERE category = @category";
                    mCmd = new SqlCommand(CommandStr, mDbConn);
                    mCmd.Parameters.AddWithValue("@category", category);
                }
                else
                {
                    CommandStr = "SELECT id, name, price FROM Products WHERE category = @category "
                                 + "AND name LIKE @keyword";
                    mCmd = new SqlCommand(CommandStr, mDbConn);
                    mCmd.Parameters.AddWithValue("@category", category);
                    mCmd.Parameters.AddWithValue("@keyword", "%" + search + "%");
                }
            }
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            while (mReader.Read())
            {
                string item = mReader["id"].ToString() + "," + mReader["name"].ToString() + ","
                              + mReader["price"].ToString();
                list.Add(item);
            }

            return list;
        }

        public List<string> DbGetProductsSupp(string supplier, string category, string search)
        {
            List<string> list = new List<string>();
            Connect();
            string CommandStr = "";
            if (category == "" && search == "")
            {
                CommandStr = "SELECT id, name, price From Products WHERE supplier_id = @id";
                mCmd = new SqlCommand(CommandStr, mDbConn);
                mCmd.Parameters.AddWithValue("@id", supplier);
            }
            if (category != "")
            {
                if (search == "")
                {
                    CommandStr = "SELECT id, name, price From Products WHERE supplier_id = @id AND category = @category";
                    mCmd = new SqlCommand(CommandStr, mDbConn);
                    mCmd.Parameters.AddWithValue("@id", supplier);
                    mCmd.Parameters.AddWithValue("@category", category);
                }
                else
                {
                    CommandStr = "SELECT id, name, price From Products WHERE supplier_id = @id AND category = @category "
                                 + "AND name LIKE '%@keyword%'";
                    mCmd = new SqlCommand(CommandStr, mDbConn);
                    mCmd.Parameters.AddWithValue("@id", supplier);
                    mCmd.Parameters.AddWithValue("@category", category);
                    mCmd.Parameters.AddWithValue("@keyword", search);
                }
            }
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            while (mReader.Read())
            {
                string item = mReader["id"].ToString() + "," + mReader["name"].ToString() + ","
                              + mReader["price"].ToString();
                list.Add(item);
            }

            return list;
        }

        public void DbInsertProduct(string strName, decimal price, int quantity, string category, string supplier)
        {
            Connect();
            string CommandStr = "SELECT TOP 1 id FROM Products ORDER BY id DESC";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mReader.Read();
            int last_id = Convert.ToInt32(mReader["id"]);
            mCmd.Dispose();
            Close();

            int new_id = last_id + 1;

            Connect();
            CommandStr = "INSERT INTO Products (id, name, price, quantity, category, supplier_id) "
                         + "VALUES (@id, @name, @price, @quantity, @category, @supp_id)";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = new_id;
            mCmd.Parameters.Add("@name", SqlDbType.VarChar);
            mCmd.Parameters["@name"].Value = strName;
            mCmd.Parameters.Add("@price", SqlDbType.Decimal);
            mCmd.Parameters["@price"].Value = price;
            mCmd.Parameters.Add("@quantity", SqlDbType.Int);
            mCmd.Parameters["@quantity"].Value = quantity;
            mCmd.Parameters.Add("@category", SqlDbType.VarChar);
            mCmd.Parameters["@category"].Value = category;
            mCmd.Parameters.Add("@supp_id", SqlDbType.VarChar);
            mCmd.Parameters["@supp_id"].Value = supplier;
            mAdapter = new SqlDataAdapter();
            mAdapter.InsertCommand = mCmd;

            try
            {
                mAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }

            mCmd.Dispose();
            Close();
        }

        public void DbGetProduct(int id, ref string refName, ref string refPrice, ref int refQuantity, 
                                 ref string refSupplier, ref string refReview)
        {
            Connect();
            string CommandStr = "SELECT Products.name AS name1, price, quantity, Suppliers.name AS name2, "
                                +  "review FROM Products, Suppliers WHERE id = @id AND supplier_id = email";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = id;
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mReader.Read();

            refName = mReader["name1"].ToString();
            refPrice = mReader["price"].ToString();
            refQuantity = Convert.ToInt32(mReader["quantity"]);
            refSupplier = mReader["name2"].ToString();
            refReview = mReader["review"].ToString();
            mCmd.Dispose();
            Close();
        }

        public void DbUpdateProduct(int product_id, int to_bill)
        {
            Connect();
            string CommandStr = "SELECT quantity FROM Products WHERE id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = product_id;
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mReader.Read();
            int quantity = Convert.ToInt32(mReader["quantity"]);
            mCmd.Dispose();
            Close();

            int new_quantity = quantity - to_bill;
            Connect();
            CommandStr = "UPDATE Products SET quantity = @quantity WHERE id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@quantity", SqlDbType.Int);
            mCmd.Parameters["@quantity"].Value = new_quantity;
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = product_id;
            mAdapter = new SqlDataAdapter();
            mAdapter.UpdateCommand = mCmd;

            try
            {
                mAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mCmd.Dispose();
            Close();
        }

        public void DbUpdateProductSupp(int product_id, decimal price, int quantity)
        {
            Connect();
            string CommandStr = "UPDATE Products SET price = @price, quantity = @quantity WHERE id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@price", SqlDbType.Decimal);
            mCmd.Parameters["@price"].Value = price;
            mCmd.Parameters.Add("@quantity", SqlDbType.Int);
            mCmd.Parameters["@quantity"].Value = quantity;
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = product_id;
            mAdapter = new SqlDataAdapter();
            mAdapter.UpdateCommand = mCmd;

            try
            {
                mAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mCmd.Dispose();
            Close();
        }

        public void DbDeleteProduct(int product_id)
        {
            Connect();
            string CommandStr = "DELETE FROM Products WHERE id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = product_id;
            mAdapter = new SqlDataAdapter();
            mAdapter.DeleteCommand = mCmd;
            try
            {
                mAdapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mCmd.Dispose();
            Close();
        }

        public void DbInsertAccount(int account, string strBank, string cust_id)
        {
            Connect();
            string CommandStr = "INSERT INTO Accounts (account_number, bank_name, customer_id) "
                                + "VALUES (@account, @bank, @customer)";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@account", SqlDbType.Int);
            mCmd.Parameters["@account"].Value = account;
            mCmd.Parameters.Add("@bank", SqlDbType.VarChar);
            mCmd.Parameters["@bank"].Value = strBank;
            mCmd.Parameters.Add("@customer", SqlDbType.VarChar);
            mCmd.Parameters["@customer"].Value = cust_id;
            mAdapter = new SqlDataAdapter();
            mAdapter.InsertCommand = mCmd;

            try
            {
                mAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }

            mCmd.Dispose();
            Close();
        }

        public List<string> DbGetAccounts(string cust_id)
        {
            List<string> accountList = new List<string>();
            Connect();
            string CommandStr = "SELECT * FROM Accounts WHERE customer_id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.VarChar);
            mCmd.Parameters["@id"].Value = cust_id;
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return accountList;
            }
            while (mReader.Read())
            {
                string account = String.Format("Account Number: {0}, Bank Name: {1}",
                                               mReader["account_number"].ToString(), mReader["bank_name"].ToString());
                accountList.Add(account);
            }
            mCmd.Dispose();
            Close();

            return accountList;
        }

        public void DbUpdateAccount(int old_account, int new_account, string strBank, string cust_id)
        {
            Connect();
            string CommandStr = "UPDATE Accounts SET account_number = @new, bank_name = @name "
                                + "WHERE customer_id = @customer AND account_number = @old";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@new", SqlDbType.Int);
            mCmd.Parameters["@new"].Value = new_account;
            mCmd.Parameters.Add("@name", SqlDbType.VarChar);
            mCmd.Parameters["@name"].Value = strBank;
            mCmd.Parameters.Add("@customer", SqlDbType.VarChar);
            mCmd.Parameters["@customer"].Value = cust_id;
            mCmd.Parameters.Add("@old", SqlDbType.Int);
            mCmd.Parameters["@old"].Value = old_account;
            mAdapter = new SqlDataAdapter();
            mAdapter.UpdateCommand = mCmd;

            try
            {
                mAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            mCmd.Dispose();
            Close();
        }

        public void DbDeleteAccount(int account)
        {
            Connect();
            string CommandStr = "DELETE FROM Accounts WHERE account_number = @account";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@account", SqlDbType.Int);
            mCmd.Parameters["@account"].Value = account;
            mAdapter = new SqlDataAdapter();
            mAdapter.DeleteCommand = mCmd;
            try
            {
                mAdapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mCmd.Dispose();
            Close();
        }

        public int DbInsertBill(string cust_id)
        {
            Connect();
            string CommandStr = "SELECT TOP 1 bill_id FROM Bills ORDER BY bill_id DESC";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }
            mReader.Read();
            int last_id = Convert.ToInt32(mReader["bill_id"]);
            mCmd.Dispose();
            Close();

            int new_id = last_id + 1;
            decimal amount = 0.00m;

            Connect();
            CommandStr = "INSERT INTO Bills (bill_id, amount, customer_id)"
                         + "VALUES (@id, @amount, @customer)";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = new_id;
            mCmd.Parameters.Add("@amount", SqlDbType.Decimal);
            mCmd.Parameters["@amount"].Value = amount;
            mCmd.Parameters.Add("@customer", SqlDbType.VarChar);
            mCmd.Parameters["@customer"].Value = cust_id;
            mAdapter = new SqlDataAdapter();
            mAdapter.InsertCommand = mCmd;

            try
            {
                mAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }

            mCmd.Dispose();
            Close();

            return new_id;
        }

        public void DbUpdateBill(int bill_id, decimal amount)
        {
            Connect();
            string CommandStr = "SELECT amount FROM Bills WHERE bill_id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = bill_id;
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mReader.Read();
            decimal new_amount = Convert.ToDecimal(mReader["amount"]);
            new_amount += amount;
            mCmd.Dispose();
            Close();

            Connect();
            CommandStr = "UPDATE Bills SET amount = @amount WHERE bill_id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@amount", SqlDbType.Decimal);
            mCmd.Parameters["@amount"].Value = new_amount;
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = bill_id;
            mAdapter = new SqlDataAdapter();
            mAdapter.UpdateCommand = mCmd;
            try
            {
                mAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            mCmd.Dispose();
            Close();
        }

        public List<string> DbGetBills(string cust_id)
        {
            List<string> billList = new List<string>();
            List<int> bills = new List<int>();
            List<string> amounts = new List<string>();
            Connect();
            string CommandStr = "SELECT * FROM Bills, Settles WHERE customer_id = @id "
                                + "AND Bills.bill_id = Settles.bill_id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.VarChar);
            mCmd.Parameters["@id"].Value = cust_id;
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return billList;
            }
            while (mReader.Read())
            {
                bills.Add(Convert.ToInt32(mReader["bill_id"]));
                amounts.Add(mReader["amount"].ToString());
            }
            mCmd.Dispose();
            Close();

            for (int i = 0; i < bills.Count; i++)
            {
                Connect();
                CommandStr = "SELECT Settles.account_id, Products.name, Products.price, Carries.quantity "
                             + "FROM Bills, Settles, Carries, Products WHERE customer_id = @id "
                             + "AND Bills.bill_id = @bill AND Bills.bill_id = Settles.bill_id "
                             + "AND Carries.bill_id = Bills.bill_id AND Carries.product_id = Products.id";

                mCmd = new SqlCommand(CommandStr, mDbConn);
                mCmd.Parameters.Add("@id", SqlDbType.VarChar);
                mCmd.Parameters["@id"].Value = cust_id;
                mCmd.Parameters.Add("@bill", SqlDbType.Int);
                mCmd.Parameters["@bill"].Value = bills[i];
                try
                {
                    mReader = mCmd.ExecuteReader();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return billList;
                }
                string bill = bills[i].ToString() + "|" + amounts[i];
                while (mReader.Read())
                {
                    bill += "|" + mReader["account_id"].ToString() + "," + mReader["name"].ToString()
                            + "," + mReader["price"].ToString() + "," + mReader["quantity"].ToString();
                }
                billList.Add(bill);
                mCmd.Dispose();
                Close();
            }

            return billList;
        }

        public bool DbCarryExist(int bill, int product, ref int quantity)
        {
            bool exist = false;
            Connect();
            string CommandStr = "SELECT quantity FROM Carries WHERE bill_id = @bill "
                                + "AND product_id = @product";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@bill", SqlDbType.Int);
            mCmd.Parameters["@bill"].Value = bill;
            mCmd.Parameters.Add("@product", SqlDbType.Int);
            mCmd.Parameters["@product"].Value = product;
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                mCmd.Dispose();
                Close();
                return false;
            }
            mReader.Read();
            if (mReader.HasRows)
            {
                quantity = Convert.ToInt32(mReader["quantity"]);
                exist = true;
            }
            mCmd.Dispose();
            Close();

            return exist;
        }

        public void DbInsertCarries(int bill, int product, int quantity)
        {
            int old = 0;
            bool exist = DbCarryExist(bill, product, ref old);
            string CommandStr = "";
            if (exist)
            {
                Connect();
                CommandStr = "UPDATE Carries SET quantity = @quantity WHERE "
                             + "bill_id = @bill AND product_id = @product";
                mCmd = new SqlCommand(CommandStr, mDbConn);
                mCmd.Parameters.Add("@quantity", SqlDbType.Int);
                mCmd.Parameters["@quantity"].Value = quantity + old;
                mCmd.Parameters.Add("@bill", SqlDbType.Int);
                mCmd.Parameters["@bill"].Value = bill;
                mCmd.Parameters.Add("@product", SqlDbType.Int);
                mCmd.Parameters["@product"].Value = product;
                mAdapter = new SqlDataAdapter();
                mAdapter.UpdateCommand = mCmd;
                try
                {
                    mAdapter.UpdateCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    mCmd.Dispose();
                    Close();
                    return;
                }
                mCmd.Dispose();
                Close();
                return;
            }
            else
            {
                Connect();
                CommandStr = "INSERT INTO Carries (bill_id, product_id, quantity)"
                             + "VALUES (@bill, @product, @quantity)";
                mCmd = new SqlCommand(CommandStr, mDbConn);
                mCmd.Parameters.Add("@bill", SqlDbType.Int);
                mCmd.Parameters["@bill"].Value = bill;
                mCmd.Parameters.Add("@product", SqlDbType.Int);
                mCmd.Parameters["@product"].Value = product;
                mCmd.Parameters.Add("@quantity", SqlDbType.Int);
                mCmd.Parameters["@quantity"].Value = quantity;
                mAdapter = new SqlDataAdapter();
                mAdapter.InsertCommand = mCmd;

                try
                {
                    mAdapter.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    mCmd.Dispose();
                    Close();
                    return;
                }

                mCmd.Dispose();
                Close();
            }
        }

        public string DbGetCart(int bill_id)
        {
            Connect();
            string CommandStr = "SELECT product_id, name, price, Carries.quantity AS quantity1, amount FROM Carries, Products, "
                                + "Bills WHERE Carries.bill_id = @id AND Bills.bill_id = Carries.bill_id "
                                + "AND product_id = id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = bill_id;
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return "";
            }
            string item = "";
            while (mReader.Read())
            {
                if (item == "")
                {
                    item = mReader["amount"].ToString();
                }
                item += "|" + mReader["product_id"].ToString() + "," + mReader["name"].ToString() + "," 
                        + mReader["price"].ToString() + "," + mReader["quantity1"].ToString();
            }
            mCmd.Dispose();
            Close();

            return item;
        }

        public void DbRemoveFromCart(int bill, int product_id, int quantity)
        {
            Connect();
            string CommandStr = "DELETE FROM Carries WHERE bill_id = @bill AND product_id = @product_id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@bill", SqlDbType.Int);
            mCmd.Parameters["@bill"].Value = bill;
            mCmd.Parameters.Add("@product_id", SqlDbType.Int);
            mCmd.Parameters["@product_id"].Value = product_id;
            mAdapter = new SqlDataAdapter();
            mAdapter.DeleteCommand = mCmd;
            try
            {
                mAdapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mCmd.Dispose();
            Close();

            Connect();
            CommandStr = "UPDATE Products SET quantity = quantity + @quantity WHERE id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@quantity", SqlDbType.Int);
            mCmd.Parameters["@quantity"].Value = quantity;
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = product_id;
            mAdapter = new SqlDataAdapter();
            mAdapter.UpdateCommand = mCmd;
            try
            {
                mAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                mCmd.Dispose();
                Close();
                return;
            }
            mCmd.Dispose();
            Close();
        }

        public void DbInsertSettle(int bill, int account)
        {
            Connect();
            string CommandStr = "INSERT INTO Settles (bill_id, account_id)"
                                + "VALUES (@bill, @account)";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@bill", SqlDbType.Int);
            mCmd.Parameters["@bill"].Value = bill;
            mCmd.Parameters.Add("@account", SqlDbType.Int);
            mCmd.Parameters["@account"].Value = account;
            mAdapter = new SqlDataAdapter();
            mAdapter.InsertCommand = mCmd;

            try
            {
                mAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }

            mCmd.Dispose();
            Close();
        }

        public void DbDeleteBill(int bill_id)
        {
            Connect();
            string CommandStr = "SELECT * FROM Settles WHERE bill_id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = bill_id;
            try
            {
                mReader = mCmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mReader.Read();
            if (mReader.HasRows)
            {
                mCmd.Dispose();
                Close();
                return;
            }
            mCmd.Dispose();
            Close();

            Connect();
            CommandStr = "DELETE FROM Bills WHERE bill_id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = bill_id;
            mAdapter = new SqlDataAdapter();
            mAdapter.DeleteCommand = mCmd;
            try
            {
                mAdapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mCmd.Dispose();
            Close();

            Connect();
            CommandStr = "DELETE FROM Carries WHERE bill_id = @id";
            mCmd = new SqlCommand(CommandStr, mDbConn);
            mCmd.Parameters.Add("@id", SqlDbType.Int);
            mCmd.Parameters["@id"].Value = bill_id;
            mAdapter = new SqlDataAdapter();
            mAdapter.DeleteCommand = mCmd;
            try
            {
                mAdapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            mCmd.Dispose();
            Close();

        }

        public void Close()
        {
            if (mDbConn == null)
            {
                return;
            }

            try
            {
                if (mDbConn.State.ToString() == "Open")
                {
                    mDbConn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
        }
    }
}
