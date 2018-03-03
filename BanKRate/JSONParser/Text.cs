using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONParser
{
    class Text : IPattern
    {
        Sequence pattern;

        public Text(string pattern) => this.pattern = new Sequence(pattern.Select(character => new Character(character)).ToArray());

        public (IMatch, string) Match(string text) => pattern.Match(text);
    }
}
