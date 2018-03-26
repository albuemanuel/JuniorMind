using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class URIPattern : IPattern
    {
        IPattern uriPattern;

        public URIPattern()
        {
            uriPattern = new Many
            (
                new Range('!', (char)ushort.MaxValue)
            );
        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            IMatch match;
            (match, text) = uriPattern.Match(text);

            if (text.CurrentIndex != text.Pattern.Length && match.Success)
            {
                Match matched = match as Match;
                return (new NoMatch($"{matched.Current}({text[matched.Current.Length]})", matched.Current.Length), text);
            }

            return (match, text);
        }
    }
}
