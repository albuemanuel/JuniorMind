using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class RealNumber : IPattern
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

        public (IMatch, string) Match(string text)
        {
            return real.Match(text);
        }
    }
}
