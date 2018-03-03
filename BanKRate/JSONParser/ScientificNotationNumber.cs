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
                new Choice(new Text("e"), new Text("E")), 
                new Optional(new Choice(
                    new Text("-"), 
                    new Text("+"))), 
                new AtLeastOnce(new Range('0', '9'))
                )
                )
            );

        public (IMatch, string) Match(string text)
        {
            return exp.Match(text);
        }
    }
}
