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
            StoreTP = new TabPage();
            StoreTC = new TabControl();
            MainTP = new TabPage();
            dataGridView1 = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            SearchResultTP = new TabPage();
            panel19 = new Panel();
            panel18 = new Panel();
            panel14 = new Panel();
            panel13 = new Panel();
            ClearCaseB = new Button();
            SellBookB = new Button();
            FoundB = new Button();
            FoundStringTB = new TextBox();
            label9 = new Label();
            label8 = new Label();
            GenreSelectCB = new ComboBox();
            label7 = new Label();
            BalanceL = new Label();
            panel15 = new Panel();
            panel16 = new Panel();
            panel17 = new Panel();
            panel24 = new Panel();
            panel25 = new Panel();
            label13 = new Label();
            tabPage1 = new TabPage();
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
            dataGridView2 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            colTitleSearch = new DataGridViewTextBoxColumn();
            colGenreSearch = new DataGridViewTextBoxColumn();
            colAuthorSearch = new DataGridViewTextBoxColumn();
            PagesCountSearch = new DataGridViewTextBoxColumn();
            colPriceSearch = new DataGridViewTextBoxColumn();
            StoreTP.SuspendLayout();
            StoreTC.SuspendLayout();
            MainTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SearchResultTP.SuspendLayout();
            panel24.SuspendLayout();
            tabPage1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            titleP.SuspendLayout();
            MainTC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // StoreTP
            // 
            StoreTP.BackColor = Color.FromArgb(226, 206, 177);
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
            StoreTP.Controls.Add(panel16);
            StoreTP.Controls.Add(panel17);
            StoreTP.Controls.Add(panel24);
            StoreTP.Location = new Point(4, 29);
            StoreTP.Name = "StoreTP";
            StoreTP.Padding = new Padding(3);
            StoreTP.Size = new Size(574, 643);
            StoreTP.TabIndex = 2;
            StoreTP.Text = "Магазин";
            // 
            // StoreTC
            // 
            StoreTC.Controls.Add(MainTP);
            StoreTC.Controls.Add(SearchResultTP);
            StoreTC.Location = new Point(75, 161);
            StoreTC.Name = "StoreTC";
            StoreTC.SelectedIndex = 0;
            StoreTC.Size = new Size(425, 300);
            StoreTC.TabIndex = 26;
            // 
            // MainTP
            // 
            MainTP.Controls.Add(dataGridView1);
            MainTP.Location = new Point(4, 29);
            MainTP.Name = "MainTP";
            MainTP.Padding = new Padding(3);
            MainTP.Size = new Size(417, 267);
            MainTP.TabIndex = 0;
            MainTP.Text = "Главная";
            MainTP.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colId, colTitle, colAuthor, colPrice });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(411, 261);
            dataGridView1.TabIndex = 16;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.Visible = false;
            colId.Width = 125;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Название";
            colTitle.MinimumWidth = 6;
            colTitle.Name = "colTitle";
            colTitle.Width = 125;
            // 
            // colAuthor
            // 
            colAuthor.HeaderText = "Автор";
            colAuthor.MinimumWidth = 6;
            colAuthor.Name = "colAuthor";
            colAuthor.Width = 125;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Цена";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.Width = 125;
            // 
            // SearchResultTP
            // 
            SearchResultTP.Controls.Add(dataGridView2);
            SearchResultTP.Location = new Point(4, 29);
            SearchResultTP.Name = "SearchResultTP";
            SearchResultTP.Padding = new Padding(3);
            SearchResultTP.Size = new Size(417, 267);
            SearchResultTP.TabIndex = 1;
            SearchResultTP.Text = "Результаты поиска";
            SearchResultTP.UseVisualStyleBackColor = true;
            // 
            // panel19
            // 
            panel19.BackColor = Color.Silver;
            panel19.BorderStyle = BorderStyle.FixedSingle;
            panel19.Location = new Point(534, 513);
            panel19.Name = "panel19";
            panel19.Size = new Size(10, 58);
            panel19.TabIndex = 25;
            // 
            // panel18
            // 
            panel18.BackColor = Color.Silver;
            panel18.BorderStyle = BorderStyle.FixedSingle;
            panel18.Location = new Point(33, 513);
            panel18.Name = "panel18";
            panel18.Size = new Size(10, 58);
            panel18.TabIndex = 24;
            // 
            // panel14
            // 
            panel14.BackColor = Color.Silver;
            panel14.BorderStyle = BorderStyle.FixedSingle;
            panel14.Location = new Point(534, 120);
            panel14.Name = "panel14";
            panel14.Size = new Size(10, 341);
            panel14.TabIndex = 23;
            // 
            // panel13
            // 
            panel13.BackColor = Color.Silver;
            panel13.BorderStyle = BorderStyle.FixedSingle;
            panel13.Location = new Point(33, 120);
            panel13.Name = "panel13";
            panel13.Size = new Size(10, 341);
            panel13.TabIndex = 22;
            // 
            // ClearCaseB
            // 
            ClearCaseB.BackColor = Color.FromArgb(199, 160, 122);
            ClearCaseB.FlatAppearance.BorderColor = Color.Black;
            ClearCaseB.FlatStyle = FlatStyle.Flat;
            ClearCaseB.Font = new Font("Cambria", 11F);
            ClearCaseB.Location = new Point(291, 577);
            ClearCaseB.Name = "ClearCaseB";
            ClearCaseB.Size = new Size(209, 35);
            ClearCaseB.TabIndex = 21;
            ClearCaseB.Text = "Очистить шкаф";
            ClearCaseB.UseVisualStyleBackColor = false;
            // 
            // SellBookB
            // 
            SellBookB.BackColor = Color.FromArgb(199, 160, 122);
            SellBookB.FlatAppearance.BorderColor = Color.Black;
            SellBookB.FlatStyle = FlatStyle.Flat;
            SellBookB.Font = new Font("Cambria", 11F);
            SellBookB.Location = new Point(75, 577);
            SellBookB.Name = "SellBookB";
            SellBookB.Size = new Size(209, 35);
            SellBookB.TabIndex = 20;
            SellBookB.Text = "Продать";
            SellBookB.UseVisualStyleBackColor = false;
            // 
            // FoundB
            // 
            FoundB.BackColor = Color.Brown;
            FoundB.FlatAppearance.BorderColor = Color.Black;
            FoundB.FlatStyle = FlatStyle.Flat;
            FoundB.Font = new Font("Cambria", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FoundB.ForeColor = SystemColors.ButtonHighlight;
            FoundB.Location = new Point(75, 523);
            FoundB.Name = "FoundB";
            FoundB.Size = new Size(425, 49);
            FoundB.TabIndex = 19;
            FoundB.Text = "НАЙТИ!";
            FoundB.UseVisualStyleBackColor = false;
            // 
            // FoundStringTB
            // 
            FoundStringTB.Location = new Point(160, 479);
            FoundStringTB.Name = "FoundStringTB";
            FoundStringTB.Size = new Size(342, 27);
            FoundStringTB.TabIndex = 18;
            FoundStringTB.TextChanged += textBox1_TextChanged;
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Cambria", 13.8F, FontStyle.Bold);
            label9.ImageAlign = ContentAlignment.MiddleLeft;
            label9.Location = new Point(75, 479);
            label9.Name = "label9";
            label9.Size = new Size(84, 29);
            label9.TabIndex = 17;
            label9.Text = "Поиск";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Cambria", 13.8F, FontStyle.Bold);
            label8.ImageAlign = ContentAlignment.MiddleLeft;
            label8.Location = new Point(349, 91);
            label8.Name = "label8";
            label8.Size = new Size(101, 29);
            label8.TabIndex = 15;
            label8.Text = "Жанр:";
            // 
            // GenreSelectCB
            // 
            GenreSelectCB.FormattingEnabled = true;
            GenreSelectCB.Location = new Point(349, 127);
            GenreSelectCB.Name = "GenreSelectCB";
            GenreSelectCB.Size = new Size(151, 28);
            GenreSelectCB.TabIndex = 14;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Cambria", 13.8F, FontStyle.Bold);
            label7.ImageAlign = ContentAlignment.MiddleLeft;
            label7.Location = new Point(72, 91);
            label7.Name = "label7";
            label7.Size = new Size(101, 29);
            label7.TabIndex = 13;
            label7.Text = "Баланс:";
            // 
            // BalanceL
            // 
            BalanceL.BackColor = Color.White;
            BalanceL.Location = new Point(75, 127);
            BalanceL.Name = "BalanceL";
            BalanceL.Size = new Size(101, 28);
            BalanceL.TabIndex = 12;
            // 
            // panel15
            // 
            panel15.BackColor = Color.Silver;
            panel15.BorderStyle = BorderStyle.FixedSingle;
            panel15.ForeColor = SystemColors.ActiveCaption;
            panel15.Location = new Point(3, 0);
            panel15.Name = "panel15";
            panel15.Size = new Size(573, 10);
            panel15.TabIndex = 12;
            // 
            // panel16
            // 
            panel16.BackColor = Color.Silver;
            panel16.BorderStyle = BorderStyle.FixedSingle;
            panel16.ForeColor = SystemColors.ActiveCaption;
            panel16.Location = new Point(440, 0);
            panel16.Name = "panel16";
            panel16.Size = new Size(10, 73);
            panel16.TabIndex = 4;
            // 
            // panel17
            // 
            panel17.BackColor = Color.Silver;
            panel17.BorderStyle = BorderStyle.FixedSingle;
            panel17.ForeColor = SystemColors.ActiveCaption;
            panel17.Location = new Point(109, 0);
            panel17.Name = "panel17";
            panel17.Size = new Size(10, 73);
            panel17.TabIndex = 3;
            // 
            // panel24
            // 
            panel24.BackColor = Color.FromArgb(172, 199, 221);
            panel24.Controls.Add(panel25);
            panel24.Controls.Add(label13);
            panel24.Dock = DockStyle.Top;
            panel24.Location = new Point(3, 3);
            panel24.Name = "panel24";
            panel24.Size = new Size(568, 69);
            panel24.TabIndex = 0;
            // 
            // panel25
            // 
            panel25.BackColor = Color.Silver;
            panel25.BorderStyle = BorderStyle.FixedSingle;
            panel25.ForeColor = SystemColors.ActiveCaption;
            panel25.Location = new Point(-3, 60);
            panel25.Name = "panel25";
            panel25.Size = new Size(573, 10);
            panel25.TabIndex = 11;
            // 
            // label13
            // 
            label13.BackColor = Color.FromArgb(57, 30, 16);
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Cambria", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label13.ForeColor = Color.FromArgb(253, 252, 232);
            label13.Location = new Point(0, 0);
            label13.Name = "label13";
            label13.Size = new Size(568, 69);
            label13.TabIndex = 0;
            label13.Text = "Магазин";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(226, 206, 177);
            tabPage1.Controls.Add(panel12);
            tabPage1.Controls.Add(panel11);
            tabPage1.Controls.Add(RandomizeBookB);
            tabPage1.Controls.Add(AddBookB);
            tabPage1.Controls.Add(panel10);
            tabPage1.Controls.Add(panel8);
            tabPage1.Controls.Add(panel7);
            tabPage1.Controls.Add(panel6);
            tabPage1.Controls.Add(panel5);
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel3);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(titleP);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(574, 643);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Новая книга";
            // 
            // panel12
            // 
            panel12.BackColor = Color.Silver;
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Location = new Point(8, 507);
            panel12.Name = "panel12";
            panel12.Size = new Size(10, 21);
            panel12.TabIndex = 16;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Silver;
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Location = new Point(8, 149);
            panel11.Name = "panel11";
            panel11.Size = new Size(10, 294);
            panel11.TabIndex = 15;
            // 
            // RandomizeBookB
            // 
            RandomizeBookB.BackColor = Color.FromArgb(199, 160, 122);
            RandomizeBookB.FlatAppearance.BorderColor = Color.Black;
            RandomizeBookB.FlatStyle = FlatStyle.Flat;
            RandomizeBookB.Font = new Font("Cambria", 14F, FontStyle.Bold);
            RandomizeBookB.ForeColor = Color.FromArgb(57, 30, 16);
            RandomizeBookB.Location = new Point(471, 565);
            RandomizeBookB.Name = "RandomizeBookB";
            RandomizeBookB.Size = new Size(66, 47);
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
            AddBookB.Location = new Point(38, 565);
            AddBookB.Name = "AddBookB";
            AddBookB.Size = new Size(411, 47);
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
            panel10.Name = "panel10";
            panel10.Size = new Size(573, 10);
            panel10.TabIndex = 12;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Silver;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.ForeColor = SystemColors.ActiveCaption;
            panel8.Location = new Point(440, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(10, 73);
            panel8.TabIndex = 4;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Silver;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.ForeColor = SystemColors.ActiveCaption;
            panel7.Location = new Point(109, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(10, 73);
            panel7.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(199, 160, 122);
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(PriceTB);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(37, 464);
            panel6.Name = "panel6";
            panel6.Size = new Size(500, 65);
            panel6.TabIndex = 10;
            // 
            // PriceTB
            // 
            PriceTB.BackColor = Color.FromArgb(199, 160, 122);
            PriceTB.BorderStyle = BorderStyle.None;
            PriceTB.Cursor = Cursors.IBeam;
            PriceTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PriceTB.Location = new Point(187, 24);
            PriceTB.Name = "PriceTB";
            PriceTB.Size = new Size(299, 20);
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
            label6.Size = new Size(173, 63);
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
            panel5.Location = new Point(37, 391);
            panel5.Name = "panel5";
            panel5.Size = new Size(500, 65);
            panel5.TabIndex = 9;
            // 
            // PagesCountTB
            // 
            PagesCountTB.BackColor = Color.FromArgb(199, 160, 122);
            PagesCountTB.BorderStyle = BorderStyle.None;
            PagesCountTB.Cursor = Cursors.IBeam;
            PagesCountTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PagesCountTB.Location = new Point(187, 24);
            PagesCountTB.Name = "PagesCountTB";
            PagesCountTB.Size = new Size(299, 20);
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
            label5.Size = new Size(173, 63);
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
            panel4.Location = new Point(37, 320);
            panel4.Name = "panel4";
            panel4.Size = new Size(500, 65);
            panel4.TabIndex = 8;
            // 
            // GenreTB
            // 
            GenreTB.BackColor = Color.FromArgb(199, 160, 122);
            GenreTB.BorderStyle = BorderStyle.None;
            GenreTB.Cursor = Cursors.IBeam;
            GenreTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GenreTB.Location = new Point(187, 24);
            GenreTB.Name = "GenreTB";
            GenreTB.Size = new Size(299, 20);
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
            label4.Size = new Size(173, 63);
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
            panel2.Location = new Point(37, 249);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 65);
            panel2.TabIndex = 7;
            // 
            // ID_TB
            // 
            ID_TB.BackColor = Color.FromArgb(199, 160, 122);
            ID_TB.BorderStyle = BorderStyle.None;
            ID_TB.Cursor = Cursors.IBeam;
            ID_TB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ID_TB.Location = new Point(187, 24);
            ID_TB.Name = "ID_TB";
            ID_TB.ReadOnly = true;
            ID_TB.Size = new Size(299, 20);
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
            label3.Size = new Size(173, 63);
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
            panel3.Location = new Point(37, 179);
            panel3.Name = "panel3";
            panel3.Size = new Size(500, 65);
            panel3.TabIndex = 6;
            // 
            // AuthorTB
            // 
            AuthorTB.BackColor = Color.FromArgb(199, 160, 122);
            AuthorTB.BorderStyle = BorderStyle.None;
            AuthorTB.Cursor = Cursors.IBeam;
            AuthorTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AuthorTB.Location = new Point(187, 24);
            AuthorTB.Name = "AuthorTB";
            AuthorTB.Size = new Size(299, 20);
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
            label2.Size = new Size(173, 63);
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
            panel1.Location = new Point(37, 108);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 65);
            panel1.TabIndex = 1;
            // 
            // TitleTB
            // 
            TitleTB.BackColor = Color.FromArgb(199, 160, 122);
            TitleTB.BorderStyle = BorderStyle.None;
            TitleTB.Cursor = Cursors.IBeam;
            TitleTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TitleTB.Location = new Point(187, 24);
            TitleTB.Name = "TitleTB";
            TitleTB.Size = new Size(299, 20);
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
            label1.Size = new Size(173, 63);
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
            titleP.Location = new Point(3, 3);
            titleP.Name = "titleP";
            titleP.Size = new Size(568, 69);
            titleP.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Silver;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.ForeColor = SystemColors.ActiveCaption;
            panel9.Location = new Point(-3, 60);
            panel9.Name = "panel9";
            panel9.Size = new Size(573, 10);
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
            titleL.Size = new Size(568, 69);
            titleL.TabIndex = 0;
            titleL.Text = "Новая книга";
            titleL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainTC
            // 
            MainTC.Controls.Add(tabPage1);
            MainTC.Controls.Add(StoreTP);
            MainTC.Dock = DockStyle.Fill;
            MainTC.Location = new Point(0, 0);
            MainTC.Name = "MainTC";
            MainTC.SelectedIndex = 0;
            MainTC.Size = new Size(582, 676);
            MainTC.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { ID, colTitleSearch, colGenreSearch, colAuthorSearch, PagesCountSearch, colPriceSearch });
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(411, 261);
            dataGridView2.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 125;
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
            // PagesCountSearch
            // 
            PagesCountSearch.HeaderText = "Количество страниц";
            PagesCountSearch.MinimumWidth = 6;
            PagesCountSearch.Name = "PagesCountSearch";
            PagesCountSearch.ReadOnly = true;
            PagesCountSearch.Width = 125;
            // 
            // colPriceSearch
            // 
            colPriceSearch.HeaderText = "Цена";
            colPriceSearch.MinimumWidth = 6;
            colPriceSearch.Name = "colPriceSearch";
            colPriceSearch.ReadOnly = true;
            colPriceSearch.Width = 125;
            // 
            // BookStoreF
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 676);
            Controls.Add(MainTC);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "BookStoreF";
            Text = "Книжный Магазин";
            StoreTP.ResumeLayout(false);
            StoreTP.PerformLayout();
            StoreTC.ResumeLayout(false);
            MainTP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            SearchResultTP.ResumeLayout(false);
            panel24.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabPage StoreTP;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
        private Panel panel24;
        private Panel panel25;
        private Label label13;
        private TabPage tabPage1;
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
        private Label label7;
        private Label BalanceL;
        private Label label8;
        private ComboBox GenreSelectCB;
        private DataGridView dataGridView1;
        private Label label9;
        private TextBox FoundStringTB;
        private Button FoundB;
        private Button ClearCaseB;
        private Button SellBookB;
        private Panel panel14;
        private Panel panel13;
        private Panel panel19;
        private Panel panel18;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colPrice;
        private TabControl StoreTC;
        private TabPage MainTP;
        private TabPage SearchResultTP;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn colTitleSearch;
        private DataGridViewTextBoxColumn colAuthorSearch;
        private DataGridViewTextBoxColumn PagesCountSearch;
        private DataGridViewTextBoxColumn colPriceSearch;
        private DataGridViewTextBoxColumn colGenreSearch;
    }
}
