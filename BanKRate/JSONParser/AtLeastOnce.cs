using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class AtLeastOnce : IPattern
    {
        IPattern pattern;

        public AtLeastOnce(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public (IMatch, string) Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new NoMoreText(), text);

            Many subPattern = new Many(pattern);
            var (match, remainingText) = subPattern.Match(text);

            if (remainingText != text)
                return (match, remainingText);

            return (new NoMatch(text[0].ToString()), text);
        }
    }
}
