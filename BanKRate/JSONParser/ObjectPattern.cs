using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class ObjectPattern : IPattern
    {
        Sequence objectPattern = new Sequence(
            new Character('{'),
            new Many(
                new Sequence(
                    new StringPattern(),
                    new Character(':'),
                    new Value()
                )));

        public (IMatch, string) Match(string text)
        {
            return objectPattern.Match(text);
        }
    }
}
