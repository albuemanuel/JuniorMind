using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JSONParser
{
    public class AnyCharacter : IPattern
    {
        readonly HashSet<Character> pattern;

        public AnyCharacter(string text)
        {
            pattern = new HashSet<Character>(text.Select(x => new Character(x)).ToArray());
        }

        public (IMatch, TextToParse) Match(ref TextToParse text)
        {
            if (text.IsAtEnd())
                return (new NoMoreText(), text);

            foreach (Character choice in pattern)
            {
                var (match, remainingText) = choice.Match(ref text);

                if (match.Success)
                    return (match, text);
            }
            return (new NoMatch(text[text.CurrentIndex].ToString()), text);
        }
    }
}
