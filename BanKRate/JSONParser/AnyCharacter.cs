using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JSONParser
{
    class AnyCharacter : IPattern
    {
        readonly HashSet<Character> pattern;

        public AnyCharacter(string text)
        {
            pattern = new HashSet<Character>(text.Select(x => new Character(x)).ToArray());
        }

        public (IMatch, string) Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new NoMoreText(), text);

            foreach (Character choice in pattern)
            {
                var (match, remainingText) = choice.Match(text);

                if (match.Success)
                    return (match, remainingText);
            }
            return (new NoMatch(text[0].ToString()), text);
        }
    }
}
