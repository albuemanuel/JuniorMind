using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Range : IPattern
    {
        char limOne;
        char limTwo;

        public Range(char limOne, char limTwo)
        {
            this.limOne = limOne;
            this.limTwo = limTwo;
        }

        public (IMatch, TextToParse) Match(ref TextToParse text)
        {
            if (text.IsAtEnd())
                return (new NoMoreText(), text);


            if (text[0] >= limOne && text[0] <= limTwo)
            {
                string matchedChar = text.Current.ToString();
                text.CurrentIndex++;
                return (new Match(matchedChar), text);
            }


            return (new NoMatch(text.Current.ToString()), text);
        }

    }
}
