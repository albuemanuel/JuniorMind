using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Optional : IPattern
    {
        Character optional;

        public Optional(char pattern)
        {
            optional = new Character(pattern);
        }

        public (IMatch, string) Match(string text)
        {
            var (match, remainingText) = optional.Match(text);

            if (match.Success)
                return (match, remainingText);
            else
                return (new Match(""), text);
        }
    }
}
