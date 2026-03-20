namespace WinForms
{
    partial class Info
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
            btnClose = new Button();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundImage = Properties.Resources.close1;
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(412, 42);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(60, 60);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // Info
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.CoverDevelopers;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(509, 507);
            Controls.Add(btnClose);
            DoubleBuffered = true;
            MaximumSize = new Size(525, 546);
            MinimumSize = new Size(525, 546);
            Name = "Info";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Книжный магазин";
            ResumeLayout(false);
        }

        #endregion

        private Button btnClose;
    }
}