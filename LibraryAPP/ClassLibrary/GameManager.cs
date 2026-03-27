using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;

namespace ClassLibrary
{
    /// <summary>
    /// Класс, описывающий логику управления событиями игры. 
    /// </summary>
    public class GameManager
    {
        public static GameManager Instance { get; private set; }

        //Ссылка на магазин
        /// <summary>Ссылка на магазин с которым работает менеджер</summary>
        public BookStore Store;
        private DataBase DB;
        private static Random rnd = new Random();


        //Настройка сложности, установка ограничений
        private int Difficulty;
        /// <summary>Максимальное число покупателей в очереди</summary>
        public int maxCustomersQueue;
        /// <summary>Максимальное число поставок в очереди</summary>
        public int maxSuppliesQueue;
        /// <summary>Максимальное число недовольных покупателей</summary>
        public int maxUnhappyCustomres;
        /// <summary>Начальный баланс</summary>
        public int startBalance;


        //Очереди и счётчики
        /// <summary>Очередь покупателей</summary>
        public Queue<Customer> CustomersQueue;
        /// <summary>Очередь необработанных поставок</summary>
        public Queue<Supply> SuppliesQueue;
        /// <summary>Счётчик недовольных покупателей</summary>
        public int UnhappyCustomersCount = 0;


        //Флаги результатов игры, когда один из них true игра заканчивается
        /// <summary>Длинна дня (5 минут)</summary>
        public int DayLength = 300;
        /// <summary>Флаг поражения</summary>
        public bool Lose = false;
        /// <summary>Причина поражения</summary>
        public string LoseReason = string.Empty;
        /// <summary>Флаг победы</summary>
        public bool Win = false;


        //Обработка появления поставки и покупателя
        private int CustomerTimeArrive;
        private int SupplyTimeArrive;
        private const int Bonus = 100;
        /// <summary>Флаг бонуса</summary>
        public bool BonusArrived = false;
        private const int Fine = 150;
        /// <summary>Флаг штрафа</summary>
        public bool FineArrived = false;
        /// <summary>Флаг спавна покупателя</summary>
        public bool CustomerArrived = false;
        /// <summary>Флаг спавна поставки</summary>
        public bool SuppliesArrived = false;


        /// <summary>
        /// От сложности зависят пределы длинны очередей: покупателей, поставок и недовольных покупателей, а также частота прихода поставок и покупателей.
        /// По умолчанию, день длится 5 минут
        /// </summary>
        /// <param name="Difficulty">Сложность: 0 - легкая, 1 - средняя, 2 - высокая.</param>
        /// <param name="DayLength">Длинна дня (В секундах).</param>
        public void StartGame(int difficulty, int dayLength = 300)
        {
            Instance = this;
            
            //Инициализация очередей и базы данных
            CustomersQueue = new Queue<Customer>();
            SuppliesQueue = new Queue<Supply>();
            DB = new DataBase();
            DB.ReadFile();

            //Настройка сложности
            Difficulty = difficulty;
            DifficultySettings();

            Store = new BookStore(5, startBalance);

            //Установка длинны дня
            DayLength = dayLength;

        }
        private void DifficultySettings()
        {
            if (Difficulty == 0)
            {
                CustomerTimeArrive = 20;
                SupplyTimeArrive = 30;

                maxCustomersQueue = 10;
                maxSuppliesQueue = 15;
                maxUnhappyCustomres = 5;

                startBalance = 2500;
            }
            else if (Difficulty == 1)
            {
                CustomerTimeArrive = 15;
                SupplyTimeArrive = 20;

                maxCustomersQueue = 8;
                maxSuppliesQueue = 10;
                maxUnhappyCustomres = 3;

                startBalance = 1500;
            }
            else
            {
                CustomerTimeArrive = 8;
                SupplyTimeArrive = 10;

                maxCustomersQueue = 6;
                maxSuppliesQueue = 8;
                maxUnhappyCustomres = 1;

                startBalance = 1000;
            }
        }
        /// <summary>
        /// Основной метод для проверки событий, при вызове обновляет флаги спавна покупателей/поставок, добавляет их в очерерь, либо сообщает о завершении игры через флаги Win/Lose + LoseReason
        /// </summary>
        /// <param name="newTime">Текущее время по таймеру</param>
        public void TimersUpdate(int newTime)
        {
            //Стираем сведения о предыдущих событиях
            CustomerArrived = false;
            SuppliesArrived = false;
            
            //День пережит!
            if (DayLength == newTime)
            {
                Win = true;
                return;
            }

            //Поражения и причины
            //if (CustomersQueue.Count > maxCustomersQueue)
            //{
            //    Lose = true;
            //    LoseReason = "В очереди слишком много покупателей!";
            //    return;
            //}

            else if (SuppliesQueue.Count > maxSuppliesQueue)
            {
                Lose = true;
                LoseReason = "В очереди слишком много поставок!";
                return;
            }
            else if (UnhappyCustomersCount >= maxUnhappyCustomres)
            {
                Lose = true;
                LoseReason = "Слишком много недовольных покупателей";
                return;
            }

            //Проверяем пора ли приходить покупателям
            if (newTime % CustomerTimeArrive == 0)
            {
                //Создаем покупателя
                CustomerArrived = true;
                var Customer = GenerateRandomCustomer();

                CustomersQueue.Enqueue(Customer); //Добавляем покупателя в очередь
            }

            //Аналогично проверяем поставки
            if (newTime % SupplyTimeArrive == 0)
            {
                SuppliesArrived = true;
                var Supply = GenerateRandomSupply();

                SuppliesQueue.Enqueue(Supply);
            }
        }

