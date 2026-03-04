using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    internal class BookCase
    {
        private List <Book> books;
        public int capacity {  get; private set; } 
        public string name { get; set; }

        public BookCase (string Name, int Capacity)
        {
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
