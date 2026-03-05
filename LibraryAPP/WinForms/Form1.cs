using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;

namespace WinForms
{
    public partial class Form1 : Form
    {
        //Коллекция шкафов — пока только один для примера
        private List<BookCase> _bookCases;

        //Список всех книг — нужен для GenerateBook (уникальность названий)
        private List<Book> _allBooks;

        public Form1()
        {
            InitializeComponent();

            //Настройка формы (требование №9)
            this.Text = "Книжный Магазин";
            this.Name = "BookStoreForm";

            //ID генерируется автоматически — поле только для чтения
            ID_TB.ReadOnly = true;
            ID_TB.TabStop = false;

            //Текст для кнопки генерации
            RandomizeBookB.Text = "🎲";

            //Инициализация данных
            _bookCases = new List<BookCase>();
            _allBooks = new List<Book>();

            //Подписка на события кнопок
            AddBookB.Click += AddBookB_Click;
            RandomizeBookB.Click += RandomizeBookB_Click;
        }

        /// <summary>
        /// Обработчик кнопки "Сохранить" — добавление книги вручную
        /// </summary>
        private void AddBookB_Click(object sender, EventArgs e)
        {
            try
            {
                //Валидация полей
                string title = TitleTB.Text.Trim();
                string author = AuthorTB.Text.Trim();
                string genre = GenreTB.Text.Trim();

                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(genre))
                {
                    MessageBox.Show("Заполните все обязательные поля: Название, Автор, Жанр",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(PagesCountTB.Text, out int pages) || pages <= 0)
                {
                    MessageBox.Show("Укажите корректное количество страниц (положительное число)",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(PriceTB.Text, out double price) || price <= 0)
                {
                    MessageBox.Show("Укажите корректную цену (положительное число)",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Ищем или создаём шкаф для жанра
                BookCase targetCase = null;
                foreach (var bc in _bookCases)
                {
                    if (string.Equals(bc.genre, genre, StringComparison.OrdinalIgnoreCase))
                    {
                        targetCase = bc;
                        break;
                    }
                }

                //Если шкафа нет — создаём новый (вместимость 10 — можно изменить)
                if (targetCase == null)
                {
                    targetCase = new BookCase(genre, 10);
                    _bookCases.Add(targetCase);
                }

                //Создаём книгу
                var book = new Book(title, author, genre, pages, price);

                // Добавляем в шкаф и в общий список
                targetCase.AddBook(book);
                _allBooks.Add(book);

                //Успех
                MessageBox.Show($"Книга \"{book.Title}\" успешно добавлена!",
                    "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очистка полей
                ClearBookForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении книги: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Случайная генерация"
        /// </summary>
        private void RandomizeBookB_Click(object sender, EventArgs e)
        {
            try
            {
                string genre = GenreTB.Text.Trim();
                if (string.IsNullOrWhiteSpace(genre))
                {
                    MessageBox.Show("Укажите жанр для генерации книги",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Генерируем книгу через статический метод класса Book
                var book = Book.GenerateBook(_allBooks, genre);

                //Заполняем форму сгенерированными данными
                TitleTB.Text = book.Title;
                AuthorTB.Text = book.Author;
                GenreTB.Text = book.Genre;
                PagesCountTB.Text = book.Pages.ToString();
                PriceTB.Text = book.Price.ToString("F2");
                ID_TB.Text = book.id.ToString();

                MessageBox.Show($"Сгенерирована книга: \"{book.Title}\"\nАвтор: {book.Author}",
                    "Генерация завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Очищает поля формы для новой книги
        /// </summary>
        private void ClearBookForm()
        {
            TitleTB.Clear();
            AuthorTB.Clear();
            GenreTB.Clear();
            PagesCountTB.Clear();
            PriceTB.Clear();
            ID_TB.Clear();
            TitleTB.Focus();
        }
    }
}