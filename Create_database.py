import csv
import random
import pyodbc

# creating database
db_connection = pyodbc.connect('Driver={SQL Server};'
                               'Server=DESKTOP-T1F4GD2;'
                               'Trusted_Connection=yes;', autocommit=True)
db_cursor = db_connection.cursor()
db_cursor.execute("CREATE DATABASE [ProjectDB]")

db_connection = pyodbc.connect('Driver={SQL Server};'
                               'Server=DESKTOP-T1F4GD2;'
                               'Database=ProjectDB;'
                               'Trusted_Connection=yes;', autocommit=True)
db_cursor = db_connection.cursor()
db_cursor.execute("CREATE TABLE Customers ("
                   + "email VARCHAR(30) PRIMARY KEY, "
                   + "pw VARCHAR(30), "
                   + "name VARCHAR(30), "
                   + "address VARCHAR(200), "
                   + "phone VARCHAR(12))")

# creating database table 'Customer' and csv file
with open('Customers.csv', 'w', newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["Email", "Password", "Name", "Address", "Phone"])
    for i in range(1000):
        email = "customer_" + str(i) + "@gmail.com"
        pw = "password_" + str(i)
        name = "name_" + str(i)
        addr = "address_" + str(i)
        phone = "phone_" + str(i)
        writer.writerow([email, pw, name, addr, phone])
        sql_query = "INSERT INTO Customers (email, pw, name, address, phone) VALUES (" + \
                     "'" + email + "', " + \
                     "'" + pw + "', " + \
                     "'" + name + "', " + \
                     "'" + addr + "', " + \
                     "'" + phone + "')"
        db_cursor.execute(sql_query)
db_cursor.close()
db_connection.close()

# creating database table 'Suppliers' and csv file
db_connection = pyodbc.connect('Driver={SQL Server};'
                               'Server=DESKTOP-T1F4GD2;'
                               'Database=ProjectDB;'
                               'Trusted_Connection=yes;', autocommit=True)
db_cursor = db_connection.cursor()
db_cursor.execute("CREATE TABLE Suppliers ("
                   + "email VARCHAR(30) PRIMARY KEY, "
                   + "pw VARCHAR(30), "
                   + "name VARCHAR(30), "
                   + "address VARCHAR(200), "
                   + "phone VARCHAR(12), "
                   + "review DECIMAL(2,1))")

with open('Suppliers.csv', 'w', newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["Email", "Password", "Name", "Address", "Phone"])
    for i in range(500):
        email = "supplier_" + str(i) + "@gmail.com"
        pw = "password_" + str(i)
        name = "name_" + str(i)
        addr = "address_" + str(i)
        phone = "phone_" + str(i)
        review = round(random.uniform(0, 9.9), 1)
        writer.writerow([email, pw, name, addr, phone, review])
        sql_query = "INSERT INTO Suppliers (email, pw, name, address, phone, review) VALUES (" + \
                     "'" + email + "', " + \
                     "'" + pw + "', " + \
                     "'" + name + "', " + \
                     "'" + addr + "', " + \
                     "'" + phone + "', " + \
                     str(review) + ")"
        db_cursor.execute(sql_query)
db_cursor.close()
db_connection.close()

# creating database table 'Products' and csv file
db_connection = pyodbc.connect('Driver={SQL Server};'
                               'Server=DESKTOP-T1F4GD2;'
                               'Database=ProjectDB;'
                               'Trusted_Connection=yes;', autocommit=True)
db_cursor = db_connection.cursor()
db_cursor.execute("CREATE TABLE Products ("
                   + "id INT PRIMARY KEY, "
                   + "name VARCHAR(30), "
                   + "price DECIMAL(5,2), "
                   + "quantity INT, "
                   + "category VARCHAR(30), "
                   + "supplier_id VARCHAR(30))")

prices = []
with open('Products.csv', 'w', newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["ID", "Name", "Price", "Quantity", "Category", "Supplier_ID"])
    for i in range(1000):
        product_id = i
        name = "product_name_" + str(i)
        price = round(random.uniform(10, 100), 2)
        prices.append(price)
        quantity = random.randrange(1, 10)
        category = random.choice(["Automotive","Beauty, Health","Books","Computers",
                                  "Electronics","Entertainments","Fashion","Food, Grocery",
                                  "Home, Garden","Outdoors","Pet Supplies","Smart Home","Sports",
                                  "Toy, Kids"])
        sup_Id = "supplier_" + str(int(i / 2)) + "@gmail.com"
        writer.writerow([product_id, name, price, quantity, category, sup_Id])
        sql_query = "INSERT INTO Products (id, name, price, quantity, category, supplier_id) VALUES (" + \
                     str(product_id) + ", " + \
                     "'" + name + "', " + \
                     str(price) + ", " + \
                     str(quantity) + ", " + \
                     "'" + category + "', " + \
                     "'" + sup_Id + "')"
        db_cursor.execute(sql_query)
