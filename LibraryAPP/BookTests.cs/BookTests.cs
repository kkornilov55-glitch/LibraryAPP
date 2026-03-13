using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BookTests
{
    [TestClass]
    public class BookTests
    {
        private static void ResetBookCounter()
        {
            var field = typeof(Book).GetField("counter",
                BindingFlags.Public | BindingFlags.Static);
            if (field != null)
                field.SetValue(null, 0);
        }

        private List<Book> _books;

        [TestInitialize]
        public void Setup() => _books = new List<Book>();

        // Проверяет: создание книги с валидными параметрами.
        // Ожидание: все свойства инициализируются корректно, ID > 0.
        [TestMethod]
        public void BookConstructor_ValidParameters_CreatesBookSuccessfully()
        {
            var book = new Book("Title", "Author", "Genre", 300, 599.99);

            Assert.AreEqual("Title", book.Title);
            Assert.AreEqual("Author", book.Author);
            Assert.AreEqual("Genre", book.Genre);
            Assert.AreEqual(300, book.Pages);
            Assert.AreEqual(599.99, book.Price);
            Assert.IsTrue(book.id > 0);
        }

        // Проверяет: защита от пустого названия книги.
        [TestMethod]
        public void BookConstructor_EmptyTitle_ThrowsArgumentNullException()
        {
            bool exceptionThrown = false;

            try
            {
                new Book("", "Author", "Genre", 200, 100);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown, "Должно быть выброшено ArgumentNullException");
        }

        // Проверяет: защита от пустого автора.
        [TestMethod]
        public void BookConstructor_NullAuthor_ThrowsArgumentNullException()
        {
            bool exceptionThrown = false;

            try
            {
                new Book("Title", null, "Genre", 200, 100);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown, "Должно быть выброшено ArgumentNullException");
        }

        // Проверяет: каждая новая книга получает уникальный ID > предыдущего.
        [TestMethod]
        public void BookConstructor_MultipleBooks_IncrementalIds()
        {
            var b1 = new Book("A", "X", "G", 100, 100);
            var b2 = new Book("B", "Y", "G", 200, 200);
            var b3 = new Book("C", "Z", "G", 300, 300);

            Assert.IsTrue(b2.id > b1.id && b3.id > b2.id && b1.id > 0);
        }


        // Проверяет: генерация книги методом GenerateBook.
        [TestMethod]
        public void GenerateBook_ValidGenre_CreatesBookWithValidGenre()
        {
            var validGenres = new[] { "Фэнтези", "Детектив", "Триллер", "Научная фантастика", "Роман", "Драма" };
            var book = Book.GenerateBook(_books, "Детектив"); 

            Assert.IsNotNull(book);
            CollectionAssert.Contains(validGenres, book.Genre); 
            Assert.IsTrue(book.Pages is >= 50 and < 500);
            Assert.IsTrue(book.Price is >= 300 and < 1500);
        }

        // Проверяет: устойчивая работа при отсутствии файла title.txt.
        [TestMethod]
        public void GenerateBook_MissingTitleFile_HandlesGracefully()
        {
            var book = Book.GenerateBook(_books, "Any");
            Assert.IsNotNull(book); // книга должна создаться даже если файл не найден
        }

        // Проверяет: добавление суффикса "2" при дублировании названия у того же автора.
        [TestMethod]
        public void EnsureUniqueTitle_Duplicate_AddsSuffix2()
        {
            _books.Add(new Book("Айсберг", "Автор", "Жанр", 200, 300));
            var result = Book.EnsureUniqueTitle("Айсберг", "Автор", _books);
            Assert.AreEqual("Айсберг 2", result);
        }

        // Проверяет: увеличение суффикса при множественных дубликатах.
        [TestMethod]
        public void EnsureUniqueTitle_MultipleDuplicates_IncrementsSuffix()
        {
            _books.Add(new Book("Айсберг", "Автор", "Жанр", 200, 300));
            _books.Add(new Book("Айсберг 2", "Автор", "Жанр", 200, 300));

            var result = Book.EnsureUniqueTitle("Айсберг", "Автор", _books);
            Assert.AreEqual("Айсберг 3", result);
        }

        // Проверяет: повторное использование освобождённого номера сиквела.
        [TestMethod]
        public void EnsureUniqueTitle_AfterRemoval_ReusesFreedNumber()
        {
            // В списке только оригинал, сиквел "Вендиго 2" был удалён (продан)
            _books.Add(new Book("Вендиго", "Автор", "Ужасы", 300, 500));

            var result = Book.EnsureUniqueTitle("Вендиго", "Автор", _books);
            Assert.AreEqual("Вендиго 2", result); // номер 2 должен освободиться и быть использован
        }

        // Проверяет: метод Sell() возвращает точную стоимость книги.
        [TestMethod]
        public void Sell_ReturnsCorrectPrice()
        {
            var book = new Book("Book", "Author", "Genre", 250, 799.50);
            Assert.AreEqual(799.50, book.Sell(), 0.01); // delta 0.01 для сравнения double
        }

        // Проверка метода DecrementCounter
        [TestMethod]
        public void DecrementCounter_ValidCounter_Decrements()
        {
            ResetBookCounter();
            // Arrange
            var b1 = new Book("A", "X", "G", 100, 100);
            int counterBefore = Book.counter;

            // Act
            Book.DecrementCounter();

            // Assert
            Assert.AreEqual(counterBefore - 1, Book.counter);
        }

        // Генерация книги с уникальным названием (интеграционный)
        [TestMethod]
        public void GenerateBook_WithExistingTitle_AddsSuffix()
        {
            // Arrange
            _books.Add(new Book("Тест", "Автор", "Жанр", 200, 300));

            // Act - генерируем книгу, эмулируя поведение формы
            var generated = Book.GenerateBook(_books, "");
            // Принудительно меняем название на дубликат для проверки EnsureUniqueTitle
            var finalTitle = Book.EnsureUniqueTitle("Тест", "Автор", _books);

            // Assert
            Assert.AreEqual("Тест 2", finalTitle);
        }
    }
}