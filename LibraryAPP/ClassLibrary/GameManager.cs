using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class GameManager
    {
        //Ссылка на магазин
        public static BookStore Store;

        //Настройка сложности, установка ограничений
        private static int Difficulty;
        public static int maxCustomersQueue;
        public static int maxSuppliesQueue;
        public static int maxUnhappyCustomres;
        //Очереди и счётчики
        public static Queue<Customer> CustomersQueue;
        public static Queue<Supply> SuppliesQueue;
        public static int UnhappyCustomersCount = 0;

        //Флаги результатов игры, когда один из них true игра заканчивается
        public static bool Lose = false;
        public static bool Win = false;

        //Обработка появления поставки и покупателя
        private static int CustomerTimeArrive;
        private static int SupplyTimeArrive;
        public static bool CustomerArrived = false;
        public static bool SuppliesArrived = false;

        private static Random rnd = new Random();


        /// <summary>
        /// От сложности зависят пределы длинны очередей: покупателей, поставок и недовольных покупателей.
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
        public static void TimersUpdate(int newTime)
        {
            //Стираем сведения о предыдущих событиях
            CustomerArrived = false;
            SuppliesArrived = false;

            if (newTime % CustomerTimeArrive == 0)
            {
                //Создаем покупателя
                CustomerArrived = true;
                var Customer = GenerateRandomCustomer();

                CustomersQueue.Enqueue(Customer); //Добавляем покупателя в очередь
                if (CustomersQueue.Count > maxCustomersQueue)
                {
                    Lose = true;
                    return;
                }
            }

            if (newTime % SupplyTimeArrive == 0)
            {
                SuppliesArrived = true;
                var Supply = GenerateRandomSupply();

                SuppliesQueue.Enqueue(Supply);
                if (SuppliesQueue.Count > maxSuppliesQueue)
                {
                    Lose = true;
                    return;
                }
            }
        }
        private static Customer GenerateRandomCustomer()
        {
            //...

            Customer customer;
            int wish = rnd.Next(2); //0 -> конкретная книга, 1 -> жанр

            switch(wish)
            {
                case 0:
                    customer = new Customer("Название книги", "Автор книги");
                    break;
                case 1:
                    customer = new Customer("Жанр");
                    break;
                default:
                    throw new InvalidOperationException("Ошибка: Не адекватный покупатель");
            }

            return customer;
        }
        private static Supply GenerateRandomSupply()
        {         
            Book book = Book.GenerateBook(Store.GetAllBooks(), "");

            bool bookHasError;
            if (rnd.Next(2) == 0)
                bookHasError = false;
            else
                bookHasError = true;

            //...

            Supply supply = new Supply(book, false, book.Price, true, "Plagiarism");

            //...

            return supply;
        }
        public static void SellBookWithoutCustomer(Book book)
        {
            Store.SellBook(book.id);
        }
        public static void SellToCustomer(Customer customer, Book book, double price)
        {

        }


    }
}
