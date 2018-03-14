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

        public (IMatch, TextToParse) Match(ref TextToParse text)
        {
            foreach (IPattern el in pattern)
            {
                if (text.IsAtEnd())
                    return (new NoMoreText(), text);

                var (match, remainingText) = el.Match(ref text);

                if (match.Success)
                    return (match, remainingText);
            }
            return (new NoMatch(text.Current.ToString()), text);
        }
    }
}
