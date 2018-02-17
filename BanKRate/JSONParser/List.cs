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
                var (match, remainingText) = valuePattern.Match(text);
                text = remainingText;

                if (!match.Success)
                    return (match, text);

                matchedText += (match as Match).Current;

                (match, remainingText) = separator.Match(text);
                text = remainingText;

                if (!match.Success)
                {
                    if (!Char.IsLetter(text[0]))
                        return (new Match(matchedText), text);
                    return (match, text);
                }

                matchedText += (match as Match).Current;

            }
        }
    }
}
