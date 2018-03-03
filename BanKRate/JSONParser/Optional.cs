using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Optional : IPattern
    {
        IPattern optionalPattern;

        public Optional(IPattern pattern) => optionalPattern = pattern;

        public (IMatch, string) Match(string text)
        {
            var (match, remainingText) = optionalPattern.Match(text);

            if (match.Success)
                return (match, remainingText);
            else
                return (new Match(""), text);
        }
    }
}
