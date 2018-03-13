using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Sequence : IPattern
    {
        IPattern[] pattern;

        public Sequence(params IPattern[] pattern) => this.pattern = pattern;

        public (IMatch, TextToParse) Match(ref TextToParse text)
        {
            string matchedText = "";
            int indexOrigin = text.CurrentIndex;

            foreach (IPattern el in pattern)
            {
                var (match, remainingText) = el.Match(ref text);

                if (!match.Success)
                {

                    return (match, text);
                }

                matchedText += (match as Match).Current;
            }
            return (new Match(matchedText), text);
        }
    }
}
