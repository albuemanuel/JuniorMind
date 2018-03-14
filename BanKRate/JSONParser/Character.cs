using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Character : IPattern
    {
        char pattern;

        public Character(char c)
        {
            pattern = c;
        }

        public(IMatch, TextToParse) Match(ref TextToParse text)
        {
            if (text.IsAtEnd())
                return (new NoMoreText(), text);

            if (text.Current != pattern)
                return (new NoMatch(text.Current.ToString()), text);

            string matchedChar = text.Current.ToString();
            text.CurrentIndex++;
            return (new Match(matchedChar), text);
        }


    }
}
