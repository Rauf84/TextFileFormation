using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TextFileFormation
{
     class WordSearcher
    {
         public void Run()
        {
            MainMenu();
        }

        private void MainMenu()

        {
            var file1 = TextToListConverter(@"\TextFiles\Text_1000.txt");
            var file2 = TextToListConverter(@"\TextFiles\Text_1500.txt");
            var file3 = TextToListConverter(@"\TextFiles\Text_3000.txt");
            bool run = true;
            while (run)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Search document for a word");
                Console.WriteLine("2. Print datastructure");
                Console.WriteLine("3. Sort in alphabethic order and print.");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        {
                            //SearchForWord();
                            break;
                        }
                    case 2:
                        {
                            PrintDataStructure();
                            break;
                        }
                    case 3:
                        {
                            SortAlphabethicAndPrint();
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Bye bye");
                            run = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong input, try again!");
                            break;
                        }
                }
            }
        }
        string [] TextToListConverter(string fileName)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + $"{fileName}";
            string[] files = File.ReadAllLines(path);
            return files; 
        }

        private void SortAlphabethicAndPrint()
        {
            throw new NotImplementedException();
        }

        private void PrintDataStructure()
        {
            throw new NotImplementedException();
        }

        private void SearchForWord(string word, string [] stArr1, string[] stArr2, string[] stArr3)
        {

            throw new NotImplementedException();
        }

    }
}
