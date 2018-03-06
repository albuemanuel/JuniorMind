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
            Many subPattern = new Many(optionalPattern);

            return subPattern.Match(text);
        }
    }
}
