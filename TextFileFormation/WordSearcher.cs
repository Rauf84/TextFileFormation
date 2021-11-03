using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TextFileFormation
{
    internal class WordSearcher
    {
        private BinaryTree binaryTree = new BinaryTree();

        /// <summary>
        /// Run method to startup the application.
        /// </summary>
        public void Run()
        {
            MainMenu();
        }

        /// <summary>
        /// Method for the main menu.
        /// </summary>
        private void MainMenu()
        {
            FileObject file1, file2, file3;
            Setup(out file1, out file2, out file3);

            bool run = true;
            while (run)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Search document for a word");
                Console.WriteLine("2. Print datastructure");
                Console.WriteLine("3. Sort in alphabethic order and print.");
                Console.WriteLine("0. End program.");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
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
                                SortAlphabetical(file1, file2, file3);
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
                else
                {
                    Console.WriteLine("Wrong input, try again.");
                }
            }
        }

        /// <summary>
        /// Setup runs to setup the files.
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="file3"></param>
        private void Setup(out FileObject file1, out FileObject file2, out FileObject file3)
        {
            var fileName1 = "Text_1000.txt";
            var fileName2 = "Text_1500.txt";
            var fileName3 = "Text_3000.txt";

            var fileConvert1 = ConvertFileToArray(@"\TextFiles\" + fileName1);
            var fileConvert2 = ConvertFileToArray(@"\TextFiles\" + fileName2);
            var fileConvert3 = ConvertFileToArray(@"\TextFiles\" + fileName3);

            file1 = new FileObject()
            {
                Name = fileName1,
                Data = fileConvert1
            };
            file2 = new FileObject()
            {
                Name = fileName2,
                Data = fileConvert2
            };
            file3 = new FileObject()
            {
                Name = fileName3,
                Data = fileConvert3
            };
        }

        /// <summary>
        /// Convert file to string array.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string[] ConvertFileToArray(string fileName)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + $"{fileName}";
            string files = File.ReadAllText(path);
            return files.Split(' ');
        }

        /// <summary>
        /// Sort words in the files in alphabetical order.
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="file3"></param>
        private void SortAlphabetical(FileObject file1, FileObject file2, FileObject file3)
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

            PrintTheAlphabeticalSortedLists(sortedList1, sortedList2, sortedList3);
        }

        /// <summary>
        /// Prints the sorted lists to console.
        /// </summary>
        /// <param name="sortedList1"></param>
        /// <param name="sortedList2"></param>
        /// <param name="sortedList3"></param>
        private static void PrintTheAlphabeticalSortedLists(List<string> sortedList1, List<string> sortedList2, List<string> sortedList3)
        {
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

        /// <summary>
        /// Prints all data in the binarytree to console.
        /// </summary>
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

        /// <summary>
        /// Search for the input word in the files.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="file3"></param>
        private void SearchForWord(string word, FileObject file1, FileObject file2, FileObject file3)
        {
            file1.Result = CountWordsInFile(word, file1.Data);
            file2.Result = CountWordsInFile(word, file2.Data);
            file3.Result = CountWordsInFile(word, file3.Data);

            SortData(file1, file2, file3);
        }

        /// <summary>
        /// Sort the data.
        /// O(n^2)
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="file3"></param>
        private void SortData(FileObject file1, FileObject file2, FileObject file3)
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

            PrintSortedData(fileObjectList, arrInt);
            SaveResultMenu(file1, file2, file3);
        }

        /// <summary>
        /// Prints the sorted data.
        /// </summary>
        /// <param name="fileObjectList"></param>
        /// <param name="arrInt"></param>
        private static void PrintSortedData(List<FileObject> fileObjectList, int[] arrInt)
        {
            for (int i = 0; i < arrInt.Length; i++)
            {
                for (int j = 0; j < fileObjectList.Count; j++)
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
        }

        /// <summary>
        /// Method to save result.
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="file3"></param>
        private void SaveResultMenu(FileObject file1, FileObject file2, FileObject file3)
        {
            bool run = true;
            while (run)
            {
                Console.Write("Save results? y/n: ");
                string input = Console.ReadLine().ToLower();
                if (!string.IsNullOrEmpty(input))
                {
                    switch (input)
                    {
                        case "y":
                            {
                                SaveResult(file1, file2, file3);
                                Console.WriteLine("Results was saved.");
                                run = false;
                                break;
                            }
                        case "n":
                            {
                                Console.WriteLine("Results was not saved.");
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

        /// <summary>
        /// Save results to binary tree.
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="file3"></param>
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