using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{

    /// <summary>
    /// Класс "BookCase" представляет собой книжный шкаф, который может содержать определенное количество книг.
    /// </summary>
    internal class BookCase
    {
        private List <Book> books;
        public int capacity {  get; private set; } 
        public string name { get; set; }

        /// <summary>
        /// Конструктор класса BookCase, инициализирует книжный шкаф с именем и вместимостью.
        /// </summary>
        public BookCase (string Name, int Capacity)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Имя книжного шкафа не может быть пустым или состоять только из пробелов.");
            }

            Name = name;
            Capacity = capacity;

            books = new List <Book> ();
        }

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
            books.Add (book);
        }



    }
}
