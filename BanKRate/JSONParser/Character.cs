using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Character : IPattern
    {
        char pattern;

        public Character(char c)
        {
            pattern = c;
        }

        public(IMatch, string) Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new NoMoreText(), text);
            if (text[0] != pattern)
                return (new NoMatch(text[0]), text);

            return (new Success(text[0]), text.Substring(1));
        }


    }
}
