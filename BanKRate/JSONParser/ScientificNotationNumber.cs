using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class ScientificNotationNumber : IPattern
    {
        Sequence exp = new Sequence(
            new RealNumber(),
            new Optional(new Sequence(
                new AnyCharacter("eE"),
                new Optional(new AnyCharacter("-+")),
                new AtLeastOnce(new Range('0', '9'))
                )
                )
            );

        public (IMatch, TextToParse) Match(TextToParse text) => exp.Match(text);
    }
}
