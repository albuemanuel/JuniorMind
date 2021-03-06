﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Many : IPattern
    {
        IPattern pattern;
        int start, end;

        public Many(IPattern pattern, int start = 0, int end = 0)
        {
            this.pattern = pattern;
            this.start = start;
            this.end = end;
        }

        public (IMatch, TextToParse) Match(TextToParse text)
        {
            string matchedText = "";
            MatchesArray matchesArray = new MatchesArray();
            IMatch match;
            TextToParse originalText = text;

            (match, text) = pattern.Match(text);
            
            int count = 0;

            while (match.Success)
            {
                count++;
                //matchedText += (match as Match).Current;
                matchesArray.AddPattern(match);
                (match, text) = pattern.Match(text);
            }

            if (count >= start && (end == 0 || count <= end))
                return (matchesArray, text);

            if ((count < start && count > 0) || count > end)
                return (new NoMatch("Wrong number of " + "<" + pattern.ToString() + ">" + " objects", pattern.ToString(), originalText.CurrentIndex), text);

            NoMatch noMatch = match as NoMatch;
            return (new NoMatch(matchedText + noMatch.Current, noMatch.Expected ,matchedText.Length + noMatch.Current.Length-3), originalText);
        }
    }
}
