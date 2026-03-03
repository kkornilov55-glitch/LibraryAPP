namespace WinForms
{
    partial class Form1
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
            MainTC = new TabControl();
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
            tabPage2 = new TabPage();
            MainTC.SuspendLayout();
            tabPage1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            titleP.SuspendLayout();
            SuspendLayout();
            // 
            // MainTC
            // 
            MainTC.Controls.Add(tabPage1);
            MainTC.Controls.Add(tabPage2);
            MainTC.Dock = DockStyle.Fill;
            MainTC.Location = new Point(0, 0);
            MainTC.Name = "MainTC";
            MainTC.SelectedIndex = 0;
            MainTC.Size = new Size(582, 653);
            MainTC.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(221, 194, 172);
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
            tabPage1.Size = new Size(574, 620);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Новая книга";
            // 
            // panel12
            // 
            panel12.BackColor = Color.Silver;
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Location = new Point(8, 507);
            panel12.Name = "panel12";
            panel12.Size = new Size(10, 20);
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
            RandomizeBookB.BackColor = Color.FromArgb(172, 199, 221);
            RandomizeBookB.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            RandomizeBookB.Location = new Point(484, 565);
            RandomizeBookB.Name = "RandomizeBookB";
            RandomizeBookB.Size = new Size(53, 36);
            RandomizeBookB.TabIndex = 14;
            RandomizeBookB.Text = "RND";
            RandomizeBookB.UseVisualStyleBackColor = false;
            // 
            // AddBookB
            // 
            AddBookB.BackColor = Color.FromArgb(172, 199, 221);
            AddBookB.Font = new Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AddBookB.Location = new Point(38, 565);
            AddBookB.Name = "AddBookB";
            AddBookB.Size = new Size(412, 36);
            AddBookB.TabIndex = 13;
            AddBookB.Text = "Сохранить";
            AddBookB.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Silver;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.ForeColor = SystemColors.ActiveCaption;
            panel10.Location = new Point(3, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(574, 10);
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
            panel6.BackColor = Color.FromArgb(207, 171, 143);
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(PriceTB);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(37, 482);
            panel6.Name = "panel6";
            panel6.Size = new Size(500, 65);
            panel6.TabIndex = 10;
            // 
            // PriceTB
            // 
            PriceTB.BackColor = Color.FromArgb(207, 171, 143);
            PriceTB.BorderStyle = BorderStyle.None;
            PriceTB.Cursor = Cursors.IBeam;
            PriceTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PriceTB.Location = new Point(158, 24);
            PriceTB.Name = "PriceTB";
            PriceTB.Size = new Size(321, 20);
            PriceTB.TabIndex = 1;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(152, 63);
            label6.TabIndex = 0;
            label6.Text = "Цена";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(207, 171, 143);
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(PagesCountTB);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(37, 398);
            panel5.Name = "panel5";
            panel5.Size = new Size(500, 65);
            panel5.TabIndex = 9;
            // 
            // PagesCountTB
            // 
            PagesCountTB.BackColor = Color.FromArgb(207, 171, 143);
            PagesCountTB.BorderStyle = BorderStyle.None;
            PagesCountTB.Cursor = Cursors.IBeam;
            PagesCountTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PagesCountTB.Location = new Point(158, 24);
            PagesCountTB.Name = "PagesCountTB";
            PagesCountTB.Size = new Size(321, 20);
            PagesCountTB.TabIndex = 1;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(152, 63);
            label5.TabIndex = 0;
            label5.Text = "Количество страниц";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(207, 171, 143);
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(GenreTB);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(37, 327);
            panel4.Name = "panel4";
            panel4.Size = new Size(500, 65);
            panel4.TabIndex = 8;
            // 
            // GenreTB
            // 
            GenreTB.BackColor = Color.FromArgb(207, 171, 143);
            GenreTB.BorderStyle = BorderStyle.None;
            GenreTB.Cursor = Cursors.IBeam;
            GenreTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GenreTB.Location = new Point(158, 24);
            GenreTB.Name = "GenreTB";
            GenreTB.Size = new Size(321, 20);
            GenreTB.TabIndex = 1;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(152, 63);
            label4.TabIndex = 0;
            label4.Text = "Жанр";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(207, 171, 143);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(ID_TB);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(37, 256);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 65);
            panel2.TabIndex = 7;
            // 
            // ID_TB
            // 
            ID_TB.BackColor = Color.FromArgb(207, 171, 143);
            ID_TB.BorderStyle = BorderStyle.None;
            ID_TB.Cursor = Cursors.IBeam;
            ID_TB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ID_TB.Location = new Point(158, 24);
            ID_TB.Name = "ID_TB";
            ID_TB.Size = new Size(321, 20);
            ID_TB.TabIndex = 1;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(152, 63);
            label3.TabIndex = 0;
            label3.Text = "ID";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(207, 171, 143);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(AuthorTB);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(37, 185);
            panel3.Name = "panel3";
            panel3.Size = new Size(500, 65);
            panel3.TabIndex = 6;
            // 
            // AuthorTB
            // 
            AuthorTB.BackColor = Color.FromArgb(207, 171, 143);
            AuthorTB.BorderStyle = BorderStyle.None;
            AuthorTB.Cursor = Cursors.IBeam;
            AuthorTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AuthorTB.Location = new Point(158, 24);
            AuthorTB.Name = "AuthorTB";
            AuthorTB.Size = new Size(321, 20);
            AuthorTB.TabIndex = 1;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(152, 63);
            label2.TabIndex = 0;
            label2.Text = "Автор";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(207, 171, 143);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TitleTB);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(37, 114);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 65);
            panel1.TabIndex = 1;
            // 
            // TitleTB
            // 
            TitleTB.BackColor = Color.FromArgb(207, 171, 143);
            TitleTB.BorderStyle = BorderStyle.None;
            TitleTB.Cursor = Cursors.IBeam;
            TitleTB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TitleTB.Location = new Point(158, 24);
            TitleTB.Name = "TitleTB";
            TitleTB.Size = new Size(321, 20);
            TitleTB.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(152, 63);
            label1.TabIndex = 0;
            label1.Text = "Название";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleP
            // 
            titleP.BackColor = Color.FromArgb(172, 199, 221);
            titleP.Controls.Add(panel9);
            titleP.Controls.Add(titleL);
            titleP.Dock = DockStyle.Top;
            titleP.Location = new Point(3, 3);
            titleP.Name = "titleP";
            titleP.Size = new Size(568, 70);
            titleP.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Silver;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.ForeColor = SystemColors.ActiveCaption;
            panel9.Location = new Point(-3, 60);
            panel9.Name = "panel9";
            panel9.Size = new Size(574, 10);
            panel9.TabIndex = 11;
            // 
            // titleL
            // 
            titleL.Dock = DockStyle.Fill;
            titleL.Font = new Font("Cambria", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            titleL.ForeColor = SystemColors.InfoText;
            titleL.Location = new Point(0, 0);
            titleL.Name = "titleL";
            titleL.Size = new Size(568, 70);
            titleL.TabIndex = 0;
            titleL.Text = "Новая книга";
            titleL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(574, 620);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Магазин";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 653);
            Controls.Add(MainTC);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            MainTC.ResumeLayout(false);
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
            ResumeLayout(false);
        }

        #endregion

        private TabControl MainTC;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel titleP;
        private Label titleL;
        private Panel panel1;
        private Label label1;
        private TextBox TitleTB;
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
        private Panel panel10;
        private Panel panel9;
        private Button AddBookB;
        private Button RandomizeBookB;
        private Panel panel8;
        private Panel panel7;
        private Panel panel11;
        private Panel panel12;
    }
}
