using System;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;


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

        private static int counter = 0;



        /// <summary>
        /// Конструктор, для ручного создания книг
        /// </summary>
        public Book(string title, string author, string genre, int pages, double price)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Название книги не может быть пустым");
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentNullException(nameof(author), "Автор не может быть пустым.");
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
        public static Book GenerateBook(List<Book> ExistingBooks, string genre) //список ExistingBooks должен содержать в себе все созданные книги.
                                                                                //он будет заполняться в классе реализующем логику книжного шкафа

        {
            Random rng = new Random();

            string rawTitle = GetRandomTitle();
            string finalTitle = titleHandler(rawTitle, ExistingBooks);
             
            int RandomPages = rng.Next(50, 500);
            double RandomPrice = rng.Next(300, 1500);
            string RandomAuthor = GetrandomAuthor();

            return new Book(finalTitle, RandomAuthor, genre, RandomPages, RandomPrice); // Вызов конструктора для создания книги, на основе случайных значений
        }

        /// <summary>
        /// Метод для получения случайного названия книги из заранее определенного списка
        /// </summary>
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

                }
                if (titles.Count == 0)
                    return "Файл пустой";

                Random rng = new Random();

                return titles[rng.Next(titles.Count)]; // Возвращаем случайное название из списка

            }

            catch (Exception ex)
            {
                return $"Ошибка при чтении файла: {ex.Message}";
            }  
        }

        private static string GetrandomAuthor()
        {
           string[] authors = new string[] {"Стивен Кинг", "Михаил Булгаков", "Федор Достоевский", "Уильям Шекспир", "Лев Толстой", "Джордж Оруэлл", "Джоан Роулинг", "Николай Гоголь", "Александр Пушкин", "Эрих Мария Ремарк"};
            Random rng = new Random();
            return authors[rng.Next(authors.Length)]; // Возвращаем случайного автора из массива
        }

        private static string titleHandler(string rawTitle, List<Book> ExistingBooks)
        {
            int count = 0;

            foreach (Book i in ExistingBooks)
            {
                if (i.Title.StartsWith(rawTitle))
                {
                    count++;
                }
            }

            if(count > 0)
             {
                return $"{rawTitle} {count + 1}";
             }

            else
            {
                return rawTitle;
            }  
        }
        /// <summary>
        /// Метод, продажи книги. При вызове возвращает стоимость книги.
        /// </summary>
        public double Sell()
        {
            return Price;
        }
    }
}