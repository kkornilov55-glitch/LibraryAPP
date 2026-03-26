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
                string difficultyName = difficulty switch
                {
                    0 => "Лёгкий",
                    1 => "Средний",
                    2 => "Сложный",
                    _ => "Неизвестный"
                };

                DialogResult confirmResult = MessageBox.Show(
                    $"Вы уверены, что хотите начать игру в режиме \"{difficultyName}\"?",
                    "Подтверждение выбора",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    GameManager gameManager = new GameManager();
                    gameManager.StartGame(difficulty);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при запуске игры:\n\n{ex.Message}\n\n{ex.StackTrace}",
                    "Критическая ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClosr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DifficultySelectionDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
