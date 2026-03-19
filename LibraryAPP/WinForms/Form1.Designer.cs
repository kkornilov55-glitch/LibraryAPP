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
            OrderBook = new TabPage();
            panel12 = new Panel();
            panel11 = new Panel();
            RandomizeBookB = new Button();
            AddBookB = new Button();
            panel10 = new Panel();
            panel8 = new Panel();
            panel7 = new Panel();
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
            titleP = new Panel();
            panel9 = new Panel();
            titleL = new Label();
            MainTC = new TabControl();
            Supples = new TabPage();
            Customers = new TabPage();
            panel20 = new Panel();
            panel21 = new Panel();
            panel22 = new Panel();
            panel23 = new Panel();
            label10 = new Label();
            panel26 = new Panel();
            panel27 = new Panel();
            panel28 = new Panel();
            panel29 = new Panel();
            label11 = new Label();
            panel24 = new Panel();
            label13 = new Label();
            panel25 = new Panel();
            panel17 = new Panel();
            panel16 = new Panel();
            panel15 = new Panel();
            BalanceL = new Label();
            label7 = new Label();
            GenreSelectCB = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            FoundStringTB = new TextBox();
            FoundB = new Button();
            SellBookB = new Button();
            ClearCaseB = new Button();
            panel13 = new Panel();
            panel14 = new Panel();
            panel18 = new Panel();
            panel19 = new Panel();
            StoreTC = new TabControl();
            SearchResultTP = new TabPage();
            SearchedBookGrid = new DataGridView();
            colPriceSearch = new DataGridViewTextBoxColumn();
            colPagesCountSearch = new DataGridViewTextBoxColumn();
            colAuthorSearch = new DataGridViewTextBoxColumn();
            colGenreSearch = new DataGridViewTextBoxColumn();
            colTitleSearch = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            MainTP = new TabPage();
            dataGridView1 = new DataGridView();
            colPrice = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colId = new DataGridViewTextBoxColumn();
            StoreTP = new TabPage();
            OrderBook.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            titleP.SuspendLayout();
            MainTC.SuspendLayout();
            Supples.SuspendLayout();
            Customers.SuspendLayout();
            panel24.SuspendLayout();
            StoreTC.SuspendLayout();
            SearchResultTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SearchedBookGrid).BeginInit();
            MainTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            StoreTP.SuspendLayout();
            SuspendLayout();
            // 
            // OrderBook
            // 
            OrderBook.BackColor = Color.FromArgb(226, 206, 177);
            OrderBook.Controls.Add(panel8);
            OrderBook.Controls.Add(panel7);
            OrderBook.Controls.Add(panel12);
            OrderBook.Controls.Add(panel11);
            OrderBook.Controls.Add(RandomizeBookB);
            OrderBook.Controls.Add(AddBookB);
            OrderBook.Controls.Add(panel10);
            OrderBook.Controls.Add(panel6);
            OrderBook.Controls.Add(panel5);
            OrderBook.Controls.Add(panel4);
            OrderBook.Controls.Add(panel2);
            OrderBook.Controls.Add(panel3);
            OrderBook.Controls.Add(panel1);
            OrderBook.Controls.Add(titleP);
            OrderBook.Location = new Point(4, 24);
            OrderBook.Margin = new Padding(3, 2, 3, 2);
            OrderBook.Name = "OrderBook";
            OrderBook.Padding = new Padding(3, 2, 3, 2);
            OrderBook.Size = new Size(501, 479);
            OrderBook.TabIndex = 0;
            OrderBook.Text = "Заказать книгу";
            // 
            // panel12
            // 
            panel12.BackColor = Color.Silver;
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Location = new Point(7, 380);
            panel12.Margin = new Padding(3, 2, 3, 2);
            panel12.Name = "panel12";
            panel12.Size = new Size(9, 16);
            panel12.TabIndex = 16;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Silver;
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Location = new Point(7, 112);
            panel11.Margin = new Padding(3, 2, 3, 2);
            panel11.Name = "panel11";
            panel11.Size = new Size(9, 221);
            panel11.TabIndex = 15;
            // 
            // RandomizeBookB
            // 
            RandomizeBookB.BackColor = Color.FromArgb(199, 160, 122);
            RandomizeBookB.FlatAppearance.BorderColor = Color.Black;
            RandomizeBookB.FlatStyle = FlatStyle.Flat;
            RandomizeBookB.Font = new Font("Cambria", 14F, FontStyle.Bold);
            RandomizeBookB.ForeColor = Color.FromArgb(57, 30, 16);
            RandomizeBookB.Location = new Point(412, 424);
            RandomizeBookB.Margin = new Padding(3, 2, 3, 2);
            RandomizeBookB.Name = "RandomizeBookB";
            RandomizeBookB.Size = new Size(58, 35);
            RandomizeBookB.TabIndex = 14;
            RandomizeBookB.Text = "🎲";
            RandomizeBookB.TextAlign = ContentAlignment.TopCenter;
            RandomizeBookB.UseVisualStyleBackColor = false;
            // 
            // AddBookB
            // 
            AddBookB.BackColor = Color.Brown;
            AddBookB.FlatAppearance.BorderColor = Color.Black;
            AddBookB.FlatAppearance.BorderSize = 0;
            AddBookB.FlatStyle = FlatStyle.Flat;
            AddBookB.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AddBookB.ForeColor = SystemColors.Control;
            AddBookB.Location = new Point(33, 424);
            AddBookB.Margin = new Padding(3, 2, 3, 2);
            AddBookB.Name = "AddBookB";
            AddBookB.Size = new Size(360, 35);
            AddBookB.TabIndex = 13;
            AddBookB.Text = "СОХРАНИТЬ";
            AddBookB.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Silver;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.ForeColor = SystemColors.ActiveCaption;
            panel10.Location = new Point(3, 0);
            panel10.Margin = new Padding(3, 2, 3, 2);
            panel10.Name = "panel10";
            panel10.Size = new Size(502, 8);
            panel10.TabIndex = 12;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Silver;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.ForeColor = SystemColors.ActiveCaption;
            panel8.Location = new Point(385, 0);
            panel8.Margin = new Padding(3, 2, 3, 2);
            panel8.Name = "panel8";
            panel8.Size = new Size(9, 55);
            panel8.TabIndex = 4;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Silver;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.ForeColor = SystemColors.ActiveCaption;
            panel7.Location = new Point(95, 0);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(9, 55);
            panel7.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(199, 160, 122);
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(PriceTB);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(32, 348);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(438, 49);
            panel6.TabIndex = 10;
            // 
            // PriceTB
            // 
            PriceTB.BackColor = Color.FromArgb(199, 160, 122);
            PriceTB.BorderStyle = BorderStyle.None;
            PriceTB.Cursor = Cursors.IBeam;
            PriceTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PriceTB.Location = new Point(164, 18);
            PriceTB.Margin = new Padding(3, 2, 3, 2);
            PriceTB.Name = "PriceTB";
            PriceTB.Size = new Size(262, 16);
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
            label6.Padding = new Padding(10, 0, 10, 0);
            label6.Size = new Size(151, 47);
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
            panel5.Location = new Point(32, 293);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(438, 49);
            panel5.TabIndex = 9;
            // 
            // PagesCountTB
            // 
            PagesCountTB.BackColor = Color.FromArgb(199, 160, 122);
            PagesCountTB.BorderStyle = BorderStyle.None;
            PagesCountTB.Cursor = Cursors.IBeam;
            PagesCountTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PagesCountTB.Location = new Point(164, 18);
            PagesCountTB.Margin = new Padding(3, 2, 3, 2);
            PagesCountTB.Name = "PagesCountTB";
            PagesCountTB.Size = new Size(262, 16);
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
            label5.Padding = new Padding(10, 0, 10, 0);
            label5.Size = new Size(151, 47);
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
            panel4.Location = new Point(32, 240);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(438, 49);
            panel4.TabIndex = 8;
            // 
            // GenreTB
            // 
            GenreTB.BackColor = Color.FromArgb(199, 160, 122);
            GenreTB.BorderStyle = BorderStyle.None;
            GenreTB.Cursor = Cursors.IBeam;
            GenreTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GenreTB.Location = new Point(164, 18);
            GenreTB.Margin = new Padding(3, 2, 3, 2);
            GenreTB.Name = "GenreTB";
            GenreTB.Size = new Size(262, 16);
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
            label4.Padding = new Padding(10, 0, 10, 0);
            label4.Size = new Size(151, 47);
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
            panel2.Location = new Point(32, 187);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(438, 49);
            panel2.TabIndex = 7;
            // 
            // ID_TB
            // 
            ID_TB.BackColor = Color.FromArgb(199, 160, 122);
            ID_TB.BorderStyle = BorderStyle.None;
            ID_TB.Cursor = Cursors.IBeam;
            ID_TB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ID_TB.Location = new Point(164, 18);
            ID_TB.Margin = new Padding(3, 2, 3, 2);
            ID_TB.Name = "ID_TB";
            ID_TB.ReadOnly = true;
            ID_TB.Size = new Size(262, 16);
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
            label3.Padding = new Padding(10, 0, 10, 0);
            label3.Size = new Size(151, 47);
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
            panel3.Location = new Point(32, 134);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(438, 49);
            panel3.TabIndex = 6;
            // 
            // AuthorTB
            // 
            AuthorTB.BackColor = Color.FromArgb(199, 160, 122);
            AuthorTB.BorderStyle = BorderStyle.None;
            AuthorTB.Cursor = Cursors.IBeam;
            AuthorTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AuthorTB.Location = new Point(164, 18);
            AuthorTB.Margin = new Padding(3, 2, 3, 2);
            AuthorTB.Name = "AuthorTB";
            AuthorTB.Size = new Size(262, 16);
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
            label2.Padding = new Padding(10, 0, 10, 0);
            label2.Size = new Size(151, 47);
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
            panel1.Location = new Point(32, 81);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(438, 49);
            panel1.TabIndex = 1;
            // 
            // TitleTB
            // 
            TitleTB.BackColor = Color.FromArgb(199, 160, 122);
            TitleTB.BorderStyle = BorderStyle.None;
            TitleTB.Cursor = Cursors.IBeam;
            TitleTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TitleTB.Location = new Point(164, 18);
            TitleTB.Margin = new Padding(3, 2, 3, 2);
            TitleTB.Name = "TitleTB";
            TitleTB.Size = new Size(262, 16);
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
            label1.Padding = new Padding(10, 0, 10, 0);
            label1.Size = new Size(151, 47);
            label1.TabIndex = 0;
            label1.Text = "Название";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // titleP
            // 
            titleP.BackColor = Color.FromArgb(172, 199, 221);
            titleP.Controls.Add(panel9);
            titleP.Controls.Add(titleL);
            titleP.Dock = DockStyle.Top;
            titleP.Location = new Point(3, 2);
            titleP.Margin = new Padding(3, 2, 3, 2);
            titleP.Name = "titleP";
            titleP.Size = new Size(495, 52);
            titleP.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Silver;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.ForeColor = SystemColors.ActiveCaption;
            panel9.Location = new Point(-3, 45);
            panel9.Margin = new Padding(3, 2, 3, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(502, 8);
            panel9.TabIndex = 11;
            // 
            // titleL
            // 
            titleL.BackColor = Color.FromArgb(57, 30, 16);
            titleL.Dock = DockStyle.Fill;
            titleL.Font = new Font("Cambria", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            titleL.ForeColor = Color.FromArgb(253, 252, 232);
            titleL.Location = new Point(0, 0);
            titleL.Name = "titleL";
            titleL.Size = new Size(495, 52);
            titleL.TabIndex = 0;
            titleL.Text = "Новая книга";
            titleL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainTC
            // 
            MainTC.Controls.Add(OrderBook);
            MainTC.Controls.Add(StoreTP);
            MainTC.Controls.Add(Supples);
            MainTC.Controls.Add(Customers);
            MainTC.Dock = DockStyle.Fill;
            MainTC.Location = new Point(0, 0);
            MainTC.Margin = new Padding(3, 2, 3, 2);
            MainTC.Name = "MainTC";
            MainTC.SelectedIndex = 0;
            MainTC.Size = new Size(509, 507);
            MainTC.TabIndex = 0;
            MainTC.Visible = false;
            // 
            // Supples
            // 
            Supples.BackColor = Color.FromArgb(226, 206, 177);
            Supples.Controls.Add(panel20);
            Supples.Controls.Add(panel21);
            Supples.Controls.Add(panel23);
            Supples.Controls.Add(panel22);
            Supples.Controls.Add(label10);
            Supples.Location = new Point(4, 24);
            Supples.Name = "Supples";
            Supples.Size = new Size(501, 479);
            Supples.TabIndex = 3;
            Supples.Text = "Поставки";
            // 
            // Customers
            // 
            Customers.BackColor = Color.FromArgb(226, 206, 177);
            Customers.Controls.Add(panel26);
            Customers.Controls.Add(panel27);
            Customers.Controls.Add(panel28);
            Customers.Controls.Add(panel29);
            Customers.Controls.Add(label11);
            Customers.Location = new Point(4, 24);
            Customers.Name = "Customers";
            Customers.Size = new Size(501, 479);
            Customers.TabIndex = 4;
            Customers.Text = "Покупатели";
            // 
            // panel20
            // 
            panel20.BackColor = Color.Silver;
            panel20.BorderStyle = BorderStyle.FixedSingle;
            panel20.ForeColor = SystemColors.ActiveCaption;
            panel20.Location = new Point(385, 0);
            panel20.Margin = new Padding(3, 2, 3, 2);
            panel20.Name = "panel20";
            panel20.Size = new Size(9, 55);
            panel20.TabIndex = 15;
            // 
            // panel21
            // 
            panel21.BackColor = Color.Silver;
            panel21.BorderStyle = BorderStyle.FixedSingle;
            panel21.ForeColor = SystemColors.ActiveCaption;
            panel21.Location = new Point(95, 0);
            panel21.Margin = new Padding(3, 2, 3, 2);
            panel21.Name = "panel21";
            panel21.Size = new Size(9, 55);
            panel21.TabIndex = 14;
            // 
            // panel22
            // 
            panel22.BackColor = Color.Silver;
            panel22.BorderStyle = BorderStyle.FixedSingle;
            panel22.ForeColor = SystemColors.ActiveCaption;
            panel22.Location = new Point(-1, 46);
            panel22.Margin = new Padding(3, 2, 3, 2);
            panel22.Name = "panel22";
            panel22.Size = new Size(502, 8);
            panel22.TabIndex = 16;
            // 
            // panel23
            // 
            panel23.BackColor = Color.Silver;
            panel23.BorderStyle = BorderStyle.FixedSingle;
            panel23.ForeColor = SystemColors.ActiveCaption;
            panel23.Location = new Point(-1, 0);
            panel23.Margin = new Padding(3, 2, 3, 2);
            panel23.Name = "panel23";
            panel23.Size = new Size(502, 8);
            panel23.TabIndex = 17;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(57, 30, 16);
            label10.Font = new Font("Cambria", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label10.ForeColor = Color.FromArgb(253, 252, 232);
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(501, 50);
            label10.TabIndex = 13;
            label10.Text = "Поставки";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel26
            // 
            panel26.BackColor = Color.Silver;
            panel26.BorderStyle = BorderStyle.FixedSingle;
            panel26.ForeColor = SystemColors.ActiveCaption;
            panel26.Location = new Point(385, 0);
            panel26.Margin = new Padding(3, 2, 3, 2);
            panel26.Name = "panel26";
            panel26.Size = new Size(9, 54);
            panel26.TabIndex = 15;
            // 
            // panel27
            // 
            panel27.BackColor = Color.Silver;
            panel27.BorderStyle = BorderStyle.FixedSingle;
            panel27.ForeColor = SystemColors.ActiveCaption;
            panel27.Location = new Point(95, 0);
            panel27.Margin = new Padding(3, 2, 3, 2);
            panel27.Name = "panel27";
            panel27.Size = new Size(9, 54);
            panel27.TabIndex = 14;
            // 
            // panel28
            // 
            panel28.BackColor = Color.Silver;
            panel28.BorderStyle = BorderStyle.FixedSingle;
            panel28.ForeColor = SystemColors.ActiveCaption;
            panel28.Location = new Point(-2, 46);
            panel28.Margin = new Padding(3, 2, 3, 2);
            panel28.Name = "panel28";
            panel28.Size = new Size(502, 8);
            panel28.TabIndex = 16;
            // 
            // panel29
            // 
            panel29.BackColor = Color.Silver;
            panel29.BorderStyle = BorderStyle.FixedSingle;
            panel29.ForeColor = SystemColors.ActiveCaption;
            panel29.Location = new Point(0, 0);
            panel29.Margin = new Padding(3, 2, 3, 2);
            panel29.Name = "panel29";
            panel29.Size = new Size(502, 8);
            panel29.TabIndex = 17;
            // 
            // label11
            // 
            label11.BackColor = Color.FromArgb(57, 30, 16);
            label11.Font = new Font("Cambria", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label11.ForeColor = Color.FromArgb(253, 252, 232);
            label11.Location = new Point(-1, 0);
            label11.Name = "label11";
            label11.Size = new Size(506, 52);
            label11.TabIndex = 13;
            label11.Text = "Покупатели";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel24
            // 
            panel24.BackColor = Color.FromArgb(172, 199, 221);
            panel24.Controls.Add(panel25);
            panel24.Controls.Add(label13);
            panel24.Dock = DockStyle.Top;
            panel24.Location = new Point(3, 2);
            panel24.Margin = new Padding(3, 2, 3, 2);
            panel24.Name = "panel24";
            panel24.Size = new Size(495, 52);
            panel24.TabIndex = 0;
            // 
            // label13
            // 
            label13.BackColor = Color.FromArgb(57, 30, 16);
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Cambria", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label13.ForeColor = Color.FromArgb(253, 252, 232);
            label13.Location = new Point(0, 0);
            label13.Name = "label13";
            label13.Size = new Size(495, 52);
            label13.TabIndex = 0;
            label13.Text = "Магазин";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel25
            // 
            panel25.BackColor = Color.Silver;
            panel25.BorderStyle = BorderStyle.FixedSingle;
            panel25.ForeColor = SystemColors.ActiveCaption;
            panel25.Location = new Point(-3, 45);
            panel25.Margin = new Padding(3, 2, 3, 2);
            panel25.Name = "panel25";
            panel25.Size = new Size(502, 10);
            panel25.TabIndex = 11;
            // 
            // panel17
            // 
            panel17.BackColor = Color.Silver;
            panel17.BorderStyle = BorderStyle.FixedSingle;
            panel17.ForeColor = SystemColors.ActiveCaption;
            panel17.Location = new Point(95, 0);
            panel17.Margin = new Padding(3, 2, 3, 2);
            panel17.Name = "panel17";
            panel17.Size = new Size(9, 55);
            panel17.TabIndex = 3;
            // 
            // panel16
            // 
            panel16.BackColor = Color.Silver;
            panel16.BorderStyle = BorderStyle.FixedSingle;
            panel16.ForeColor = SystemColors.ActiveCaption;
            panel16.Location = new Point(385, 0);
            panel16.Margin = new Padding(3, 2, 3, 2);
            panel16.Name = "panel16";
            panel16.Size = new Size(9, 55);
            panel16.TabIndex = 4;
            // 
            // panel15
            // 
            panel15.BackColor = Color.Silver;
            panel15.BorderStyle = BorderStyle.FixedSingle;
            panel15.ForeColor = SystemColors.ActiveCaption;
            panel15.Location = new Point(3, 0);
            panel15.Margin = new Padding(3, 2, 3, 2);
            panel15.Name = "panel15";
            panel15.Size = new Size(502, 8);
            panel15.TabIndex = 12;
            // 
            // BalanceL
            // 
            BalanceL.BackColor = Color.White;
            BalanceL.Location = new Point(66, 95);
            BalanceL.Name = "BalanceL";
            BalanceL.Size = new Size(88, 21);
            BalanceL.TabIndex = 12;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Cambria", 13.8F, FontStyle.Bold);
            label7.ImageAlign = ContentAlignment.MiddleLeft;
            label7.Location = new Point(63, 68);
            label7.Name = "label7";
            label7.Size = new Size(88, 22);
            label7.TabIndex = 13;
            label7.Text = "Баланс:";
            // 
            // GenreSelectCB
            // 
            GenreSelectCB.FormattingEnabled = true;
            GenreSelectCB.Location = new Point(305, 95);
            GenreSelectCB.Margin = new Padding(3, 2, 3, 2);
            GenreSelectCB.Name = "GenreSelectCB";
            GenreSelectCB.Size = new Size(133, 23);
            GenreSelectCB.TabIndex = 14;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Cambria", 13.8F, FontStyle.Bold);
            label8.ImageAlign = ContentAlignment.MiddleLeft;
            label8.Location = new Point(305, 68);
            label8.Name = "label8";
            label8.Size = new Size(88, 22);
            label8.TabIndex = 15;
            label8.Text = "Жанр:";
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Cambria", 13.8F, FontStyle.Bold);
            label9.ImageAlign = ContentAlignment.MiddleLeft;
            label9.Location = new Point(66, 359);
            label9.Name = "label9";
            label9.Size = new Size(74, 22);
            label9.TabIndex = 17;
            label9.Text = "Поиск";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FoundStringTB
            // 
            FoundStringTB.Location = new Point(140, 359);
            FoundStringTB.Margin = new Padding(3, 2, 3, 2);
            FoundStringTB.Name = "FoundStringTB";
            FoundStringTB.Size = new Size(300, 23);
            FoundStringTB.TabIndex = 18;
            // 
            // FoundB
            // 
            FoundB.BackColor = Color.Brown;
            FoundB.FlatAppearance.BorderColor = Color.Black;
            FoundB.FlatStyle = FlatStyle.Flat;
            FoundB.Font = new Font("Cambria", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FoundB.ForeColor = SystemColors.ButtonHighlight;
            FoundB.Location = new Point(66, 392);
            FoundB.Margin = new Padding(3, 2, 3, 2);
            FoundB.Name = "FoundB";
            FoundB.Size = new Size(372, 37);
            FoundB.TabIndex = 19;
            FoundB.Text = "НАЙТИ!";
            FoundB.UseVisualStyleBackColor = false;
            // 
            // SellBookB
            // 
            SellBookB.BackColor = Color.FromArgb(199, 160, 122);
            SellBookB.FlatAppearance.BorderColor = Color.Black;
            SellBookB.FlatStyle = FlatStyle.Flat;
            SellBookB.Font = new Font("Cambria", 11F);
            SellBookB.Location = new Point(66, 433);
            SellBookB.Margin = new Padding(3, 2, 3, 2);
            SellBookB.Name = "SellBookB";
            SellBookB.Size = new Size(183, 26);
            SellBookB.TabIndex = 20;
            SellBookB.Text = "Продать";
            SellBookB.UseVisualStyleBackColor = false;
            // 
            // ClearCaseB
            // 
            ClearCaseB.BackColor = Color.FromArgb(199, 160, 122);
            ClearCaseB.FlatAppearance.BorderColor = Color.Black;
            ClearCaseB.FlatStyle = FlatStyle.Flat;
            ClearCaseB.Font = new Font("Cambria", 11F);
            ClearCaseB.Location = new Point(255, 433);
            ClearCaseB.Margin = new Padding(3, 2, 3, 2);
            ClearCaseB.Name = "ClearCaseB";
            ClearCaseB.Size = new Size(183, 26);
            ClearCaseB.TabIndex = 21;
            ClearCaseB.Text = "Очистить шкаф";
            ClearCaseB.UseVisualStyleBackColor = false;
            // 
            // panel13
            // 
            panel13.BackColor = Color.Silver;
            panel13.BorderStyle = BorderStyle.FixedSingle;
            panel13.Location = new Point(29, 90);
            panel13.Margin = new Padding(3, 2, 3, 2);
            panel13.Name = "panel13";
            panel13.Size = new Size(9, 256);
            panel13.TabIndex = 22;
            // 
            // panel14
            // 
            panel14.BackColor = Color.Silver;
            panel14.BorderStyle = BorderStyle.FixedSingle;
            panel14.Location = new Point(467, 90);
            panel14.Margin = new Padding(3, 2, 3, 2);
            panel14.Name = "panel14";
            panel14.Size = new Size(9, 256);
            panel14.TabIndex = 23;
            // 
            // panel18
            // 
            panel18.BackColor = Color.Silver;
            panel18.BorderStyle = BorderStyle.FixedSingle;
            panel18.Location = new Point(29, 385);
            panel18.Margin = new Padding(3, 2, 3, 2);
            panel18.Name = "panel18";
            panel18.Size = new Size(9, 44);
            panel18.TabIndex = 24;
            // 
            // panel19
            // 
            panel19.BackColor = Color.Silver;
            panel19.BorderStyle = BorderStyle.FixedSingle;
            panel19.Location = new Point(467, 385);
            panel19.Margin = new Padding(3, 2, 3, 2);
            panel19.Name = "panel19";
            panel19.Size = new Size(9, 44);
            panel19.TabIndex = 25;
            // 
            // StoreTC
            // 
            StoreTC.Controls.Add(MainTP);
            StoreTC.Controls.Add(SearchResultTP);
            StoreTC.Location = new Point(66, 121);
            StoreTC.Margin = new Padding(3, 2, 3, 2);
            StoreTC.Name = "StoreTC";
            StoreTC.SelectedIndex = 0;
            StoreTC.Size = new Size(372, 225);
            StoreTC.TabIndex = 26;
            // 
            // SearchResultTP
            // 
            SearchResultTP.Controls.Add(SearchedBookGrid);
            SearchResultTP.Location = new Point(4, 24);
            SearchResultTP.Margin = new Padding(3, 2, 3, 2);
            SearchResultTP.Name = "SearchResultTP";
            SearchResultTP.Padding = new Padding(3, 2, 3, 2);
            SearchResultTP.Size = new Size(364, 197);
            SearchResultTP.TabIndex = 1;
            SearchResultTP.Text = "Результаты поиска";
            SearchResultTP.UseVisualStyleBackColor = true;
            // 
            // SearchedBookGrid
            // 
            SearchedBookGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SearchedBookGrid.Columns.AddRange(new DataGridViewColumn[] { ID, colTitleSearch, colGenreSearch, colAuthorSearch, colPagesCountSearch, colPriceSearch });
            SearchedBookGrid.Dock = DockStyle.Fill;
            SearchedBookGrid.Location = new Point(3, 2);
            SearchedBookGrid.Margin = new Padding(3, 2, 3, 2);
            SearchedBookGrid.Name = "SearchedBookGrid";
            SearchedBookGrid.RowHeadersWidth = 51;
            SearchedBookGrid.Size = new Size(358, 193);
            SearchedBookGrid.TabIndex = 0;
            // 
            // colPriceSearch
            // 
            colPriceSearch.HeaderText = "Цена";
            colPriceSearch.MinimumWidth = 6;
            colPriceSearch.Name = "colPriceSearch";
            colPriceSearch.ReadOnly = true;
            colPriceSearch.Width = 125;
            // 
            // colPagesCountSearch
            // 
            colPagesCountSearch.HeaderText = "Количество страниц";
            colPagesCountSearch.MinimumWidth = 6;
            colPagesCountSearch.Name = "colPagesCountSearch";
            colPagesCountSearch.ReadOnly = true;
            colPagesCountSearch.Width = 125;
            // 
            // colAuthorSearch
            // 
            colAuthorSearch.HeaderText = "Автор";
            colAuthorSearch.MinimumWidth = 6;
            colAuthorSearch.Name = "colAuthorSearch";
            colAuthorSearch.ReadOnly = true;
            colAuthorSearch.Width = 125;
            // 
            // colGenreSearch
            // 
            colGenreSearch.HeaderText = "Жанр";
            colGenreSearch.MinimumWidth = 6;
            colGenreSearch.Name = "colGenreSearch";
            colGenreSearch.ReadOnly = true;
            colGenreSearch.Width = 125;
            // 
            // colTitleSearch
            // 
            colTitleSearch.HeaderText = "Название";
            colTitleSearch.MinimumWidth = 6;
            colTitleSearch.Name = "colTitleSearch";
            colTitleSearch.ReadOnly = true;
            colTitleSearch.Width = 125;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 125;
            // 
            // MainTP
            // 
            MainTP.Controls.Add(dataGridView1);
            MainTP.Location = new Point(4, 24);
            MainTP.Margin = new Padding(3, 2, 3, 2);
            MainTP.Name = "MainTP";
            MainTP.Padding = new Padding(3, 2, 3, 2);
            MainTP.Size = new Size(364, 197);
            MainTP.TabIndex = 0;
            MainTP.Text = "Главная";
            MainTP.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colId, colTitle, colAuthor, colPrice });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 2);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(358, 193);
            dataGridView1.TabIndex = 16;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Цена";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 125;
            // 
            // colAuthor
            // 
            colAuthor.HeaderText = "Автор";
            colAuthor.MinimumWidth = 6;
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            colAuthor.Width = 125;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Название";
            colTitle.MinimumWidth = 6;
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            colTitle.Width = 125;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 125;
            // 
            // StoreTP
            // 
            StoreTP.BackColor = Color.FromArgb(226, 206, 177);
            StoreTP.Controls.Add(panel16);
            StoreTP.Controls.Add(panel17);
            StoreTP.Controls.Add(StoreTC);
            StoreTP.Controls.Add(panel19);
            StoreTP.Controls.Add(panel18);
            StoreTP.Controls.Add(panel14);
            StoreTP.Controls.Add(panel13);
            StoreTP.Controls.Add(ClearCaseB);
            StoreTP.Controls.Add(SellBookB);
            StoreTP.Controls.Add(FoundB);
            StoreTP.Controls.Add(FoundStringTB);
            StoreTP.Controls.Add(label9);
            StoreTP.Controls.Add(label8);
            StoreTP.Controls.Add(GenreSelectCB);
            StoreTP.Controls.Add(label7);
            StoreTP.Controls.Add(BalanceL);
            StoreTP.Controls.Add(panel15);
            StoreTP.Controls.Add(panel24);
            StoreTP.Location = new Point(4, 24);
            StoreTP.Margin = new Padding(3, 2, 3, 2);
            StoreTP.Name = "StoreTP";
            StoreTP.Padding = new Padding(3, 2, 3, 2);
            StoreTP.Size = new Size(501, 479);
            StoreTP.TabIndex = 2;
            StoreTP.Text = "Магазин";
            // 
            // BookStoreF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 507);
            Controls.Add(MainTC);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "BookStoreF";
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
            titleP.ResumeLayout(false);
            MainTC.ResumeLayout(false);
            Supples.ResumeLayout(false);
            Customers.ResumeLayout(false);
            panel24.ResumeLayout(false);
            StoreTC.ResumeLayout(false);
            SearchResultTP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SearchedBookGrid).EndInit();
            MainTP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            StoreTP.ResumeLayout(false);
            StoreTP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabPage OrderBook;
        private Panel panel12;
        private Panel panel11;
        private Button RandomizeBookB;
        private Button AddBookB;
        private Panel panel10;
        private Panel panel8;
        private Panel panel7;
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
        private Panel titleP;
        private Panel panel9;
        private Label titleL;
        private TabControl MainTC;
        private TabPage Supples;
        private Panel panel20;
        private Panel panel21;
        private Panel panel22;
        private Panel panel23;
        private Label label10;
        private TabPage Customers;
        private Panel panel26;
        private Panel panel27;
        private Panel panel28;
        private Panel panel29;
        private Label label11;
        private TabPage StoreTP;
        private Panel panel16;
        private Panel panel17;
        private TabControl StoreTC;
        private TabPage MainTP;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colPrice;
        private TabPage SearchResultTP;
        private DataGridView SearchedBookGrid;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn colTitleSearch;
        private DataGridViewTextBoxColumn colGenreSearch;
        private DataGridViewTextBoxColumn colAuthorSearch;
        private DataGridViewTextBoxColumn colPagesCountSearch;
        private DataGridViewTextBoxColumn colPriceSearch;
        private Panel panel19;
        private Panel panel18;
        private Panel panel14;
        private Panel panel13;
        private Button ClearCaseB;
        private Button SellBookB;
        private Button FoundB;
        private TextBox FoundStringTB;
        private Label label9;
        private Label label8;
        private ComboBox GenreSelectCB;
        private Label label7;
        private Label BalanceL;
        private Panel panel15;
        private Panel panel24;
        private Panel panel25;
        private Label label13;
    }
}
