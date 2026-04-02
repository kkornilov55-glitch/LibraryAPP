using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.IO;

namespace BookTests.cs
{
    [TestClass]
    public class GameManagerTests
    {
        private GameManager gm;
        private string testDataPath = "TestDataBase.txt";
        private string testPrePath = "TestBookAuthor.txt";

        [TestInitialize]
        public void Setup()
        {
            Book.counter = 0;

            // Создаём тестовые файлы с уникальными именами
            File.WriteAllText(testPrePath, "ТестоваяКнига|ТестовыйАвтор\nДругаяКнига|ДругойАвтор");
            File.WriteAllText(testDataPath, "ТестоваяКнига|ТестовыйАвтор\nДругаяКнига|ДругойАвтор");

            gm = new GameManager();
            gm.StartGame(difficulty: 0, dayLength: 1000);

            // Добавляем шкаф для тестов
            gm.Store.AddBookCase("ТестЖанр", 10);
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
            Assert.AreEqual(2500, gm.startBalance);
            Assert.AreEqual(10, gm.maxCustomersQueue);
            Assert.AreEqual(15, gm.maxSuppliesQueue);
            Assert.AreEqual(5, gm.maxUnhappyCustomres);
        }

        [TestMethod]
        public void TimersUpdate_DayEnds_Wins()
        {
            gm.StartGame(0, dayLength: 10);
            gm.TimersUpdate(10);
            Assert.IsTrue(gm.Win);
        }

        [TestMethod]
        public void TimersUpdate_ZeroBalance_Loses()
        {
            gm.StartGame(0, 100);
            gm.Store.Balance = 0;
            gm.TimersUpdate(5);
            Assert.IsTrue(gm.Lose);
            Assert.AreEqual("Баланс магазина исчерпан!", gm.LoseReason);
        }

        [TestMethod]
        public void TimersUpdate_TooManySupplies_Loses()
        {
            gm.StartGame(0, 100);
            for (int i = 0; i < 16; i++)
                gm.SuppliesQueue.Enqueue(new Supply(new Book("B", "A", "G", 1, 1), false, false, ""));

            gm.TimersUpdate(5);
            Assert.IsTrue(gm.Lose);
        }

        [TestMethod]
        public void CheckCustomerLimit_Exceeds_SetsLose()
        {
            gm.StartGame(0, 100);
            bool result = gm.CheckCustomerLimit(11);
            Assert.IsTrue(result);
            Assert.IsTrue(gm.Lose);
        }

        [TestMethod]
        public void SellToCustomer_Happy_UpdatesBalance()
        {
            gm.StartGame(0, 100);
            var book = new Book("Title", "Author", "ТестЖанр", 100, 100);
            gm.Store.AddBook(book);
            var cust = new Customer("Title", "Author");

            gm.SellToCustomer(cust, book, 110);

            Assert.IsTrue(cust.isHappy);
            Assert.AreEqual(2610, gm.Store.Balance);
        }

        [TestMethod]
        public void SellToCustomer_WrongBook_IncrementsUnhappy()
        {
            gm.StartGame(0, 100);
            var book = new Book("Title", "Author", "ТестЖанр", 100, 100);
            var cust = new Customer("WrongTitle", "WrongAuthor");

            gm.SellToCustomer(cust, book, 50);

            Assert.IsFalse(cust.isHappy);
            Assert.AreEqual(1, gm.UnhappyCustomersCount);
        }

        [TestMethod]
        public void SupplyProcessing_AcceptCorrect_RemovesFromQueue()
        {
            gm.StartGame(0, 100);
            var book = new Book("B", "A", "ТестЖанр", 1, 50);
            var supply = new Supply(book, false, false, "");
            gm.SuppliesQueue.Enqueue(supply);

            gm.SupplyProcessing(supply, true, null);

            Assert.AreEqual(2450, gm.Store.Balance);
            Assert.AreEqual(0, gm.SuppliesQueue.Count);
        }

        [TestMethod]
        public void SupplyProcessing_AcceptWithError_AppliesFine()
        {
            gm.StartGame(0, 100);
            var book = new Book("B", "A", "ТестЖанр", 1, 30);
            var supply = new Supply(book, false, true, "ПЛАГИАТ");
            gm.SuppliesQueue.Enqueue(supply);

            gm.SupplyProcessing(supply, true, null);

            Assert.AreEqual(2320, gm.Store.Balance);
            Assert.IsTrue(gm.FineArrived);
        }

        [TestMethod]
        public void SupplyProcessing_RejectError_GivesBonus()
        {
            gm.StartGame(0, 100);
            var book = new Book("B", "A", "ТестЖанр", 1, 40);
            var supply = new Supply(book, false, true, "ОПЕЧАТКА");
            gm.SuppliesQueue.Enqueue(supply);

            gm.SupplyProcessing(supply, false, "ОПЕЧАТКА");

            Assert.AreEqual(2600, gm.Store.Balance);
            Assert.IsTrue(gm.BonusArrived);
        }

        [TestMethod]
        public void BuyBook_CheatCode_SetsMaxBalance()
        {
            gm.StartGame(0, 100);
            var book = new Book("67", "A", "G", 1, 1);

            gm.BuyBook(book);

            Assert.AreEqual(99999999, gm.Store.Balance);
        }

        [TestMethod]
        public void BuyBook_Normal_EnqueuesSupply()
        {
            gm.StartGame(0, 100);
            var book = new Book("Ordered", "Auth", "ТестЖанр", 1, 10);

            gm.BuyBook(book);

            Assert.AreEqual(1, gm.SuppliesQueue.Count);
        }
    }
}