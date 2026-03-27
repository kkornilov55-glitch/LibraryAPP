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


        // Храним ссылку на последнюю сгенерированную, но не сохраненную книгу
        private Book _currentGeneratedBook = null;

        public BookStoreF()
        {
            InitializeComponent();

            // Скрываем вкладку "Поставки" при запуске
            MainTC.TabPages.Remove(Supples);

            UpdateCounters();
            timeCustomer.Start();


            // Скрываем вкладку панель с покупателями по умолчанию
            pnlCustomerArea.Visible = false;

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


            if (_currentGeneratedBook != null)
            {
                // Откатываем счетчик, так как старая книга не будет использована
                Book.DecrementCounter();
                _currentGeneratedBook = null;
            }

            string uniqueTitle = Book.EnsureUniqueTitle(t, a, GameManager.Instance.Store.GetAllBooks());

            var newBook = new Book(uniqueTitle, a, g, p, pr);

            try
            {
                if (GameManager.Instance.Store.Balance < pr)
                {
                    MessageBox.Show($"Недостаточно средств!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GameManager.Instance.Store.SubtractFromBalance(pr);
                GameManager.Instance.Store.AddBook(newBook);

                MessageBox.Show($"Добавлено!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                Refresh();
                // Обновляем список книг для текущего жанра
                if (GenreSelectCB.SelectedItem != null)
                    ShowBooks();

                // Если есть текущий покупатель — обновляем для него
                if (currentCustomer != null)
                {
                    FillAvailableBooksComboBox(currentCustomer);
                }
                // Если текущего нет, но есть очередь — берём первого из очереди
                else if (GameManager.Instance.CustomersQueue.Count > 0)
                {
                    FillAvailableBooksComboBox(GameManager.Instance.CustomersQueue.Peek());
                }
                // Если очередь пуста — просто очищаем ComboBox
                else
                {
                    cmbAvailableBooks.Items.Clear();
                    cmbAvailableBooks.Items.Add("Нет покупателей в очереди");
                    cmbAvailableBooks.Enabled = false;
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        /// <summary>Генерирует книгу через библиотеку и заполняет форму.</summary>
        private void Generate()
        {
            // Если есть предыдущая сгенерированная книга, которую не сохранили — откатываем ID
            if (_currentGeneratedBook != null)
            {
                Book.DecrementCounter();
            }

            _currentGeneratedBook = Book.GenerateBook(GameManager.Instance.Store.GetAllBooks(), "");

            TitleTB.Text = _currentGeneratedBook.Title;
            AuthorTB.Text = _currentGeneratedBook.Author;
            GenreTB.Text = _currentGeneratedBook.Genre;
            PagesCountTB.Text = _currentGeneratedBook.Pages.ToString();
            PriceTB.Text = _currentGeneratedBook.Price.ToString("F2");
            ID_TB.Text = _currentGeneratedBook.id.ToString();

            MessageBox.Show($"Сгенерировано: {_currentGeneratedBook.Title}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            GameManager.Instance.Store.SellBook(id);
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

            GameManager.Instance.Store.ClearBookCase(g);
            if (SearchedBookGrid.SelectedRows.Count != 0) SearchedBookGrid.Rows.Clear();

            MessageBox.Show("Очищено", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refresh(); dataGridView1.Rows.Clear();
        }

        /// <summary>Ищет книгу по ID или названию.</summary>
        private void Search()
        {
            var q = FoundStringTB.Text.Trim();
            if (!Required(q, "Запрос")) return;

            var book = int.TryParse(q, out var id) ? GameManager.Instance.Store.FindBookById(id) : GameManager.Instance.Store.FindBookByTitle(q);

            SearchBooks(book);
        }

        //ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ

        private void ClearForm()
        {
            TitleTB.Clear(); AuthorTB.Clear(); GenreTB.Clear();
            PagesCountTB.Clear(); PriceTB.Clear();
            ID_TB.Text = "Авто"; TitleTB.Focus();
            _currentGeneratedBook = null;
        }

        private void Refresh()
        {
            BalanceL.Text = $"{GameManager.Instance.Store.Balance:F2} ₽";
            GenreSelectCB.Items.Clear();
            foreach (var g in GameManager.Instance.Store.GetAllGenres())
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

            if (string.IsNullOrEmpty(g))
            {
                dataGridView1.Rows.Clear();
                return;
            }

            try
            {
                dataGridView1.Rows.Clear();
                foreach (var b in GameManager.Instance.Store.GetBooksByGenre(g))
                {
                    var i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["colId"].Value = b.id;
                    dataGridView1.Rows[i].Cells["colTitle"].Value = b.Title;
                    dataGridView1.Rows[i].Cells["colAuthor"].Value = b.Author;
                    dataGridView1.Rows[i].Cells["colPrice"].Value = $"{b.Price:F2} ₽";
                }
            }
            catch (InvalidOperationException)
            {
                // Жанр не найден — просто очищаем таблицу
                dataGridView1.Rows.Clear();
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainForm = new MainMenu();
            mainForm.ShowDialog();
        }



        // ============= ПОКУПАТЕЛИ ================

        private Customer currentCustomer = null;
        private int gameTimer = 0;

        // Кнопка продать
        private void btnSellToCustomer_Click(object sender, EventArgs e)
        {
            if (currentCustomer == null)
            {
                MessageBox.Show("Нет покупателя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtSellPrice.Text, out double sellPrice))
            {
                MessageBox.Show("Введите корректную цену!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbAvailableBooks.SelectedItem == null || !cmbAvailableBooks.Enabled)
            {
                MessageBox.Show("Выберите книгу для продажи!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book bookToSell = cmbAvailableBooks.SelectedItem as Book;

            if (bookToSell == null)
            {
                MessageBox.Show("Книга не найдена!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentCustomer.MatchedBook(bookToSell, sellPrice);

            if (!currentCustomer.isHappy)
            {
                GameManager.Instance.UnhappyCustomersCount++;

                string reason = "Неподходящая книга или цена";
                double maxPrice = bookToSell.Price * 1.15;
                if (sellPrice > maxPrice)
                    reason = $"Цена {sellPrice:F2} ₽ > макс. {maxPrice:F2} ₽";
                else
                    reason = "Книга не соответствует запросу";

                MessageBox.Show(
                    $"Покупатель ушёл!\nПричина: {reason}",
                    "Отказ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (GameManager.Instance.UnhappyCustomersCount >= GameManager.Instance.maxUnhappyCustomres)
                {
                    GameOver(GameManager.Instance.LoseReason);
                    return;
                }

                currentCustomer = null;
                UpdateCustomerView();
                return;
            }

            GameManager.Instance.Store.SellBook(bookToSell.id);
            double profit = sellPrice - bookToSell.Price;
            GameManager.Instance.Store.Balance += profit;

            MessageBox.Show(
                $"Продано!\n" +
                $"Книга: «{bookToSell.Title}»\n" +
                $"Цена: {sellPrice:F2} ₽ | Прибыль: {profit:F2} ₽",
                "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            currentCustomer = null;
            UpdateCustomerView();
            Refresh();
        }

        // Кнопка отказать
        private void btnRejectCustomer_Click(object sender, EventArgs e)
        {
            if (currentCustomer == null)
            {
                MessageBox.Show("Нет покупателя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GameManager.Instance.UnhappyCustomersCount++;

            if (GameManager.Instance.UnhappyCustomersCount >= GameManager.Instance.maxUnhappyCustomres)
            {
                GameOver("Слишком много недовольных клиентов!");
                return;
            }

            // Переходим к следующему покупателю
            currentCustomer = null;
            UpdateCustomerView();
        }

        // Экран проигрыша
        private void GameOver(string reason)
        {
            GameManager.Instance.Lose = true;
            timeCustomer.Stop();

            if (GameManager.Instance.Win)
            {
                // ПОБЕДА
                MessageBox.Show(
                    $"ПОБЕДА!\n" +
                    $"Вы пережили день!\n" +
                    $"Финальный баланс: {GameManager.Instance.Store.Balance:F2} ₽\n" +
                    $"Недовольных: {GameManager.Instance.UnhappyCustomersCount}",
                    "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // ПРОИГРЫШ
                MessageBox.Show(
                    $"ИГРА ОКОНЧЕНА!\n" +
                    $"Причина: {reason}\n",
                    "Проигрыш", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // Возврат в главное меню
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        // Таймер
        private void timeCustomer_Tick(object sender, EventArgs e)
        {
            gameTimer++;

            if (GameManager.Instance.Lose || GameManager.Instance.Win)
            {
                timeCustomer.Stop();
                return;
            }

            GameManager.Instance.TimersUpdate(gameTimer);

            // Покупатели
            if (GameManager.Instance.CustomerArrived && GameManager.Instance.CustomersQueue.Count > 0)
            {
                UpdateCustomerView();
            }

            // Поставки
            if (GameManager.Instance.SuppliesArrived)
            {
                ProcessSupplyArrival();
            }

            UpdateCounters();
        }

        // Обновление отображения очереди и текущего покупателя
        private void UpdateCustomerView()
        {

            lstCustomersQueue.Items.Clear();
            foreach (var customer in GameManager.Instance.CustomersQueue)
            {
                string displayText = GetCustomerDisplayText(customer);
                lstCustomersQueue.Items.Add(displayText);
            }

            // Показываем/скрываем панель
            if (GameManager.Instance.CustomersQueue.Count == 0 && currentCustomer == null)
            {

                pnlCustomerArea.Visible = false;
                currentCustomer = null;
            }
            else
            {

                pnlCustomerArea.Visible = true;

                if (currentCustomer == null && GameManager.Instance.CustomersQueue.Count > 0)
                {
                    currentCustomer = GameManager.Instance.CustomersQueue.Dequeue();
                    ShowCurrentCustomer(currentCustomer);
                }
            }

            int totalCustomers = GameManager.Instance.CustomersQueue.Count;
            if (currentCustomer != null)
                totalCustomers++;

            if (GameManager.Instance.CheckCustomerLimit(totalCustomers))
            {
                GameOver(GameManager.Instance.LoseReason);
                return;
            }


            UpdateCounters();
        }

        // Получение текста для отображения покупателя
        private string GetCustomerDisplayText(Customer customer)
        {
            return $"{customer.RequestDisplayText}";
        }

        // Показать текущего покупателя
        private void ShowCurrentCustomer(Customer customer)
        {
            lblCustomerRequest.Text = customer.RequestDisplayText;
            FillAvailableBooksComboBox(customer);
            txtSellPrice.Clear();
        }

        // Заполнить ComboBox книгами
        private void FillAvailableBooksComboBox(Customer customer)
        {
            cmbAvailableBooks.Items.Clear();

            var allBooks = GameManager.Instance.Store.GetAllBooks();


            if (allBooks.Count > 0)
            {
                foreach (var book in allBooks)
                {
                    cmbAvailableBooks.Items.Add(book);
                }
                cmbAvailableBooks.Enabled = true;
            }
            else
            {
                cmbAvailableBooks.Items.Add("В магазине нет книг!");
                cmbAvailableBooks.Enabled = false;
            }

            cmbAvailableBooks.SelectedIndex = 0;
        }

        // Обновление счётчиков на верхней панели
        private void UpdateCounters()
        {
            int totalInQueue = GameManager.Instance.CustomersQueue.Count;

            if (currentCustomer != null)
            {
                totalInQueue++;
            }

            lblQueueCount.Text = $"{totalInQueue}/{GameManager.Instance.maxCustomersQueue}";
            lblUnhappyCount.Text = $"{GameManager.Instance.UnhappyCustomersCount}/{GameManager.Instance.maxUnhappyCustomres}";
        }

        // ============= ПОСТАВКИ ================

        // Показывает текущую книгу из очереди поставок
        private void ShowCurrentSupply()
        {
            if (GameManager.Instance.SuppliesQueue.Count == 0)
            {
                // Если очередь пуста - скрываем вкладку
                if (MainTC.TabPages.Contains(Supples))
                    MainTC.TabPages.Remove(Supples);
                return;
            }

            Supply currentSupply = GameManager.Instance.SuppliesQueue.Peek();

            // Заполняем поля информацией о книге
            txtSupplyTitle.Text = currentSupply.Book.Title;
            txtSupplyAuthor.Text = currentSupply.Book.Author;
            txtSupplyGenre.Text = currentSupply.Book.Genre;
            txtSupplyPages.Text = currentSupply.Book.Pages.ToString();
            txtSupplyPrice.Text = $"{currentSupply.Price:F2} ₽";

            // Устанавливаем RadioButton в зависимости от типа ошибки
            radioNoError.Checked = !currentSupply.HasError;
            radioPlagiath.Checked = currentSupply.HasError && currentSupply.ErrorType == "ПЛАГИАТ";
            radioTypo.Checked = currentSupply.HasError && currentSupply.ErrorType == "ОПЕЧАТКА";

            // Обновляем счетчик очереди
            lblSuppliesQueue.Text = $"В очереди поставок: {GameManager.Instance.SuppliesQueue.Count}";
        }


        // Проверяет появление новых поставок и показывает вкладку
        private void ProcessSupplyArrival()
        {
            if (GameManager.Instance.SuppliesQueue.Count > 0 && !MainTC.TabPages.Contains(Supples))
            {
                MainTC.TabPages.Add(Supples);
                ShowCurrentSupply();
            }
        }

        // Кнопка принять (книгу)
        private void btnAcceptSupply_Click(object sender, EventArgs e)
        {

        }

        // Кнопка отклонить (книгу)
        private void btnRejectSupply_Click(object sender, EventArgs e)
        {

        }
    }
}