using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Optional : IPattern
    {
        IPattern optionalPattern;

        public Optional(IPattern pattern) => optionalPattern = pattern;

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            Many subPattern = new Many(optionalPattern, 0, 1);

            return subPattern.Match(text);
        }
    }
}
