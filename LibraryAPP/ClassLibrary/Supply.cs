using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Supply
    {
        // Свойства
        public Book Book { get; set; }
        public bool IsOrdered { get; set; }
        public double Price { get; set; }
        public bool HasError { get; set; }
        public string ErrorType { get; set; }

        // Конструктор
        public Supply(Book book, bool isOrdered, bool hasError, string errorType)
        {
            Book = book;
            IsOrdered = isOrdered;
            //Price = price;
            Price = Book.Price;
            HasError = hasError;
            ErrorType = errorType;
        }
    }
}
