using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class AnyCharacter : IPattern
    {
        string pattern;

        public AnyCharacter(string pattern)
        {
            this.pattern = pattern;
        }

        public (IMatch, string) Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new NoMoreText(), text);

            foreach (Char c in pattern)
            {
                if (c == text[0])
                    return (new Match(text[0].ToString()), text.Substring(1));
            }

            return (new NoMatch(text[0].ToString()), text);
        }



    }
}
