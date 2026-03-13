using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTests
{
    [TestClass]
    public class BookCaseTests
    {
        private BookCase _bookCase;

        [TestInitialize]
        public void Setup()
        {
            _bookCase = new BookCase("Фантастика", 3);
        }


        // Проверяет создание шкафа с указанием жанра и вместимости.
        [TestMethod]
        public void BookCaseConstructor_ValidParameters_InitializesCorrectly()
        {
            // Arrange
            string genre = "Детектив";
            int capacity = 10;

            // Act
            BookCase bookCase = new BookCase(genre, capacity);

            // Assert
            Assert.AreEqual(genre, bookCase.genre, "Жанр должен совпадать с указанным");
            Assert.AreEqual(capacity, bookCase.capacity, "Вместимость должна совпадать с указанной");
        }

        // Проверяет, что шкаф не создаётся без указания жанра.
        [TestMethod]
        public void BookCaseConstructor_EmptyGenre_ThrowsArgumentException()
        {
            // Arrange
            string emptyGenre = "";
            int capacity = 5;
            bool exceptionThrown = false;

            // Act
            try
            {
                BookCase bookCase = new BookCase(emptyGenre, capacity);
            }
            catch (ArgumentException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Шкаф не должен создаваться без жанра");
        }


        // В шкафу хранятся книги только одного жанра.
        [TestMethod]
        public void AddBook_ValidBook_AddsSuccessfully()
        {
            // Arrange
            Book book = new Book("Книга 1", "Автор 1", "Фантастика", 200, 400);

            // Act
            _bookCase.AddBook(book);

            // Assert
            List<Book> books = _bookCase.GetAllBooks();
            Assert.AreEqual(1, books.Count, "В шкафу должна быть одна книга");
            Assert.AreEqual("Фантастика", books[0].Genre, "Жанр книги должен совпадать с жанром шкафа");
        }

        // В шкафу могут храниться книги ТОЛЬКО одного жанра.
        [TestMethod]
        public void AddBook_WrongGenre_ThrowsInvalidOperationException()
        {
            // Arrange
            Book book = new Book("Книга", "Автор", "Детектив", 200, 300);
            bool exceptionThrown = false;

            // Act
            try
            {
                _bookCase.AddBook(book);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Книга другого жанра не должна добавляться в шкаф");
        }

        // Проверяет обработку null книги.
        [TestMethod]
        public void AddBook_NullBook_ThrowsArgumentNullException()
        {
            // Arrange
            Book nullBook = null;
            bool exceptionThrown = false;

            // Act
            try
            {
                _bookCase.AddBook(nullBook);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Null книга не должна добавляться");
        }

        //  У каждого шкафа своя вместимость. При превышении вместимости книга не должна добавляться.
        [TestMethod]
        public void AddBook_CapacityExceeded_ThrowsInvalidOperationException()
        {
            // Arrange
            Book book1 = new Book("К1", "А1", "Фантастика", 100, 100);
            Book book2 = new Book("К2", "А2", "Фантастика", 100, 100);
            Book book3 = new Book("К3", "А3", "Фантастика", 100, 100);
            Book book4 = new Book("К4", "А4", "Фантастика", 100, 100);
            bool exceptionThrown = false;

            // Act
            _bookCase.AddBook(book1);
            _bookCase.AddBook(book2);
            _bookCase.AddBook(book3);

            try
            {
                _bookCase.AddBook(book4);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "При переполнении шкафа книга не должна добавляться");
        }

        // В шкафу можно искать книгу по идентификационному номеру.
        [TestMethod]
        public void FindById_ExistingId_ReturnsBook()
        {
            // Arrange
            Book book = new Book("Искомая книга", "Автор", "Фантастика", 200, 300);
            _bookCase.AddBook(book);

            // Act
            Book found = _bookCase.FindById(book.id);

            // Assert
            Assert.IsNotNull(found, "Книга должна быть найдена по ID");
            Assert.AreEqual("Искомая книга", found.Title);
        }

        // Поиск по несуществующему ID
        [TestMethod]
        public void FindById_NonExistingId_ReturnsNull()
        {
            // Arrange
            int nonExistingId = 9999;

            // Act
            Book found = _bookCase.FindById(nonExistingId);

            // Assert
            Assert.IsNull(found, "Поиск несуществующего ID должен вернуть null");
        }

        // В шкафу можно искать книгу по названию.
        [TestMethod]
        public void FindbyTitle_ExistingTitle_ReturnsBook()
        {
            // Arrange
            Book book = new Book("Уникальное название", "Автор", "Фантастика", 250, 500);
            _bookCase.AddBook(book);

            // Act
            Book found = _bookCase.FindbyTitle("Уникальное название");

            // Assert
            Assert.IsNotNull(found, "Книга должна быть найдена по названию");
            Assert.AreEqual("Уникальное название", found.Title);
        }

        // Поиск по несуществующему названию
        [TestMethod]
        public void FindbyTitle_NonExistingTitle_ReturnsNull()
        {
            // Arrange
            string nonExistingTitle = "Несуществующая книга";

            // Act
            Book found = _bookCase.FindbyTitle(nonExistingTitle);

            // Assert
            Assert.IsNull(found, "Поиск несуществующего названия должен вернуть null");
        }

        // При продаже книги в шкафу освобождается место. Проверяет удаление книги по ID.
        [TestMethod]
        public void RemoveBook_ExistingId_RemovesSuccessfully()
        {
            // Arrange
            Book book = new Book("Книга для удаления", "Автор", "Фантастика", 200, 300);
            _bookCase.AddBook(book);
            int initialCount = _bookCase.GetAllBooks().Count;

            // Act
            _bookCase.RemoveBook(book.id);

            // Assert
            Book found = _bookCase.FindById(book.id);
            Assert.IsNull(found, "Книга должна быть удалена из шкафа");
            Assert.AreEqual(initialCount - 1, _bookCase.GetAllBooks().Count,
                "После удаления количество книг должно уменьшиться на 1");
        }

        // Удаление несуществующей книги должно выбрасывать исключение.
        [TestMethod]
        public void RemoveBook_NonExistingId_ThrowsInvalidOperationException()
        {
            // Arrange
            int nonExistingId = 12345;
            bool exceptionThrown = false;

            // Act
            try
            {
                _bookCase.RemoveBook(nonExistingId);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Удаление несуществующей книги должно выбрасывать исключение");
        }

        // Книги выводятся по порядку их добавления.
        [TestMethod]
        public void GetAllBooks_ReturnsCopy_NotReference()
        {
            // Arrange
            Book book = new Book("Книга", "Автор", "Фантастика", 200, 300);
            _bookCase.AddBook(book);

            // Act
            List<Book> list1 = _bookCase.GetAllBooks();
            List<Book> list2 = _bookCase.GetAllBooks();

            // Assert
            Assert.AreNotSame(list1, list2, "Метод должен возвращать копию списка, а не ссылку");
            Assert.AreEqual(list1.Count, list2.Count);
        }
    }
}
