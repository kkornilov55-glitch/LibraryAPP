using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClassLibrary;

namespace WinForms
{
    /// <summary>
    /// Главная форма приложения "Книжный магазин"
    /// Отвечает за отображение интерфейса, обработку пользовательского ввода и координацию с GameManager
    /// </summary>
    public partial class BookStoreF : Form
    {
        // ============================================================================
        // ПОЛЯ КЛАССА
        // ============================================================================

        /// <summary>
        /// Хранит ссылку на последнюю сгенерированную, но ещё не сохранённую книгу
        /// Используется для корректного управления счётчиком ID при отмене генерации
        /// </summary>
        private Book _currentGeneratedBook = null;


        // ============================================================================
        // КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ
        // ============================================================================

        /// <summary>
        /// Конструктор формы: инициализирует UI, подписывает события, запускает таймер
        /// </summary>
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


        // ============================================================================
        // ВАЛИДАЦИЯ ВВОДА
        // ============================================================================

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


        // ============================================================================
        // ОСНОВНЫЕ ДЕЙСТВИЯ: КНИГИ
        // ============================================================================

        /// <summary>
        /// Добавляет книгу в магазин по данным из формы
        /// Проверяет валидность ввода, баланс, уникальность названия, списывает средства
        /// </summary>
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
                // Проверка баланса перед покупкой
                if (GameManager.Instance.Store.Balance < pr)
                {
                    MessageBox.Show($"Недостаточно средств!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Списываем средства и добавляем книгу в магазин
                GameManager.Instance.Store.SubtractFromBalance(pr);
                GameManager.Instance.Store.AddBook(newBook);

                MessageBox.Show($"Добавлено!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                Refresh();

                // Обновляем список книг для текущего жанра
                if (GenreSelectCB.SelectedItem != null)
                    ShowBooks();

                // Обновляем ComboBox покупателя
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

            // Заполняем форму сгенерированными данными
            TitleTB.Text = _currentGeneratedBook.Title;
            AuthorTB.Text = _currentGeneratedBook.Author;
            GenreTB.Text = _currentGeneratedBook.Genre;
            PagesCountTB.Text = _currentGeneratedBook.Pages.ToString();
            PriceTB.Text = _currentGeneratedBook.Price.ToString("F2");
            ID_TB.Text = _currentGeneratedBook.id.ToString();

            MessageBox.Show($"Сгенерировано: {_currentGeneratedBook.Title}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Продаёт выделенную книгу через библиотеку (без покупателя).</summary>
        private void Sell()
        {
            if (dataGridView1.SelectedRows.Count == 0 && SearchedBookGrid.SelectedRows.Count == 0)
            {
                ShowWarning("Выберите книгу");
                return;
            }

            // Получаем ID книги из выделенной строки
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

        /// <summary>Очищает (продает все книги) шкаф выбранного жанра.</summary>
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


        // ============================================================================
        // ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ОТОБРАЖЕНИЯ
        // ============================================================================

        /// <summary> Очищает поля формы заказа книги </summary>
        private void ClearForm()
        {
            TitleTB.Clear(); AuthorTB.Clear(); GenreTB.Clear();
            PagesCountTB.Clear(); PriceTB.Clear();
            ID_TB.Text = "Авто"; TitleTB.Focus();
            _currentGeneratedBook = null;
        }

        /// <summary> Обновляет отображение баланса и списка жанров в интерфейсе </summary>
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

        /// <summary> Отображает книги выбранного жанра в DataGridView (вкладка Магазин) </summary>
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

        /// <summary> Отображает найденную книгу в отдельной таблице и переключает вкладку </summary>
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

        /// <summary> Возврат в главное меню </summary>
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainForm = new MainMenu();
            mainForm.ShowDialog();
        }



        // ============================================================================
        // ПОКУПАТЕЛИ
        // ============================================================================

        private Customer currentCustomer = null; // Текущий обслуживаемый покупатель
        private int gameTimer = 0; // Счётчик игрового времени (секунды)

        /// <summary>
        /// Кнопка продать: проверяет соответствие книги запросу, цену, обновляет баланс и статистику
        /// </summary>
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

            // Получаем объект книги из ComboBox (хранится как объект, не строка)
            Book bookToSell = cmbAvailableBooks.SelectedItem as Book;

            if (bookToSell == null)
            {
                MessageBox.Show("Книга не найдена!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем, доволен ли покупатель книгой и ценой
            currentCustomer.MatchedBook(bookToSell, sellPrice);

            if (!currentCustomer.isHappy)
            {
                // Покупатель недоволен: увеличиваем счётчик, показываем причину
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

                // Проверка условия проигрыша по недовольным клиентам
                if (GameManager.Instance.UnhappyCustomersCount >= GameManager.Instance.maxUnhappyCustomres)
                {
                    GameOver(GameManager.Instance.LoseReason);
                    return;
                }

                currentCustomer = null;
                UpdateCustomerView();
                return;
            }

            // Успешная продажа: обновляем баланс, удаляем книгу
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

        /// <summary>
        /// Кнопка отказать: увеличивает счётчик недовольных, переходит к следующему покупателю
        /// </summary>
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

        /// <summary>
        /// Экран завершения игры (победа или проигрыш)
        /// </summary>
        /// <param name="reason">Причина проигрыша</param>
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


        // ============================================================================
        // ТАЙМЕР ИГРЫ
        // ============================================================================

        /// <summary>
        /// Обработчик игрового таймера: обновляет события, проверяет приходы покупателей/поставок
        /// </summary>
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

        // ============================================================================
        // ОТОБРАЖЕНИЕ ПОКУПАТЕЛЕЙ
        // ============================================================================

        /// <summary>
        /// Обновляет отображение очереди и текущего покупателя на форме
        /// Также проверяет лимит очереди и завершает игру при превышении лимита
        /// </summary>
        private void UpdateCustomerView()
        {
            // Обновляем список очереди
            lstCustomersQueue.Items.Clear();
            foreach (var customer in GameManager.Instance.CustomersQueue)
            {
                string displayText = GetCustomerDisplayText(customer);
                lstCustomersQueue.Items.Add(displayText);
            }

            // Показываем/скрываем панель покупателя
            if (GameManager.Instance.CustomersQueue.Count == 0 && currentCustomer == null)
            {

                pnlCustomerArea.Visible = false;
                currentCustomer = null;
            }
            else
            {

                pnlCustomerArea.Visible = true;
              
                // Если нет текущего, но есть очередь — берём следующего
                if (currentCustomer == null && GameManager.Instance.CustomersQueue.Count > 0)
                {
                    currentCustomer = GameManager.Instance.CustomersQueue.Dequeue();
                    ShowCurrentCustomer(currentCustomer);
                }
            }

            UpdateCounters();

            // Проверка лимита покупателей (очередь + текущий)
            int totalCustomers = GameManager.Instance.CustomersQueue.Count;
            if (currentCustomer != null)
                totalCustomers++;

            if (GameManager.Instance.CheckCustomerLimit(totalCustomers))
            {
                GameOver(GameManager.Instance.LoseReason);
                return;
            }

        }

        /// <summary>
        /// Получение текста для отображения покупателя
        /// </summary>
        private string GetCustomerDisplayText(Customer customer)
        {
            return $"{customer.RequestDisplayText}";
        }

        /// <summary>
        /// Показывает текущего покупателя и заполняет ComboBox доступными книгами
        /// </summary>
        private void ShowCurrentCustomer(Customer customer)
        {
            lblCustomerRequest.Text = customer.RequestDisplayText;
            FillAvailableBooksComboBox(customer);
            txtSellPrice.Clear();
        }

        /// <summary>
        /// Заполняет ComboBox объектами книг из магазина для выбора покупателем
        /// </summary>
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

        /// <summary>
        /// Обновление счётчиков на верхней панели (очередь покупателей и недовольные клиенты)
        /// </summary>
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


        // ============================================================================
        // ПОСТАВКИ
        // ============================================================================
      
        /// <summary>
        /// Показывает текущую книгу из очереди поставок на вкладке "Поставки"
        /// Заполняет поля только для чтения, устанавливает RadioButton по типу ошибки
        /// </summary>
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

            // По умолчанию выбрано "Ошибок нет" — игрок сам меняет, если видит проблему
            radioNoError.Checked = true;
            radioPlagiath.Checked = false;
            radioTypo.Checked = false;

            // Обновляем счетчик очереди
            lblSuppliesQueue.Text = $"В очереди поставок: {GameManager.Instance.SuppliesQueue.Count}";
        }

        /// <summary>
        /// Проверяет появление новых поставок и автоматически показывает вкладку "Поставки"
        /// </summary>
        private void ProcessSupplyArrival()
        {
            if (GameManager.Instance.SuppliesQueue.Count > 0 && !MainTC.TabPages.Contains(Supples))
            {
                MainTC.TabPages.Add(Supples);
                ShowCurrentSupply();
            }
        }

        /// <summary>
        /// Кнопка принять (книгу)
        /// </summary>
        private void btnAcceptSupply_Click(object sender, EventArgs e)
        {
            if (GameManager.Instance.SuppliesQueue.Count == 0)
            {
                MessageBox.Show("Нет книг в очереди поставок!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Получаем текущую поставку
                Supply currentSupply = GameManager.Instance.SuppliesQueue.Peek();

                // Проверка баланса
                if (GameManager.Instance.Store.Balance < currentSupply.Price)
                {
                    MessageBox.Show($"Недостаточно средств! Нужно {currentSupply.Price:F2} ₽",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Определяем, что выбрал игрок (для передачи в метод)
                string userErrorType = null;
                if (radioPlagiath.Checked)
                    userErrorType = "ПЛАГИАТ";
                else if (radioTypo.Checked)
                    userErrorType = "ОПЕЧАТКА";


                // Вызываем метод обработки
                GameManager.Instance.SupplyProcessing(
                    currentSupply,
                    playerChoice: true,      // true = принять
                    errorType: userErrorType // что выбрал игрок
                );

                // Показываем результат на основе флагов
                if (GameManager.Instance.FineArrived)
                    MessageBox.Show($"Вы приняли книгу с ошибкой типа {currentSupply.ErrorType?.ToLower()}!\nШтраф: -{150} ₽",
                        "Штраф!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show($"Книга «{currentSupply.Book.Title}» принята и размещена на полке!",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Обновляем ComboBox покупателя
                if (currentCustomer != null)
                    FillAvailableBooksComboBox(currentCustomer);
                else if (GameManager.Instance.CustomersQueue.Count > 0)
                    FillAvailableBooksComboBox(GameManager.Instance.CustomersQueue.Peek());

                // Обновляем интерфейс
                ShowCurrentSupply();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Кнопка отклонить (книгу)
        /// </summary>
        private void btnRejectSupply_Click(object sender, EventArgs e)
        {
            if (GameManager.Instance.SuppliesQueue.Count == 0)
            {
                MessageBox.Show("Нет книг в очереди поставок!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Supply currentSupply = GameManager.Instance.SuppliesQueue.Peek();

                // Определяем, что выбрал игрок
                string userErrorType = null;
                if (radioPlagiath.Checked)
                    userErrorType = "ПЛАГИАТ";
                else if (radioTypo.Checked)
                    userErrorType = "ОПЕЧАТКА";

                // Вызываем метод обработки
                GameManager.Instance.SupplyProcessing(
                    currentSupply,
                    playerChoice: false,      // false = отклонить
                    errorType: userErrorType // что выбрал игрок
                );


                // Показываем результат
                if (GameManager.Instance.BonusArrived)
                {
                    // Правильно определил ошибку и отклонил
                    MessageBox.Show($"Отлично! Вы отклонили книгу с типом ошибки {currentSupply.ErrorType?.ToLower()} и получили бонус +{100} ₽",
                        "Бонус!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentSupply.HasError)
                {
                    // Книга с ошибкой, но игрок не выбрал правильный тип
                    if (userErrorType == null)
                    {
                        // Вообще не выбрал ошибку
                        MessageBox.Show($"Книга отклонена, но вы не заметили в ней тип ошибки {currentSupply.ErrorType?.ToLower()}. Бонус не начислен.",
                            "Отклонено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (userErrorType != currentSupply.ErrorType)
                    {
                        // Выбрал НЕ тот тип ошибки
                        MessageBox.Show($"Книга отклонена, но вы ошиблись с типом ошибки: это {currentSupply.ErrorType?.ToLower()}, а не {userErrorType?.ToLower()}. Бонус не начислен.",
                            "Отклонено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Книга без ошибок — просто отклонена
                    MessageBox.Show($"Книга «{currentSupply.Book.Title}» отклонена.",
                        "Отклонено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ShowCurrentSupply();
                Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}