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

        public string Title { get; set; }
        public string Author { get; private set; }
        public int id { get; private set; }
        public string Genre { get; private set; }
        public int Pages { get; private set; }
        public double Price { get; private set; }

        public static int counter = 0;



        /// <summary>
        /// Конструктор для ручного создания книг
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
            string RandomAuthor = GetrandomAuthor();
            string rawTitle = GetRandomTitle();
            string finalTitle = titleHandler(rawTitle,RandomAuthor, ExistingBooks);

            int RandomPages = rng.Next(50, 500);
            double RandomPrice = rng.Next(300, 1500);
            string RandomGenre = GetRandomGenre();

            // Вызов конструктора для создания книги, на основе случайных значений
            var book = new Book(finalTitle, RandomAuthor, RandomGenre, RandomPages, RandomPrice);
            BookStore.PendingBook = book;
            return book;
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
            string[] authors = new string[] { "Стивен Кинг", "Михаил Булгаков", "Федор Достоевский", "Уильям Шекспир", "Лев Толстой", "Джордж Оруэлл", "Джоан Роулинг", "Николай Гоголь", "Александр Пушкин", "Эрих Мария Ремарк" };
            Random rng = new Random();
            return authors[rng.Next(authors.Length)]; // Возвращаем случайного автора из массива
        }

        private static string GetRandomGenre()
        {
            string[] genres = new string[] { "Фэнтези", "Детектив", "Триллер", "Научная фантастика", "Роман", "Драма" };
            Random rng = new Random();
            return genres[rng.Next(genres.Length)];
        }

        private static string titleHandler(string rawTitle, string RandomAuthor, List<Book> ExistingBooks)
        {
            return EnsureUniqueTitle(rawTitle, RandomAuthor, ExistingBooks);
        }

        /// <summary>
        /// Метод, продажи книги. При вызове возвращает стоимость книги.
        /// </summary>
        public double Sell()
        {
            return Price;
        }

        /// <summary>
        /// Проверяет уникальность названия и добавляет цифру при дублировании.
        /// </summary>
        public static string EnsureUniqueTitle(string title, string author, List<Book> existingBooks)
        {
            // Собираем все использованные номера для этого названия и автора
            List<int> usedNumbers = new List<int>();

            foreach (Book book in existingBooks)
            {
                // Проверяем только книги того же автора и с похожим названием
                if (book.Author == author && book.Title.StartsWith(title))
                {
                    // Извлекаем суффикс после базового названия
                    string suffix = book.Title.Substring(title.Length).Trim();

                    if (string.IsNullOrEmpty(suffix))
                    {
                        // Это базовая книга без номера (считаем её как номер 1)
                        usedNumbers.Add(1);
                    }
                    else if (int.TryParse(suffix, out int number))
                    {
                        // Это книга с номером (например, "Вендиго 2" → number = 2)
                        usedNumbers.Add(number);
                    }
                }
            }

            // Ищем первый свободный номер, начиная с 1
            int newNumber = 1;
            while (usedNumbers.Contains(newNumber))
            {
                newNumber++;
            }

            // Если номер 1 не занят — возвращаем базовое название без суффикса
            // Иначе возвращаем название с найденным свободным номером
            return newNumber == 0 || (newNumber == 1 && !usedNumbers.Contains(0))
                ? title
                : $"{title} {newNumber}";
        }

    }
}