using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Value : IPattern
    {
        Choice value = new Choice(
            new StringPattern(),
            new ScientificNotationNumber(),
            new ObjectPattern(),
            new ArrayPattern(),
            new Text("true"),
            new Text("false"),
            new Text("null")

            );


        public (IMatch, string) Match(string text)
        {
            return value.Match(text);
        }
    }
}