       // Добавила проверку очереди тут отдельно, если что - пофикси, мне просто нужен был отдельный метод
        public bool CheckCustomerLimit(int totalCustomers)
        {
            if (totalCustomers > maxCustomersQueue)
            {
                Lose = true;
                LoseReason = "В очереди слишком много покупателей!";
                return true;
            }
            return false;
        }

        private Customer GenerateRandomCustomer()
        {
            Customer customer;

            Book wishBook = Book.GenerateBook(Store.GetAllBooks(), ""); Book.counter--;
            int wish = rnd.Next(2); //0 -> конкретная книга, 1 -> жанр

            switch(wish)
            {
                case 0:
                    customer = new Customer(wishBook.Title, wishBook.Author);
                    break;
                case 1:
                    customer = new Customer(wishBook.Genre);
                    break;
                default:
                    throw new InvalidOperationException("Ошибка: Неадекватный покупатель");
            }

            return customer;
        }
        private Supply GenerateRandomSupply()
        {         
            Book book = Book.GenerateBook(Store.GetAllBooks(), "");
            string[] randomBook = DB.GetRandomBook();
            book.Title = randomBook[0];
            book.Author = randomBook[1];

            //Будет ли ошибка?
            bool bookHasError = rnd.Next(2) == 0 ? false : true;
            string errorType = string.Empty;
            if (bookHasError)
            {
                book = GenerateRandomError(book, out errorType);

            }

            Supply supply = new Supply(book, false, book.Price, bookHasError,errorType);
            return supply;
        }
        private Book GenerateRandomError(Book book, out string errorType)
       {
            if (rnd.Next(2) == 0) //Опечатка
            {
                errorType = "ОПЕЧАТКА";
                if (rnd.Next(2) == 0) //В названии
                {
                    int chr = rnd.Next(0, book.Title.Length); //Индекс буквы
                    char[] chrs = book.Title.ToCharArray(); //Название книги -> массив символов
                    chrs[chr] = Convert.ToChar(rnd.Next(1, 50)); //Замена случайного символа
                    book.Title = new string(chrs); //Подменяем название
                }
                else //В авторе
                {
                    int chr = rnd.Next(0, book.Author.Length);
                    char[] chrs = book.Author.ToCharArray();
                    chrs[chr] = Convert.ToChar(rnd.Next(1, 50));
                    book.Author = new string(chrs);
                }
            }
            else //Плагиат
            {
                errorType = "ПЛАГИАТ";
                string newAuthor = book.Author;
                //while (newAuthor == book.Author)
                //{
                //    newAuthor = Book.GenerateBook(Store.GetAllBooks(), "").Author; Book.counter--;
                //}
                while (newAuthor == book.Author)
                    newAuthor = DB.GetRandomBook()[1];

                book.Author = newAuthor;
            }
            return book;
        }
        /// <summary>Продаёт книгу по цене покупки</summary>
        public void SellBookWithoutCustomer(Book book)
        {
            Store.SellBook(book.id);
        }
        /// <summary>
        /// Метод для продажи книги покупателю, убирает покупателя из очереди и продаёт книгу ему если она его устраивает, иначе не принимает и счётчик недовольных покупателей инкрементируется
        /// </summary>
        /// <param name="customer">Покупатель, которому продаётся книга</param>
        /// <param name="book">Продаваемая книга</param>
        /// <param name="price">Цена, по которой игрок желает продать книгу</param>
        public void SellToCustomer(Customer customer, Book book, double price)
        {
            //Customer targetCustomer = CustomersQueue.Dequeue();

            //Пробуем продать
            customer.MatchedBook(book, price);
            if (customer.isHappy) //Понравилась, принял
            {
                Store.Balance += price - book.Price; //Зачисляем наценку
                Store.SellBook(book.id); //Зачисляем цену книги
            }
            else //Не понравилась, не принял
            {
                UnhappyCustomersCount++;
                if (UnhappyCustomersCount > maxUnhappyCustomres)
                {
                    Lose = true;
                    return;
                }    
            }
        }

