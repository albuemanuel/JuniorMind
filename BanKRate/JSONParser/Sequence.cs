using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Sequence : IPattern
    {
        IPattern[] pattern;

        public Sequence(params IPattern[] pattern)
        {
            this.pattern = pattern;
        }

        public(IMatch, string) Match(string text)
        {
            string matchText = "";
            foreach (IPattern el in pattern)
            {
                matchText += text[0];
                var (m, n) = el.Match(text);
                text = n;

                if (m.Success != true)
                    return (new NoMatch(n[0].ToString()), text);
                
            }
            return (new Match(matchText), text);
        }
    }
}
