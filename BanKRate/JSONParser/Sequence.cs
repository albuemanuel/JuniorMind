using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Sequence : IPattern
    {
        IPattern[] pattern;

        public Sequence(params IPattern[] pattern) => this.pattern = pattern;

        public (IMatch, string) Match(string text)
        {
            string matchedText = "";
            string tempText = text;
            foreach (IPattern el in pattern)
            {
                var (match, remainingText) = el.Match(tempText);
                tempText = remainingText;

                if (!match.Success)
                    return (match, text);

                matchedText += (match as Match).Current;
                
            }
            return (new Match(matchedText), tempText);
        }
    }
}
