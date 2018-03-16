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

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            //return pattern.Match(text);
            var (match, rText) = pattern.Match(text);

            if (match.Success)
                return (match, rText);

            else if (match as NoMatch != null)
                return (new NoMatch(rText.Pattern.Substring(0, rText.CurrentIndex)), rText);

            return (match, rText);

        }
    }
}
