using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Value : Choice
    {
        Choice value = new Choice(
            new StringPattern(),
            new ScientificNotationNumber(),
            new Text("true"),
            new Text("false"),
            new Text("null")
            );

        public void AddPattern(IPattern newPattern)
        {
            Array.Resize(ref , value.Length + 1);
            pattern[pattern.Length - 1] = newPattern;
        }

        public (IMatch, string) Match(string text)
        {
            return value.Match(text);
        }
    }
}
