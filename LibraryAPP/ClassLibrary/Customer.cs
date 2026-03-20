using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Класс "Customer" представляет покупателя в книжном магазине.
    /// Покупатель может хотеть конкретную книгу или книгу определённого жанра.
    /// </summary>
    public class Customer
    {
        // Поля
        private string wantedBookTitle;
        private string wantedBookAuthor;
        private string wantedGenre;
        private bool wishType;  // true = конкретная книга, false = жанр
        public bool isHappy;   // доволен ли покупатель


        /// <summary>
        /// Конструктор: покупатель хочет конкретную книгу (по названию и автору)
        /// </summary>
        public Customer(string wantedBookTitle, string wantedBookAuthor)
        {
            this.wantedBookTitle = wantedBookTitle;
            this.wantedBookAuthor = wantedBookAuthor;
            this.wantedGenre = string.Empty;
            this.wishType = true;  // true = хочет конкретную книгу
            this.isHappy = false;
        }

        /// <summary>
        /// Конструктор: покупатель хочет книгу определённого жанра
        /// </summary>
        public Customer(string wantedGenre)
        {
            this.wantedBookTitle = string.Empty;
            this.wantedBookAuthor = string.Empty;
            this.wantedGenre = wantedGenre;
            this.wishType = false;  // false = хочет книгу по жанру
            this.isHappy = false;
        }

        /// <summary>
        /// Проверяет, подходит ли книга покупателю
        /// Устанавливает IsHappy = true, если книга подходит
        /// </summary>
        public void MatchedBook(Book book, out bool isHappy)
        {
            if (book == null)
            {
                isHappy = false;
                this.isHappy = false;
                return;
            }

            if (wishType)
            {
                // Покупатель хочет конкретную книгу
                // Проверяем название И автора
                isHappy = (book.Title == wantedBookTitle && book.Author == wantedBookAuthor);
            }
            else
            {
                // Покупатель хочет книгу определённого жанра
                // Проверяем только жанр
                isHappy = (book.Genre == wantedGenre);
            }

            this.isHappy = isHappy;
        }
    }
}