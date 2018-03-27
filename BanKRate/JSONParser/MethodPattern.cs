using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class MethodPattern : IPattern
    {
        IPattern method;

        public MethodPattern()
        {
            method = new Choice
                (
                    new Text("GET"),
                    new Text("POST"),
                    new Text("OPTIONS"),
                    new Text("HEAD"),
                    new Text("PUT"),
                    new Text("DELETE"),
                    new Text("TRACE"),
                    new Text("CONNECT")

                );
        }
        public (IMatch, TextToParse) Match(TextToParse text)
        {
            IMatch match;
            (match, text) = method.Match(text);

            //if (text.CurrentIndex != text.Pattern.Length && match.Success)
            //{
            //    Match matched = match as Match;
            //    return (new NoMatch($"{matched.Current}({text[matched.Current.Length]})", matched.Current.Length), text);
            //}

            return (match, text);
        }
    }
}
