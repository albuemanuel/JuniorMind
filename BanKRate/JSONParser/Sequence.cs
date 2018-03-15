using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Sequence : IPattern
    {
        IPattern[] pattern;

        public Sequence(params IPattern[] pattern) => this.pattern = pattern;

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            string matchedText = "";
            IMatch match;
            int originalIndex = text.CurrentIndex;

            foreach (IPattern el in pattern)
            {
                (match, text) = el.Match(text);

                if (!match.Success)
                {
                    text.CurrentIndex = originalIndex;
                    return (match, text);
                }

                matchedText += (match as Match).Current;
            }
            return (new Match(matchedText), text);
        }
    }
}
