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
                new Range('!', (char)byte.MaxValue)
            );
        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            IMatch match;
            (match, text) = uriPattern.Match(text);

            //if (text.CurrentIndex != text.Pattern.Length && match.Success)
            //{
            //    Match matched = match as Match;
            //    return (new NoMatch($"{matched.Current}({text[matched.Current.Length]})", matched.Current.Length), text);
            //}

            if (match.Success)
                return (new URIPatternMatch(match, UriKind.RelativeOrAbsolute), text);

            return (match, text);
        }
    }
}
