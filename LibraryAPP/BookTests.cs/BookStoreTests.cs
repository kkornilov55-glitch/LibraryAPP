using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BookTests
{
    [TestClass]
    public class BookStoreTests
    {
        private static void ResetBookCounter()
        {
            var field = typeof(Book).GetField("counter",
                BindingFlags.Public | BindingFlags.Static);
            if (field != null)
                field.SetValue(null, 0);
        }

        private BookStore _store;

        [TestInitialize]
        public void Setup()
        {
            _store = new BookStore(3);
        }

        // Проверяет создание BookStore с валидным параметром.
        [TestMethod]
        public void BookStoreConstructor_ValidMaxCases_InitializesCorrectly()
        {
            // Arrange
            int maxBookCases = 5;

            // Act
            BookStore store = new BookStore(maxBookCases);

            // Assert
            Assert.AreEqual(maxBookCases, store.MaxBookCases);
            Assert.AreEqual(0.0, store.Balance, "Начальный баланс должен быть 0");
        }

        // Проверяет защиту от невалидного количества шкафов (<= 0).
        [TestMethod]
        public void BookStoreConstructor_ZeroMaxCases_ThrowsArgumentException()
        {
            // Arrange
            int zeroCases = 0;
            bool exceptionThrown = false;

            // Act
            try
            {
                new BookStore(zeroCases);
            }
            catch (ArgumentException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Количество шкафов должно быть больше 0");
        }

        // Проверяет добавление нового шкафа с уникальным жанром.
        [TestMethod]
        public void AddBookCase_ValidParameters_AddsSuccessfully()
        {
            // Arrange
            string genre = "Фантастика";
            int capacity = 10;

            // Act
            _store.AddBookCase(genre, capacity);
            // Добавляем книгу, чтобы жанр отобразился в GetAllGenres()
            _store.AddBook(new Book("Тест", "Автор", genre, 200, 300));

            // Assert
            List<string> genres = _store.GetAllGenres();
            Assert.IsTrue(genres.Contains(genre), "Шкаф с книгой должен отображаться в списке жанров");
        }


        // Проверяет лимит на количество шкафов.
        [TestMethod]
        public void AddBookCase_ReachesMaxLimit_ThrowsOnNextAdd()
        {
            // Arrange
            _store.AddBookCase("Жанр 1", 5);
            _store.AddBookCase("Жанр 2", 5);
            _store.AddBookCase("Жанр 3", 5);
            bool exceptionThrown = false;

            // Act
            try
            {
                _store.AddBookCase("Жанр 4", 5);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Нельзя добавить больше шкафов, чем максимум");
        }

        // Добавление книги создаёт шкаф с вместимостью по умолчанию (10)
        [TestMethod]
        public void AddBook_NewGenre_CreatesCaseWithDefaultCapacity()
        {
            // Arrange
            Book book = new Book("Тест", "Автор", "НовыйЖанр", 200, 300);

            // Act
            _store.AddBook(book);

            // Assert - проверяем, что шкаф создан и в него можно добавить ещё 9 книг
            for (int i = 2; i <= 10; i++)
            {
                _store.AddBook(new Book($"К{i}", $"А{i}", "НовыйЖанр", 100, 100));
            }

            // 11-я книга должна вызвать исключение (шкаф полон)
            bool exceptionThrown = false;
            try
            {
                _store.AddBook(new Book("К11", "А11", "НовыйЖанр", 100, 100));
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }
            Assert.IsTrue(exceptionThrown, "11-я книга не должна добавиться в шкаф вместимостью 10");
        }

        // Защита от добавления null-книги.
        [TestMethod]
        public void AddBook_NullBook_ThrowsArgumentNullException()
        {
            // Arrange
            bool exceptionThrown = false;

            // Act
            try
            {
                _store.AddBook(null);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Null книга не должна добавляться");
        }

        // Продажа книги обновляет баланс и удаляет книгу.
        // Код удаляет ВЕСЬ шкаф, если продаётся последняя книга в нём.
        [TestMethod]
        public void SellBook_ValidId_UpdatesBalanceAndRemovesBook()
        {
            // Arrange
            Book book = new Book("Книга", "Автор", "Фантастика", 200, 599.99);
            _store.AddBook(book);
            double initialBalance = _store.Balance;

            // Act
            _store.SellBook(book.id);

            // Assert
            double expectedBalance = initialBalance + book.Price;
            Assert.AreEqual(expectedBalance, _store.Balance, 0.01,
                "Баланс должен увеличиться на цену проданной книги");
            Assert.IsNull(_store.FindBookById(book.id), "Книга должна быть удалена после продажи");
        }

        // После продажи книги в шкафу освобождается место.
        [TestMethod]
        public void SellBook_FreesSpaceInBookCase()
        {
            ResetBookCounter();
            BookStore testStore = new BookStore(5);

            // Arrange
            _store.AddBookCase("Фантастика", 3);
            Book book1 = new Book("К1", "А1", "Фантастика", 100, 200);
            Book book2 = new Book("К2", "А2", "Фантастика", 100, 300);
            Book book3 = new Book("К3", "А3", "Фантастика", 100, 400);
            testStore.AddBook(book1);
            testStore.AddBook(book2);
            testStore.AddBook(book3);

            // Act
            testStore.SellBook(book1.id);

            // Assert
            Assert.IsNull(testStore.FindBookById(book1.id), "Проданная книга не должна находиться");

            var booksAfter = testStore.GetBooksByGenre("Фантастика");
            Assert.AreEqual(2, booksAfter.Count, "После продажи должно остаться 2 книги");

            Assert.IsTrue(booksAfter.Exists(b => b.id == book2.id));
            Assert.IsTrue(booksAfter.Exists(b => b.id == book3.id));
        }

        // Продажа несуществующей книги.
        [TestMethod]
        public void SellBook_NonExistingId_ThrowsInvalidOperationException()
        {
            // Arrange
            int nonExistingId = 99999;
            bool exceptionThrown = false;

            // Act
            try
            {
                _store.SellBook(nonExistingId);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Продажа несуществующей книги должна выбрасывать исключение");
        }

        // Очистка шкафа при достижении лимита позволяет добавить новый жанр.
        [TestMethod]
        public void ClearBookCase_AllowsNewGenreWhenMaxReached()
        {
            // Arrange
            _store.AddBookCase("Жанр 1", 2);
            _store.AddBookCase("Жанр 2", 2);
            _store.AddBookCase("Жанр 3", 2);

            Book book1 = new Book("К1", "А1", "Жанр 1", 100, 200);
            Book book2 = new Book("К2", "А2", "Жанр 1", 100, 300);
            Book book3 = new Book("К3", "А3", "Жанр 2", 100, 400);
            Book book4 = new Book("К4", "А4", "Жанр 3", 100, 500);
            
            _store.AddBook(book1);
            _store.AddBook(book2);
            _store.AddBook(book3);
            _store.AddBook(book4);

            double balanceBeforeClear = _store.Balance;
            double expectedBalanceAfterClear = balanceBeforeClear + book1.Price + book2.Price;

            // Act
            _store.ClearBookCase("Жанр 1");
            _store.AddBookCase("Новый жанр", 5);

            // Assert
            Assert.AreEqual(expectedBalanceAfterClear, _store.Balance, 0.01,
                "Баланс должен увеличиться на сумму продаж всех книг из очищенного шкафа");

            List<string> genres = _store.GetAllGenres();
            Assert.IsFalse(genres.Contains("Жанр 1"), "Старый жанр должен быть удалён");
            Assert.IsTrue(genres.Contains("Жанр 2"), "Жанр 2 должен остаться в списке");
            Assert.IsTrue(genres.Contains("Жанр 3"), "Жанр 3 должен остаться в списке");
            Assert.IsFalse(genres.Contains("Новый жанр"), "Новый жанр без книг не отображается в GetAllGenres()");
            Assert.AreEqual(2, genres.Count, "Должно остаться ровно 2 жанра с книгами");
        }

        // После очистки шкафа можно добавить шкаф с другим жанром.
        [TestMethod]
        public void EmptyBookCase_CanBeReassignedToNewGenre()
        {
            // Arrange
            _store.AddBookCase("Детективы", 5);
            _store.ClearBookCase("Детективы");

            // Act
            _store.AddBookCase("Любовные романы", 5);

            // Assert
            List<string> genres = _store.GetAllGenres();
            Assert.IsFalse(genres.Contains("Детективы"), "Старый жанр должен быть удалён");
            Assert.AreEqual(0, genres.Count, "Список жанров с книгами должен быть пуст");
        }

        // Очистка шкафа продаёт все книги и удаляет шкаф.
        [TestMethod]
        public void ClearBookCase_ValidGenre_SellsBooksAndRemovesCase()
        {
            // Arrange
            Book book1 = new Book("К1", "А1", "Фантастика", 100, 300);
            Book book2 = new Book("К2", "А2", "Фантастика", 150, 400);
            _store.AddBook(book1);
            _store.AddBook(book2);
            double expectedBalance = book1.Price + book2.Price;

            // Act
            _store.ClearBookCase("Фантастика");

            // Assert
            Assert.AreEqual(expectedBalance, _store.Balance, 0.01,
                "Баланс должен увеличиться на сумму продаж всех книг");
            List<string> genres = _store.GetAllGenres();
            Assert.IsFalse(genres.Contains("Фантастика"), "Шкаф должен быть удалён после очистки");
        }

        // Очистка несуществующего жанра.
        [TestMethod]
        public void ClearBookCase_NonExistingGenre_ThrowsInvalidOperationException()
        {
            // Arrange
            string nonExistingGenre = "Пустой жанр";
            bool exceptionThrown = false;

            // Act
            try
            {
                _store.ClearBookCase(nonExistingGenre);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Очистка несуществующего жанра должна выбрасывать исключение");
        }

        // Поиск книги по ID во всех шкафах.
        [TestMethod]
        public void FindBookById_ExistingId_ReturnsBook()
        {
            // Arrange
            Book book = new Book("Поиск по ID", "Автор", "Детектив", 300, 450);
            _store.AddBook(book);

            // Act
            Book found = _store.FindBookById(book.id);

            // Assert
            Assert.IsNotNull(found, "Книга должна быть найдена по ID");
            Assert.AreEqual("Поиск по ID", found.Title);
        }

        // Поиск книги по названию во всех шкафах.
        [TestMethod]
        public void FindBookByTitle_ExistingTitle_ReturnsBook()
        {
            // Arrange
            Book book = new Book("Уникальное название для поиска", "Автор", "Роман", 220, 380);
            _store.AddBook(book);

            // Act
            Book found = _store.FindBookByTitle("Уникальное название для поиска");

            // Assert
            Assert.IsNotNull(found, "Книга должна быть найдена по названию");
            Assert.AreEqual(book.id, found.id);
        }
    }
}