using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class ScientificNotationNumber : IPattern
    {
        Sequence exp = new Sequence(new RealNumber(), new Choice(new Character('e'), new Character('E')), new Optional(new Choice(new Character('-'), new Character('+'))), new Many(new Range('0', '9')));

        public (IMatch, string) Match(string text)
        {
            return exp.Match(text);
        }
    }
}
