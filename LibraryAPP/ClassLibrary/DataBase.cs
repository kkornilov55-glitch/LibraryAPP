using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class DataBase
    {

        public List<(string Title, string Author)> LibraryBooks = new List<(string Title, string Author)>();
        private string DataPath = "DataBase.txt";
        private string PrePath = "BookAuthor.txt";
        private Random rng = new Random();

        public void ReadFile()
        {

            if (!File.Exists(DataPath))
            {
                if (File.Exists(PrePath))
                {
                    File.Copy(PrePath, DataPath);
                }

                else
                {
                    throw new Exception("Файл с исходными книгами не найден");
                }
            }

            string[] lines = File.ReadAllLines(DataPath);
            LibraryBooks.Clear();

            foreach (string line in lines)
            {

                if (string.IsNullOrWhiteSpace(line)) 
                    continue;

                var word = line.Split('|');

                if (word.Length == 2)
                {
                    LibraryBooks.Add((word[0].Trim(), word[1].Trim()));
                }                         
            }

        }

        public void AddBook(in Book book)
        {
            bool AlreadyExist = false; //флаг, указывающий существует ли уже такая книга


             foreach(var ExistingBook in LibraryBooks)
            {
                if(ExistingBook.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase) && ExistingBook.Author.Equals(book.Author, StringComparison.OrdinalIgnoreCase))
                {
                    AlreadyExist = true;
                    break;
                }
            }

            if (!AlreadyExist)
            {
                LibraryBooks.Add((book.Title, book.Author));

                string line = $"\n{book.Title}|{book.Author}";

                File.AppendAllText(DataPath, line);
            }
        }

        public string[] GetRandomBook()
        {
            var RandomBook = LibraryBooks[rng.Next(LibraryBooks.Count)];

            return new string[] { RandomBook.Title, RandomBook.Author };
        }

        public bool IsPlagiarism(in Book book)
        {
            
            foreach(var ExistingTitle in LibraryBooks)
            {
                if (ExistingTitle.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase))
                {
                    if (ExistingTitle.Author.Equals(book.Author, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }

                    return false;
                }
                
            }
            return false;
        }

    }
}
 