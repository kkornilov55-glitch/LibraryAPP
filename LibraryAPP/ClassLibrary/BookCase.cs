using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassLibrary
{

    /// <summary>
    /// Класс "BookCase" представляет собой книжный шкаф, который может содержать определенное количество книг.
    /// </summary>
    public class BookCase
    {
        private List<Book> books;
        public int capacity { get; private set; }
        public string genre { get; private set; }

        /// <summary>
        /// Конструктор класса BookCase, инициализирует книжный шкаф с именем и вместимостью.
        /// </summary>
        public BookCase(string Genre, int Capacity)
        {
            if (string.IsNullOrWhiteSpace(Genre))
            {
                throw new ArgumentException("Жанр шкафа должен быть указан");
            }

            this.genre = Genre;
            this.capacity = Capacity;

            books = new List<Book>();
        }

        /// <summary>
        /// Метод, который добавляет книгу в коллекцию books.
        /// </summary>
        public void AddBook(Book book)
        {
            if (books.Count >= capacity)
            {
                throw new InvalidOperationException("Книжный шкаф полон. Невозможно добавить новую книгу.");
            }

            if (book == null)
            {
                throw new ArgumentNullException("Невозможно добавить пустую книгу в книжный шкаф.");
            }

            if (genre != book.Genre)
            {
                throw new InvalidOperationException($"Невозможно добавить книгу жанра {book.Genre} в шкаф жанра {genre}.");
            }

            //book.Title = GetUniqueTitle(book.Title, book.Author);
            books.Add(book);
        }
        /// <summary>
        /// Метод для поиска книги по её id.
        /// </summary>
        public Book FindById(int id)
        {
            foreach (var i in books)
            {
                if (i.id == id)
                    return i;
            }

            return null;
        }

        public Book FindbyTitle(string title)
        {
            foreach (var i in books)
            {
                if (i.Title == title)
                    return i;
            }
            return null;
        }
        /// <summary>
        /// Метод для удаления книги.
        /// </summary>
        public void RemoveBook(int id)
        {
            Book bookToRemove = FindById(id);


            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }

            else
            {
                throw new InvalidOperationException($"Книга с id {id} не найдена в книжном шкафу.");
            }
        }

        /// <summary>
        /// Возвращает все книги в шкафу по порядку их добавления.
        /// </summary>
        public List<Book> GetAllBooks()
        {
            // Возвращаем копию списка, чтобы нельзя было его испортить
            return new List<Book>(books);
        }


    }
}
