using System;
using System.Reflection;


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
        public Book(string title, string author, int id, string genre, int pages, double price)
        {
            if(string.IsNullOrWhiteSpace(title)  || string.IsNullOrWhiteSpace(author))
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


    }
}
