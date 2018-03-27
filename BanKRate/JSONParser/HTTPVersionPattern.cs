using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class HTTPVersionPattern : IPattern
    {
        IPattern version;

        public HTTPVersionPattern()
        {
            IPattern digit = new Choice
            (
                new Range('0', '9')
            );

            IPattern number = new Many(digit);

            version = new Sequence
            (
                new Text("HTTP/"),
                number,
                new Character('.'),
                number
                );
        }
        public (IMatch, TextToParse) Match(TextToParse text)
        {
            IMatch match;
            (match, text) = version.Match(text);

            //if (text.CurrentIndex != text.Pattern.Length && match.Success)
            //{
            //    Match matched = match as Match;
            //    return (new NoMatch($"{matched.Current}({text[matched.Current.Length]})", matched.Current.Length), text);
            //}

            return (match, text);
        }
    }
}
