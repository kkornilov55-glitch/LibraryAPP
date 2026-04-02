using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.IO;

namespace BookTests.cs
{
    [TestClass]
    public class GameManagerTests
    {
        private GameManager _gm;
        private string testDataPath = "TestDataBase.txt";
        private string testPrePath = "TestBookAuthor.txt";

        [TestInitialize]
        public void Setup()
        {
            Book.counter = 0;

            // Создаём тестовые файлы с уникальными именами
            File.WriteAllText(testPrePath, "ТестоваяКнига|ТестовыйАвтор\nДругаяКнига|ДругойАвтор");
            File.WriteAllText(testDataPath, "ТестоваяКнига|ТестовыйАвтор\nДругаяКнига|ДругойАвтор");

            _gm = new GameManager();
            _gm.StartGame(difficulty: 0, dayLength: 1000);

            // Добавляем шкаф для тестов
            _gm.Store.AddBookCase("ТестЖанр", 10);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Удаляем тестовые файлы после каждого теста
            if (File.Exists(testDataPath))
                File.Delete(testDataPath);
            if (File.Exists(testPrePath))
                File.Delete(testPrePath);
        }

        [TestMethod]
        public void StartGame_Easy_SetsCorrectLimits()
        {
            Assert.AreEqual(2500, _gm.startBalance);
            Assert.AreEqual(10, _gm.maxCustomersQueue);
            Assert.AreEqual(15, _gm.maxSuppliesQueue);
            Assert.AreEqual(5, _gm.maxUnhappyCustomres);
        }

        [TestMethod]
        public void TimersUpdate_DayEnds_Wins()
        {
            _gm.StartGame(0, dayLength: 10);
            _gm.TimersUpdate(10);
            Assert.IsTrue(_gm.Win);
        }

        [TestMethod]
        public void TimersUpdate_ZeroBalance_Loses()
        {
            _gm.StartGame(0, 100);
            _gm.Store.Balance = 0;
            _gm.TimersUpdate(5);
            Assert.IsTrue(_gm.Lose);
            Assert.AreEqual("Баланс магазина исчерпан!", _gm.LoseReason);
        }

        [TestMethod]
        public void TimersUpdate_TooManySupplies_Loses()
        {
            _gm.StartGame(0, 100);
            for (int i = 0; i < 16; i++)
                _gm.SuppliesQueue.Enqueue(new Supply(new Book("B", "A", "G", 1, 1), false, false, ""));

            _gm.TimersUpdate(5);
            Assert.IsTrue(_gm.Lose);
        }

        [TestMethod]
        public void CheckCustomerLimit_Exceeds_SetsLose()
        {
            _gm.StartGame(0, 100);
            bool result = _gm.CheckCustomerLimit(11);
            Assert.IsTrue(result);
            Assert.IsTrue(_gm.Lose);
        }

        [TestMethod]
        public void SellToCustomer_Happy_UpdatesBalance()
        {
            _gm.StartGame(0, 100);
            var book = new Book("Title", "Author", "ТестЖанр", 100, 100);
            _gm.Store.AddBook(book);
            var cust = new Customer("Title", "Author");

            _gm.SellToCustomer(cust, book, 110);

            Assert.IsTrue(cust.isHappy);
            Assert.AreEqual(2610, _gm.Store.Balance);
        }

        [TestMethod]
        public void SellToCustomer_WrongBook_IncrementsUnhappy()
        {
            _gm.StartGame(0, 100);
            var book = new Book("Title", "Author", "ТестЖанр", 100, 100);
            var cust = new Customer("WrongTitle", "WrongAuthor");

            _gm.SellToCustomer(cust, book, 50);

            Assert.IsFalse(cust.isHappy);
            Assert.AreEqual(1, _gm.UnhappyCustomersCount);
        }

        [TestMethod]
        public void SupplyProcessing_AcceptCorrect_RemovesFromQueue()
        {
            _gm.StartGame(0, 100);
            var book = new Book("B", "A", "ТестЖанр", 1, 50);
            var supply = new Supply(book, false, false, "");
            _gm.SuppliesQueue.Enqueue(supply);

            _gm.SupplyProcessing(supply, true, null);

            Assert.AreEqual(2450, _gm.Store.Balance);
            Assert.AreEqual(0, _gm.SuppliesQueue.Count);
        }

        [TestMethod]
        public void SupplyProcessing_AcceptWithError_AppliesFine()
        {
            _gm.StartGame(0, 100);
            var book = new Book("B", "A", "ТестЖанр", 1, 30);
            var supply = new Supply(book, false, true, "ПЛАГИАТ");
            _gm.SuppliesQueue.Enqueue(supply);

            _gm.SupplyProcessing(supply, true, null);

            Assert.AreEqual(2320, _gm.Store.Balance);
            Assert.IsTrue(_gm.FineArrived);
        }

        [TestMethod]
        public void SupplyProcessing_RejectError_GivesBonus()
        {
            _gm.StartGame(0, 100);
            var book = new Book("B", "A", "ТестЖанр", 1, 40);
            var supply = new Supply(book, false, true, "ОПЕЧАТКА");
            _gm.SuppliesQueue.Enqueue(supply);

            _gm.SupplyProcessing(supply, false, "ОПЕЧАТКА");

            Assert.AreEqual(2600, _gm.Store.Balance);
            Assert.IsTrue(_gm.BonusArrived);
        }

        [TestMethod]
        public void BuyBook_CheatCode_SetsMaxBalance()
        {
            _gm.StartGame(0, 100);
            var book = new Book("67", "A", "G", 1, 1);

            _gm.BuyBook(book);

            Assert.AreEqual(99999999, _gm.Store.Balance);
        }

        [TestMethod]
        public void BuyBook_Normal_EnqueuesSupply()
        {
            _gm.StartGame(0, 100);
            var book = new Book("Ordered", "Auth", "ТестЖанр", 1, 10);

            _gm.BuyBook(book);

            Assert.AreEqual(1, _gm.SuppliesQueue.Count);
        }
    }
}