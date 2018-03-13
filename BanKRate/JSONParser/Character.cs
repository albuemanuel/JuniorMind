﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Character : IPattern
    {
        char pattern;

        public Character(char c)
        {
            pattern = c;
        }

        public(IMatch, string) Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new NoMoreText(), text);

            if (text[0] != pattern)
                return (new NoMatch(text[0].ToString()), text);
                
            return (new Match(text[0].ToString()), text.Substring(1));
        }


    }
}
