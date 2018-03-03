using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class ScientificNotationNumber : IPattern
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

        public (IMatch, string) Match(string text) => exp.Match(text);
    }
}
