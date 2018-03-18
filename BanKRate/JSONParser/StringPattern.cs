using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class StringPattern : IPattern
    {
        Sequence stringPattern;

        public StringPattern()
        {
            Choice digit = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));

            Sequence unicode = new Sequence(new Text("\\u"), new Many(digit, 4, 4));

            stringPattern = new Sequence(
                new Character('\"'),
                new Many(
                    new Choice(
                                            //  
                        new Range('0', (char)ushort.MaxValue),
                        new Text("\\\""),
                        new Text("\\\\"),
                        new Text("\\/"),
                        new Text("\\b"),
                        new Text("\\f"),
                        new Text("\\n"),
                        new Text("\\r"),
                        new Text("\\t"),
                        unicode,
                        new Range('#', '.'),             //any unicode char except ", \ or any ctrl char
                        new AnyCharacter("! ")                               //
                    )
                ),
                new Character('\"')
            );
        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            return stringPattern.Match(text);
        }
    }
}
