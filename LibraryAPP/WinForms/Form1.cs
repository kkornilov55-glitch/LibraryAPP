using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClassLibrary;

namespace WinForms
{
    /// <summary>
    /// Главная форма. ОТВЕТСТВЕННОСТЬ: ввод → валидация → вызов библиотеки → вывод.
    /// Не создаёт объекты Book и не меняет внутреннее состояние библиотеки.
    /// </summary>
    public partial class BookStoreF : Form
    {
        private readonly BookStore store;

        public BookStoreF()
        {
            InitializeComponent();
            store = new BookStore(5);

            // ✅ Подписки на события — в конструкторе
            AddBookB.Click += (s, e) => AddBook();
            RandomizeBookB.Click += (s, e) => Generate();
            SellBookB.Click += (s, e) => Sell();
            ClearCaseB.Click += (s, e) => ClearShelf();
            FoundB.Click += (s, e) => Search();
            GenreSelectCB.SelectedIndexChanged += (s, e) => ShowBooks();
            MainTC.SelectedIndexChanged += (s, e) => { if (MainTC.SelectedTab == StoreTP) Refresh(); };

            Refresh(); // Первое обновление интерфейса
        }

        // ==================== ВАЛИДАЦИЯ (только формат) ====================

        /// <summary>Проверяет, что строка не пустая.</summary>
        private bool Required(string s, string name) =>
            string.IsNullOrWhiteSpace(s) ? ShowWarning($"Заполните: {name}") : true;

        /// <summary>Проверяет, что строка — положительное целое число.</summary>
        private bool PositiveInt(string s, string name, out int v) =>
            int.TryParse(s, out v) && v > 0 ? true : ShowWarning($"{name} > 0");

        /// <summary>Проверяет, что строка — положительная цена.</summary>
        private bool PositiveDouble(string s, out double v) =>
            double.TryParse(s, out v) && v > 0 ? true : ShowWarning("Цена > 0");

        private bool ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // ==================== ОСНОВНЫЕ ДЕЙСТВИЯ ====================

