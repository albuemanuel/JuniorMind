using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Text : IPattern
    {
        string pattern;

        public Text(string pattern)
        {
            this.pattern = pattern;
        }

        public (IMatch, string) Match(string text)
        {
            if(String.IsNullOrEmpty(text))
                return (new NoMoreText(), text);
            if (text.IndexOf(pattern) != -1)
                return (new Match(text), text.Substring(text.Length));

            return (new NoMatch(text), text);
        }
    }
}
