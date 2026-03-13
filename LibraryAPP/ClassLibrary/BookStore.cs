using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Класс "BookStore" представляет книжный магазин с определённым количеством шкафов и балансом.
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
        /// Добавляет новый книжный шкаф в магазин.
        /// </summary>
        public void AddBookCase(string genre, int capacity)
        {
            // Проверка: шкаф с таким жанром уже существует
            foreach (var bc in bookCases)
            {
                if (bc.genre == genre)
                    throw new InvalidOperationException($"Шкаф с жанром '{genre}' уже существует.");
            }

            // Проверка: достигнут лимит шкафов
            if (bookCases.Count >= MaxBookCases)
                throw new InvalidOperationException($"Достигнуто максимальное количество шкафов ({MaxBookCases}).");

            bookCases.Add(new BookCase(genre, capacity));
        }

        /// <summary>
        /// Добавляет книгу в магазин (в соответствующий шкаф по жанру).
        /// </summary>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            // Поиск шкафа с подходящим жанром
            BookCase targetCase = null;
            foreach (var bc in bookCases)
            {
                if (bc.genre == book.Genre)
                {
                    targetCase = bc;
                    break;
                }
            }

            // Если шкаф не найден — создаём новый (если есть место)
            if (targetCase == null)
            {
                if (bookCases.Count >= MaxBookCases)
                    throw new InvalidOperationException($"Нет места для нового жанра '{book.Genre}'.");

                AddBookCase(book.Genre, 10);

                // Повторный поиск только что созданного шкафа
                foreach (var bc in bookCases)
                {
                    if (bc.genre == book.Genre)
                    {
                        targetCase = bc;
                        break;
                    }
                }
            }

            targetCase.AddBook(book);
        }

        /// <summary>
        /// Продаёт книгу по ID и обновляет баланс.
        /// </summary>
        public void SellBook(int bookId)
        {
            Book book = FindBookById(bookId);
            if (book == null)
                throw new InvalidOperationException($"Книга с ID {bookId} не найдена.");

            // Поиск и удаление книги из соответствующего шкафа
            foreach (var bookCase in bookCases)
            {
                if (bookCase.FindById(bookId) != null)
                {
                    Balance += book.Sell();
                    if (bookCase.GetAllBooks().Count == 1) //Если последняя книга в шкафу избавляемя от шкафа
                    {
                        bookCases.Remove(bookCase);
                        return;
                    }
                    else
                        bookCase.RemoveBook(bookId);
                    return;
                }
            }
        }

        /// <summary>
        /// Находит книгу по ID во всех шкафах.
        /// </summary>
        public Book FindBookById(int id)
        {
            foreach (var bookCase in bookCases)
            {
                Book found = bookCase.FindById(id);
                if (found != null)
                    return found;
            }
            return null;
        }

        /// <summary>
        /// Находит книгу по названию.
        /// </summary>
        public Book FindBookByTitle(string title)
        {
            foreach (var bookCase in bookCases)
            {
                Book found = bookCase.FindbyTitle(title);
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
            List<Book> allBooks = new List<Book>();
            foreach (var bookCase in bookCases)
                allBooks.AddRange(bookCase.GetAllBooks());
            return allBooks;
        }

        /// <summary>
        /// Возвращает книги определённого жанра.
        /// </summary>
        public List<Book> GetBooksByGenre(string genre)
        {
            BookCase bookCase = null;
            foreach (var bc in bookCases)
            {
                if (bc.genre == genre)
                {
                    bookCase = bc;
                    break;
                }
            }

            if (bookCase == null)
                throw new InvalidOperationException($"Шкаф с жанром '{genre}' не найден.");

            return bookCase.GetAllBooks();
        }

        /// <summary>
        /// Возвращает список всех жанров в магазине.
        /// </summary>
        public List<string> GetAllGenres()
        {
            List<string> genres = new List<string>();
            foreach (var bc in bookCases)
            {
                if (bc.GetAllBooks().Count != 0)
                    genres.Add(bc.genre);
            }
                
            return genres;
        }

        /// <summary>
        /// Очищает шкаф (продаёт все книги и освобождает место).
        /// </summary>
        public void ClearBookCase(string genre)
        {
            BookCase bookCase = null;
            foreach (var bc in bookCases)
            {
                if (bc.genre == genre)
                {
                    bookCase = bc;
                    break;
                }
            }

            if (bookCase == null)
                throw new InvalidOperationException($"Шкаф с жанром '{genre}' не найден.");

            // Продажа всех книг из шкафа
            foreach (var book in bookCase.GetAllBooks())
                Balance += book.Sell();

            bookCases.Remove(bookCase);

        }
        //public void AddBook(string title, string author, string genre, int pages, double price)
        //{
        //    // Создаём книгу внутри библиотеки — не в форме
        //    var book = new Book(title, author, genre, pages, price);
        //    AddBook(book);
        //}
    }   
}