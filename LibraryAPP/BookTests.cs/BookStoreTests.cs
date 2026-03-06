using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTests.cs
{
    /// <summary>
    /// Класс тестов для проверки класса BookStore согласно требованиям ТЗ.
    /// Проверяет баланс, лимит шкафов, перепрофилирование, продажу книг.
    /// </summary>
    [TestClass]
    public class BookStoreTests
    {
        private BookStore _store;

        /// <summary>
        /// Метод инициализации. Создаёт новый магазин перед каждым тестом.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _store = new BookStore(3);
        }


        /// <summary>
        /// ТЗ п.2.c: Магазин имеет баланс и максимальное количество шкафов.
        /// </summary>
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

        /// <summary>
        /// ТЗ п.5: Максимальное количество шкафов должно быть больше 0.
        /// </summary>
        [TestMethod]
        public void BookStoreConstructor_ZeroMaxCases_ThrowsArgumentException()
        {
            // Arrange
            int zeroCases = 0;
            bool exceptionThrown = false;

            // Act
            try
            {
                BookStore store = new BookStore(zeroCases);
            }
            catch (ArgumentException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Количество шкафов должно быть больше 0");
        }


        /// <summary>
        /// ТЗ п.2.c: В магазине может уместиться определённое количество шкафов (не больше n).
        /// </summary>
        [TestMethod]
        public void AddBookCase_ValidParameters_AddsSuccessfully()
        {
            // Arrange
            string genre = "Фантастика";
            int capacity = 10;

            // Act
            _store.AddBookCase(genre, capacity);

            // Assert
            List<string> genres = _store.GetAllGenres();
            Assert.IsTrue(genres.Contains("Фантастика"), "Шкаф должен быть добавлен");
        }

        /// <summary>
        /// ТЗ п.2.c: Жанр шкафа должен быть уникальным.
        /// </summary>
        [TestMethod]
        public void AddBookCase_DuplicateGenre_ThrowsInvalidOperationException()
        {
            // Arrange
            _store.AddBookCase("Детектив", 5);
            bool exceptionThrown = false;

            // Act
            try
            {
                _store.AddBookCase("Детектив", 10);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Не должно быть двух шкафов одного жанра");
        }

        /// <summary>
        /// ТЗ п.2.c: Нельзя добавить больше шкафов, чем максимум n.
        /// </summary>
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
            Assert.IsTrue(exceptionThrown, "Нельзя добавить больше шкафов чем максимум n");
        }


        /// <summary>
        /// ТЗ п.3.a: Книга может быть добавлена только если в шкафу есть место.
        /// Новый жанр создаёт новый шкаф (если есть место).
        /// </summary>
        [TestMethod]
        public void AddBook_NewGenre_CreatesNewBookCase()
        {
            // Arrange
            Book book = new Book("Книга", "Автор", "Новый жанр", 200, 400);

            // Act
            _store.AddBook(book);

            // Assert
            List<string> genres = _store.GetAllGenres();
            Assert.IsTrue(genres.Contains("Новый жанр"), "Для нового жанра должен создаться шкаф");
        }

        /// <summary>
        /// ТЗ п.5: Null книга не должна добавляться.
        /// </summary>
        [TestMethod]
        public void AddBook_NullBook_ThrowsArgumentNullException()
        {
            // Arrange
            Book nullBook = null;
            bool exceptionThrown = false;

            // Act
            try
            {
                _store.AddBook(nullBook);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Null книга не должна добавляться");
        }


        /// <summary>
        /// ТЗ п.3.b: При продаже книги баланс магазина обновляется.
        /// </summary>
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
            double expectedBalance = initialBalance + 599.99;
            Assert.AreEqual(expectedBalance, _store.Balance, 0.01,
                "Баланс должен увеличиться на цену проданной книги");
            Assert.IsNull(_store.FindBookById(book.id), "Книга должна быть удалена после продажи");
        }

        /// <summary>
        /// ТЗ п.3.b: При продаже книги в шкафу освобождается место.
        /// </summary>
        [TestMethod]
        public void SellBook_FreesSpaceInBookCase()
        {
            // Arrange
            _store.AddBookCase("Фантастика", 2);
            Book book1 = new Book("К1", "А1", "Фантастика", 100, 200);
            Book book2 = new Book("К2", "А2", "Фантастика", 100, 300);
            _store.AddBook(book1);
            _store.AddBook(book2);
            int initialCount = _store.GetBooksByGenre("Фантастика").Count;

            // Act
            _store.SellBook(book1.id);

            // Assert
            int finalCount = _store.GetBooksByGenre("Фантастика").Count;
            Assert.AreEqual(initialCount - 1, finalCount,
                "После продажи в шкафу должно освободиться место");
        }

        /// <summary>
        /// ТЗ п.5: Продажа несуществующей книги должна выбрасывать исключение.
        /// </summary>
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


        /// <summary>
        /// ТЗ п.3.b: Если достигнуто максимальное число шкафов, можно распродать целый шкаф
        /// и переназначить его жанр на новый.
        /// Пустой шкаф может стать шкафом с другим жанром.
        /// </summary>
        [TestMethod]
        public void ClearBookCase_AllowsNewGenreWhenMaxReached()
        {
            // Arrange: заполняем все шкафы
            _store.AddBookCase("Жанр 1", 2);
            _store.AddBookCase("Жанр 2", 2);
            _store.AddBookCase("Жанр 3", 2);

            Book book1 = new Book("К1", "А1", "Жанр 1", 100, 200);
            Book book2 = new Book("К2", "А2", "Жанр 1", 100, 300);
            _store.AddBook(book1);
            _store.AddBook(book2);

            double balanceBeforeClear = _store.Balance;
            double expectedBalanceAfterClear = balanceBeforeClear + book1.Price + book2.Price;

            // Act: очищаем шкаф "Жанр 1" (продаём все книги)
            _store.ClearBookCase("Жанр 1");

            // Теперь можно добавить новый жанр вместо очищенного
            _store.AddBookCase("Новый жанр", 5);

            // Assert
            Assert.AreEqual(expectedBalanceAfterClear, _store.Balance, 0.01,
                "Баланс должен увеличиться на сумму продаж всех книг из очищенного шкафа");

            List<string> genres = _store.GetAllGenres();
            Assert.IsFalse(genres.Contains("Жанр 1"), "Старый жанр должен быть удалён");
            Assert.IsTrue(genres.Contains("Новый жанр"), "Новый жанр должен быть добавлен");
            Assert.AreEqual(3, genres.Count, "Количество шкафов должно остаться равным максимуму");
        }

        /// <summary>
        /// ТЗ п.3.b: Пустой шкаф может быть перепрофилирован на другой жанр.
        /// Детективы → Любовные романы.
        /// </summary>
        [TestMethod]
        public void EmptyBookCase_CanBeReassignedToNewGenre()
        {
            // Arrange: создаём шкаф и сразу очищаем его
            _store.AddBookCase("Детективы", 5);
            _store.ClearBookCase("Детективы");

            // Act: добавляем новый жанр (должен занять место очищенного шкафа)
            _store.AddBookCase("Любовные романы", 5);

            // Assert
            List<string> genres = _store.GetAllGenres();
            Assert.IsFalse(genres.Contains("Детективы"), "Старый жанр должен быть удалён");
            Assert.IsTrue(genres.Contains("Любовные романы"), "Новый жанр должен быть добавлен");
        }


        /// <summary>
        /// ТЗ п.3.b: Очистка шкафа продаёт все книги и освобождает место.
        /// </summary>
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

        /// <summary>
        /// ТЗ п.5: Очистка несуществующего жанра должна выбрасывать исключение.
        /// </summary>
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

        /// <summary>
        /// ТЗ п.3.b: В магазине можно искать книгу по ID.
        /// </summary>
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

        /// <summary>
        /// ТЗ п.3.b: В магазине можно искать книгу по названию.
        /// </summary>
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


        /// <summary>
        /// ТЗ п.2.c: Баланс магазина - количество заработанных денег.
        /// Проверяет, что баланс отображается корректно.
        /// </summary>
        [TestMethod]
        public void Balance_UpdatesAfterMultipleSales()
        {
            // Arrange
            Book book1 = new Book("К1", "А1", "Жанр 1", 100, 200);
            Book book2 = new Book("К2", "А2", "Жанр 1", 100, 300);
            Book book3 = new Book("К3", "А3", "Жанр 2", 100, 400);
            _store.AddBook(book1);
            _store.AddBook(book2);
            _store.AddBook(book3);
            double expectedBalance = book1.Price + book2.Price + book3.Price;

            // Act
            _store.SellBook(book1.id);
            _store.SellBook(book2.id);
            _store.SellBook(book3.id);

            // Assert
            Assert.AreEqual(expectedBalance, _store.Balance, 0.01,
                "Баланс должен равняться сумме всех продаж");
        }

    }
}
