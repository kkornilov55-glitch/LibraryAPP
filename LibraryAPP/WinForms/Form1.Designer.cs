namespace WinForms
{
    partial class BookStoreF
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            OrderBook = new TabPage();
            panel13 = new Panel();
            panel18 = new Panel();
            panel9 = new Panel();
            panel10 = new Panel();
            RandomizeBookB = new Button();
            AddBookB = new Button();
            panel6 = new Panel();
            PriceTB = new TextBox();
            label6 = new Label();
            panel5 = new Panel();
            PagesCountTB = new TextBox();
            label5 = new Label();
            panel4 = new Panel();
            GenreTB = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            ID_TB = new TextBox();
            label3 = new Label();
            panel3 = new Panel();
            AuthorTB = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            TitleTB = new TextBox();
            label1 = new Label();
            label18 = new Label();
            MainTC = new TabControl();
            StoreTP = new TabPage();
            panel14 = new Panel();
            panel17 = new Panel();
            panel8 = new Panel();
            panel7 = new Panel();
            label7 = new Label();
            StoreTC = new TabControl();
            MainTP = new TabPage();
            dataGridView1 = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            SearchResultTP = new TabPage();
            SearchedBookGrid = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            colTitleSearch = new DataGridViewTextBoxColumn();
            colGenreSearch = new DataGridViewTextBoxColumn();
            colAuthorSearch = new DataGridViewTextBoxColumn();
            colPagesCountSearch = new DataGridViewTextBoxColumn();
            colPriceSearch = new DataGridViewTextBoxColumn();
            ClearCaseB = new Button();
            SellBookB = new Button();
            FoundB = new Button();
            FoundStringTB = new TextBox();
            label9 = new Label();
            label8 = new Label();
            GenreSelectCB = new ComboBox();
            Customers = new TabPage();
            panel19 = new Panel();
            panel20 = new Panel();
            panel11 = new Panel();
            panel12 = new Panel();
            label11 = new Label();
            pnlCustomerArea = new Panel();
            btnRejectCustomer = new Button();
            btnSellToCustomer = new Button();
            txtSellPrice = new TextBox();
            label20 = new Label();
            cmbAvailableBooks = new ComboBox();
            lblCustomerRequest = new Label();
            label19 = new Label();
            lblCustomerRequest1 = new Label();
            lblCurrentTitle = new Label();
            lstCustomersQueue = new ListBox();
            lblQueueTitle = new Label();
            label13 = new Label();
            Supples = new TabPage();
            panel15 = new Panel();
            panel16 = new Panel();
            label10 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label12 = new Label();
            BalanceL = new Label();
            pictureBoxMoney = new PictureBox();
            pictureBoxGood = new PictureBox();
            pictureBoxBad = new PictureBox();
            lblUnhappyCount = new Label();
            btnHome = new Button();
            lblQueueCount = new Label();
            timeCustomer = new System.Windows.Forms.Timer(components);
            OrderBook.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            MainTC.SuspendLayout();
            StoreTP.SuspendLayout();
            StoreTC.SuspendLayout();
            MainTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SearchResultTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SearchedBookGrid).BeginInit();
            Customers.SuspendLayout();
            pnlCustomerArea.SuspendLayout();
            Supples.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMoney).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGood).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBad).BeginInit();
            SuspendLayout();
            // 
            // OrderBook
            // 
            OrderBook.BackColor = Color.FromArgb(171, 136, 106);
            OrderBook.BackgroundImage = Properties.Resources.bgList;
            OrderBook.BackgroundImageLayout = ImageLayout.Stretch;
            OrderBook.Controls.Add(panel13);
            OrderBook.Controls.Add(panel18);
            OrderBook.Controls.Add(panel9);
            OrderBook.Controls.Add(panel10);
            OrderBook.Controls.Add(RandomizeBookB);
            OrderBook.Controls.Add(AddBookB);
            OrderBook.Controls.Add(panel6);
            OrderBook.Controls.Add(panel5);
            OrderBook.Controls.Add(panel4);
            OrderBook.Controls.Add(panel2);
            OrderBook.Controls.Add(panel3);
            OrderBook.Controls.Add(panel1);
            OrderBook.Controls.Add(label18);
            OrderBook.Location = new Point(4, 29);
            OrderBook.Margin = new Padding(3, 2, 3, 2);
            OrderBook.Name = "OrderBook";
            OrderBook.Padding = new Padding(3, 2, 3, 2);
            OrderBook.Size = new Size(585, 553);
            OrderBook.TabIndex = 0;
            OrderBook.Text = "Заказать книгу";
            // 
            // panel13
            // 
            panel13.BackColor = Color.Orange;
            panel13.BorderStyle = BorderStyle.FixedSingle;
            panel13.ForeColor = SystemColors.ActiveCaption;
            panel13.Location = new Point(115, 4);
            panel13.Margin = new Padding(3, 2, 3, 2);
            panel13.Name = "panel13";
            panel13.Size = new Size(10, 56);
            panel13.TabIndex = 24;
            // 
            // panel18
            // 
            panel18.BackColor = Color.Orange;
            panel18.BorderStyle = BorderStyle.FixedSingle;
            panel18.ForeColor = SystemColors.ActiveCaption;
            panel18.Location = new Point(457, 1);
            panel18.Margin = new Padding(3, 2, 3, 2);
            panel18.Name = "panel18";
            panel18.Size = new Size(10, 56);
            panel18.TabIndex = 23;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Orange;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.ForeColor = SystemColors.ActiveCaption;
            panel9.Location = new Point(0, 0);
            panel9.Margin = new Padding(3, 2, 3, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(589, 9);
            panel9.TabIndex = 22;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Orange;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.ForeColor = SystemColors.ActiveCaption;
            panel10.Location = new Point(0, 52);
            panel10.Margin = new Padding(3, 2, 3, 2);
            panel10.Name = "panel10";
            panel10.Size = new Size(589, 9);
            panel10.TabIndex = 21;
            // 
            // RandomizeBookB
            // 
            RandomizeBookB.BackColor = Color.Transparent;
            RandomizeBookB.BackgroundImage = Properties.Resources.btnRandom;
            RandomizeBookB.BackgroundImageLayout = ImageLayout.Stretch;
            RandomizeBookB.Cursor = Cursors.Hand;
            RandomizeBookB.FlatAppearance.BorderSize = 0;
            RandomizeBookB.FlatAppearance.MouseDownBackColor = Color.Transparent;
            RandomizeBookB.FlatAppearance.MouseOverBackColor = Color.Transparent;
            RandomizeBookB.FlatStyle = FlatStyle.Flat;
            RandomizeBookB.Font = new Font("Cambria", 14F, FontStyle.Bold);
            RandomizeBookB.ForeColor = Color.FromArgb(57, 30, 16);
            RandomizeBookB.Location = new Point(479, 472);
            RandomizeBookB.Margin = new Padding(3, 2, 3, 2);
            RandomizeBookB.Name = "RandomizeBookB";
            RandomizeBookB.Size = new Size(60, 60);
            RandomizeBookB.TabIndex = 14;
            RandomizeBookB.TextAlign = ContentAlignment.TopCenter;
            RandomizeBookB.UseVisualStyleBackColor = false;
            // 
            // AddBookB
            // 
            AddBookB.BackColor = Color.Transparent;
            AddBookB.BackgroundImage = Properties.Resources.btnGame;
            AddBookB.BackgroundImageLayout = ImageLayout.Stretch;
            AddBookB.Cursor = Cursors.Hand;
            AddBookB.FlatAppearance.BorderSize = 0;
            AddBookB.FlatAppearance.MouseDownBackColor = Color.Transparent;
            AddBookB.FlatAppearance.MouseOverBackColor = Color.Transparent;
            AddBookB.FlatStyle = FlatStyle.Flat;
            AddBookB.Font = new Font("Kepler 296", 13F);
            AddBookB.ForeColor = Color.WhiteSmoke;
            AddBookB.Location = new Point(45, 477);
            AddBookB.Margin = new Padding(3, 2, 3, 2);
            AddBookB.Name = "AddBookB";
            AddBookB.Size = new Size(411, 50);
            AddBookB.TabIndex = 13;
            AddBookB.Text = "СОХРАНИТЬ";
            AddBookB.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(199, 160, 122);
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(PriceTB);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(48, 394);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(487, 55);
            panel6.TabIndex = 10;
            // 
            // PriceTB
            // 
            PriceTB.BackColor = Color.FromArgb(199, 160, 122);
            PriceTB.BorderStyle = BorderStyle.None;
            PriceTB.Cursor = Cursors.IBeam;
            PriceTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PriceTB.Location = new Point(187, 20);
            PriceTB.Margin = new Padding(3, 2, 3, 2);
            PriceTB.Name = "PriceTB";
            PriceTB.Size = new Size(299, 16);
            PriceTB.TabIndex = 1;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(115, 65, 40);
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.FromArgb(253, 252, 232);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(11, 0, 11, 0);
            label6.Size = new Size(173, 53);
            label6.TabIndex = 0;
            label6.Text = "Цена";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(199, 160, 122);
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(PagesCountTB);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(48, 332);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(487, 55);
            panel5.TabIndex = 9;
            // 
            // PagesCountTB
            // 
            PagesCountTB.BackColor = Color.FromArgb(199, 160, 122);
            PagesCountTB.BorderStyle = BorderStyle.None;
            PagesCountTB.Cursor = Cursors.IBeam;
            PagesCountTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PagesCountTB.Location = new Point(187, 20);
            PagesCountTB.Margin = new Padding(3, 2, 3, 2);
            PagesCountTB.Name = "PagesCountTB";
            PagesCountTB.Size = new Size(299, 16);
            PagesCountTB.TabIndex = 1;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(115, 65, 40);
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.FromArgb(253, 252, 232);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(11, 0, 11, 0);
            label5.Size = new Size(173, 53);
            label5.TabIndex = 0;
            label5.Text = "Количество страниц";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(199, 160, 122);
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(GenreTB);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(48, 272);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(487, 55);
            panel4.TabIndex = 8;
            // 
            // GenreTB
            // 
            GenreTB.BackColor = Color.FromArgb(199, 160, 122);
            GenreTB.BorderStyle = BorderStyle.None;
            GenreTB.Cursor = Cursors.IBeam;
            GenreTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GenreTB.Location = new Point(187, 20);
            GenreTB.Margin = new Padding(3, 2, 3, 2);
            GenreTB.Name = "GenreTB";
            GenreTB.Size = new Size(299, 16);
            GenreTB.TabIndex = 1;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(115, 65, 40);
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.FromArgb(253, 252, 232);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(11, 0, 11, 0);
            label4.Size = new Size(173, 53);
            label4.TabIndex = 0;
            label4.Text = "Жанр";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(199, 160, 122);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(ID_TB);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(48, 212);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(487, 55);
            panel2.TabIndex = 7;
            // 
            // ID_TB
            // 
            ID_TB.BackColor = Color.FromArgb(199, 160, 122);
            ID_TB.BorderStyle = BorderStyle.None;
            ID_TB.Cursor = Cursors.IBeam;
            ID_TB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ID_TB.Location = new Point(187, 20);
            ID_TB.Margin = new Padding(3, 2, 3, 2);
            ID_TB.Name = "ID_TB";
            ID_TB.ReadOnly = true;
            ID_TB.Size = new Size(299, 16);
            ID_TB.TabIndex = 1;
            ID_TB.Text = "Авто";
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(115, 65, 40);
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.FromArgb(253, 252, 232);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(11, 0, 11, 0);
            label3.Size = new Size(173, 53);
            label3.TabIndex = 0;
            label3.Text = "ID";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(199, 160, 122);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(AuthorTB);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(48, 152);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(487, 55);
            panel3.TabIndex = 6;
            // 
            // AuthorTB
            // 
            AuthorTB.BackColor = Color.FromArgb(199, 160, 122);
            AuthorTB.BorderStyle = BorderStyle.None;
            AuthorTB.Cursor = Cursors.IBeam;
            AuthorTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AuthorTB.Location = new Point(187, 20);
            AuthorTB.Margin = new Padding(3, 2, 3, 2);
            AuthorTB.Name = "AuthorTB";
            AuthorTB.Size = new Size(299, 16);
            AuthorTB.TabIndex = 1;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(115, 65, 40);
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.FromArgb(253, 252, 232);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(11, 0, 11, 0);
            label2.Size = new Size(173, 53);
            label2.TabIndex = 0;
            label2.Text = "Автор";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(199, 160, 122);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TitleTB);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(48, 92);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(487, 55);
            panel1.TabIndex = 1;
            // 
            // TitleTB
            // 
            TitleTB.BackColor = Color.FromArgb(199, 160, 122);
            TitleTB.BorderStyle = BorderStyle.None;
            TitleTB.Cursor = Cursors.IBeam;
            TitleTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TitleTB.Location = new Point(187, 20);
            TitleTB.Margin = new Padding(3, 2, 3, 2);
            TitleTB.Name = "TitleTB";
            TitleTB.Size = new Size(299, 16);
            TitleTB.TabIndex = 1;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(115, 65, 40);
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(253, 252, 232);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(11, 0, 11, 0);
            label1.Size = new Size(173, 53);
            label1.TabIndex = 0;
            label1.Text = "Название";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            label18.BackColor = Color.FromArgb(57, 30, 16);
            label18.Font = new Font("Cambria", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label18.ForeColor = Color.FromArgb(253, 252, 232);
            label18.Location = new Point(0, 0);
            label18.Name = "label18";
            label18.Size = new Size(589, 57);
            label18.TabIndex = 18;
            label18.Text = "Заказать книгу";
            label18.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainTC
            // 
            MainTC.Appearance = TabAppearance.Buttons;
            MainTC.Controls.Add(OrderBook);
            MainTC.Controls.Add(StoreTP);
            MainTC.Controls.Add(Customers);
            MainTC.Controls.Add(Supples);
            MainTC.Font = new Font("Kepler 296", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            MainTC.Location = new Point(-4, 81);
            MainTC.Margin = new Padding(3, 2, 3, 2);
            MainTC.Name = "MainTC";
            MainTC.SelectedIndex = 0;
            MainTC.Size = new Size(593, 586);
            MainTC.TabIndex = 0;
            // 
            // StoreTP
            // 
            StoreTP.BackColor = Color.FromArgb(171, 136, 106);
            StoreTP.BackgroundImage = Properties.Resources.bgList;
            StoreTP.BackgroundImageLayout = ImageLayout.Stretch;
            StoreTP.Controls.Add(panel14);
            StoreTP.Controls.Add(panel17);
            StoreTP.Controls.Add(panel8);
            StoreTP.Controls.Add(panel7);
            StoreTP.Controls.Add(label7);
            StoreTP.Controls.Add(StoreTC);
            StoreTP.Controls.Add(ClearCaseB);
            StoreTP.Controls.Add(SellBookB);
            StoreTP.Controls.Add(FoundB);
            StoreTP.Controls.Add(FoundStringTB);
            StoreTP.Controls.Add(label9);
            StoreTP.Controls.Add(label8);
            StoreTP.Controls.Add(GenreSelectCB);
            StoreTP.Location = new Point(4, 29);
            StoreTP.Margin = new Padding(3, 2, 3, 2);
            StoreTP.Name = "StoreTP";
            StoreTP.Padding = new Padding(3, 2, 3, 2);
            StoreTP.Size = new Size(585, 553);
            StoreTP.TabIndex = 2;
            StoreTP.Text = "Магазин";
            // 
            // panel14
            // 
            panel14.BackColor = Color.Orange;
            panel14.BorderStyle = BorderStyle.FixedSingle;
            panel14.ForeColor = SystemColors.ActiveCaption;
            panel14.Location = new Point(115, 4);
            panel14.Margin = new Padding(3, 2, 3, 2);
            panel14.Name = "panel14";
            panel14.Size = new Size(10, 56);
            panel14.TabIndex = 36;
            // 
            // panel17
            // 
            panel17.BackColor = Color.Orange;
            panel17.BorderStyle = BorderStyle.FixedSingle;
            panel17.ForeColor = SystemColors.ActiveCaption;
            panel17.Location = new Point(457, 1);
            panel17.Margin = new Padding(3, 2, 3, 2);
            panel17.Name = "panel17";
            panel17.Size = new Size(10, 56);
            panel17.TabIndex = 35;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Orange;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.ForeColor = SystemColors.ActiveCaption;
            panel8.Location = new Point(0, 52);
            panel8.Margin = new Padding(3, 2, 3, 2);
            panel8.Name = "panel8";
            panel8.Size = new Size(589, 9);
            panel8.TabIndex = 34;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Orange;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.ForeColor = SystemColors.ActiveCaption;
            panel7.Location = new Point(0, 0);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(589, 9);
            panel7.TabIndex = 33;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(57, 30, 16);
            label7.Font = new Font("Cambria", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.FromArgb(253, 252, 232);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(589, 57);
            label7.TabIndex = 32;
            label7.Text = "Магазин";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StoreTC
            // 
            StoreTC.Appearance = TabAppearance.Buttons;
            StoreTC.Controls.Add(MainTP);
            StoreTC.Controls.Add(SearchResultTP);
            StoreTC.Location = new Point(75, 137);
            StoreTC.Margin = new Padding(3, 2, 3, 2);
            StoreTC.Name = "StoreTC";
            StoreTC.SelectedIndex = 0;
            StoreTC.Size = new Size(425, 255);
            StoreTC.TabIndex = 26;
            // 
            // MainTP
            // 
            MainTP.Controls.Add(dataGridView1);
            MainTP.Location = new Point(4, 29);
            MainTP.Margin = new Padding(3, 2, 3, 2);
            MainTP.Name = "MainTP";
            MainTP.Padding = new Padding(3, 2, 3, 2);
            MainTP.Size = new Size(417, 222);
            MainTP.TabIndex = 0;
            MainTP.Text = "Главная";
            MainTP.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.Linen;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = Color.FromArgb(57, 30, 16);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colId, colTitle, colAuthor, colPrice });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 2);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(411, 218);
            dataGridView1.TabIndex = 16;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 50;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Название";
            colTitle.MinimumWidth = 6;
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            colTitle.Width = 125;
            // 
            // colAuthor
            // 
            colAuthor.HeaderText = "Автор";
            colAuthor.MinimumWidth = 6;
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            colAuthor.Width = 125;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Цена";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 125;
            // 
            // SearchResultTP
            // 
            SearchResultTP.Controls.Add(SearchedBookGrid);
            SearchResultTP.Location = new Point(4, 29);
            SearchResultTP.Margin = new Padding(3, 2, 3, 2);
            SearchResultTP.Name = "SearchResultTP";
            SearchResultTP.Padding = new Padding(3, 2, 3, 2);
            SearchResultTP.Size = new Size(417, 222);
            SearchResultTP.TabIndex = 1;
            SearchResultTP.Text = "Результаты поиска";
            SearchResultTP.UseVisualStyleBackColor = true;
            // 
            // SearchedBookGrid
            // 
            dataGridViewCellStyle2.BackColor = Color.Linen;
            SearchedBookGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            SearchedBookGrid.BackgroundColor = Color.FromArgb(57, 30, 16);
            SearchedBookGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SearchedBookGrid.Columns.AddRange(new DataGridViewColumn[] { ID, colTitleSearch, colGenreSearch, colAuthorSearch, colPagesCountSearch, colPriceSearch });
            SearchedBookGrid.Dock = DockStyle.Fill;
            SearchedBookGrid.Location = new Point(3, 2);
            SearchedBookGrid.Margin = new Padding(3, 2, 3, 2);
            SearchedBookGrid.Name = "SearchedBookGrid";
            SearchedBookGrid.RowHeadersWidth = 51;
            SearchedBookGrid.Size = new Size(411, 218);
            SearchedBookGrid.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 50;
            // 
            // colTitleSearch
            // 
            colTitleSearch.HeaderText = "Название";
            colTitleSearch.MinimumWidth = 6;
            colTitleSearch.Name = "colTitleSearch";
            colTitleSearch.ReadOnly = true;
            colTitleSearch.Width = 125;
            // 
            // colGenreSearch
            // 
            colGenreSearch.HeaderText = "Жанр";
            colGenreSearch.MinimumWidth = 6;
            colGenreSearch.Name = "colGenreSearch";
            colGenreSearch.ReadOnly = true;
            colGenreSearch.Width = 125;
            // 
            // colAuthorSearch
            // 
            colAuthorSearch.HeaderText = "Автор";
            colAuthorSearch.MinimumWidth = 6;
            colAuthorSearch.Name = "colAuthorSearch";
            colAuthorSearch.ReadOnly = true;
            colAuthorSearch.Width = 125;
            // 
            // colPagesCountSearch
            // 
            colPagesCountSearch.HeaderText = "Количество страниц";
            colPagesCountSearch.MinimumWidth = 6;
            colPagesCountSearch.Name = "colPagesCountSearch";
            colPagesCountSearch.ReadOnly = true;
            colPagesCountSearch.Width = 125;
            // 
            // colPriceSearch
            // 
            colPriceSearch.HeaderText = "Цена";
            colPriceSearch.MinimumWidth = 6;
            colPriceSearch.Name = "colPriceSearch";
            colPriceSearch.ReadOnly = true;
            colPriceSearch.Width = 125;
            // 
            // ClearCaseB
            // 
            ClearCaseB.BackColor = Color.FromArgb(199, 160, 122);
            ClearCaseB.FlatAppearance.BorderColor = Color.Black;
            ClearCaseB.FlatStyle = FlatStyle.Flat;
            ClearCaseB.Font = new Font("Kepler 296", 11F);
            ClearCaseB.Location = new Point(291, 495);
            ClearCaseB.Margin = new Padding(3, 2, 3, 2);
            ClearCaseB.Name = "ClearCaseB";
            ClearCaseB.Size = new Size(209, 29);
            ClearCaseB.TabIndex = 21;
            ClearCaseB.Text = "Очистить шкаф";
            ClearCaseB.UseVisualStyleBackColor = false;
            // 
            // SellBookB
            // 
            SellBookB.BackColor = Color.FromArgb(199, 160, 122);
            SellBookB.FlatAppearance.BorderColor = Color.Black;
            SellBookB.FlatStyle = FlatStyle.Flat;
            SellBookB.Font = new Font("Kepler 296", 11F);
            SellBookB.Location = new Point(75, 495);
            SellBookB.Margin = new Padding(3, 2, 3, 2);
            SellBookB.Name = "SellBookB";
            SellBookB.Size = new Size(209, 29);
            SellBookB.TabIndex = 20;
            SellBookB.Text = "Продать";
            SellBookB.UseVisualStyleBackColor = false;
            // 
            // FoundB
            // 
            FoundB.BackColor = Color.Transparent;
            FoundB.BackgroundImage = Properties.Resources.btnGame;
            FoundB.BackgroundImageLayout = ImageLayout.Stretch;
            FoundB.Cursor = Cursors.Hand;
            FoundB.FlatAppearance.BorderSize = 0;
            FoundB.FlatAppearance.MouseDownBackColor = Color.Transparent;
            FoundB.FlatAppearance.MouseOverBackColor = Color.Transparent;
            FoundB.FlatStyle = FlatStyle.Flat;
            FoundB.Font = new Font("Kepler 296", 13F);
            FoundB.ForeColor = SystemColors.ButtonHighlight;
            FoundB.Location = new Point(75, 446);
            FoundB.Margin = new Padding(3, 2, 3, 2);
            FoundB.Name = "FoundB";
            FoundB.Size = new Size(425, 42);
            FoundB.TabIndex = 19;
            FoundB.Text = "НАЙТИ!";
            FoundB.UseVisualStyleBackColor = false;
            // 
            // FoundStringTB
            // 
            FoundStringTB.BackColor = Color.Bisque;
            FoundStringTB.BorderStyle = BorderStyle.FixedSingle;
            FoundStringTB.Location = new Point(156, 409);
            FoundStringTB.Margin = new Padding(3, 2, 3, 2);
            FoundStringTB.Name = "FoundStringTB";
            FoundStringTB.Size = new Size(342, 24);
            FoundStringTB.TabIndex = 18;
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Kepler 296", 13.8F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(57, 30, 16);
            label9.ImageAlign = ContentAlignment.MiddleLeft;
            label9.Location = new Point(75, 407);
            label9.Name = "label9";
            label9.Size = new Size(85, 25);
            label9.TabIndex = 17;
            label9.Text = "Поиск";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Kepler 296", 13.8F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(57, 30, 16);
            label8.ImageAlign = ContentAlignment.MiddleLeft;
            label8.Location = new Point(342, 78);
            label8.Name = "label8";
            label8.Size = new Size(101, 25);
            label8.TabIndex = 15;
            label8.Text = "Жанр:";
            // 
            // GenreSelectCB
            // 
            GenreSelectCB.BackColor = Color.Bisque;
            GenreSelectCB.Cursor = Cursors.Hand;
            GenreSelectCB.FlatStyle = FlatStyle.Flat;
            GenreSelectCB.ForeColor = Color.FromArgb(57, 30, 16);
            GenreSelectCB.FormattingEnabled = true;
            GenreSelectCB.Location = new Point(349, 108);
            GenreSelectCB.Margin = new Padding(3, 2, 3, 2);
            GenreSelectCB.Name = "GenreSelectCB";
            GenreSelectCB.Size = new Size(151, 25);
            GenreSelectCB.TabIndex = 14;
            // 
            // Customers
            // 
            Customers.BackColor = Color.FromArgb(171, 136, 106);
            Customers.BackgroundImage = Properties.Resources.bgList;
            Customers.BackgroundImageLayout = ImageLayout.Stretch;
            Customers.Controls.Add(panel19);
            Customers.Controls.Add(panel20);
            Customers.Controls.Add(panel11);
            Customers.Controls.Add(panel12);
            Customers.Controls.Add(label11);
            Customers.Controls.Add(pnlCustomerArea);
            Customers.Controls.Add(label13);
            Customers.Location = new Point(4, 29);
            Customers.Name = "Customers";
            Customers.Size = new Size(585, 553);
            Customers.TabIndex = 4;
            Customers.Text = "Покупатели";
            // 
            // panel19
            // 
            panel19.BackColor = Color.Orange;
            panel19.BorderStyle = BorderStyle.FixedSingle;
            panel19.ForeColor = SystemColors.ActiveCaption;
            panel19.Location = new Point(115, 3);
            panel19.Margin = new Padding(3, 2, 3, 2);
            panel19.Name = "panel19";
            panel19.Size = new Size(10, 56);
            panel19.TabIndex = 42;
            // 
            // panel20
            // 
            panel20.BackColor = Color.Orange;
            panel20.BorderStyle = BorderStyle.FixedSingle;
            panel20.ForeColor = SystemColors.ActiveCaption;
            panel20.Location = new Point(457, 0);
            panel20.Margin = new Padding(3, 2, 3, 2);
            panel20.Name = "panel20";
            panel20.Size = new Size(10, 56);
            panel20.TabIndex = 41;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Orange;
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.ForeColor = SystemColors.ActiveCaption;
            panel11.Location = new Point(0, 51);
            panel11.Margin = new Padding(3, 2, 3, 2);
            panel11.Name = "panel11";
            panel11.Size = new Size(589, 9);
            panel11.TabIndex = 37;
            // 
            // panel12
            // 
            panel12.BackColor = Color.Orange;
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.ForeColor = SystemColors.ActiveCaption;
            panel12.Location = new Point(0, 0);
            panel12.Margin = new Padding(3, 2, 3, 2);
            panel12.Name = "panel12";
            panel12.Size = new Size(589, 9);
            panel12.TabIndex = 36;
            // 
            // label11
            // 
            label11.BackColor = Color.FromArgb(57, 30, 16);
            label11.Font = new Font("Cambria", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label11.ForeColor = Color.FromArgb(253, 252, 232);
            label11.Location = new Point(0, 0);
            label11.Name = "label11";
            label11.Size = new Size(589, 57);
            label11.TabIndex = 35;
            label11.Text = "Покупатели";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCustomerArea
            // 
            pnlCustomerArea.BackgroundImage = Properties.Resources.bgList;
            pnlCustomerArea.BackgroundImageLayout = ImageLayout.Stretch;
            pnlCustomerArea.Controls.Add(btnRejectCustomer);
            pnlCustomerArea.Controls.Add(btnSellToCustomer);
            pnlCustomerArea.Controls.Add(txtSellPrice);
            pnlCustomerArea.Controls.Add(label20);
            pnlCustomerArea.Controls.Add(cmbAvailableBooks);
            pnlCustomerArea.Controls.Add(lblCustomerRequest);
            pnlCustomerArea.Controls.Add(label19);
            pnlCustomerArea.Controls.Add(lblCustomerRequest1);
            pnlCustomerArea.Controls.Add(lblCurrentTitle);
            pnlCustomerArea.Controls.Add(lstCustomersQueue);
            pnlCustomerArea.Controls.Add(lblQueueTitle);
            pnlCustomerArea.Location = new Point(0, 58);
            pnlCustomerArea.Name = "pnlCustomerArea";
            pnlCustomerArea.Size = new Size(581, 503);
            pnlCustomerArea.TabIndex = 40;
            pnlCustomerArea.Visible = false;
            // 
            // btnRejectCustomer
            // 
            btnRejectCustomer.BackColor = Color.Transparent;
            btnRejectCustomer.BackgroundImage = Properties.Resources.btn5;
            btnRejectCustomer.BackgroundImageLayout = ImageLayout.Stretch;
            btnRejectCustomer.Cursor = Cursors.Hand;
            btnRejectCustomer.FlatAppearance.BorderSize = 0;
            btnRejectCustomer.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnRejectCustomer.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnRejectCustomer.FlatStyle = FlatStyle.Flat;
            btnRejectCustomer.Font = new Font("Kepler 296", 13F);
            btnRejectCustomer.ForeColor = Color.FromArgb(64, 0, 0);
            btnRejectCustomer.Location = new Point(304, 397);
            btnRejectCustomer.Name = "btnRejectCustomer";
            btnRejectCustomer.Size = new Size(232, 61);
            btnRejectCustomer.TabIndex = 10;
            btnRejectCustomer.Text = "ОТКАЗАТЬ";
            btnRejectCustomer.UseVisualStyleBackColor = false;
            btnRejectCustomer.Click += btnRejectCustomer_Click;
            // 
            // btnSellToCustomer
            // 
            btnSellToCustomer.BackColor = Color.Transparent;
            btnSellToCustomer.BackgroundImage = Properties.Resources.btn1_1;
            btnSellToCustomer.BackgroundImageLayout = ImageLayout.Stretch;
            btnSellToCustomer.Cursor = Cursors.Hand;
            btnSellToCustomer.FlatAppearance.BorderSize = 0;
            btnSellToCustomer.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSellToCustomer.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSellToCustomer.FlatStyle = FlatStyle.Flat;
            btnSellToCustomer.Font = new Font("Kepler 296", 13F);
            btnSellToCustomer.ForeColor = Color.DarkGreen;
            btnSellToCustomer.Location = new Point(47, 397);
            btnSellToCustomer.Name = "btnSellToCustomer";
            btnSellToCustomer.Size = new Size(232, 61);
            btnSellToCustomer.TabIndex = 9;
            btnSellToCustomer.Text = "ПРОДАТЬ";
            btnSellToCustomer.UseVisualStyleBackColor = false;
            btnSellToCustomer.Click += btnSellToCustomer_Click;
            // 
            // txtSellPrice
            // 
            txtSellPrice.BackColor = Color.Bisque;
            txtSellPrice.BorderStyle = BorderStyle.FixedSingle;
            txtSellPrice.Cursor = Cursors.IBeam;
            txtSellPrice.Font = new Font("Kepler 296", 12F);
            txtSellPrice.ForeColor = Color.FromArgb(57, 30, 16);
            txtSellPrice.Location = new Point(233, 333);
            txtSellPrice.Name = "txtSellPrice";
            txtSellPrice.Size = new Size(303, 30);
            txtSellPrice.TabIndex = 8;
            txtSellPrice.Text = "0";
            txtSellPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.Transparent;
            label20.Font = new Font("Kepler 296", 14F);
            label20.ForeColor = Color.Maroon;
            label20.Location = new Point(47, 335);
            label20.Name = "label20";
            label20.Size = new Size(168, 27);
            label20.TabIndex = 7;
            label20.Text = "Цена продажи:";
            // 
            // cmbAvailableBooks
            // 
            cmbAvailableBooks.BackColor = Color.Bisque;
            cmbAvailableBooks.FlatStyle = FlatStyle.Flat;
            cmbAvailableBooks.ForeColor = Color.FromArgb(57, 30, 16);
            cmbAvailableBooks.FormattingEnabled = true;
            cmbAvailableBooks.Location = new Point(233, 296);
            cmbAvailableBooks.Name = "cmbAvailableBooks";
            cmbAvailableBooks.Size = new Size(303, 25);
            cmbAvailableBooks.TabIndex = 6;
            // 
            // lblCustomerRequest
            // 
            lblCustomerRequest.AutoSize = true;
            lblCustomerRequest.BackColor = Color.Transparent;
            lblCustomerRequest.Font = new Font("Kepler 296", 14F);
            lblCustomerRequest.ForeColor = Color.Green;
            lblCustomerRequest.Location = new Point(127, 255);
            lblCustomerRequest.Name = "lblCustomerRequest";
            lblCustomerRequest.Size = new Size(82, 27);
            lblCustomerRequest.TabIndex = 5;
            lblCustomerRequest.Text = "запрос";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.Transparent;
            label19.Font = new Font("Kepler 296", 14F);
            label19.ForeColor = Color.Maroon;
            label19.Location = new Point(47, 295);
            label19.Name = "label19";
            label19.Size = new Size(180, 27);
            label19.TabIndex = 4;
            label19.Text = "Выберите книгу:";
            // 
            // lblCustomerRequest1
            // 
            lblCustomerRequest1.AutoSize = true;
            lblCustomerRequest1.BackColor = Color.Transparent;
            lblCustomerRequest1.Font = new Font("Kepler 296", 14F);
            lblCustomerRequest1.ForeColor = Color.Maroon;
            lblCustomerRequest1.Location = new Point(47, 255);
            lblCustomerRequest1.Name = "lblCustomerRequest1";
            lblCustomerRequest1.Size = new Size(78, 27);
            lblCustomerRequest1.TabIndex = 3;
            lblCustomerRequest1.Text = "Хочет:";
            // 
            // lblCurrentTitle
            // 
            lblCurrentTitle.AutoSize = true;
            lblCurrentTitle.BackColor = Color.Transparent;
            lblCurrentTitle.Font = new Font("Kepler 296", 16F);
            lblCurrentTitle.ForeColor = Color.Maroon;
            lblCurrentTitle.Location = new Point(129, 212);
            lblCurrentTitle.Name = "lblCurrentTitle";
            lblCurrentTitle.Size = new Size(324, 31);
            lblCurrentTitle.TabIndex = 2;
            lblCurrentTitle.Text = "👤 ТЕКУЩИЙ ПОКУПАТЕЛЬ";
            // 
            // lstCustomersQueue
            // 
            lstCustomersQueue.BackColor = Color.Bisque;
            lstCustomersQueue.BorderStyle = BorderStyle.None;
            lstCustomersQueue.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lstCustomersQueue.ForeColor = Color.FromArgb(57, 30, 16);
            lstCustomersQueue.FormattingEnabled = true;
            lstCustomersQueue.Location = new Point(47, 72);
            lstCustomersQueue.Name = "lstCustomersQueue";
            lstCustomersQueue.Size = new Size(489, 105);
            lstCustomersQueue.TabIndex = 1;
            // 
            // lblQueueTitle
            // 
            lblQueueTitle.AutoSize = true;
            lblQueueTitle.BackColor = Color.Transparent;
            lblQueueTitle.Font = new Font("Kepler 296", 16F);
            lblQueueTitle.ForeColor = Color.Maroon;
            lblQueueTitle.Location = new Point(125, 30);
            lblQueueTitle.Name = "lblQueueTitle";
            lblQueueTitle.Size = new Size(332, 31);
            lblQueueTitle.TabIndex = 0;
            lblQueueTitle.Text = "📋 ОЧЕРЕДЬ ПОКУПАТЕЛЕЙ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Kepler 296", 24F);
            label13.ForeColor = Color.FromArgb(57, 30, 16);
            label13.Location = new Point(79, 250);
            label13.Name = "label13";
            label13.Size = new Size(434, 90);
            label13.TabIndex = 39;
            label13.Text = "У Вас пока нет\r\nни одного покупателя =(";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Supples
            // 
            Supples.BackColor = Color.FromArgb(171, 136, 106);
            Supples.BackgroundImage = Properties.Resources.bgList;
            Supples.Controls.Add(panel15);
            Supples.Controls.Add(panel16);
            Supples.Controls.Add(label10);
            Supples.Controls.Add(label17);
            Supples.Controls.Add(label16);
            Supples.Controls.Add(label15);
            Supples.Controls.Add(label14);
            Supples.Controls.Add(label12);
            Supples.Location = new Point(4, 29);
            Supples.Name = "Supples";
            Supples.Size = new Size(585, 553);
            Supples.TabIndex = 3;
            Supples.Text = "Поставки";
            // 
            // panel15
            // 
            panel15.BackColor = Color.Orange;
            panel15.BorderStyle = BorderStyle.FixedSingle;
            panel15.ForeColor = SystemColors.ActiveCaption;
            panel15.Location = new Point(0, 50);
            panel15.Margin = new Padding(3, 2, 3, 2);
            panel15.Name = "panel15";
            panel15.Size = new Size(589, 9);
            panel15.TabIndex = 37;
            // 
            // panel16
            // 
            panel16.BackColor = Color.Orange;
            panel16.BorderStyle = BorderStyle.FixedSingle;
            panel16.ForeColor = SystemColors.ActiveCaption;
            panel16.Location = new Point(0, 0);
            panel16.Margin = new Padding(3, 2, 3, 2);
            panel16.Name = "panel16";
            panel16.Size = new Size(589, 9);
            panel16.TabIndex = 36;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(57, 30, 16);
            label10.Font = new Font("Cambria", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label10.ForeColor = Color.FromArgb(253, 252, 232);
            label10.Image = Properties.Resources.bookLabel;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(589, 57);
            label10.TabIndex = 35;
            label10.Text = "Поставки";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Cambria", 18F);
            label17.Location = new Point(45, 222);
            label17.Name = "label17";
            label17.Size = new Size(66, 28);
            label17.TabIndex = 22;
            label17.Text = "Цена";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Cambria", 18F);
            label16.Location = new Point(49, 192);
            label16.Name = "label16";
            label16.Size = new Size(123, 28);
            label16.TabIndex = 21;
            label16.Text = "Страницы";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Cambria", 18F);
            label15.Location = new Point(49, 154);
            label15.Name = "label15";
            label15.Size = new Size(73, 28);
            label15.TabIndex = 20;
            label15.Text = "Жанр";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Cambria", 18F);
            label14.Location = new Point(46, 124);
            label14.Name = "label14";
            label14.Size = new Size(78, 28);
            label14.TabIndex = 19;
            label14.Text = "Автор";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Cambria", 18F);
            label12.Location = new Point(48, 94);
            label12.Name = "label12";
            label12.Size = new Size(116, 28);
            label12.TabIndex = 18;
            label12.Text = "Название";
            // 
            // BalanceL
            // 
            BalanceL.BackColor = Color.FromArgb(150, 54, 4);
            BalanceL.Font = new Font("Kepler 296", 10F);
            BalanceL.ForeColor = SystemColors.ControlLightLight;
            BalanceL.Location = new Point(185, 32);
            BalanceL.Name = "BalanceL";
            BalanceL.Size = new Size(131, 17);
            BalanceL.TabIndex = 12;
            BalanceL.Text = "0";
            BalanceL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBoxMoney
            // 
            pictureBoxMoney.BackColor = Color.Transparent;
            pictureBoxMoney.BackgroundImage = Properties.Resources.money_1;
            pictureBoxMoney.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxMoney.Location = new Point(153, 22);
            pictureBoxMoney.Name = "pictureBoxMoney";
            pictureBoxMoney.Size = new Size(173, 37);
            pictureBoxMoney.TabIndex = 13;
            pictureBoxMoney.TabStop = false;
            // 
            // pictureBoxGood
            // 
            pictureBoxGood.BackColor = Color.Transparent;
            pictureBoxGood.BackgroundImage = Properties.Resources.queue_3;
            pictureBoxGood.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxGood.Location = new Point(343, 21);
            pictureBoxGood.Name = "pictureBoxGood";
            pictureBoxGood.Size = new Size(101, 37);
            pictureBoxGood.TabIndex = 14;
            pictureBoxGood.TabStop = false;
            // 
            // pictureBoxBad
            // 
            pictureBoxBad.BackColor = Color.Transparent;
            pictureBoxBad.BackgroundImage = Properties.Resources.bad;
            pictureBoxBad.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxBad.Location = new Point(461, 21);
            pictureBoxBad.Name = "pictureBoxBad";
            pictureBoxBad.Size = new Size(101, 37);
            pictureBoxBad.TabIndex = 15;
            pictureBoxBad.TabStop = false;
            // 
            // lblUnhappyCount
            // 
            lblUnhappyCount.BackColor = Color.FromArgb(150, 54, 4);
            lblUnhappyCount.Font = new Font("Kepler 296", 10F);
            lblUnhappyCount.ForeColor = SystemColors.ControlLightLight;
            lblUnhappyCount.Location = new Point(496, 32);
            lblUnhappyCount.Name = "lblUnhappyCount";
            lblUnhappyCount.Size = new Size(57, 17);
            lblUnhappyCount.TabIndex = 17;
            lblUnhappyCount.Text = "0 / 3";
            lblUnhappyCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Transparent;
            btnHome.BackgroundImage = Properties.Resources.btnHome;
            btnHome.BackgroundImageLayout = ImageLayout.Stretch;
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnHome.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Location = new Point(20, 15);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(50, 50);
            btnHome.TabIndex = 18;
            btnHome.UseMnemonic = false;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // lblQueueCount
            // 
            lblQueueCount.BackColor = Color.FromArgb(150, 54, 4);
            lblQueueCount.Font = new Font("Kepler 296", 10F);
            lblQueueCount.ForeColor = SystemColors.ControlLightLight;
            lblQueueCount.Location = new Point(380, 32);
            lblQueueCount.Name = "lblQueueCount";
            lblQueueCount.Size = new Size(56, 17);
            lblQueueCount.TabIndex = 16;
            lblQueueCount.Text = "0 / 0";
            lblQueueCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeCustomer
            // 
            timeCustomer.Interval = 1000;
            timeCustomer.Tick += timeCustomer_Tick;
            // 
            // BookStoreF
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.bgGame_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(582, 657);
            Controls.Add(btnHome);
            Controls.Add(lblUnhappyCount);
            Controls.Add(lblQueueCount);
            Controls.Add(BalanceL);
            Controls.Add(pictureBoxBad);
            Controls.Add(pictureBoxGood);
            Controls.Add(pictureBoxMoney);
            Controls.Add(MainTC);
            DoubleBuffered = true;
            Font = new Font("Kepler 296", 8.999999F);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "BookStoreF";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Книжный магазин";
            OrderBook.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            MainTC.ResumeLayout(false);
            StoreTP.ResumeLayout(false);
            StoreTP.PerformLayout();
            StoreTC.ResumeLayout(false);
            MainTP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            SearchResultTP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SearchedBookGrid).EndInit();
            Customers.ResumeLayout(false);
            Customers.PerformLayout();
            pnlCustomerArea.ResumeLayout(false);
            pnlCustomerArea.PerformLayout();
            Supples.ResumeLayout(false);
            Supples.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMoney).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGood).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBad).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabPage OrderBook;
        private Button RandomizeBookB;
        private Button AddBookB;
        private Panel panel6;
        private TextBox PriceTB;
        private Label label6;
        private Panel panel5;
        private TextBox PagesCountTB;
        private Label label5;
        private Panel panel4;
        private TextBox GenreTB;
        private Label label4;
        private Panel panel2;
        private TextBox ID_TB;
        private Label label3;
        private Panel panel3;
        private TextBox AuthorTB;
        private Label label2;
        private Panel panel1;
        private TextBox TitleTB;
        private Label label1;
        private TabControl MainTC;
        private TabPage Supples;
        private TabPage Customers;
        private TabPage StoreTP;
        private TabControl StoreTC;
        private TabPage MainTP;
        private DataGridView dataGridView1;
        private TabPage SearchResultTP;
        private DataGridView SearchedBookGrid;
        private Button ClearCaseB;
        private Button SellBookB;
        private Button FoundB;
        private TextBox FoundStringTB;
        private Label label9;
        private Label label8;
        private ComboBox GenreSelectCB;
        private Label BalanceL;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label12;
        private PictureBox pictureBoxMoney;
        private PictureBox pictureBoxGood;
        private PictureBox pictureBoxBad;
        private Label lblUnhappyCount;
        private Button btnHome;
        private Panel panel9;
        private Panel panel10;
        private Panel panel8;
        private Panel panel7;
        private Panel panel11;
        private Panel panel12;
        private Label label11;
        private Panel panel15;
        private Panel panel16;
        private Label label10;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn colTitleSearch;
        private DataGridViewTextBoxColumn colGenreSearch;
        private DataGridViewTextBoxColumn colAuthorSearch;
        private DataGridViewTextBoxColumn colPagesCountSearch;
        private DataGridViewTextBoxColumn colPriceSearch;
        private System.Windows.Forms.Timer timerCustomers;
        private Label label13;
        private Label lblQueueCount;
        private Panel pnlCustomerArea;
        private Label lblQueueTitle;
        private Label lblCurrentTitle;
        private ListBox lstCustomersQueue;
        private ComboBox cmbAvailableBooks;
        private Label lblCustomerRequest;
        private Label label19;
        private Label lblCustomerRequest1;
        private TextBox txtSellPrice;
        private Label label20;
        private Button btnRejectCustomer;
        private Button btnSellToCustomer;
        private System.Windows.Forms.Timer timerCustomer;
        private System.Windows.Forms.Timer timeCustomer;
        private Panel panel18;
        private Panel panel13;
        private Label label18;
        private Panel panel14;
        private Panel panel17;
        private Label label7;
        private Panel panel19;
        private Panel panel20;
    }
}