db_cursor.close()
db_connection.close()

# creating database table 'Accounts' and csv file
db_connection = pyodbc.connect('Driver={SQL Server};'
                               'Server=DESKTOP-T1F4GD2;'
                               'Database=ProjectDB;'
                               'Trusted_Connection=yes;', autocommit=True)
db_cursor = db_connection.cursor()
db_cursor.execute("CREATE TABLE Accounts ("
                   + "account_number INT PRIMARY KEY, "
                   + "bank_name VARCHAR(30), "
                   + "customer_id VARCHAR(30))")
with open('Accounts.csv', 'w', newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["Account Number", "Bank Name", "Customer_ID"])
    for i in range(800):
        account = i
        bank = random.choice(["BBVA", "Bank of America", "Chase Bank", "Wells Fargo", "US Bank"])
        cust_Id = "customer_" + str(i % 700) + "@gmail.com"
        writer.writerow([account, bank, cust_Id])
        sql_query = "INSERT INTO Accounts (account_number, bank_name, customer_id) VALUES (" + \
                     str(account) + ", " + \
                     "'" + bank + "', " + \
                     "'" + cust_Id + "')"
        db_cursor.execute(sql_query)
db_cursor.close()
db_connection.close()

# creating list of quantities for table 'Carries'
quantities = []
for i in range(600):
    quantity = random.randrange(1, 5)
    quantities.append(quantity)

# creating database table 'Carries' and csv file
db_connection = pyodbc.connect('Driver={SQL Server};'
                               'Server=DESKTOP-T1F4GD2;'
                               'Database=ProjectDB;'
                               'Trusted_Connection=yes;', autocommit=True)
db_cursor = db_connection.cursor()
db_cursor.execute("CREATE TABLE Carries ("
                   + "bill_id INT, "
                   + "product_id INT, "
                   + "quantity INT, "
                   + "PRIMARY KEY (bill_id, product_id))")
with open('Carries.csv', 'w', newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["Bill", "Product", "Quantity"])
    for i in range(600):
        bill_id = int(i / 3)
        product_id = i
        quantity = quantities[i]
        writer.writerow([bill_id, product_id, quantity])
        sql_query = "INSERT INTO Carries (bill_id, product_id, quantity) VALUES (" + \
                     str(bill_id) + ", " + \
                     str(product_id) + ", " + \
                     str(quantity) + ")"
        db_cursor.execute(sql_query)
db_cursor.close()
db_connection.close()

# creating database table 'Bills' and csv file
db_connection = pyodbc.connect('Driver={SQL Server};'
                               'Server=DESKTOP-T1F4GD2;'
                               'Database=ProjectDB;'
                               'Trusted_Connection=yes;', autocommit=True)
db_cursor = db_connection.cursor()
db_cursor.execute("CREATE TABLE Bills ("
                   + "bill_id INT PRIMARY KEY, "
                   + "amount DECIMAL(6,2), "
                   + "customer_id VARCHAR(30))")
c_ids = []
with open('Bills.csv', 'w', newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["Bill_ID", "Amount", "Customer_ID"])
    for i in range(200):
        bill_id = i
        index = 3 * i
        amount = round(prices[index] * quantities[index] + prices[index + 1] * quantities[index + 1]
                 + prices[index + 2] * quantities[index + 2], 2)
        c_id = random.randrange(0, 700)
        c_ids.append(c_id)
        cust_id = "customer_" + str(c_id) + "@gmail.com"
        writer.writerow([bill_id, amount, cust_id])
        sql_query = "INSERT INTO Bills (bill_id, amount, customer_id) VALUES (" + \
                     str(bill_id) + ", " + \
                     str(amount) + ", " + \
                     "'" + cust_id + "')"
        db_cursor.execute(sql_query)
db_cursor.close()
db_connection.close()

# creating database table 'Settles' and csv file
db_connection = pyodbc.connect('Driver={SQL Server};'
                               'Server=DESKTOP-T1F4GD2;'
                               'Database=ProjectDB;'
                               'Trusted_Connection=yes;', autocommit=True)
db_cursor = db_connection.cursor()
db_cursor.execute("CREATE TABLE Settles ("
                   + "bill_id INT PRIMARY KEY, "
                   + "account_id INT)")

with open('Settles.csv', 'w', newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["Bill_ID", "Account_ID"])
    for i in range(200):
        bill_id = i
        account = c_ids[i]
        writer.writerow([account, bill_id])
        sql_query = "INSERT INTO Settles (bill_id, account_id) VALUES (" + \
                     str(bill_id) + ", " + \
                     str(account) + ")"
        db_cursor.execute(sql_query)
db_cursor.close()
db_connection.close()

