using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    interface IPattern
    {
        (IMatch, string) Match(string text);
    }
}
