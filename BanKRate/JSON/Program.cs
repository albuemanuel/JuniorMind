using System;
using JSONParser;

namespace JSON
{
    class Program
    {

        static (int, int) CalculateIndexOf(char x, string source)
        {
            int countNL = 0;
            int countChar = 0;
            foreach(var el in source)
            {
                if (el == '\n')
                {
                    countChar = 0;
                    countNL++;
                }
                countChar++;
                if (el == x)
                    return (countNL+1, countChar-1);
            }
            return (0, 0);
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
                char noMatch = (match as NoMatch).Current[0];
                Console.Write($"--> !jSONPattern '{noMatch}' at ind ( {CalculateIndexOf(noMatch, text.Pattern)} )\n");
            }

        }
    }
}
