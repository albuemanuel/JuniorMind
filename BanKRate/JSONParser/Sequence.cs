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
            IMatch match;
            MatchesArray matchesArray = new MatchesArray();
            int originalIndex = text.CurrentIndex;

            foreach (IPattern el in pattern)
            {
                (match, text) = el.Match(text);

                if(match.Success)
                {
                    matchesArray.AddPattern(match);
                    //matchedText += (match as Match).Current;
                }

                if (!match.Success)
                {
                    text.CurrentIndex = originalIndex;

                    if (match is NoMatch noMatch)
                        return (new NoMatch(matchesArray.ToString() + noMatch.Current, noMatch.Expected , noMatch.Current.Length - 2 + matchesArray.ToString().Length - 1), text);

                    if (match is NoMoreText noMoreText)
                        return (new NoMatch($"{matchesArray.ToString()}({noMoreText.Expected})", 3), text);

                    return (new NoMatch(matchesArray.ToString(), matchesArray.ToString().Length), text);
                }
            }
            return (matchesArray, text);
        }
    }
}
