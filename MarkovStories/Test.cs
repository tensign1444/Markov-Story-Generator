using MarkovLibrary;
using System;
using System.Diagnostics;
using System.IO;

namespace MarkovStories
{
    class Program
    {
        static int num;
        static int length;
        static string fileName;

        static void Main(string[] args)
        {
            Console.WriteLine("Please input file location");
            // String fileName = Console.ReadLine();
            fileName = @"C:\Users\trish\Desktop\Lincoln.txt";
            Console.WriteLine("Please input a max substring length");
            //int num = Int32.Parse(Console.ReadLine());
            num = 100;
            Console.WriteLine("Please input a max story length");
            // int length = Int32.Parse(Console.ReadLine());
            length = 1000;
            GenerateLLST();
            GenerateBST();
            GenerateDictionary();

        }

        static void GenerateDictionary()
        {
            Console.WriteLine("__________________________________________");
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            MarkovModel model = new MarkovModel(fileName, num, length, 2);

            model.ReadFile();
            string story = model.GenerateStory().ToString();

            stopWatch.Stop();
            long executionTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine($"DotNet Sorted Dictionary\nText Length:{model.TxtDocCount} chars\nNew Text Length:{model.NewTxtCount} chars\nExecution Time: {executionTime} ms\n{story}");
        }

        static void GenerateLLST()
        {
            Console.WriteLine("__________________________________________");
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            MarkovModel model = new MarkovModel(fileName, num, length, 0);

            model.ReadFile();
            string story = model.GenerateStory().ToString();

            stopWatch.Stop();
            long executionTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine($"Custom Linked List Symbol Table\nOld Text Length:{model.TxtDocCount} chars\nNew Text Length:{model.NewTxtCount} chars\nExecution Time: {executionTime} ms\n{story}");
        }

        static void GenerateBST()
        {
            Console.WriteLine("__________________________________________");
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            MarkovModel model = new MarkovModel(fileName, num, length, 1);
            model.ReadFile();
            string story = model.GenerateStory().ToString();
            stopWatch.Stop();

            long executionTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine($"Custom Binary Tree Symbol Table\nText Length:{model.TxtDocCount} chars\nNew Text Length:{model.NewTxtCount} chars\nExecution Time: {executionTime} ms\n{story}");
        }


    }
}
