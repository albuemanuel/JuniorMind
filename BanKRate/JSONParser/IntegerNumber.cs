using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class IntegerNumber : IPattern
    {
        Sequence integer = new Sequence(new Optional(new Character('-')), new Choice(new Character('0'), new Sequence(new Range('1', '9'), new Many(new Range('0', '9')))));

        public (IMatch, string) Match(string text)
        {
            return integer.Match(text);
        }
    }
}
