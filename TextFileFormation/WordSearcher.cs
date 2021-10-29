using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

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
                            Console.WriteLine("Input word: ");
                            string word = Console.ReadLine();
                            if (!string.IsNullOrEmpty(word))
                            {
                               SearchForWord(word, file1, file2, file3);
                            }
                            else
                            {
                                Console.WriteLine("Wrong input, try again!");
                            }
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
            string files = File.ReadAllText(path);

            string[] splittedFile = files.Split(' ');

            return splittedFile;
        }

        private void SortAlphabethicAndPrint()
        {
            throw new NotImplementedException();
        }

        private void PrintDataStructure()
        {
            throw new NotImplementedException();
        }

        private void SearchForWord(string word, string[] file1, string[] file2, string[] file3)
        {
            int result1, result2, result3;

            result1 = CountWordsInFile(word, file1);
            result2 = CountWordsInFile(word, file2);
            result3 = CountWordsInFile(word, file3);

            ShowResult(result1, result2, result3);
        }

        private void ShowResult(int result1, int result2, int result3)
        {
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            int[] arr = { result1, result2, result3 };
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j+1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            myDictionary.Add("Text_1000.txt", result1);
            myDictionary.Add("Text_1500.txt", result2);
            myDictionary.Add("Text_3000.txt", result3);
            foreach (var item in myDictionary)
            {
                Console.WriteLine(item.Key, item.Value);
            }
        }

        private static int CountWordsInFile(string word, string[] stArr)
        {
            int result = 0;
            for (int i = 0; i < stArr.Length; i++)
            {
                if (stArr[i] == word)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
