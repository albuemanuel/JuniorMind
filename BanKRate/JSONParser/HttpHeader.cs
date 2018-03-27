using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class HttpHeader : IPattern
    {
        IPattern httpHeader;

        public HttpHeader()
        {
            IPattern stringPattern = new Many
                (
                    new Choice
                    (
                        new Range('!', '9'),
                        new Range(';', (char)byte.MaxValue)
                    )
                );

            IPattern endRequestLine = new Text("\r\n");

            httpHeader = new Many
                (
                    new Sequence
                    (
                        stringPattern,
                        new Character(':'),
                        stringPattern,
                        endRequestLine
                    )
                );
        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            return httpHeader.Match(text);
        }
    }
}
