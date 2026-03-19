namespace WinForms
{
    partial class DifficultySelectionDialog
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
            btnEasy = new Button();
            btnNormal = new Button();
            bthHard = new Button();
            btnClosr = new Button();
            SuspendLayout();
            // 
            // btnEasy
            // 
            btnEasy.BackColor = Color.Transparent;
            btnEasy.BackgroundImage = Properties.Resources.btn1_1;
            btnEasy.BackgroundImageLayout = ImageLayout.Stretch;
            btnEasy.Cursor = Cursors.Hand;
            btnEasy.FlatAppearance.BorderSize = 0;
            btnEasy.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnEasy.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEasy.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEasy.FlatStyle = FlatStyle.Flat;
            btnEasy.Font = new Font("Kepler 296", 11.999999F, FontStyle.Bold);
            btnEasy.ForeColor = Color.DarkGreen;
            btnEasy.Location = new Point(148, 169);
            btnEasy.Name = "btnEasy";
            btnEasy.Size = new Size(220, 60);
            btnEasy.TabIndex = 0;
            btnEasy.Text = "Легкая";
            btnEasy.UseVisualStyleBackColor = false;
            btnEasy.Click += btnEasy_Click;
            // 
            // btnNormal
            // 
            btnNormal.BackColor = Color.Transparent;
            btnNormal.BackgroundImage = Properties.Resources.btn2_1;
            btnNormal.BackgroundImageLayout = ImageLayout.Stretch;
            btnNormal.Cursor = Cursors.Hand;
            btnNormal.FlatAppearance.BorderSize = 0;
            btnNormal.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnNormal.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnNormal.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnNormal.FlatStyle = FlatStyle.Flat;
            btnNormal.Font = new Font("Kepler 296", 11.999999F, FontStyle.Bold);
            btnNormal.ForeColor = Color.SaddleBrown;
            btnNormal.Location = new Point(148, 235);
            btnNormal.Name = "btnNormal";
            btnNormal.Size = new Size(220, 60);
            btnNormal.TabIndex = 1;
            btnNormal.Text = "Средняя";
            btnNormal.UseVisualStyleBackColor = false;
            btnNormal.Click += btnNormal_Click;
            // 
            // bthHard
            // 
            bthHard.BackColor = Color.Transparent;
            bthHard.BackgroundImage = Properties.Resources.btn5;
            bthHard.BackgroundImageLayout = ImageLayout.Stretch;
            bthHard.Cursor = Cursors.Hand;
            bthHard.FlatAppearance.BorderSize = 0;
            bthHard.FlatAppearance.CheckedBackColor = Color.Transparent;
            bthHard.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bthHard.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bthHard.FlatStyle = FlatStyle.Flat;
            bthHard.Font = new Font("Kepler 296", 11.999999F, FontStyle.Bold);
            bthHard.ForeColor = Color.FromArgb(64, 0, 0);
            bthHard.Location = new Point(148, 301);
            bthHard.Name = "bthHard";
            bthHard.Size = new Size(220, 60);
            bthHard.TabIndex = 2;
            bthHard.Text = "Сложная";
            bthHard.UseVisualStyleBackColor = false;
            bthHard.Click += bthHard_Click;
            // 
            // btnClosr
            // 
            btnClosr.BackColor = Color.Transparent;
            btnClosr.BackgroundImage = Properties.Resources.close1;
            btnClosr.BackgroundImageLayout = ImageLayout.Stretch;
            btnClosr.Cursor = Cursors.Hand;
            btnClosr.FlatAppearance.BorderSize = 0;
            btnClosr.FlatAppearance.CheckedBackColor = Color.Transparent;
            btnClosr.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnClosr.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnClosr.FlatStyle = FlatStyle.Flat;
            btnClosr.Location = new Point(412, 42);
            btnClosr.Name = "btnClosr";
            btnClosr.Size = new Size(60, 60);
            btnClosr.TabIndex = 3;
            btnClosr.UseVisualStyleBackColor = false;
            btnClosr.Click += btnClosr_Click;
            // 
            // DifficultySelectionDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.CoverDifficult;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(509, 507);
            Controls.Add(btnClosr);
            Controls.Add(bthHard);
            Controls.Add(btnNormal);
            Controls.Add(btnEasy);
            DoubleBuffered = true;
            MaximumSize = new Size(525, 546);
            MinimumSize = new Size(525, 546);
            Name = "DifficultySelectionDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Книжный магазин";
            ResumeLayout(false);
        }

        #endregion

        private Button btnEasy;
        private Button btnNormal;
        private Button bthHard;
        private Button btnClosr;
    }
}