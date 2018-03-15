using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public interface IPattern
    {
        (IMatch, TextToParse) Match(TextToParse text);
    }
}
