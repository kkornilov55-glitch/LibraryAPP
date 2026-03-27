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
    /// <summary>
    /// Форма выбора сложности игры
    /// Предоставляет пользователю выбор между тремя режимами: Лёгкий, Средний, Сложный
    /// После подтверждения выбора создаёт экземпляр GameManager и запускает игру
    /// </summary>
    public partial class DifficultySelectionDialog : Form
    {
        public int SelectedDifficulty { get; private set; } = 1; // По умолчанию — средний

        // Инициализация формы
        public DifficultySelectionDialog()
        {
            InitializeComponent();
        }

        // Легкая
        private void btnEasy_Click(object sender, EventArgs e)
        {
            StartGameWithDifficulty(0);
        }

        // Средняя
        private void btnNormal_Click(object sender, EventArgs e)
        {
            StartGameWithDifficulty(1);
        }

        // Сложная
        private void bthHard_Click(object sender, EventArgs e)
        {
            StartGameWithDifficulty(2);
        }

        /// <summary>
        /// Запускает игру с указанной сложностью после подтверждения пользователя
        /// Создаёт GameManager, вызывает StartGame(), закрывает форму выбора
        /// </summary>
        /// <param name="difficulty">Код сложности: 0, 1 или 2</param>
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

        /// <summary>
        /// Закрывает окно сложности
        /// </summary>
        private void btnClosr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Обработчик события закрытия формы: гарантирует, что при отмене будет установлен DialogResult = Cancel
        /// </summary>
        private void DifficultySelectionDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
