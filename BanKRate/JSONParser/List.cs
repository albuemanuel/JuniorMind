using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class List : IPattern
    {
        Choice listPattern;

        public List(IPattern valuePattern)
        {
            listPattern =
                new Choice(
                    new Sequence(
                        new Many
                        (
                            new Sequence
                            (
                                valuePattern,
                                new Character(',')
                            )
                        ),
                        valuePattern
                    ),

                    valuePattern

                );
            
        }

        public(IMatch, TextToParse) Match(TextToParse text)
        {
            if (text.IsAtEnd())
                return (new Match(""), text);
            //string matchedText = "";
            //while (true)
            //{
            //    var (match, remainingText) = valuePattern.Match(text);
            //    text = remainingText;

            //    if (!match.Success)
            //        return (match, text);

            //    matchedText += (match as Match).Current;

            //    (match, remainingText) = separator.Match(text);
            //    text = remainingText;

            //    if (!match.Success)
            //    {
            //        if (!Char.IsLetter(text[0]))
            //            return (new Match(matchedText), text);
            //        return (match, text);
            //    }

            //    matchedText += (match as Match).Current;

            //}
            return listPattern.Match(text);
        }
    }
}
