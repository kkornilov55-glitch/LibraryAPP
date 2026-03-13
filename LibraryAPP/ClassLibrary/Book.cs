using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Класс книги.
    /// </summary>
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
        /// Конструктор для создания книги.
        /// </summary>
        public Book(string title, string author, string genre, int pages, double price)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title), "Название не может быть пустым");
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentNullException(nameof(author), "Автор не может быть пустым");
            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentNullException(nameof(genre), "Жанр не может быть пустым");
            if (pages <= 0)
                throw new ArgumentException("Страницы должны быть > 0", nameof(pages));
            if (price <= 0)
                throw new ArgumentException("Цена должна быть > 0", nameof(price));

            id = ++counter;
            Title = title;
            Author = author;
            Genre = genre;
            Pages = pages;
            Price = price;
        }

        /// <summary>
        /// Генерирует случайную книгу и возвращает её.
        /// </summary>
        /// <summary>
        /// Генерирует случайную книгу и возвращает её.
        /// Если жанр не указан — выбирает случайный из списка.
        /// </summary>
        public static Book GenerateBook(List<Book> existingBooks, string genre)
        {
            // Списки для генерации
            string[] authors = { "Л. Толстой", "Ф. Достоевский", "А. Чехов", "И. Тургенев", "Стивен Кинг", "Джоан Роулинг" };
            string[] titles = { "Война и мир", "Преступление и наказание", "Вишнёвый сад", "Отцы и дети", "Тёмная башня", "Гарри Поттер" };
            string[] genres = { "Фантастика", "Детектив", "Роман", "Фэнтези", "Триллер", "Драма", "Приключения" };

            var random = new Random();

            // ✅ Если жанр не передан или пустой — выбираем случайный
            string randomGenre = string.IsNullOrWhiteSpace(genre)
                ? genres[random.Next(genres.Length)]
                : genre;

            // Генерируем уникальное название
            string finalTitle;
            do
            {
                finalTitle = titles[random.Next(titles.Length)] + " " + random.Next(1, 100);
            } while (existingBooks?.Any(b => b.Title == finalTitle) == true);

            // Генерируем остальные параметры
            string randomAuthor = authors[random.Next(authors.Length)];
            int randomPages = random.Next(100, 1000);
            double randomPrice = Math.Round(random.NextDouble() * 900 + 100, 2);

            return new Book(finalTitle, randomAuthor, randomGenre, randomPages, randomPrice);
        }

        /// <summary>
        /// Продаёт книгу и возвращает цену.
        /// </summary>
        public double Sell() => Price;

        /// <summary>
        /// Сравнивает данные книги с параметрами.
        /// </summary>
        public bool HasSameDataAs(string title, string author, string genre, int pages, double price) =>
            Title == title && Author == author && Genre == genre &&
            Pages == pages && Math.Abs(Price - price) < 0.01;
    }
}