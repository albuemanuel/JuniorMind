using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Many : IPattern
    {
        IPattern pattern;

        public Many(IPattern pattern) => this.pattern = pattern;

        public (IMatch, string) Match(string text)
        {
            string matchedText = "";
            var (match, remainingText) = pattern.Match(text);

            while(match.Success)
            {
                matchedText += (match as Match).Current;
                (match, remainingText) = pattern.Match(remainingText);
            }

            return (new Match(matchedText), remainingText);
        }
    }
}
