using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class AnyCharacter : IPattern
    {
        public (IMatch, string) Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new NoMoreText(), text);

            if (!Char.IsLetter(text[0]))
                return (new NoMatch(text[0].ToString()), text);

            return (new Match(text[0].ToString()), text.Substring(1));
        }
    }
}
