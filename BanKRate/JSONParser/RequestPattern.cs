using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class RequestPattern : IPattern
    {
        IPattern request;

        public RequestPattern()
        {
            IPattern endRequestPattern = new Text("\r\n");

            request = new Sequence
                (
                    new RequestLinePattern(),
                    new Many
                    (
                        new HttpHeaderField()
                    ),
                    endRequestPattern
                );
        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            return request.Match(text);
        }
    }
}
