using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class AtLeastOnce : IPattern
    {
        IPattern pattern;

        public AtLeastOnce(IPattern pattern) => this.pattern = pattern;

        public (IMatch, TextToParse) Match(ref TextToParse text)
        {
            if (text.IsAtEnd())
                return (new NoMoreText(), text);

            Many subPattern = new Many(pattern, 1);

            return subPattern.Match(ref text);
        }
    }
}
