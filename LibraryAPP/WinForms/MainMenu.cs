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
    /// Главное меню игры
    /// </summary>
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка начать игру, открывает диалог выбора сложности
        /// </summary>
        private void butGameStart_Click(object sender, EventArgs e)
        {
            DifficultySelectionDialog difficultyDialog = new DifficultySelectionDialog();
            if (difficultyDialog.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
                BookStoreF gameForm = new BookStoreF();
                gameForm.FormClosed += (s, args) =>
                {
                    this.Close();
                };

                gameForm.Show();
                gameForm.BringToFront();
                gameForm.Activate();
            }
        }

        /// <summary>
        /// Кнопка Об игре
        /// </summary>
        private void btnAboutGame_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Кнопка выхода из игры
        /// </summary>
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

        /// <summary>
        ///  Кнопка информации о разработчиках
        /// </summary>
        private void btnInfo_Click(object sender, EventArgs e)
        {
            Info infoForm = new Info();
            infoForm.ShowDialog();
        }
    }
}
