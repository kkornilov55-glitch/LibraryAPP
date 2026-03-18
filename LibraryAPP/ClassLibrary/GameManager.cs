using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    internal class GameManager
    {
        public static BookStore Store;
        public static Queue<Customer> CustomersQueue;
        public static Queue<Supply> SuppliesQueue;
        public static int UnhappyCustomersCount = 0;

        public static int Difficulty;
        private static int maxCustomersQueue;
        private static int maxSuppliesQueue;
        private static int maxUnhappyCustomres;

        public static int CustomersTimer;
        public static int SuppliesTimer;

        public static bool Lose = false;

        /// <summary>
        /// От сложности зависят пределы длинны очередей: покупателей, поставок и недовольных покупателей.
        /// </summary>
        /// <param name="Difficulty">Сложность: 0 - легкая, 1 - средняя, 2 - высокая.</param>
        public static void StartGame(int difficulty)
        {
            Store = new BookStore(5, 1000);

            Difficulty = difficulty;
            DifficultySettings();
            

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
    }
}
