using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Character : IPattern
    {
        char pattern;

        public char Pattern => pattern;

        public Character(char c)
        {
            pattern = c;
        }

        public(IMatch, TextToParse) Match(TextToParse text)
        {
            if (text.IsAtEnd())
                return (new NoMoreText(pattern.ToString()), text);

            if (text.Current != pattern)
                return (new NoMatch($"({text.Current})", pattern.ToString(), text.CurrentIndex), text);

            string matchedChar = text.Current.ToString();
            text.CurrentIndex++;
            return (new Match(matchedChar), text);
        }


    }
}
