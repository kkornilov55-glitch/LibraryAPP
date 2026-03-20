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
        public static int Difficulty;
        private static int maxCustomersQueue;
        private static int maxSuppliesQueue;
        private static int maxUnhappyCustomres;
        //Очереди и счётчики
        public static Queue<Customer> CustomersQueue;
        public static Queue<Supply> SuppliesQueue;
        public static int UnhappyCustomersCount = 0;

        //Флаги результатов игры, когда один из них true игра заканчивается
        public static bool Lose = false;
        public static bool Win = false;

        //Обработка появления поставки и покупателя
        private const int CustomerTimeArrive = 10;
        private const int SupplyTimeArrive = 15;
        public static bool CustomerArrived = false;
        public static bool SuppliesArrived = false;


        /// <summary>
        /// От сложности зависят пределы длинны очередей: покупателей, поставок и недовольных покупателей.
        /// </summary>
        /// <param name="Difficulty">Сложность: 0 - легкая, 1 - средняя, 2 - высокая.</param>
        public static void StartGame(int difficulty)
        {
            Store = new BookStore(5, 1000);

            Difficulty = difficulty;
            DifficultySettings();
            //....

        }
        private static void DifficultySettings()
        {
            if (Difficulty == 0)
            {
                maxCustomersQueue = 10;
                maxSuppliesQueue = 15;
                maxUnhappyCustomres = 5;
            }
            else if (Difficulty == 1)
            {
                maxCustomersQueue = 8;
                maxSuppliesQueue = 10;
                maxUnhappyCustomres = 3;
            }
            else
            {
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
            Customer customer = new Customer();

            //...

            return customer;
        }
        private static Supply GenerateRandomSupply()
        {
            Supply supply = new Supply();

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
