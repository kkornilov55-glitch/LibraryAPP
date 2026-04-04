using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.IO;
using System.Linq;

namespace LibraryTests
{
    [TestClass]
    public class DataBaseTests
    {
        private DataBase db;
        private const string DataFile = "DataBase.txt";
        private const string PreFile = "BookAuthor.txt";

        // Выполняется перед КАЖДЫМ тестом
        [TestInitialize]
        public void Setup()
        {
            db = new DataBase();

            
            File.WriteAllText(DataFile, string.Empty);
            File.WriteAllText(PreFile, "Война и мир|Толстой\nПреступление и наказание|Достоевский");
        }

        // Выполняется после КАЖДОГО теста
        [TestCleanup]
        public void Cleanup()
        {
            // Удаляем файлы, чтобы не оставлять мусор
            if (File.Exists(DataFile)) File.Delete(DataFile);
            if (File.Exists(PreFile)) File.Delete(PreFile);
        }

        [TestMethod]
        public void ReadFile_ShouldCopyFromPrePath_IfDataPathIsEmpty()
        {
            
            db.ReadFile();

            
            Assert.AreEqual(2, db.LibraryBooks.Count);
            Assert.AreEqual("Война и мир", db.LibraryBooks[0].Title);
        }

        [TestMethod]
        public void AddBook_ShouldSaveToMemoryAndFile_IfBookIsUnique()
        {
          
            db.ReadFile(); 
            var newBook = new Book("Приключения Тома Сойера", "Марк Твен", "Роман", 600, 400);

           
            db.AddBook(newBook);

            
            Assert.AreEqual(3, db.LibraryBooks.Count);
            string fileContent = File.ReadAllText(DataFile);
            Assert.IsTrue(fileContent.Contains("Приключения Тома Сойера|Марк Твен"));
        }

        [TestMethod]
        public void AddBook_ShouldNotAdd_IfDuplicate()
        {
           
            db.ReadFile();
            var duplicate = new Book("Война и мир", "Толстой", "Классика", 1000, 500);

            
            db.AddBook(duplicate);

           
            Assert.AreEqual(2, db.LibraryBooks.Count); // Количество не изменилось
        }

        [TestMethod]
        public void GetRandomBook_ShouldReturnValidArray()
        {
         
            db.ReadFile();

         
            string[] result = db.GetRandomBook();

         
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);

            // Проверяем, что вернувшаяся книга есть в нашем списке
            Assert.IsTrue(db.LibraryBooks.Any(b => b.Title == result[0]));
        }
        


        [TestMethod]
        public void IsPlagiarism_ShouldReturnTrue_IfTitleExistsWithDifferentAuthor()
        {
            
            db.ReadFile(); 
            var plagiarizedBook = new Book("Война и мир", "Пушкин", "Жанр", 10, 10);

            
            bool result = db.IsPlagiarism(plagiarizedBook);

            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMispell_ShouldReturnTrue_IfAuthorExistsButTitleIsNew()
        {
            
            db.ReadFile(); 
           
            var mispelledBook = new Book("Братья Карамазовы", "Достоевский", "Жанр", 10, 10);

            
            bool result = db.IsMispell(mispelledBook);

            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DataBaseClear_ShouldEmptyListAndFile()
        {
          
            db.ReadFile();
            Assert.AreEqual(2, db.LibraryBooks.Count);

            
            db.DataBaseClear();

            
            Assert.AreEqual(0, db.LibraryBooks.Count);
            Assert.AreEqual(0, new FileInfo(DataFile).Length);
        }
    }
}