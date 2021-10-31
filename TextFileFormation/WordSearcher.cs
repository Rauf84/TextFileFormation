using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
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
            var fileName1 = "Text_1000.txt";
            var fileName2 = "Text_1500.txt";
            var fileName3 = "Text_3000.txt";

            var file1 = TextToListConverter(@"\TextFiles\" + fileName1);
            var file2 = TextToListConverter(@"\TextFiles\" + fileName2);
            var file3 = TextToListConverter(@"\TextFiles\" + fileName3);

            var fileObject1 = new FileObject()
            {
                Name = fileName1,
                Data = file1
            };

            var fileObject2 = new FileObject()
            {
                Name = fileName2,
                Data = file2
            };

            var fileObject3 = new FileObject()
            {
                Name = fileName3,
                Data = file3
            };

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
                               SearchForWord(word, fileObject1, fileObject2, fileObject3);
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

        private void SearchForWord(string word, FileObject file1, FileObject file2, FileObject file3)
        {
            file1.Result = CountWordsInFile(word, file1.Data);
            file2.Result = CountWordsInFile(word, file2.Data);
            file3.Result = CountWordsInFile(word, file3.Data);

            ShowResult(file1, file2, file3);
        }

        private void ShowResult(FileObject file1, FileObject file2, FileObject file3)
        {
            var fileObjectList = new List<FileObject>();
            fileObjectList.Add(file1);
            fileObjectList.Add(file2);
            fileObjectList.Add(file3);

            int[] arrInt = { file1.Result, file2.Result, file3.Result };
            int temp;

            for (int i = 0; i < arrInt.Length - 1; i++)
            {
                for (int j = 0; j < arrInt.Length - i - 1; j++)
                {
                    if (arrInt[j] < arrInt[j + 1])
                    {
                        temp = arrInt[j + 1];
                        arrInt[j + 1] = arrInt[j];
                        arrInt[j] = temp;
                    }
                }
            }

            for (int i = 0; i < arrInt.Length; i++)
            {
                for (int j =0; j < fileObjectList.Count; j++)
                {
                    if (arrInt[i] == fileObjectList[j].Result && arrInt[i] != 0)
                    {
                        Console.WriteLine($"{fileObjectList[j].Name} - {fileObjectList[j].Result}");
                    }
                }
                if (arrInt[i] == 0)
                {
                    Console.WriteLine($"{fileObjectList[i].Name} - No result found.");
                }
            }
            MenuSaveResult();
        }

        private void MenuSaveResult()
        {
            bool run = true;
            while (run)
            {
                Console.Write("Save results? y/n: ");
                string input = Console.ReadLine();
                input.ToLower();
                if (!string.IsNullOrEmpty(input))
                {
                    switch (input)
                    {
                        case "y":
                            {
                                SaveResult();
                                break;
                            }
                        case "n":
                            {
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong input, try again.");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input, try again.");
                }
            }
        }

        private void SaveResult()
        {
            throw new NotImplementedException();
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
