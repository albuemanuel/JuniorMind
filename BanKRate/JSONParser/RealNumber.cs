using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class RealNumber : IPattern
    {
        Sequence real = new Sequence(
            new IntegerNumber(),
            new Optional(
                new Sequence(
                    new Character('.'),
                    new AtLeastOnce(new Range('0', '9'))
                    )
                )
            );

        public (IMatch, TextToParse) Match(TextToParse text) => real.Match(text);
    }
}
