using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace BookStoreTests
{
    [TestClass]
    public class CustomerTests
    {
        // Тест 1: Покупатель хочет конкретную книгу — правильная книга, цена в лимите
        [TestMethod]
        public void MatchedBook_CorrectBook_PriceWithinLimit_ShouldMakeCustomerHappy()
        {
            var customer = new Customer("Бесы", "Достоевский");
            var book = new Book("Бесы", "Достоевский", "Роман", 500, 400);

            customer.MatchedBook(book, 460);

            Assert.IsTrue(customer.isHappy, "Покупатель должен быть доволен при цене ≤15%");
        }

        // Тест 2: Покупатель хочет конкретную книгу — правильная книга, цена выше лимита
        [TestMethod]
        public void MatchedBook_CorrectBook_PriceOverLimit_ShouldMakeCustomerUnhappy()
        {

            var customer = new Customer("Бесы", "Достоевского");
            var book = new Book("Бесы", "Достоевского", "Роман", 500, 400);

            customer.MatchedBook(book, 461);

            Assert.IsFalse(customer.isHappy, "Покупатель должен быть недоволен при цене >15%");
        }

        // Тест 3: Покупатель хочет конкретную книгу — неправильный автор (плагиат)
        [TestMethod]
        public void MatchedBook_WrongAuthor_ShouldMakeCustomerUnhappy()
        {

            var customer = new Customer("Бесы", "Достоевский");
            var book = new Book("Бесы", "Пушкин", "Роман", 500, 400);

            customer.MatchedBook(book, 400);

            Assert.IsFalse(customer.isHappy, "Покупатель должен быть недоволен при плагиате");
        }

        // Тест 4: Покупатель хочет книгу жанра — правильный жанр, цена в лимите
        [TestMethod]
        public void MatchedBook_CorrectGenre_PriceWithinLimit_ShouldMakeCustomerHappy()
        {
            var customer = new Customer("Фантастика");
            var book = new Book("Дюна", "Герберт", "Фантастика", 600, 500);

            customer.MatchedBook(book, 575);

            Assert.IsTrue(customer.isHappy, "Покупатель должен быть доволен при правильном жанре и цене ≤15%");
        }

        // Тест 5: Покупатель хочет книгу жанра — неправильный жанр
        [TestMethod]
        public void MatchedBook_WrongGenre_ShouldMakeCustomerUnhappy()
        {
            var customer = new Customer("Фантастика");
            var book = new Book("Преступление и наказание", "Достоевский", "Роман", 500, 400);

            customer.MatchedBook(book, 400);

            Assert.IsFalse(customer.isHappy, "Покупатель должен быть недоволен при неправильном жанре");
        }

        // Тест 6: Граничный случай — точная наценка 15.00%
        [TestMethod]
        public void MatchedBook_Exact15PercentMarkup_ShouldAccept()
        {
            var customer = new Customer("Бесы", "Достоевский");
            var book = new Book("Бесы", "Достоевский", "Роман", 500, 400);

            customer.MatchedBook(book, 460.00);  // Точно 15%

            Assert.IsTrue(customer.isHappy, "Покупатель должен принять точную наценку 15%");
        }
    }
}
