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
    public partial class DifficultySelectionDialog : Form
    {
        public int SelectedDifficulty { get; private set; } = 1; // По умолчанию — нормальный

        public DifficultySelectionDialog()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            StartGameWithDifficulty(0);
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            StartGameWithDifficulty(1);
        }

        private void bthHard_Click(object sender, EventArgs e)
        {
            StartGameWithDifficulty(2);
        }

        private void StartGameWithDifficulty(int difficulty)
        {
            try
            {
                GameManager.StartGame(difficulty);
                this.Close();
                BookStoreF gameForm = new BookStoreF();
                gameForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при запуске игры:\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClosr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
