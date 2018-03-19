using System;
using JSONParser;

namespace JSON
{
    class Program
    {

        static (int, int) CalculateIndexOf(char x, string source)
        {
            int noOfNL = CalculateNoOfNL(source);
            int countNL = 0;
            int countChar = 0;
            int countCol = 0;
            foreach(var el in source)
            {
                if (el == '\n')
                {
                    countNL++;
                }

                if (countNL == noOfNL)
                {
                    countCol = source.Length  - countChar - 3;
                    return (noOfNL, countCol);
                }

                countChar++;
            }

            return (0, 0);
        }

        static int CalculateNoOfNL(string text)
        {
            int count = 0;
            foreach(var el in text)
            {
                if (el == '\n')
                    count++;
            }
            return count;
        }

        static void Main(string[] args)
        {
            TextToParse text = new TextToParse(System.IO.File.ReadAllText(args[0]));

            JSONPattern pattern = new JSONPattern();
            var (match, remainingText) = pattern.Match(text);

            if (match.Success)
                Console.WriteLine($"{text.Pattern} \n\n is a jSONPattern\n");
            else
            {
                char noMatch = (match as NoMatch).CharOfNoMatch;

                if (Char.IsWhiteSpace(noMatch))
                    noMatch = ' '; 

                string exp = (match as NoMatch).Expected;

                Console.Write($"\r\n--> !jSONPattern because of '{noMatch}' at ind {CalculateIndexOf(noMatch, (match as NoMatch).Current)}\nExpected '{exp}'\n");
            }


        }
    }
}