        /// <summary>
        /// Обрабатывает поставку: принимает или отклоняет книгу.
        /// Возвращает true, если поставка обработана и удалена из очереди.
        /// Возвращает false, если книга осталась в очереди (нет места на полке).
        /// </summary>
        /// <param name="supply">Обрабатываемая поставка</param>
        /// <param name="playerChoice">true = принять, false = отклонить</param>
        /// <param name="errorType">То какая ошибка, по мнению игрока. Виды(Что передавать): "ОПЕЧАТКА", "ПЛАГИАТ" (по умолчанию = null => не выделил ошибок)</param>
        /// <returns>True если книга обработана и удалена из очереди</returns>
        public void SupplyProcessing(Supply supply, bool playerChoice, string errorType)
        {
            FineArrived = false;
            BonusArrived = false;

            //Принимает поставку
            if (playerChoice)
            {
                try
                {
                    Store.SubtractFromBalance(supply.Price); //Списываем деньги
                    Store.AddBook(supply.Book); //Добавляем книгу

                    // Логика бонусов/штрафов для случайных поставок с ошибками
                    if (supply.HasError)
                    {
                        // Игрок не заметил ошибку => штраф
                        Store.Balance -= Fine;
                        FineArrived = true;
                    }

                    // Добавляем в БД только корректные книги (без ошибок)
                    if (!supply.HasError)
                    {
                        DB.AddBook(supply.Book);
                    }

                    //Поставка принята
                    SuppliesQueue.Dequeue();
                    return;
                }
                catch (InvalidOperationException)
                {
                    // Нет места на полке — возвращаем средства и НЕ удаляем из очереди
                    Store.Balance += supply.Price;
                    return; // Книга осталась в очереди
                }
            }
            else
            {
                //Игрок отклоняет книгу
                if (supply.HasError && supply.ErrorType == errorType)
                {
                    //Правильно отклонил книгу с ошибкой → бонус
                    Store.Balance += Bonus;
                    BonusArrived = true;
                }
                //Если отклонил нормальную книгу — просто теряем её

                SuppliesQueue.Dequeue();
                return; //Книга отклонена и удалена из очереди
            }

            ////Проверка случайной поставки
            //if (!supply.IsOrdered)
            //{
            //    //Какая-то проблема с книгой
            //    if (DB.IsMispell(supply.Book) || DB.IsPlagiarism(supply.Book))
            //    {
            //        if (playerChoice)
            //        {
            //            Store.Balance -= Fine;
            //            FineArrived = true;
            //        }
            //        else
            //        {
            //            Store.Balance += Bonus;
            //            BonusArrived = true;
            //        }
            //    }    
            //}

            //DB.AddBook(supply.Book); //Добавляем книгу в БД
            //SuppliesQueue.Dequeue(); //В результате обработки поставка выходит из очереди
        }
    }
}
