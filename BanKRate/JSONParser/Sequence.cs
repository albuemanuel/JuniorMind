using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Sequence : IPattern
    {
        IPattern[] pattern;

        public IPattern this[int index]
        {
            get => pattern[index];
            set => pattern[index] = value;
        }

        public Sequence(params IPattern[] pattern)
        {
            this.pattern = pattern;
        }

        public(IMatch, string) Match(string text)
        {
            string matchedText = "";
            foreach (IPattern el in pattern)
            {
                var (m, n) = el.Match(text);
                text = n;

                if (m.Success != true)
                    return (m, text);

                matchedText += (m as Match).Current;
                
            }
            return (new Match(matchedText), text);
        }
    }
}
