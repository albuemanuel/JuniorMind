using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Choice : IPattern
    {
        protected IPattern[] pattern;

        public Choice(params IPattern[] pattern)
        {
            this.pattern = pattern;
        }
                
        public (IMatch, string) Match(string text)
        {
            foreach (IPattern el in pattern)
            {
                if (String.IsNullOrEmpty(text))
                    return (new NoMoreText(), text);

                var (match, remainingText) = el.Match(text);

                if (match.Success)
                    return (match, remainingText);
            }
            return (new NoMatch(text[0].ToString()), text);
        }
    }
}
