using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Класс "BookCase" представляет книжный шкаф с книгами определённого жанра.
    /// </summary>
    public class BookCase
    {
        private List<Book> books;
        public int capacity { get; private set; }
        public string genre { get; private set; }

        /// <summary>
        /// Конструктор: создаёт шкаф с указанным жанром и вместимостью.
        /// </summary>
        public BookCase(string Genre, int Capacity)
        {
            if (string.IsNullOrWhiteSpace(Genre))
                throw new ArgumentException("Жанр шкафа должен быть указан");

            if (Capacity <= 0)
                throw new ArgumentException("Вместимость должна быть больше нуля");

            this.genre = Genre;
            this.capacity = Capacity;
            books = new List<Book>();
        }

        /// <summary>
        /// Добавляет книгу в шкаф.
        /// </summary>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Невозможно добавить пустую книгу");

            if (books.Count >= capacity)
                throw new InvalidOperationException("Книжный шкаф полон");

            if (genre != book.Genre)
                throw new InvalidOperationException($"Нельзя добавить книгу жанра '{book.Genre}' в шкаф жанра '{genre}'");

            // ✅ Убрали вызов GetUniqueTitle — уникальность теперь обеспечивает BookStore
            books.Add(book);
        }

        /// <summary>
        /// Находит книгу по ID.
        /// </summary>
        public Book? FindById(int id)
        {
            foreach (var book in books)
                if (book.id == id)
                    return book;
            return null;
        }

        /// <summary>
        /// Находит книгу по названию.
        /// </summary>
        public Book? FindbyTitle(string title)
        {
            foreach (var book in books)
                if (book.Title == title)
                    return book;
            return null;
        }

        /// <summary>
        /// Удаляет книгу по ID.
        /// </summary>
        public void RemoveBook(int id)
        {
            var bookToRemove = FindById(id);
            if (bookToRemove != null)
                books.Remove(bookToRemove);
            else
                throw new InvalidOperationException($"Книга с id {id} не найдена");
        }

        /// <summary>
        /// Возвращает копию списка всех книг в шкафу.
        /// </summary>
        public List<Book> GetAllBooks() => new List<Book>(books);
    }
}