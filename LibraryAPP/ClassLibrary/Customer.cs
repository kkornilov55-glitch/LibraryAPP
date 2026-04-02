using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{

    //Класс "Customer" представляет покупателя в книжном магазине.
    //Покупатель может хотеть конкретную книгу или книгу определённого жанра.

    public class Customer
    {
        //Поля
        private string wantedBookTitle;
        private string wantedBookAuthor;
        private string wantedGenre;
        private bool wishType;  //true = конкретная книга, false = жанр
        public bool isHappy;

        //Конструктор: покупатель хочет конкретную книгу (по названию и автору).
        public Customer(string wantedBookTitle, string wantedBookAuthor)
        {
            this.wantedBookTitle = wantedBookTitle;
            this.wantedBookAuthor = wantedBookAuthor;
            this.wantedGenre = string.Empty;
            this.wishType = true;   //true = хочет конкретную книгу
            this.isHappy = false;
        }


        //Конструктор: покупатель хочет книгу определённого жанра.
        public Customer(string wantedGenre)
        {
            this.wantedBookTitle = string.Empty;
            this.wantedBookAuthor = string.Empty;
            this.wantedGenre = wantedGenre;
            this.wishType = false;  // false = хочет книгу по жанру
            this.isHappy = false;
        }


        //Проверяет, подходит ли книга покупателю и устраивает ли цена.
        //Устанавливает isHappy = true, если книга соответствует желанию И цена не превышает базовую (book.Price) более чем на 15%.

        public void MatchedBook(Book book, double price)
        {
            if (book == null)
            {
                isHappy = false;
                return;
            }

            //Проверяем соответствие книги желанию покупателя
            bool matchesWish;
            if (wishType)
            {
                //Хочет конкретную книгу: проверяем название И автора
                matchesWish = (book.Title == wantedBookTitle && book.Author == wantedBookAuthor);
            }
            else
            {
                //Хочет книгу жанра: проверяем только жанр
                matchesWish = (book.Genre == wantedGenre);
            }

            if (!matchesWish)
            {
                isHappy = false;
                return;
            }

            //Проверяем цену: наценка не должна превышать 15%
            //Базовая цена = book.Price (цена закупки книги)
            double maxAcceptablePrice = Math.Round(book.Price * 1.15, 2);
            bool priceAcceptable = (price <= maxAcceptablePrice);

            //Покупатель доволен, если книга подходит И цена устраивает
            isHappy = priceAcceptable;
        }

        //Методы для доступа тестов
        public string GetWantedTitle() => wantedBookTitle;
        public string GetWantedAuthor() => wantedBookAuthor;
        public string GetWantedGenre() => wantedGenre;
        public bool WantsSpecificBook() => wishType;
        
        /// <summary>Вспомогательное свойство: текст запроса покупателя для отображения</summary>
        public string RequestDisplayText
        {
            get
            {
                if (wishType) // конкретная книга
                    return $"«{wantedBookTitle}» ({wantedBookAuthor})";
                else // жанр
                    return $"Жанр: «{wantedGenre}»";
            }
        }
    }
}