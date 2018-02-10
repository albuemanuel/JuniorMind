using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class List : IPattern
    {
        IPattern valuePattern;
        Character separator;

        public List(Character separator, IPattern valuePattern)
        {
            this.valuePattern = valuePattern;
            this.separator = separator;
        }

        public(IMatch, string) Match(string text)
        {
            string matchedText = "";
            while (true)
            {
                var (m, n) = valuePattern.Match(text);
                text = n;

                if (!m.Success)
                    return (m, text);

                matchedText += (m as Match).Current;

                (m, n) = separator.Match(text);
                text = n;

                if (!m.Success)
                {
                    if (!Char.IsLetter(text[0]))
                        return (new Match(matchedText), text);
                    return (m, text);
                }

                matchedText += (m as Match).Current;

            }
        }
    }
}
