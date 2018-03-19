using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class List : IPattern
    {
        IPattern listPattern;

        public List(IPattern valuePattern) 
            : this(valuePattern, new Character(','))
        {
        }

        public List(IPattern valuePattern, IPattern separator)
        {
            listPattern = new Sequence(
                        valuePattern,
                        new Many
                        (
                            new Sequence
                            (
                                
                                separator,
                                valuePattern
                               
                            )

                         )
                         );
        }

        public(IMatch, TextToParse) Match(TextToParse text)
        {

            Text emptyList = new Text("[]");

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

            if (emptyList.Match(text).Item1 is Match empty)
                return (empty, new TextToParse(text.Pattern, 2));


            return listPattern.Match(text);
        }
    }
}
