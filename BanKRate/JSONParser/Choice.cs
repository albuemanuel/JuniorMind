﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JSONParser
{
    //public class Choice : IPattern
    //{
    //    private readonly List<IPattern> pattern;

    //    public Choice(params IPattern[] pattern)
    //    {
    //        this.pattern = pattern.ToList();
    //    }

    //    public void AddPattern(IPattern newPattern)
    //    {
    //        pattern.Add(newPattern);
    //    }

    //    public (IMatch, string) Match(string text)
    //    {
    //        foreach (IPattern el in pattern)
    //        {
    //            if (String.IsNullOrEmpty(text))
    //                return (new NoMoreText(), text);

    //            var (match, remainingText) = el.Match(text);

    //            if (match.Success)
    //                return (match, remainingText);
    //        }
    //        return (new NoMatch(text[0].ToString()), text);
    //    }
    //}
}
