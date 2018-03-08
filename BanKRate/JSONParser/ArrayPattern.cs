using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class ArrayPattern : IPattern
    {
        Sequence arrayPattern = new Sequence(
            new Character('['),
            new List(new Character(','), new Value()),
            new Character(']')
            );

            
        public (IMatch, string) Match(string text)
        {
            return arrayPattern.Match(text);
        }
    }
}
