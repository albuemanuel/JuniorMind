using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class JSONPattern : IPattern
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

        IPattern jsPattern;

        public JSONPattern()
        {
            var value = new Choice
            (
                new StringPattern(),
                new ScientificNotationNumber(),
                new Text("true"),
                new Text("false"),
                new Text("null")
            );

            var objectPattern = new Sequence
            (
                new Character('{'),
                whitespace,
                new List
                (
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

            var arrayPattern = new Sequence
            (
                new Character('['),
                whitespace,
                new List
                (
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

            jsPattern = new Sequence(
                whitespace,
                value,
                whitespace
                );

        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            IMatch match;
            (match, text) = jsPattern.Match(text);

            if (text.CurrentIndex != text.Pattern.Length && match.Success)
            {
                Match matched = match as Match;
                return (new NoMatch($"{matched.Current}({text[matched.Current.Length]})", matched.Current.Length), text);
            }

            return (match, text);


        }
    }
}
