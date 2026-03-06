using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClassLibrary;

namespace WinForms
{
    /// <summary>
    /// Главная форма приложения "Книжный магазин".
    /// Обрабатывает ввод пользователя, вызывает методы библиотеки классов
    /// и обновляет интерфейс.
    /// </summary>
    public partial class BookStoreF : Form
    {
        // Экземпляр магазина — вся бизнес-логика здесь
        private BookStore store;

        /// <summary>Конструктор формы. Инициализирует компоненты и подписки.</summary>
        public BookStoreF()
        {
            InitializeComponent();
            // Создаём магазин с лимитом 5 шкафов (требование задания)
            store = new BookStore(5);
            // ID генерируется автоматически — поле только для чтения
            ID_TB.ReadOnly = true; ID_TB.Text = "Авто";

            // Подписываем кнопки на обработчики (лямбды для краткости)
            AddBookB.Click += (s, e) => AddBook();
            RandomizeBookB.Click += (s, e) => Generate();
            SellBookB.Click += (s, e) => Sell();
            ClearCaseB.Click += (s, e) => ClearShelf();
            FoundB.Click += (s, e) => Search();
            // При смене жанра — обновляем таблицу книг
            GenreSelectCB.SelectedIndexChanged += (s, e) => ShowBooks();
            // При переключении на вкладку "Магазин" — обновляем данные
            MainTC.SelectedIndexChanged += (s, e) => { if (MainTC.SelectedTab == StoreTP) Refresh(); };

            // Применяем фон и обновляем интерфейс
            SetBg(); Refresh();
        }

        /// <summary>
        /// Устанавливает фон формы из файла background.jpg.
        /// Если файл не найден — использует цвет по умолчанию.
        /// </summary>
        private void SetBg()
        {
            try
            {
                // Путь к фону в папке приложения
                string p = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "background.jpg");
                // Загружаем, если файл существует
                BackgroundImage = File.Exists(p) ? Image.FromFile(p) : null;
            }
            catch { BackColor = Color.FromArgb(226, 206, 177); } // Фоллбэк-цвет при ошибке
        }

        /// <summary>Проверяет, что строка не пустая. Возвращает true если ошибка.</summary>
        /// <param name="s">Проверяемая строка</param>
        /// <param name="n">Имя поля для сообщения</param>
        private bool Empty(string s, string n) { if (string.IsNullOrWhiteSpace(s)) { MessageBox.Show("Заполните: " + n, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); return true; } return false; }

