using MarkovLibrary;
using System;
using System.IO;

namespace MarkovStories
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input file location");
            // String fileName = Console.ReadLine();
            String fileName = @"C:\Users\trish\Desktop\Lincoln.txt";
            Console.WriteLine("Please input a max substring length");
            //int num = Int32.Parse(Console.ReadLine());
            int num = 10;
            Console.WriteLine("Please input a max story length");
            // int length = Int32.Parse(Console.ReadLine());
            int length = 4000;
            MarkovModel model = new MarkovModel(fileName, num, length, 0);

            model.ReadFile();

            Console.WriteLine(model.ToString());

        }


      
    }
}
