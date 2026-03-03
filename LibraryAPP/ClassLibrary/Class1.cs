using System;
using System.Dynamic;
using System.Reflection;
using System.IO;

namespace ClassLibrary
{
    public class Book
    {

        public string Title { get; private set; }
        public string Author { get; private set; }
        public int id { get; private set; }
        public string Genre { get; private set; }
        public int Pages { get; private set; }
        public double Price { get; private set; }

        private int counter = 0;



        /// <summary>
        /// Конструктор, для ручного создания книг
        /// </summary>
        public Book(string title, string author, string genre, int pages, double price)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentNullException("Название книги или автор не могут быть пустыми");
            }
            id = ++counter;
            Title = title;
            Author = author;
            Genre = genre;
            Pages = pages;
            Price = price;
        }

        /// <summary>
        /// Статический метод, случайно генерирующий книгу.
        /// Принадлежит самому классу а не конкретной книге т.е. создает новую книгу без привязки к существующей
        /// </summary>
        public static Book GenerateBook(List<Book> ExistingBooks, string genre)
        {
            Random rng = new Random();

            string rawTitle = GetRandomTitle();
            string finalTitle = titleHandler();

            int RandomPages = rng.Next(50, 500);
            double RandomPrice = rng.Next(300, 1500);
            string RandomAuthor = GetrandomAuthor();

            return new Book(finalTitle, RandomAuthor, genre, RandomPages, RandomPrice); // Вызов конструктора для создания книги, на основе случайных значений
        }

        static private string GetRandomTitle()
        {
            string FilePath = "title.txt"; // Путь к файлу с названиями книг
            List<string> titles = new List<string>(); // Список для хранения названий книг

            try
            {

                if (!File.Exists(FilePath))
                    return "Файл не найден";

                using (StreamReader file = new StreamReader(FilePath)) //using чтобы файл автоматически закрывался после использования
                {
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            titles.Add(line.Trim());

                        }
                    }

                    if (titles.Count == 0)
                        return "Файл пустой";

                }


            }
        }
    }
}


        