        /// <summary>Проверяет, что строка — положительное целое число.</summary>
        /// <param name="s">Строка для парсинга</param>
        /// <param name="v">Результат парсинга (out)</param>
        /// <param name="n">Имя поля для сообщения</param>
        private bool Num(string s, out int v, string n) { if (int.TryParse(s, out v) && v > 0) return true; MessageBox.Show(n + " > 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

        /// <summary>Проверяет, что строка — положительная цена.</summary>
        private bool Price(string s, out double v) { if (double.TryParse(s, out v) && v > 0) return true; MessageBox.Show("Цена > 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

        /// <summary>Показывает сообщение об ошибке (короткая запись).</summary>
        private void Err(string m) => MessageBox.Show(m, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        /// <summary>Показывает сообщение об успехе (короткая запись).</summary>
        private void Ok(string m) => MessageBox.Show(m, "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>Добавляет книгу вручную после валидации полей.</summary>
        private void AddBook()
        {
            try
            {
                // Считываем и обрезаем пробелы
                string t = TitleTB.Text.Trim(), a = AuthorTB.Text.Trim(), g = GenreTB.Text.Trim();
                // Валидация текстовых полей
                if (Empty(t, "Название") || Empty(a, "Автор") || Empty(g, "Жанр")) return;
                // Валидация числовых полей
                if (!Num(PagesCountTB.Text, out int p, "Страницы")) return;
                if (!Price(PriceTB.Text, out double pr)) return;
                // Создаём книгу и добавляем в магазин (логика шкафов внутри)
                store.AddBook(new Book(t, a, g, p, pr));
                Ok("Добавлено!"); ClearForm(); Refresh();
            }
            catch (Exception ex) { Err(ex.Message); } // Обработка непредвиденных ошибок
        }

        /// <summary>Генерирует случайную книгу и заполняет форму данными.</summary>
        private void Generate()
        {
            try
            {
                string g = GenreTB.Text.Trim();
                if (Empty(g, "Жанр")) return;
                // Вызываем статический метод генерации из класса Book
                // Передаём все книги для проверки уникальности названия
                Book b = Book.GenerateBook(store.GetAllBooks(), g);
                // Заполняем поля формы сгенерированными данными
                TitleTB.Text = b.Title; AuthorTB.Text = b.Author; PagesCountTB.Text = b.Pages.ToString();
                PriceTB.Text = b.Price.ToString("F2"); ID_TB.Text = b.id.ToString();
                Ok("Сгенерировано: " + b.Title);
            }
            catch (Exception ex) { Err(ex.Message); }
        }

        /// <summary>Очищает все поля формы "Новая книга" для следующего ввода.</summary>
        private void ClearForm() { TitleTB.Clear(); AuthorTB.Clear(); GenreTB.Clear(); PagesCountTB.Clear(); PriceTB.Clear(); ID_TB.Text = "Авто"; TitleTB.Focus(); }

        /// <summary>Обновляет данные на вкладке "Магазин": баланс, жанры, таблицу.</summary>
        private void Refresh()
        {
            // Обновляем отображение баланса
            BalanceL.Text = store.Balance.ToString("F2") + " ₽";
            // Перезаполняем комбобокс жанров
            GenreSelectCB.Items.Clear();
            foreach (string g in store.GetAllGenres()) GenreSelectCB.Items.Add(g);
            // Автовыбор первого жанра, если список не пуст
            if (GenreSelectCB.Items.Count > 0 && GenreSelectCB.SelectedIndex == -1) GenreSelectCB.SelectedIndex = 0;
            // Если жанров нет — очищаем таблицу
            else if (GenreSelectCB.Items.Count == 0) dataGridView1.Rows.Clear();
        }

        /// <summary>Заполняет таблицу книгами выбранного жанра.</summary>
        private void ShowBooks()
        {
            try
            {
                string g = GenreSelectCB.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(g)) return;
                dataGridView1.Rows.Clear();
                // Проходим по всем книгам жанра и добавляем строки в таблицу
                foreach (Book b in store.GetBooksByGenre(g))
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["colId"].Value = b.id;
                    dataGridView1.Rows[i].Cells["colTitle"].Value = b.Title;
                    dataGridView1.Rows[i].Cells["colAuthor"].Value = b.Author;
                    dataGridView1.Rows[i].Cells["colPrice"].Value = b.Price.ToString("F2") + " ₽";
                }
            }
            catch (Exception ex) { Err(ex.Message); }
        }

        /// <summary>Ищет книгу по названию или по ID (если введено число).</summary>
        private void Search()
        {
            try
            {
                string q = FoundStringTB.Text.Trim();
                if (Empty(q, "Запрос")) return;
                // Если запрос — число, ищем по ID, иначе по названию
                Book b = int.TryParse(q, out int id) ? store.FindBookById(id) : store.FindBookByTitle(q);
                Ok(b != null ? "Найдено: " + b.Title : "Не найдено");
            }
            catch (Exception ex) { Err(ex.Message); }
        }

        /// <summary>Продаёт выделенную в таблице книгу, обновляет баланс.</summary>
        private void Sell()
        {
            try
            {
                // Проверяем, что строка выделена
                if (dataGridView1.SelectedRows.Count == 0) { MessageBox.Show("Выберите книгу", "Продажа", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                // Получаем ID из выделенной строки
                object v = dataGridView1.SelectedRows[0].Cells["colId"].Value;
                if (v == null || !int.TryParse(v.ToString(), out int id)) { Err("Ошибка ID"); return; }
                // Продаём книгу через магазин
                store.SellBook(id); Ok("Продано!"); Refresh(); ShowBooks();
            }
            catch (Exception ex) { Err(ex.Message); }
        }

        /// <summary>Очищает весь шкаф: продаёт все книги, освобождает место под новый жанр.</summary>
        private void ClearShelf()
        {
            try
            {
                string g = GenreSelectCB.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(g)) { MessageBox.Show("Выберите жанр", "Очистка", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                // Подтверждение необратимого действия
                if (MessageBox.Show("Распродать \"" + g + "\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                // Очищаем шкаф через магазин
                store.ClearBookCase(g); Ok("Очищено"); Refresh(); dataGridView1.Rows.Clear();
            }
            catch (Exception ex) { Err(ex.Message); }
        }

        /// <summary>Пустой обработчик для совместимости с Designer (автогенерация).</summary>
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}