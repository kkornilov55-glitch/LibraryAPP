using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class DataBase
    {

        public List<(string Title, string Author)> LibraryBooks = new List<(string Title, string Author)>();
        public string DataPath = "DataBase.txt";
        public string PrePath = "BookAuthor.txt";

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

        public void AddBook()
        {

        }

        

    }
}
 