using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Number : IPattern
    {
        Sequence number = new Sequence(new Character('-'), new Choice(new Character('0'), new Many(new Range('1', '9'))));

        public (IMatch, string) Match(string text)
        {
            return number.Match(text);
        }
    }
}
