﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class HttpHeaderField : IPattern
    {
        IPattern httpHeader;

        public HttpHeaderField()
        {
            IPattern stringPattern = new Many
                (
                    new Choice
                    (
                        new Range(' ', '9'),
                        new Range(';', (char)byte.MaxValue)
                    )
                );

            IPattern cStringPattern = new Many                            //complete string pattern --> it has <space> and <:> chars
                (
                    new Choice
                    (
                        new Range(' ', (char)byte.MaxValue)
                    )
                );

            IPattern whitespace = new Many
            (
                new Choice
                (
                    new Character(' '),
                    new Character('\t')
                )
            );

            IPattern endHeaderField = new Text("\r\n");

            httpHeader = new Sequence
                    (
                        stringPattern,
                        //whitespace,
                        new Character(':'),
                        //whitespace,
                        cStringPattern,
                        endHeaderField
                    );
        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            return httpHeader.Match(text);
        }
    }
}
