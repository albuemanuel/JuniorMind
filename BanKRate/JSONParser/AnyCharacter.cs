using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class AnyCharacter : IPattern
    {
        Choice pattern;

        public AnyCharacter(string text)
        {
            Character[] textArray = new Character[text.Length];

            int i = 0;
            foreach (char el in text)
                textArray[i++] = new Character(el);

            pattern = new Choice(textArray);
        }

        public (IMatch, string) Match(string text) => pattern.Match(text);
    }
}
