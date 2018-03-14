using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Many : IPattern
    {
        IPattern pattern;
        int start, end;

        public Many(IPattern pattern, int start = 0, int end = 0)
        {
            this.pattern = pattern;
            this.start = start;
            this.end = end;
        }

        public (IMatch, TextToParse) Match(ref TextToParse text)
        {
            string matchedText = "";
            //var (match, remainingText) = pattern.Match(ref text);

            var match = pattern.Match(ref text).Item1;
            int count = 0;

            while (match.Success)
            {
                count++;
                matchedText += (match as Match).Current;
                match = pattern.Match(ref text).Item1;
            }

            if (count >= start && (end == 0 || count <= end))
                return (new Match(matchedText), text);

            if ((count < start && count > 0) || count > end)
                return (new NoMatch("Wrong number of " + "<" + pattern.ToString() + ">" + " objects"), text);


            return (new NoMatch(text[0].ToString()), text);
        }
    }
}
