using System;
using System.Collections.Generic;
using System.IO;

namespace TextFileFormation
{
    class Program
    {
        static string choiseMainMienu = "";
        static string choiseSecondMenu = "";
        static void Main(string[] args)
        {
<<<<<<< HEAD
            do
            {
                Console.WriteLine("******************MENU*******************");
                Console.WriteLine("1. CREATE A TEXTFILE C:\\1000_words.txt");
                Console.WriteLine("2. CREATE A TEXTFILE C:\\1500_words.txt");
                Console.WriteLine("3. CREATE A TEXTFILE C:\\3000_words.txt");
                Console.WriteLine("4. CHOISE A TEXT FILE TO CONTINUE");
                Console.WriteLine("Q. QUIT");
                Console.WriteLine();
                Console.Write("Enter you choise: ");
                choiseMainMienu = Console.ReadLine();
                Console.Clear();

                switch (choiseMainMienu)
                {
                    case "1":
                        CreateFile(1000, @"C:\1000_test.txt");
                        break;
                    case "2":
                        CreateFile(1500, @"C:\1500_test.txt");
                        break;
                    case "3":
                        CreateFile(3000, @"C:\3000_test.txt");
                        break;
                    case "4":
                        do
                        {
                            ShowSecondMenu();
                            Console.Write("Enter you choise: ");
                            choiseSecondMenu = Console.ReadLine();

                        } while (choiseSecondMenu != "Q");
                        break;
                    case "Q":
                        break;
                    default:
                        Console.WriteLine("WRONG INPUT. PLEASE PRESS ENTER TRY AGAIN ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (choiseMainMienu != "Q");
        }

        static void ShowSecondMenu()
        {
            Console.WriteLine("1. 1000 WORDS");
            Console.WriteLine("2. 1500 WORDS");
            Console.WriteLine("3. 3000 WORDS");
            Console.Write("CHOISE A TEXTFILE TO CONTINUE: ");
        }

        static void SecondMenu()
        {
            //switch ()
        }

            List<string> TextToListConverter(string fileName)
            {
                List<string> listOfWords = new List<string>();


                return listOfWords;
            }

            static void CreateFile(int words, string fileName)
            {
                try
                {
                    if (File.Exists(fileName))
                    {
                        Console.WriteLine("FILE " + fileName + "ALREDY EXISTS");
                        Console.Write("DELETE FILE (Y - delete existing file and create a new/N - go to main meu)?: ");
                        string input = Console.ReadLine();
                        if (input == "Y")
                        {
                            File.Delete(fileName);
                            using (FileStream fs = File.Create(fileName))
                            {
                                Console.WriteLine("FILE " + fileName + " IS CREATED. PRESS ENTER TO ADD " + words + " WORDS.");
                                Console.ReadKey();
                            }
                            using (StreamWriter sw = new StreamWriter(File.OpenWrite(fileName)))
                            {
                                for (int i = 1; i < words / 10; i++)
                                {
                                    sw.Write("Testfil som innehåller " + words + " ord. Test file existing " + words + " words. ");
                                }
                                Console.WriteLine(words + " WORDS ADDED TO THE FILE " + fileName);
                                Console.WriteLine("PRESS ENTER TO CONTINUE ...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                    }
                    else
                    {
                        using (FileStream fs = File.Create(fileName))
                        {
                            Console.WriteLine("FILE " + fileName + " IS CREATED. PRESS ENTER TO ADD " + words + " WORDS.");
                            Console.ReadKey();
                        };
                        using (StreamWriter sw = new StreamWriter(File.OpenWrite(fileName)))
                        {
                            for (int i = 1; i < words / 10; i++)
                            {
                                sw.Write("Testfil som innehåller " + words + " ord. Test file existing " + words + " words. ");
                            }
                            Console.WriteLine(words + " WORDS IS ADDED TO THE FILE " + fileName);
                            Console.WriteLine("PRESS ENTER TO CONTINUE ...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("SYSTEM CAN'T CREATE A FILE. ACCESS DENIED:  " + ex.ToString());
                    Console.WriteLine("PRESS ENTER TO CONTINUE ...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

=======
            var wordSearcher = new WordSearcher();
            wordSearcher.Run();
        }
>>>>>>> d8eea7156f0d2206a821764db5195c1be9e15712
    }
}
