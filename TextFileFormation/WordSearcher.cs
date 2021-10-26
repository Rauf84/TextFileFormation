using System;
using System.Collections.Generic;
using System.Text;

namespace TextFileFormation
{
    class WordSearcher
    {
        public void Run()
        {
            var list1 = TextToListConverter("1000_words.txt");
            var list2 = TextToListConverter("1500_words.txt");
            var list3 = TextToListConverter("3000_words.txt");
            MainMenu();
        }

        private void MainMenu()
        {
            //Console.WriteLine("******MENU******");
            //Console.WriteLine("1. CREATE TEXTFILE C:\\1000_words.txt");
            //Console.WriteLine("2. CREATE TEXTFILE C:\\1500_words.txt");
            //Console.WriteLine("3. CREATE TEXTFILE C:\\3000_words.txt");
            //Console.WriteLine("4. CHOISE TEXT FILE TO CONTINUE");
            //Console.WriteLine("Q. QUIT");

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
                            SearchForWord();
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
        List<string> TextToListConverter(string fileName)
        {
            List<string> listOfWords = new List<string>();

            return listOfWords;
        }

        private void SortAlphabethicAndPrint()
        {
            throw new NotImplementedException();
        }

        private void PrintDataStructure()
        {
            throw new NotImplementedException();
        }

        private void SearchForWord()
        {
            throw new NotImplementedException();
        }

    }
}
