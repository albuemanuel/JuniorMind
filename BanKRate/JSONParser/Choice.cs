﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Choice : IPattern
    {
        IPattern[] pattern;

        public Choice(params IPattern[] pattern)
        {
            this.pattern = pattern;
        }

        public (IMatch, string) Match(string text)
        {
            foreach (IPattern el in pattern)
            {
                var (match, remainingText) = el.Match(text);

                if (match.Success)
                    return (match, remainingText);
            }
            return (new NoMatch(text[0].ToString()), text);
        }
    }
}
