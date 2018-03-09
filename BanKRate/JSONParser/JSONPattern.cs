using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class JSONPattern : IPattern
    {
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
                new List
                (
                    new Character(','),
                    new Sequence
                    (
                        new StringPattern(),
                        new Character(':'),
                        value
                    )
                ),
                new Character('}')
            );

            arrayPattern = new Sequence
            (
                new Character('['),
                new List
                (
                    new Character(','),
                    value
                ),
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
            return jsPattern.Match(text);


        }
    }
}
