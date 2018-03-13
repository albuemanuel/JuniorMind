using System;
using JSONParser;

namespace JSON
{
    class Program
    {



        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(args[0]);
            Console.WriteLine(text);

            JSONPattern pattern = new JSONPattern();



        }
    }
}