        /// <summary>Добавляет книгу: валидация → библиотека → вывод.</summary>
        private void AddBook()
        {
            // 1. Считываем и валидируем данные (формат)
            var t = TitleTB.Text.Trim();
            var a = AuthorTB.Text.Trim();
            var g = GenreTB.Text.Trim();

            if (!Required(t, "Название") || !Required(a, "Автор") || !Required(g, "Жанр")) return;
            if (!PositiveInt(PagesCountTB.Text, "Страницы", out var p)) return;
            if (!PositiveDouble(PriceTB.Text, out var pr)) return;

            try
            {
                // 2. ✅ Передаём данные в библиотеку — она сама создаёт Book
                store.AddBook(t, a, g, p, pr);

                // 3. Показываем результат
                MessageBox.Show("Добавлено!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                Refresh();
            }
            catch (InvalidOperationException ex)
            {
                // Бизнес-ошибки: нет места, жанр существует и т.п.
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Генерирует книгу: библиотека возвращает объект → форма показывает.</summary>
        /// <summary>
        /// Генерирует полностью случайную книгу (жанр тоже случайный).
        /// Поле жанра можно оставить пустым.
        /// </summary>
        private void Generate()
        {
            // ✅ Берём жанр из поля, если ввели; если пусто — библиотека выберет сама
            var g = GenreTB.Text.Trim();

            try
            {
                // Передаём жанр (может быть пустым) — библиотека разберётся
                var book = Book.GenerateBook(store.GetAllBooks(), g);

                // Заполняем форму сгенерированными данными
                TitleTB.Text = book.Title;
                AuthorTB.Text = book.Author;
                GenreTB.Text = book.Genre;  // ← Покажем сгенерированный жанр
                PagesCountTB.Text = book.Pages.ToString();
                PriceTB.Text = book.Price.ToString("F2");
                ID_TB.Text = book.id.ToString();

                MessageBox.Show($"Сгенерировано: {book.Title}\nЖанр: {book.Genre}", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Продаёт выделенную книгу через библиотеку.</summary>
        private void Sell()
        {
            // Определяем, из какой таблицы взята выделенная строка
            var grid = dataGridView1.SelectedRows.Count > 0 ? dataGridView1 : SearchedBookGrid;
            if (grid.SelectedRows.Count == 0) { ShowWarning("Выберите книгу"); return; }

            // Получаем ID из нужной ячейки
            var cellName = grid == dataGridView1 ? "colId" : "ID";
            var v = grid.SelectedRows[0].Cells[cellName].Value;

            if (v == null || !int.TryParse(v.ToString(), out var id))
            {
                MessageBox.Show("Ошибка ID", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Очищаем таблицу поиска, если книга продавалась оттуда
            if (grid == SearchedBookGrid) SearchedBookGrid.Rows.Clear();

            store.SellBook(id);
            MessageBox.Show("Продано!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refresh();
            ShowBooks();
        }

        /// <summary>Очищает шкаф выбранного жанра.</summary>
        private void ClearShelf()
        {
            var g = GenreSelectCB.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(g)) { ShowWarning("Выберите жанр"); return; }

            if (MessageBox.Show($"Распродать \"{g}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            store.ClearBookCase(g);
            if (SearchedBookGrid.Rows.Count > 0) SearchedBookGrid.Rows.Clear();

            MessageBox.Show("Очищено", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refresh();
            dataGridView1.Rows.Clear();
        }

        /// <summary>Ищет книгу по ID или названию.</summary>
        private void Search()
        {
            var q = FoundStringTB.Text.Trim();
            if (!Required(q, "Запрос")) return;

            // Если запрос — число, ищем по ID, иначе по названию
            var book = int.TryParse(q, out var id) ? store.FindBookById(id) : store.FindBookByTitle(q);
            SearchBooks(book);
        }

        // ==================== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ====================

        private void ClearForm()
        {
            TitleTB.Clear(); AuthorTB.Clear(); GenreTB.Clear();
            PagesCountTB.Clear(); PriceTB.Clear();
            ID_TB.Text = "Авто";
            TitleTB.Focus();
        }

        private void Refresh()
        {
            BalanceL.Text = $"{store.Balance:F2} ₽";

            GenreSelectCB.Items.Clear();
            foreach (var g in store.GetAllGenres())
                GenreSelectCB.Items.Add(g);

            if (GenreSelectCB.Items.Count == 0)
                GenreSelectCB.Text = string.Empty;
            else if (GenreSelectCB.Items.Count > 0 && GenreSelectCB.SelectedIndex == -1)
                GenreSelectCB.SelectedIndex = 0;
            else if (GenreSelectCB.Items.Count == 0)
                dataGridView1.Rows.Clear();
        }

        private void ShowBooks()
        {
            var g = GenreSelectCB.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(g)) return;

            dataGridView1.Rows.Clear();
            foreach (var b in store.GetBooksByGenre(g))
            {
                var i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["colId"].Value = b.id;
                dataGridView1.Rows[i].Cells["colTitle"].Value = b.Title;
                dataGridView1.Rows[i].Cells["colAuthor"].Value = b.Author;
                dataGridView1.Rows[i].Cells["colPrice"].Value = $"{b.Price:F2} ₽";
            }
        }

        /// <summary>Показывает результат поиска в отдельной таблице.</summary>
        private void SearchBooks(Book? book)
        {
            SearchedBookGrid.Rows.Clear();

            if (book != null)
            {
                var row = SearchedBookGrid.Rows.Add();
                SearchedBookGrid.Rows[row].Cells["ID"].Value = book.id;
                SearchedBookGrid.Rows[row].Cells["colTitleSearch"].Value = book.Title;
                SearchedBookGrid.Rows[row].Cells["colAuthorSearch"].Value = book.Author;
                SearchedBookGrid.Rows[row].Cells["colPriceSearch"].Value = $"{book.Price:F2} ₽";
                SearchedBookGrid.Rows[row].Cells["colPagesCountSearch"].Value = book.Pages;
                SearchedBookGrid.Rows[row].Cells["colGenreSearch"].Value = book.Genre;

                // Переключаем на вкладку с результатом и выделяем найденную книгу
                StoreTC.SelectedIndex = 1;
                SearchedBookGrid.ClearSelection();
                SearchedBookGrid.Rows[row].Selected = true;
            }

            MessageBox.Show(book != null ? $"Найдено: {book.Title}" : "Не найдено", "Результат",
                MessageBoxButtons.OK, book != null ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        // Пустой обработчик для Designer
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}