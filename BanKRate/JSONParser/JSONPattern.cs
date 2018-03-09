using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class JSONPattern : IPattern
    {
        Many whitespace = new Many
        (
            new Choice
            (
                new Character(' '),
                new Character('\n'),
                new Character('\t'),
                new Character('\r')
            )
        );

        Choice value;
        Sequence objectPattern;
        Sequence arrayPattern;
        Sequence jsPattern;

        public JSONPattern()
        {
            value = new Choice
            (
                new StringPattern(),
                new ScientificNotationNumber(),
                new Text("true"),
                new Text("false"),
                new Text("null")
            );

            objectPattern = new Sequence
            (
                new Character('{'),
                whitespace,
                new List
                (
                    new Character(','),
                    new Sequence
                    (
                        whitespace,
                        new StringPattern(),
                        whitespace,
                        new Character(':'),
                        whitespace,

                        value,

                        whitespace
                    )
                ),
                whitespace,
                new Character('}')
            );

            arrayPattern = new Sequence
            (
                new Character('['),
                whitespace,
                new List
                (
                    new Character(','),
                    new Sequence
                    (
                        whitespace,
                        value,
                        whitespace
                    )
                ),
                whitespace,
                new Character(']')
            );

            value.AddPattern(objectPattern);
            value.AddPattern(arrayPattern);

            jsPattern = new Sequence
            (
                new Many
                (
                    new Choice
                    (
                        objectPattern,
                        arrayPattern
                    )
                )
            );
            
        }

        public (IMatch, string) Match(string text)
        {
            //var (match, remainingText) = jsPattern.Match(text);

            return jsPattern.Match(text);


        }
    }
}
