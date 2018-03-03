using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class AnyCharacter : IPattern
    {
        HashSet<Character> pattern;

        public AnyCharacter(string text)
        {
            Character[] textArray = new Character[text.Length];

            int i = 0;
            foreach (char el in text)
                textArray[i++] = new Character(el);

            pattern = new HashSet<Character>(textArray);
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
