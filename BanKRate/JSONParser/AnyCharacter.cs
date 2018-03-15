using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JSONParser
{
    public class AnyCharacter : IPattern
    {
        readonly HashSet<char> pattern;

        public AnyCharacter(string text)
        {
            pattern = new HashSet<char>(text.Select(x => x));
        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            if (text.IsAtEnd())
                return (new NoMoreText(), text);

            if (pattern.Contains(text.Current))
                return (new Match(text.Current.ToString()), new TextToParse(text.Pattern, text.CurrentIndex+1));

            return (new NoMatch(text[text.CurrentIndex].ToString()), text);
        }
    }
}
