using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ClassLibrary
{
    public class GameManager
    {
        //Ссылка на магазин
        private static BookStore Store;
        private static Random rnd = new Random();


        //Настройка сложности, установка ограничений
        private static int Difficulty;
        /// <summary>Максимальное число покупателей в очереди</summary>
        public static int maxCustomersQueue;
        /// <summary>Максимальное число поставок в очереди</summary>
        public static int maxSuppliesQueue;
        /// <summary>Максимальное число недовольных покупателей</summary>
        public static int maxUnhappyCustomres;


        //Очереди и счётчики
        /// <summary>Очередь покупателей</summary>
        public static Queue<Customer> CustomersQueue;
        /// <summary>Очередь необработанных поставок</summary>
        public static Queue<Supply> SuppliesQueue;
        /// <summary>Счётчик недовольных покупателей</summary>
        public static int UnhappyCustomersCount = 0;


        //Флаги результатов игры, когда один из них true игра заканчивается
        /// <summary>Длинна дня (5 минут)</summary>
        public const int DayLength = 300;
        /// <summary>Флаг поражения</summary>
        public static bool Lose = false;
        /// <summary>Причина поражения</summary>
        public static string LoseReason = string.Empty;
        /// <summary>Флаг победы</summary>
        public static bool Win = false;


        //Обработка появления поставки и покупателя
        private static int CustomerTimeArrive;
        private static int SupplyTimeArrive;
        /// <summary>Флаг спавна покупателя</summary>
        public static bool CustomerArrived = false;
        /// <summary>Флаг спавна поставки</summary>
        public static bool SuppliesArrived = false;


        /// <summary>
        /// От сложности зависят пределы длинны очередей: покупателей, поставок и недовольных покупателей, а также частота прихода поставок и покупателей.
        /// </summary>
        /// <param name="Difficulty">Сложность: 0 - легкая, 1 - средняя, 2 - высокая.</param>
        public static void StartGame(int difficulty)
        {
            Store = new BookStore(5, 1000);

            // вот здесь вот добавила инициализацию очереди
            CustomersQueue = new Queue<Customer>();
            SuppliesQueue = new Queue<Supply>();
            UnhappyCustomersCount = 0;

            Difficulty = difficulty;
            DifficultySettings();

        }
        private static void DifficultySettings()
        {
            if (Difficulty == 0)
            {
                CustomerTimeArrive = 20;
                SupplyTimeArrive = 30;

                maxCustomersQueue = 10;
                maxSuppliesQueue = 15;
                maxUnhappyCustomres = 5;
            }
            else if (Difficulty == 1)
            {
                CustomerTimeArrive = 15;
                SupplyTimeArrive = 20;

                maxCustomersQueue = 8;
                maxSuppliesQueue = 10;
                maxUnhappyCustomres = 3;
            }
            else
            {
                CustomerTimeArrive = 8;
                SupplyTimeArrive = 10;

                maxCustomersQueue = 6;
                maxSuppliesQueue = 8;
                maxUnhappyCustomres = 1;
            }
        }
        /// <summary>
        /// Основной метод для проверки событий, при вызове обновляет флаги спавна покупателей/поставок, добавляет их в очерерь, либо сообщает о завершении игры через флаги Win/Lose + LoseReason
        /// </summary>
        /// <param name="newTime">Текущее время по таймеру</param>
        public static void TimersUpdate(int newTime)
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
            if (CustomersQueue.Count > maxCustomersQueue)
            {
                Lose = true;
                LoseReason = "В очереди слишком много покупателей!";
                return;
            }
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
        private static Customer GenerateRandomCustomer()
        {
            Customer customer;
            Book wishBook = Book.GenerateBook(Store.GetAllBooks(), "");
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
        private static Supply GenerateRandomSupply()
        {         
            Book book = Book.GenerateBook(Store.GetAllBooks(), "");

            //Будет ли ошибка?
            bool bookHasError;
            //Тип ошибки
            string errorType = string.Empty;
            if (rnd.Next(2) == 0)
            {
                bookHasError = false;
                
            }    
            else
            {
                book = GenerateRandomError(book, out errorType);
                bookHasError = true;
            }

            Supply supply = new Supply(book, false, book.Price, bookHasError, errorType);

            return supply;
        }
        private static Book GenerateRandomError(Book book, out string errorType)
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
                while (newAuthor == book.Author)
                {
                    newAuthor = Book.GenerateBook(Store.GetAllBooks(), "").Author;
                }
                book.Author = newAuthor;
            }
            return book;
        }
        /// <summary>Продаёт книгу по цене покупки</summary>
        public static void SellBookWithoutCustomer(Book book)
        {
            Store.SellBook(book.id);
        }
        /// <summary>
        /// Метод для продажи книги покупателю, убирает покупателя из очереди и продаёт книгу ему если она его устраивает, иначе не принимает и счётчик недовольных покупателей инкрементируется
        /// </summary>
        /// <param name="customer">Покупатель, которому продаётся книга</param>
        /// <param name="book">Продаваемая книга</param>
        /// <param name="price">Цена, по которой игрок желает продать книгу</param>
        public static void SellToCustomer(Customer customer, Book book, double price)
        {
            Customer targetCustomer = CustomersQueue.Dequeue();

            //Пробуем продать
            targetCustomer.MatchedBook(book, price);
            if (targetCustomer.isHappy) //Понравилась, принял
            {
                Store.Balance += price - book.Price; //Зачисляем наценку
                Store.SellBook(book.id); //Зачисляем цену книги
            }
            else //Не понравилась, не принял
            {
                UnhappyCustomersCount++;
            }
        }
    }
}
