﻿using System;
using JSONParser;

namespace JSON
{
    class Program
    {

        static void Main(string[] args)
        {
            TextToParse text = new TextToParse(System.IO.File.ReadAllText(args[0]));

            JSONPattern pattern = new JSONPattern();
            var (match, remainingText) = pattern.Match(text);

            Console.WriteLine(match.Success);

        }
    }
}
