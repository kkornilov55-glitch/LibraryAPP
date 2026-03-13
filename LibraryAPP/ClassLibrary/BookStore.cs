using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Класс "BookStore" представляет книжный магазин.
    /// </summary>
    public class BookStore
    {
        private List<BookCase> bookCases;
        public int MaxBookCases { get; private set; }
        public double Balance { get; private set; }

        public BookStore(int maxBookCases)
        {
            if (maxBookCases <= 0)
                throw new ArgumentException("Максимальное количество шкафов должно быть больше нуля");

            MaxBookCases = maxBookCases;
            bookCases = new List<BookCase>();
            Balance = 0.0;
        }

        /// <summary>
        /// Добавляет шкаф с указанным жанром.
        /// </summary>
        public void AddBookCase(string genre, int capacity)
        {
            foreach (var bc in bookCases)
                if (bc.genre == genre)
                    throw new InvalidOperationException($"Шкаф с жанром '{genre}' уже существует");

            if (bookCases.Count >= MaxBookCases)
                throw new InvalidOperationException($"Достигнут лимит шкафов ({MaxBookCases})");

            bookCases.Add(new BookCase(genre, capacity));
        }

        /// <summary>
        /// Добавляет книгу в магазин.
        /// </summary>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            BookCase? targetCase = null;
            foreach (var bc in bookCases)
            {
                if (bc.genre == book.Genre)
                {
                    targetCase = bc;
                    break;
                }
            }

            if (targetCase == null)
            {
                if (bookCases.Count >= MaxBookCases)
                    throw new InvalidOperationException($"Нет места для нового жанра '{book.Genre}'.");

                AddBookCase(book.Genre, 10);

                foreach (var bc in bookCases)
                {
                    if (bc.genre == book.Genre)
                    {
                        targetCase = bc;
                        break;
                    }
                }
            }

            // ✅ Просто добавляем книгу (уникальность уже обеспечена в AddBook(string, ...))
            targetCase.AddBook(book);
        }

        /// <summary>
        /// Добавляет книгу по параметрам (создаёт объект внутри библиотеки).
        /// </summary>
        public void AddBook(string title, string author, string genre, int pages, double price)
        {
            // Генерируем уникальное название
            string uniqueTitle = GenerateUniqueTitle(title, author);

            // Создаём книгу
            var book = new Book(uniqueTitle, author, genre, pages, price);

            // Добавляем через основной метод
            AddBook(book);
        }

        /// <summary>
        /// Генерирует уникальное название книги.
        /// </summary>
        private string GenerateUniqueTitle(string title, string author)
        {
            string uniqueTitle = title;
            int counter = 2;

            var allBooks = GetAllBooks();

            while (allBooks.Any(b => b.Title == uniqueTitle && b.Author == author))
            {
                uniqueTitle = $"{title} {counter}";
                counter++;
            }

            return uniqueTitle;
        }

        /// <summary>
        /// Продаёт книгу по ID.
        /// </summary>
        public void SellBook(int bookId)
        {
            var book = FindBookById(bookId);
            if (book == null)
                throw new InvalidOperationException($"Книга с ID {bookId} не найдена");

            foreach (var bookCase in bookCases)
                if (bookCase.FindById(bookId) != null)
                {
                    Balance += book.Sell();
                    bookCase.RemoveBook(bookId);
                    return;
                }
        }

        /// <summary>
        /// Находит книгу по ID.
        /// </summary>
        public Book? FindBookById(int id)
        {
            foreach (var bookCase in bookCases)
            {
                var found = bookCase.FindById(id);
                if (found != null)
                    return found;
            }
            return null;
        }

        /// <summary>
        /// Находит книгу по названию.
        /// </summary>
        public Book? FindBookByTitle(string title)
        {
            foreach (var bookCase in bookCases)
            {
                var found = bookCase.FindbyTitle(title);
                if (found != null)
                    return found;
            }
            return null;
        }

        /// <summary>
        /// Возвращает все книги в магазине.
        /// </summary>
        public List<Book> GetAllBooks()
        {
            var allBooks = new List<Book>();
            foreach (var bookCase in bookCases)
                allBooks.AddRange(bookCase.GetAllBooks());
            return allBooks;
        }

        /// <summary>
        /// Возвращает книги указанного жанра.
        /// </summary>
        public List<Book> GetBooksByGenre(string genre)
        {
            BookCase? bookCase = null;
            foreach (var bc in bookCases)
                if (bc.genre == genre)
                {
                    bookCase = bc;
                    break;
                }

            if (bookCase == null)
                throw new InvalidOperationException($"Шкаф с жанром '{genre}' не найден");

            return bookCase.GetAllBooks();
        }

        /// <summary>
        /// Возвращает список всех жанров.
        /// </summary>
        public List<string> GetAllGenres()
        {
            var genres = new List<string>();
            foreach (var bc in bookCases)
                genres.Add(bc.genre);
            return genres;
        }

        /// <summary>
        /// Очищает шкаф: продаёт все книги и удаляет шкаф.
        /// </summary>
        public void ClearBookCase(string genre)
        {
            BookCase? bookCase = null;
            foreach (var bc in bookCases)
                if (bc.genre == genre)
                {
                    bookCase = bc;
                    break;
                }

            if (bookCase == null)
                throw new InvalidOperationException($"Шкаф с жанром '{genre}' не найден");

            foreach (var book in bookCase.GetAllBooks())
                Balance += book.Sell();

            bookCases.Remove(bookCase);
        }
    }
}