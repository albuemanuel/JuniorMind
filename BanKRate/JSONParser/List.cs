using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class List : IPattern
    {
        Sequence listPattern;

        public List(Character separator, IPattern valuePattern)
        {
            listPattern = new Sequence
            (
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
                )
            );
        }

        public(IMatch, string) Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                return (new Match(""), "");
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
