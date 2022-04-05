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
            String fileName = Console.ReadLine();
            Console.WriteLine("Please input a max substring length");
            int num = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please input a max story length");
            int length = Int32.Parse(Console.ReadLine());
            MarkovModel model = new MarkovModel(fileName, num, length);

            model.ReadFile();

            Console.WriteLine(model.ToString());

        }


      
    }
}
