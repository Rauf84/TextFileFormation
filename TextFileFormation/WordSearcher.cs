using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
         private BinaryTree binaryTree = new BinaryTree();

         public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            var fileName1 = "Text_1000.txt";
            var fileName2 = "Text_1500.txt";
            var fileName3 = "Text_3000.txt";

            var fileConvert1 = TextToListConverter(@"\TextFiles\" + fileName1);
            var fileConvert2 = TextToListConverter(@"\TextFiles\" + fileName2);
            var fileConvert3 = TextToListConverter(@"\TextFiles\" + fileName3);

            var file1 = new FileObject()
            {
                Name = fileName1,
                Data = fileConvert1
            };

            var file2 = new FileObject()
            {
                Name = fileName2,
                Data = fileConvert2
            };

            var file3 = new FileObject()
            {
                Name = fileName3,
                Data = fileConvert3
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
                            SortAlphabethicAndPrint(file1, file2, file3);
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

        private void SortAlphabethicAndPrint(FileObject file1, FileObject file2, FileObject file3)
        {
            List<string> sortedList1 = new List<string>();
            List<string> sortedList2 = new List<string>();
            List<string> sortedList3 = new List<string>();

            string pattern = "^[a-öA-Ö]";
            Regex rgx = new Regex(pattern);

            for (int i = 0; i < file1.Data.Length; i++)
            {
                if (rgx.IsMatch(file1.Data[i]))
                {
                    sortedList1.Add(file1.Data[i]);
                }
            }
            for (int i = 0; i < file2.Data.Length; i++)
            {
                if (rgx.IsMatch(file2.Data[i]))
                {
                    sortedList2.Add(file2.Data[i]);
                }
            }
            for (int i = 0; i < file3.Data.Length; i++)
            {
                if (rgx.IsMatch(file3.Data[i]))
                {
                    sortedList3.Add(file3.Data[i]);
                }
            }
            sortedList1.Sort();
            sortedList2.Sort();
            sortedList3.Sort();

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(sortedList1[i]);
            }
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(sortedList2[i]);
            }
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(sortedList3[i]);
            }
        }

        private void PrintDataStructure()
        {
            if (binaryTree != null)
            {
                 binaryTree.TraverseInOrder(binaryTree.Root);
            }
            else
            {
                Console.WriteLine("Datastructure is empty.");
            }
        }

        private void SearchForWord(string word, FileObject file1, FileObject file2, FileObject file3)
        {
            file1.Result = CountWordsInFile(word, file1.Data);
            file2.Result = CountWordsInFile(word, file2.Data);
            file3.Result = CountWordsInFile(word, file3.Data);

            ShowResult(file1, file2, file3);
        }

        /// <summary>
        /// O(n^2 + n^2)
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="file3"></param>
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
            MenuSaveResult(file1, file2, file3);
        }

        private void MenuSaveResult(FileObject file1, FileObject file2, FileObject file3)
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
                                SaveResult(file1, file2, file3);
                                run = false;
                                break;
                            }
                        case "n":
                            {
                                run = false;
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

        private void SaveResult(FileObject file1, FileObject file2, FileObject file3)
        {
            binaryTree.Add(file1.Result);
            binaryTree.Add(file2.Result);
            binaryTree.Add(file3.Result);
        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="word"></param>
        /// <param name="stArr"></param>
        /// <returns></returns>
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
