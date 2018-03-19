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

                if(match.Success)
                {
                    matchedText += (match as Match).Current;
                }

                if (!match.Success)
                {
                    text.CurrentIndex = originalIndex;

                    if (match is NoMatch noMatch)
                        return (new NoMatch(matchedText + noMatch.Current, noMatch.Expected , noMatch.Current.Length - 2 + matchedText.Length - 1), text);

                    return (new NoMatch(matchedText, matchedText.Length), text);
                }
            }
            return (new Match(matchedText), text);
        }
    }
}
