using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Range : IPattern
    {
        char limOne;
        char limTwo;

        public Range(char limOne, char limTwo)
        {
            this.limOne = limOne;
            this.limTwo = limTwo;
        }

        public (IMatch, string) Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new NoMoreText(), text);

            
            if (text[0] >= limOne && text[0] <= limTwo)
                return (new Match(text[0].ToString()), text.Substring(1));
            

            return (new NoMatch(text[0].ToString()), text);
        }

    }
}
