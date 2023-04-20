namespace Project1
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMain = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnToy = new System.Windows.Forms.Button();
            this.btnSport = new System.Windows.Forms.Button();
            this.btnSmart = new System.Windows.Forms.Button();
            this.btnPet = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnFashion = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnElec = new System.Windows.Forms.Button();
            this.btnComp = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnBeauty = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlProcess = new System.Windows.Forms.Panel();
            this.pnlForms = new System.Windows.Forms.Panel();
            this.pnlList = new System.Windows.Forms.Panel();
            this.labelNoResult = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.pnlProcess.SuspendLayout();
            this.pnlForms.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.btnMain);
            this.panel1.Controls.Add(this.btnCategory);
            this.panel1.Controls.Add(this.btnAccount);
            this.panel1.Controls.Add(this.btnCart);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1484, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnMain
            // 
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMain.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMain.Location = new System.Drawing.Point(74, 22);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(75, 46);
            this.btnMain.TabIndex = 7;
            this.btnMain.Text = "LOGO";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.BackgroundImage = global::Project1.Properties.Resources.category;
            this.btnCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Location = new System.Drawing.Point(21, 22);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(44, 42);
            this.btnCategory.TabIndex = 6;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAccount.ForeColor = System.Drawing.Color.White;
            this.btnAccount.Location = new System.Drawing.Point(1066, 0);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(276, 100);
            this.btnAccount.TabIndex = 5;
            this.btnAccount.Text = "Hello, name\r\nAccount and Orders";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnCart
            // 
            this.btnCart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCart.BackgroundImage")));
            this.btnCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Location = new System.Drawing.Point(1342, 0);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(142, 100);
            this.btnCart.TabIndex = 4;
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Location = new System.Drawing.Point(187, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 35);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(231, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(586, 35);
            this.panel4.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(586, 35);
            this.txtSearch.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbCategory);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 35);
            this.panel3.TabIndex = 3;
            // 
            // cbCategory
            // 
            this.cbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "All",
            "Automotive",
            "Beauty & Health",
            "Books",
            "Computers",
            "Electronics",
            "Entertainments",
            "Fashion",
            "Food & Grocery",
            "Home, Garden",
            "Outdoors",
            "Pet Supplies",
            "Smart Home",
            "Sports",
            "Toy, Kids"});
            this.cbCategory.Location = new System.Drawing.Point(0, 0);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(231, 35);
            this.cbCategory.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Orange;
            this.btnSearch.BackgroundImage = global::Project1.Properties.Resources.search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(817, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlCategory
            // 
            this.pnlCategory.Controls.Add(this.btnClose);
            this.pnlCategory.Controls.Add(this.btnToy);
            this.pnlCategory.Controls.Add(this.btnSport);
            this.pnlCategory.Controls.Add(this.btnSmart);
            this.pnlCategory.Controls.Add(this.btnPet);
            this.pnlCategory.Controls.Add(this.btnOut);
            this.pnlCategory.Controls.Add(this.btnHome);
            this.pnlCategory.Controls.Add(this.btnFood);
            this.pnlCategory.Controls.Add(this.btnFashion);
            this.pnlCategory.Controls.Add(this.btnEnter);
            this.pnlCategory.Controls.Add(this.btnElec);
            this.pnlCategory.Controls.Add(this.btnComp);
            this.pnlCategory.Controls.Add(this.btnBook);
            this.pnlCategory.Controls.Add(this.btnBeauty);
            this.pnlCategory.Controls.Add(this.btnAuto);
            this.pnlCategory.Controls.Add(this.label1);
            this.pnlCategory.Location = new System.Drawing.Point(0, 0);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(301, 911);
            this.pnlCategory.TabIndex = 1;
            this.pnlCategory.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.BackgroundImage = global::Project1.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(256, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 41);
            this.btnClose.TabIndex = 16;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnToy
            // 
            this.btnToy.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnToy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToy.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnToy.Location = new System.Drawing.Point(0, 769);
            this.btnToy.Name = "btnToy";
            this.btnToy.Size = new System.Drawing.Size(301, 56);
            this.btnToy.TabIndex = 15;
            this.btnToy.Text = "Toy, Kids";
            this.btnToy.UseVisualStyleBackColor = true;
            this.btnToy.Click += new System.EventHandler(this.btnToy_Click);
            // 
            // btnSport
            // 
            this.btnSport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSport.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSport.Location = new System.Drawing.Point(0, 713);
            this.btnSport.Name = "btnSport";
            this.btnSport.Size = new System.Drawing.Size(301, 56);
            this.btnSport.TabIndex = 14;
            this.btnSport.Text = "Sports";
            this.btnSport.UseVisualStyleBackColor = true;
            this.btnSport.Click += new System.EventHandler(this.btnSport_Click);
            // 
            // btnSmart
            // 
            this.btnSmart.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSmart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmart.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSmart.Location = new System.Drawing.Point(0, 657);
            this.btnSmart.Name = "btnSmart";
            this.btnSmart.Size = new System.Drawing.Size(301, 56);
            this.btnSmart.TabIndex = 13;
            this.btnSmart.Text = "Smart Home";
            this.btnSmart.UseVisualStyleBackColor = true;
            this.btnSmart.Click += new System.EventHandler(this.btnSmart_Click);
            // 
            // btnPet
            // 
            this.btnPet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPet.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPet.Location = new System.Drawing.Point(0, 601);
            this.btnPet.Name = "btnPet";
            this.btnPet.Size = new System.Drawing.Size(301, 56);
            this.btnPet.TabIndex = 12;
            this.btnPet.Text = "Pet Supplies";
            this.btnPet.UseVisualStyleBackColor = true;
            this.btnPet.Click += new System.EventHandler(this.btnPet_Click);
            // 
            // btnOut
            // 
            this.btnOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOut.Location = new System.Drawing.Point(0, 545);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(301, 56);
            this.btnOut.TabIndex = 11;
            this.btnOut.Text = "Outdoors";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHome.Location = new System.Drawing.Point(0, 489);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(301, 56);
            this.btnHome.TabIndex = 10;
            this.btnHome.Text = "Home, Garden";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnFood
            // 
            this.btnFood.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFood.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFood.Location = new System.Drawing.Point(0, 433);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(301, 56);
            this.btnFood.TabIndex = 9;
            this.btnFood.Text = "Food, Grocery";
            this.btnFood.UseVisualStyleBackColor = true;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnFashion
            // 
            this.btnFashion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFashion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFashion.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFashion.Location = new System.Drawing.Point(0, 377);
            this.btnFashion.Name = "btnFashion";
            this.btnFashion.Size = new System.Drawing.Size(301, 56);
            this.btnFashion.TabIndex = 8;
            this.btnFashion.Text = "Fashion";
            this.btnFashion.UseVisualStyleBackColor = true;
            this.btnFashion.Click += new System.EventHandler(this.btnFashion_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnter.Location = new System.Drawing.Point(0, 321);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(301, 56);
            this.btnEnter.TabIndex = 7;
            this.btnEnter.Text = "Entertainments";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnElec
            // 
            this.btnElec.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnElec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElec.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnElec.Location = new System.Drawing.Point(0, 265);
            this.btnElec.Name = "btnElec";
            this.btnElec.Size = new System.Drawing.Size(301, 56);
            this.btnElec.TabIndex = 6;
            this.btnElec.Text = "Electronics";
            this.btnElec.UseVisualStyleBackColor = true;
            this.btnElec.Click += new System.EventHandler(this.btnElec_Click);
            // 
            // btnComp
            // 
            this.btnComp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComp.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnComp.Location = new System.Drawing.Point(0, 209);
            this.btnComp.Name = "btnComp";
            this.btnComp.Size = new System.Drawing.Size(301, 56);
            this.btnComp.TabIndex = 5;
            this.btnComp.Text = "Computers";
            this.btnComp.UseVisualStyleBackColor = true;
            this.btnComp.Click += new System.EventHandler(this.btnComp_Click);
            // 
            // btnBook
            // 
            this.btnBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBook.Location = new System.Drawing.Point(0, 153);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(301, 56);
            this.btnBook.TabIndex = 4;
            this.btnBook.Text = "Books";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnBeauty
            // 
            this.btnBeauty.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBeauty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeauty.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBeauty.Location = new System.Drawing.Point(0, 97);
            this.btnBeauty.Name = "btnBeauty";
            this.btnBeauty.Size = new System.Drawing.Size(301, 56);
            this.btnBeauty.TabIndex = 3;
            this.btnBeauty.Text = "Beauty, Health";
            this.btnBeauty.UseVisualStyleBackColor = true;
            this.btnBeauty.Click += new System.EventHandler(this.btnBeauty_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuto.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAuto.Location = new System.Drawing.Point(0, 41);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(301, 56);
            this.btnAuto.TabIndex = 2;
            this.btnAuto.Text = "Automotive";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "SHOP BY CATEGORY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProcess
            // 
            this.pnlProcess.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlProcess.Controls.Add(this.pnlForms);
            this.pnlProcess.Controls.Add(this.pnlRight);
            this.pnlProcess.Controls.Add(this.pnlLeft);
            this.pnlProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProcess.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlProcess.Location = new System.Drawing.Point(0, 100);
            this.pnlProcess.Name = "pnlProcess";
            this.pnlProcess.Size = new System.Drawing.Size(1484, 811);
            this.pnlProcess.TabIndex = 2;
            // 
            // pnlForms
            // 
            this.pnlForms.AutoScroll = true;
            this.pnlForms.Controls.Add(this.pnlList);
            this.pnlForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForms.Location = new System.Drawing.Point(150, 0);
            this.pnlForms.Name = "pnlForms";
            this.pnlForms.Size = new System.Drawing.Size(1184, 811);
            this.pnlForms.TabIndex = 0;
            // 
            // pnlList
            // 
            this.pnlList.AutoScroll = true;
            this.pnlList.Controls.Add(this.labelNoResult);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(0, 0);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(1184, 811);
            this.pnlList.TabIndex = 0;
            // 
            // labelNoResult
            // 
            this.labelNoResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNoResult.AutoSize = true;
            this.labelNoResult.Location = new System.Drawing.Point(563, 90);
            this.labelNoResult.Name = "labelNoResult";
            this.labelNoResult.Size = new System.Drawing.Size(93, 19);
            this.labelNoResult.TabIndex = 0;
            this.labelNoResult.Text = "No Result.";
            this.labelNoResult.Visible = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnAdd);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1334, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(150, 811);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(150, 811);
            this.pnlLeft.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 33);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1484, 911);
            this.Controls.Add(this.pnlCategory);
            this.Controls.Add(this.pnlProcess);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.Text = "Project";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlCategory.ResumeLayout(false);
            this.pnlProcess.ResumeLayout(false);
            this.pnlForms.ResumeLayout(false);
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlCategory;
        private System.Windows.Forms.Button btnToy;
        private System.Windows.Forms.Button btnSport;
        private System.Windows.Forms.Button btnSmart;
        private System.Windows.Forms.Button btnPet;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnFashion;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnElec;
        private System.Windows.Forms.Button btnComp;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnBeauty;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlProcess;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlForms;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Label labelNoResult;
        private System.Windows.Forms.Button btnAdd;
    }
}