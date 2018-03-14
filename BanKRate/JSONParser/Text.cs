using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONParser
{
    public class Text : IPattern
    {
        Sequence pattern;

        public Text(string pattern) => this.pattern = new Sequence(pattern.Select(character => new Character(character)).ToArray());

        public (IMatch, TextToParse) Match(ref TextToParse text) => pattern.Match(ref text);
    }
}
