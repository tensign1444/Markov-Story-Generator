using MarkovLibrary;
using System;
using System.Diagnostics;
using System.IO;

/**
* <author>
* Tanner Ensign, Nathan Maldonado, Masaya Takahashi
* </author> 
* 
*<summary>
* This is the Main class which is what displays the console along with talks to the user.
*</summary>
*
* <date>
* 4/9/2022
* </date> 
*/
namespace MarkovStories
{
    class Program
    {
        static int num;
        static int length;
        static string fileName;
        static bool checkWords;
        static bool CompleteSentence;
        static void Main(string[] args)
        {
                bool stopWhileLoop = false;
                Console.WriteLine("Please input file location");
                fileName = Console.ReadLine();


                WaitForSubStringLength();


                WaitForMaxLength();

                Console.WriteLine("Do you want to end with a complete sentence? (Y/N)");
                while (!stopWhileLoop)
                {
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "Y":
                            CompleteSentence = true;
                            stopWhileLoop = true;
                            break;
                        case "N":
                            CompleteSentence = false;
                            stopWhileLoop = true;
                            break;
                        default:
                            Console.WriteLine("Please insert Y/N");
                            break;
                    }
                }

                stopWhileLoop = false;

                Console.WriteLine("Do you want to check that the words exist in the original story?(Y/N) Note: THIS MAY MESS WITH ENDING A SENTENCE PROPERLY");
                while (!stopWhileLoop)
                {
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "Y":
                            checkWords = true;
                            stopWhileLoop = true;
                            break;
                        case "N":
                            checkWords = false;
                            stopWhileLoop = true;
                            break;
                        default:
                            Console.WriteLine("Please insert Y/N");
                            break;
                    }
                }

                GenerateLLST();
                GenerateBST();
                GenerateDictionary();

        }


        /// <summary>
        /// Waits for the user to input a number for substring length. Uses recursion if they do not input a valid number.
        /// </summary>
        static void WaitForSubStringLength()
        {
            Console.WriteLine("Please input a max substring length");
            try
            {
                num = Int32.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("That is not a number");
                WaitForSubStringLength();
            }
        }

        /// <summary>
        /// Waits for the user to input a number for max story length. Uses recursion if they do not input a valid number.
        /// </summary>
        static void WaitForMaxLength()
        {
            Console.WriteLine("Please input a max story length");
            
            try
            {
                length = Int32.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("That is not a number");
                WaitForMaxLength();
            }
        }


        /// <summary>
        /// Generates a story using the .Net Dictionary class
        /// </summary>
        static void GenerateDictionary()
        {
            Console.WriteLine("__________________________________________");
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            MarkovModel model = new MarkovModel(fileName, num, length, CompleteSentence, checkWords, 2);

            model.ReadFile();
            string story = model.GenerateStory().ToString();

            stopWatch.Stop();
            long executionTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine($"DotNet Sorted Dictionary\nText Length:{model.TxtDocCount} chars\nNew Text Length:{model.NewTxtCount} chars\nExecution Time: {executionTime} ms\n{story}");
        }

        /// <summary>
        /// Generates a story using our Linked List Symbol Table
        /// </summary>
        static void GenerateLLST()
        {
            Console.WriteLine("__________________________________________");
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            MarkovModel model = new MarkovModel(fileName, num, length, CompleteSentence, checkWords, 0);

            model.ReadFile();
            string story = model.GenerateStory().ToString();

            stopWatch.Stop();
            long executionTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine($"Custom Linked List Symbol Table\nOld Text Length:{model.TxtDocCount} chars\nNew Text Length:{model.NewTxtCount} chars\nExecution Time: {executionTime} ms\n{story}");
        }


        /// <summary>
        /// Generates a story using our custom Binary Search Tree
        /// </summary>
        static void GenerateBST()
        {
            Console.WriteLine("__________________________________________");
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            MarkovModel model = new MarkovModel(fileName, num, length, CompleteSentence, checkWords, 1);
            model.ReadFile();
            string story = model.GenerateStory().ToString();
            stopWatch.Stop();

            long executionTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine($"Custom Binary Tree Symbol Table\nText Length:{model.TxtDocCount} chars\nNew Text Length:{model.NewTxtCount} chars\nExecution Time: {executionTime} ms\n{story}");
        }


    }
}
