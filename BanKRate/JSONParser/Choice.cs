using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Choice : IPattern
    {
        IPattern[] pattern;

        public IPattern this[int index]
        {
            get => pattern[index];
            set => pattern[index] = value;
        }

        public Choice(params IPattern[] pattern)
        {
            this.pattern = pattern;
        }

        public (IMatch, string) Match(string text)
        {
            foreach (IPattern el in pattern)
            {
                var (m, n) = el.Match(text);

                if (m.Success)
                    return (m, n);
            }
            return (new NoMatch(text[0].ToString()), text);
        }
    }
}
