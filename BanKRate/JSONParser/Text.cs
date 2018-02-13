using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Text : IPattern
    {
        Sequence pattern;

        public Text(string pattern)
        {
            Character[] characters = new Character[pattern.Length];
            int i = 0;

            foreach(char character in pattern.ToCharArray())
                characters[i++] = new Character(character);

            this.pattern = new Sequence(characters);
        }

        public (IMatch, string) Match(string text)
        {
            return (pattern.Match(text));
        }
    }
}
