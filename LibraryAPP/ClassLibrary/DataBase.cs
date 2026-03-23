using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class DataBase
    {

        string DataPath = "DataBase.txt";

        public void ReadFile()
        {
            string PrePath = "BookAuthor.txt";

            List<(string Title, string Author)> LibraryBooks = new List<(string Title, string Author)> ();

            string[] lines = File.ReadAllLines(PrePath);

            foreach (string line in lines)
            {
                var word = line.Split('|');

                LibraryBooks.Add((word[0].Trim(), word[1].Trim()));                       
            }

        }

    }
}
 