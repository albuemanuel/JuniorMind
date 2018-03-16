using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JSONParser
{
    public class Choice : IPattern
    {
        private readonly List<IPattern> pattern;

        public Choice(params IPattern[] pattern)
        {
            this.pattern = pattern.ToList();
        }

        public void AddPattern(IPattern newPattern)
        {
            pattern.Add(newPattern);
        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            IMatch match;
            TextToParse originalText = text;

            NoMatch partialMatch = new NoMatch("");

            foreach (IPattern el in pattern)
            {
                if (text.IsAtEnd())
                    return (new NoMoreText(), text);

                (match, text) = el.Match(text);

                if (match.Success)
                    return (match, text);
                else if(match as NoMatch != null)
                {
                    if ((match as NoMatch).Current.Length > partialMatch.Current.Length)
                        partialMatch = match as NoMatch;
                }

            }
            return (partialMatch, originalText);
        }
    }
}
