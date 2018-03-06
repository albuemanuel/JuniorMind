using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Many : IPattern
    {
        IPattern pattern;
        int start, end;

        public Many(IPattern pattern, int start = 0, int end = 0)
        {
            this.pattern = pattern;
            this.start = start;
            this.end = end;
        }

        public (IMatch, string) Match(string text)
        {
            string matchedText = "";
            var (match, remainingText) = pattern.Match(text);
            int count = 0;

            while(match.Success)
            {
                count++;
                matchedText += (match as Match).Current;
                (match, remainingText) = pattern.Match(remainingText);
            }

            if( count >= start && (end == 0 || count <= end) )
                return (new Match(matchedText), remainingText);

            return (new NoMatch(text[0].ToString()), text);
        }
    }
}
