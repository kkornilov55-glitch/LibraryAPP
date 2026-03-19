namespace WinForms
{
    partial class MainMenu
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
            butGameStart = new Button();
            btnAboutGame = new Button();
            btnExit = new Button();
            btnInfo = new Button();
            SuspendLayout();
            // 
            // butGameStart
            // 
            butGameStart.BackColor = Color.Transparent;
            butGameStart.BackgroundImage = Properties.Resources.btn1_1;
            butGameStart.BackgroundImageLayout = ImageLayout.Stretch;
            butGameStart.Cursor = Cursors.Hand;
            butGameStart.FlatAppearance.BorderSize = 0;
            butGameStart.FlatAppearance.MouseDownBackColor = Color.Transparent;
            butGameStart.FlatAppearance.MouseOverBackColor = Color.Transparent;
            butGameStart.FlatStyle = FlatStyle.Flat;
            butGameStart.Font = new Font("Kepler 296", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butGameStart.ForeColor = Color.DarkGreen;
            butGameStart.Location = new Point(136, 241);
            butGameStart.Name = "butGameStart";
            butGameStart.Size = new Size(250, 60);
            butGameStart.TabIndex = 0;
            butGameStart.Text = "НАЧАТЬ ИГРУ";
            butGameStart.UseVisualStyleBackColor = false;
            butGameStart.Click += butGameStart_Click;
            // 
            // btnAboutGame
            // 
            btnAboutGame.BackColor = Color.Transparent;
            btnAboutGame.BackgroundImage = Properties.Resources.btn2_1;
            btnAboutGame.BackgroundImageLayout = ImageLayout.Stretch;
            btnAboutGame.Cursor = Cursors.Hand;
            btnAboutGame.FlatAppearance.BorderSize = 0;
            btnAboutGame.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnAboutGame.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnAboutGame.FlatStyle = FlatStyle.Flat;
            btnAboutGame.Font = new Font("Kepler 296", 11.999999F, FontStyle.Bold);
            btnAboutGame.ForeColor = Color.SaddleBrown;
            btnAboutGame.Location = new Point(136, 307);
            btnAboutGame.Name = "btnAboutGame";
            btnAboutGame.Size = new Size(250, 60);
            btnAboutGame.TabIndex = 1;
            btnAboutGame.Text = "ОБ ИГРЕ";
            btnAboutGame.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.BackgroundImage = Properties.Resources.btnSmall_1;
            btnExit.BackgroundImageLayout = ImageLayout.Stretch;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Kepler 296", 11.999999F, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(64, 0, 0);
            btnExit.Location = new Point(208, 394);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(107, 41);
            btnExit.TabIndex = 2;
            btnExit.Text = "ВЫЙТИ";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnInfo
            // 
            btnInfo.BackColor = Color.Transparent;
            btnInfo.BackgroundImage = Properties.Resources.btn5;
            btnInfo.BackgroundImageLayout = ImageLayout.Stretch;
            btnInfo.Cursor = Cursors.Hand;
            btnInfo.FlatAppearance.BorderSize = 0;
            btnInfo.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnInfo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.Font = new Font("Kepler 296", 14F, FontStyle.Bold);
            btnInfo.ForeColor = Color.Yellow;
            btnInfo.Location = new Point(457, 455);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(40, 40);
            btnInfo.TabIndex = 3;
            btnInfo.Text = "i";
            btnInfo.UseVisualStyleBackColor = false;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Cover;
            ClientSize = new Size(509, 507);
            Controls.Add(btnInfo);
            Controls.Add(btnExit);
            Controls.Add(btnAboutGame);
            Controls.Add(butGameStart);
            MaximumSize = new Size(525, 546);
            MinimumSize = new Size(525, 546);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Книжный магазин";
            ResumeLayout(false);
        }

        #endregion

        private Button butGameStart;
        private Button btnAboutGame;
        private Button btnExit;
        private Button btnInfo;
    }
}