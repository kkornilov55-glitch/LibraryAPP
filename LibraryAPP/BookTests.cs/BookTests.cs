using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BookTests.cs
{
    /// <summary>
    /// Класс тестов для проверки класса Book согласно требованиям ТЗ.
    /// Проверяет уникальность ID, генерацию названий, продажу книг.
    /// </summary>
    [TestClass]
    public class BookTests
    {
        private List<Book> _existingBooks;

        /// <summary>
        /// Метод инициализации. Создаёт пустой список перед каждым тестом.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _existingBooks = new List<Book>();
        }

        /// <summary>
        /// ТЗ п.2.a: Проверяет создание книги с корректными параметрами.
        /// Все поля должны быть заполнены, ID присвоен автоматически.
        /// </summary>
        [TestMethod]
        public void BookConstructor_ValidParameters_CreatesBookSuccessfully()
        {
            // Arrange
            string title = "Тестовая книга";
            string author = "Автор Тестов";
            string genre = "Фантастика";
            int pages = 300;
            double price = 599.99;

            // Act
            Book book = new Book(title, author, genre, pages, price);

            // Assert
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(genre, book.Genre);
            Assert.AreEqual(pages, book.Pages);
            Assert.AreEqual(price, book.Price);
            Assert.IsTrue(book.id > 0, "ID должен быть больше 0");
        }

        /// <summary>
        /// ТЗ п.5: Проверяет, что книга не создаётся с пустым названием.
        /// Должна быть обработка ошибок и обязательность заполнения полей.
        /// </summary>
        [TestMethod]
        public void BookConstructor_EmptyTitle_ThrowsArgumentNullException()
        {
            // Arrange
            string emptyTitle = "";
            string author = "Автор";
            string genre = "Жанр";
            int pages = 200;
            double price = 100;
            bool exceptionThrown = false;

            // Act
            try
            {
                Book book = new Book(emptyTitle, author, genre, pages, price);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Книга не должна создаваться с пустым названием");
        }

        /// <summary>
        /// ТЗ п.5: Проверяет, что книга не создаётся с пустым автором.
        /// </summary>
        [TestMethod]
        public void BookConstructor_NullAuthor_ThrowsArgumentNullException()
        {
            // Arrange
            string title = "Название";
            string nullAuthor = null;
            string genre = "Жанр";
            int pages = 200;
            double price = 100;
            bool exceptionThrown = false;

            // Act
            try
            {
                Book book = new Book(title, nullAuthor, genre, pages, price);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown, "Книга не должна создаваться с пустым автором");
        }

        /// <summary>
        /// ТЗ п.2.a: ID должен присваиваться автоматически и быть уникальным.
        /// Проверяет, что ID инкрементируется при создании новых книг.
        /// </summary>
        [TestMethod]
        public void BookConstructor_MultipleBooks_IncrementalIds()
        {
            // Arrange
            Book book1 = new Book("Книга 1", "Автор 1", "Жанр 1", 100, 100);
            Book book2 = new Book("Книга 2", "Автор 2", "Жанр 2", 200, 200);
            Book book3 = new Book("Книга 3", "Автор 3", "Жанр 3", 300, 300);

            // Act
            int id1 = book1.id;
            int id2 = book2.id;
            int id3 = book3.id;

            // Assert
            Assert.IsTrue(id2 > id1, "ID второй книги должен быть больше ID первой");
            Assert.IsTrue(id3 > id2, "ID третьей книги должен быть больше ID второй");
            Assert.IsTrue(id1 > 0, "Все ID должны быть положительными");
        }


        /// <summary>
        /// ТЗ п.3.a: Проверяет генерацию книги с указанным жанром.
        /// Цена и страницы генерируются случайно в допустимых диапазонах.
        /// </summary>
        [TestMethod]
        public void GenerateBook_ValidGenre_CreatesBookWithCorrectGenre()
        {
            // Arrange
            string genre = "Детектив";
            List<Book> existingBooks = new List<Book>();

            // Act
            Book book = Book.GenerateBook(existingBooks, genre);

            // Assert
            Assert.IsNotNull(book);
            Assert.AreEqual(genre, book.Genre, "Жанр должен совпадать с указанным");
            Assert.IsTrue(book.Pages >= 50 && book.Pages <= 500, "Страницы должны быть в диапазоне 50-500");
            Assert.IsTrue(book.Price >= 300 && book.Price <= 1500, "Цена должна быть в диапазоне 300-1500");
        }

        /// <summary>
        /// ТЗ п.3.a: Если книга с таким названием уже есть, к названию добавляется цифра.
        /// "Айсберг" -> "Айсберг 2"
        /// </summary>
        [TestMethod]
        public void GenerateBook_DuplicateTitle_AddsNumericSuffix()
        {
            // Arrange
            Book existingBook = new Book("Айсберг", "Автор 1", "Жанр 1", 200, 300);
            _existingBooks.Add(existingBook);
            string genre = "Жанр 1";

            // Act
            Book newBook = Book.GenerateBook(_existingBooks, genre);

            // Assert
            Assert.IsNotNull(newBook);
            Assert.IsTrue(newBook.Title.StartsWith("Айсберг"), "Название должно начинаться с 'Айсберг'");
            Assert.IsTrue(newBook.Title.EndsWith("2") || newBook.Title.Contains(" 2"),
                "К названию должна добавиться цифра 2");
        }

        /// <summary>
        /// ТЗ п.3.a: При повторном дублировании цифра инкрементируется.
        /// "Айсберг" -> "Айсберг 2" -> "Айсберг 3" 
        /// </summary>
        [TestMethod]
        public void GenerateBook_MultipleDuplicates_IncrementingSuffix()
        {
            // Arrange
            Book book1 = new Book("Айсберг", "Автор 1", "Жанр 1", 200, 300);
            Book book2 = new Book("Айсберг 2", "Автор 2", "Жанр 1", 200, 300);
            _existingBooks.Add(book1);
            _existingBooks.Add(book2);
            string genre = "Жанр 1";

            // Act
            Book newBook = Book.GenerateBook(_existingBooks, genre);

            // Assert
            Assert.IsNotNull(newBook);
            Assert.IsTrue(newBook.Title.StartsWith("Айсберг"), "Название должно начинаться с 'Айсберг'");
            Assert.IsTrue(newBook.Title.EndsWith("3") || newBook.Title.Contains(" 3"),
                "К названию должна добавиться цифра 3, а не '2 2'");
            Assert.IsFalse(newBook.Title.Contains("2 2"), "Не должно быть дублирования суффикса");
        }

        /// <summary>
        /// ТЗ п.3.a: Проверяет, что генерация работает даже без файла title.txt.
        /// Приложение не должно падать с ошибкой.
        /// </summary>
        [TestMethod]
        public void GenerateBook_MissingTitleFile_HandlesGracefully()
        {
            // Arrange
            List<Book> existingBooks = new List<Book>();
            string genre = "Тестовый жанр";

            // Act
            Book book = Book.GenerateBook(existingBooks, genre);

            // Assert
            Assert.IsNotNull(book, "Книга должна создаться даже без файла title.txt");
        }

        /// <summary>
        /// ТЗ п.2.a: Метод "Продать книгу" должен возвращать стоимость книги.
        /// </summary>
        [TestMethod]
        public void Sell_ReturnsCorrectPrice()
        {
            // Arrange
            Book book = new Book("Книга", "Автор", "Жанр", 250, 799.50);
            double expectedPrice = 799.50;

            // Act
            double result = book.Sell();

            // Assert
            Assert.AreEqual(expectedPrice, result, 0.01, "Метод Sell должен возвращать цену книги");
        }
    }
}
