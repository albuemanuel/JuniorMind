using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONParser
{
    public class Text : IPattern
    {
        Sequence pattern;

        public Text(string pattern)
        {
            this.pattern = new Sequence(pattern.Select(character => new Character(character)).ToArray());
        }

        public (IMatch, TextToParse) Match(TextToParse text) => pattern.Match(text);
    }
}
