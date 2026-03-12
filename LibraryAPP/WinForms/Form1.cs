using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClassLibrary;

namespace WinForms
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class BookStoreF : Form
    {
        private readonly BookStore store;

        public BookStoreF()
        {
            InitializeComponent();
            store = new BookStore(5);

            //Подписки на события — в конструкторе
            AddBookB.Click += (s, e) => AddBook();
            RandomizeBookB.Click += (s, e) => Generate();
            SellBookB.Click += (s, e) => Sell();
            ClearCaseB.Click += (s, e) => ClearShelf();
            FoundB.Click += (s, e) => Search();
            GenreSelectCB.SelectedIndexChanged += (s, e) => ShowBooks();
            MainTC.SelectedIndexChanged += (s, e) => { if (MainTC.SelectedTab == StoreTP) Refresh(); };

            //Первое обновление — в конструкторе
            Refresh();
        }

        //ВАЛИДАЦИЯ

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

        //ОСНОВНЫЕ ДЕЙСТВИЯ

        /// <summary>Добавляет книгу</summary>
        private void AddBook()
        {
            var t = TitleTB.Text.Trim();
            var a = AuthorTB.Text.Trim();
            var g = GenreTB.Text.Trim();

            if (!Required(t, "Название") || !Required(a, "Автор") || !Required(g, "Жанр")) return;
            if (!PositiveInt(PagesCountTB.Text, "Страницы", out var p)) return;
            if (!PositiveDouble(PriceTB.Text, out var pr)) return;

            //Форма НЕ создаёт Book — только передаёт данные в библиотеку
            store.AddBook(t, a, g, p, pr);

            MessageBox.Show("Добавлено!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm(); Refresh();
        }

        /// <summary>Генерирует книгу через библиотеку и заполняет форму.</summary>
        private void Generate()
        {
            var g = GenreTB.Text.Trim();
            

            var book = Book.GenerateBook(store.GetAllBooks(), g);
            TitleTB.Text = book.Title;
            AuthorTB.Text = book.Author;
            GenreTB.Text = book.Genre;
            PagesCountTB.Text = book.Pages.ToString();
            PriceTB.Text = book.Price.ToString("F2");
            ID_TB.Text = book.id.ToString();

            MessageBox.Show($"Сгенерировано: {book.Title}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Продаёт выделенную книгу через библиотеку.</summary>
        private void Sell()
        {
            if (dataGridView1.SelectedRows.Count == 0 && SearchedBookGrid.SelectedRows.Count == 0)
            { 
                ShowWarning("Выберите книгу"); 
                return; 
            }

            var v = dataGridView1.SelectedRows.Count == 0 ? SearchedBookGrid.SelectedRows[0].Cells["ID"].Value : dataGridView1.SelectedRows[0].Cells["colId"].Value;
            if (v == null || !int.TryParse(v.ToString(), out var id))
            { 
                MessageBox.Show("Ошибка ID", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return; 
            }

            if (SearchedBookGrid.SelectedRows.Count != 0) SearchedBookGrid.Rows.Clear(); 

            store.SellBook(id);
            MessageBox.Show("Продано!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refresh(); ShowBooks();
        }

        /// <summary>Очищает шкаф выбранного жанра.</summary>
        private void ClearShelf()
        {
            var g = GenreSelectCB.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(g)) { ShowWarning("Выберите жанр"); return; }
            if (MessageBox.Show($"Распродать \"{g}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            store.ClearBookCase(g);
            MessageBox.Show("Очищено", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refresh(); dataGridView1.Rows.Clear();
        }

        /// <summary>Ищет книгу по ID или названию.</summary>
        private void Search()
        {
            var q = FoundStringTB.Text.Trim();
            if (!Required(q, "Запрос")) return;

            var book = int.TryParse(q, out var id) ? store.FindBookById(id) : store.FindBookByTitle(q);

            SearchBooks(book);
        }

        //ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ

        private void ClearForm()
        {
            TitleTB.Clear(); AuthorTB.Clear(); GenreTB.Clear();
            PagesCountTB.Clear(); PriceTB.Clear();
            ID_TB.Text = "Авто"; TitleTB.Focus();
        }

        private void Refresh()
        {
            BalanceL.Text = $"{store.Balance:F2} ₽";
            GenreSelectCB.Items.Clear();
            foreach (var g in store.GetAllGenres()) 
                GenreSelectCB.Items.Add(g);

            if (GenreSelectCB.Items.Count == 0) GenreSelectCB.Text = string.Empty;

            if (GenreSelectCB.Items.Count > 0 && GenreSelectCB.SelectedIndex == -1)
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

        private void SearchBooks(Book b)
        {
            SearchedBookGrid.Rows.Clear();

            if (b != null)
            {
                var row = SearchedBookGrid.Rows.Add();

                SearchedBookGrid.Rows[row].Cells["ID"].Value = b.id;
                SearchedBookGrid.Rows[row].Cells["colTitleSearch"].Value = b.Title;
                SearchedBookGrid.Rows[row].Cells["colAuthorSearch"].Value = b.Author;
                SearchedBookGrid.Rows[row].Cells["colPriceSearch"].Value = $"{b.Price:F2} ₽";
                SearchedBookGrid.Rows[row].Cells["colPagesCountSearch"].Value = b.Pages;
                SearchedBookGrid.Rows[row].Cells["colGenreSearch"].Value = b.Genre;

                StoreTC.SelectedIndex = 1; //Переключаем tabControl на 2 страничку (по индексу 1)
                SearchedBookGrid.ClearSelection(); //Отчищаем предыдущее выделение
                SearchedBookGrid.Rows[row].Selected = true; //Выделяем найденную книгу
            }

            MessageBox.Show(b != null ? $"Найдено: {b.Title}" : "Не найдено", "Результат",
                MessageBoxButtons.OK, b != null ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}