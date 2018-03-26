using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class RequestLinePattern : IPattern
    {
        IPattern requestLine;

        public RequestLinePattern()
        {
            IPattern whitespace = new Many
            (
                new Choice
                (
                    new Character(' '),
                    new Character('\t')
                )
            );

            IPattern endRequestLine = new Text("\r\n");

            requestLine = new Sequence
            (
                new MethodPattern(),
                whitespace,
                new URIPattern(),
                whitespace,
                new HTTPVersionPattern(),
                endRequestLine
            );
        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            return requestLine.Match(text);
        }
    }
}
