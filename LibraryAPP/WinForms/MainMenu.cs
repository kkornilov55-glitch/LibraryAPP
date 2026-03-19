using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace WinForms
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void butGameStart_Click(object sender, EventArgs e)
        {
            DifficultySelectionDialog difficultyDialog = new DifficultySelectionDialog();
            difficultyDialog.ShowDialog();
            this.Close();
         }

        //private void btnAboutGame_Click(object sender, EventArgs e)
        //{
        //    AboutForm aboutForm = new AboutForm();
        //    aboutForm.ShowDialog();
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы действительно хотите выйти?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //private void btnInfo_Click(object sender, EventArgs e)
        //{
        //    InfoForm infoForm = new InfoForm();
        //    infoForm.ShowDialog();
        //}
    }
}
