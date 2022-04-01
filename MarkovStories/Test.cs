using System;
using System.IO;

namespace MarkovStories
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input file location");
            String fileName = Console.ReadLine();
            Console.WriteLine("Pleas input a number");
            int num = Int32.Parse(Console.ReadLine());
            ReadFile(@"C:\Users\trish\Desktop\Test (2).txt");
            Console.WriteLine($"{fileName} : {num}");
        }


        private static void ReadFile(string fileLocation)
        {
            foreach (string line in File.ReadLines(fileLocation))
            {
                
            }
        }
    }
}
