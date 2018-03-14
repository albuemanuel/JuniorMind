using System;
using Xunit;

namespace JSONParser
{
    public class JSONParserTests
    {
        [Fact]
        public void CharacterMatch()
        {
            Character pattern = new Character('a');
            TextToParse text = new TextToParse("abcd");

            var (match, remainingText) = pattern.Match(ref text);

            Assert.Equal((new Match("a"), text), (match, remainingText));
        }

        [Fact]
        public void AnyCharacterMatchOrNot()
        {
            AnyCharacter pattern = new AnyCharacter("abc");
            TextToParse text = new TextToParse("abcd");
            TextToParse text2 = new TextToParse("efgh");

            var (match, remainingText) = pattern.Match(ref text);

            Assert.Equal((new Match("a"), text), (match, remainingText));


            (match, remainingText) = pattern.Match(ref text2);

            Assert.Equal((new NoMatch("e"), text2), (match, remainingText));
        }

        [Fact]
        public void CharacterNoMatch()
        {
            Character pattern = new Character('c');
            TextToParse text = new TextToParse("abcd");

            var (match, remainingText) = pattern.Match(ref text);

            Assert.Equal((new NoMatch("a"), text), (match, remainingText));
        }

        [Fact]
        public void CharacterNoMoreText()
        {
            Character pattern = new Character('c');
            TextToParse text = new TextToParse("");

            var (match, remainingText) = pattern.Match(ref text);

            Assert.Equal((new NoMoreText(), text), (match, remainingText));
        }

        [Fact]
        public void SequenceMatch()
        {
            Sequence pattern = new Sequence(new Character('a'), new Character('b'), new Character('c'));
            Sequence pattern2 = new Sequence(new AnyCharacter("xz"), new AnyCharacter("xz"), new Character('c'));
            Sequence pattern3 = new Sequence(new Character('['), new List(new AnyCharacter("xyz")), new Character(']'));
            TextToParse text = new TextToParse("abcd");
            TextToParse text2 = new TextToParse("xzcdef");
            TextToParse text3 = new TextToParse("[z,x,y]");

            var (match, remainingText) = pattern.Match(ref text);

            Assert.Equal((new Match("abc"), text), (match, remainingText));

            (match, remainingText) = pattern2.Match(ref text2);

            Assert.Equal((new Match("xzc"), text2), (match, remainingText));

            match = pattern3.Match(ref text3).Item1;

            Assert.Equal((new Match("[z,x,y]"), text3), (match, text3));
        }

        [Fact]
        public void ListMatch()
        {
            List listPattern = new List(new AnyCharacter("xyz"));

            TextToParse text = new TextToParse("x,y,z]");

            var (match, remainingText) = listPattern.Match(ref text);

            Assert.Equal((new Match("x,y,z"), text), (match, remainingText));
        }

        //[Fact]
        //public void ArrayPatternMatch()
        //{

        //    Many whitespace = new Many
        //     (
        //    new Choice
        //    (
        //        new Character(' '),
        //        new Character('\n'),
        //        new Character('\t'),
        //        new Character('\r')
        //    )
        //        );

        //    Sequence arrayPattern = new Sequence
        //    (
        //        new Character('['),
        //        whitespace,
        //        new List
        //        (
        //            new Sequence
        //            (
        //                whitespace,
        //                new StringPattern(),
        //                whitespace
        //            )
        //        ),
        //        whitespace,
        //        new Character(']')
        //    );

        //    string text = "[\"value1\",\"value2\"]";
        //    string text2 = "[\"value1\"\"value2\"]";

        //    Assert.Equal((new Match(text), ""), arrayPattern.Match(text));
        //    Assert.NotEqual((new Match(text2), ""), arrayPattern.Match(text2));
        //}

        [Fact]
        public void ListMatch2()
        {
            List listPattern = new List(new AnyCharacter("123456"));

            TextToParse text = new TextToParse("2,");

            var match = listPattern.Match(ref text).Item1;

            Assert.Equal((new Match("2"), text), (match, text));
        }

        [Fact]
        public void ListMatchEmpty()
        {
            List listPattern = new List(new AnyCharacter("123456"));

            TextToParse text = new TextToParse("");

            var match = listPattern.Match(ref text).Item1;

            Assert.Equal((new Match(""), text), (match, text));
        }

        [Fact]
        public void ChoiceMatch()
        {
            Choice pattern = new Choice(new Character('a'), new Character('b'), new Character('c'));
            TextToParse text = new TextToParse("bef");

            var (match, remainingText) = pattern.Match(ref text);

            TextToParse expectedRemainingText = new TextToParse("bef");
            expectedRemainingText.CurrentIndex++;


            Assert.Equal((new Match("b"), expectedRemainingText), (match, remainingText));

            (match, remainingText) = pattern.Match(ref text);

            Assert.Equal((new NoMatch("e"), text), (match, remainingText));

        }

        [Fact]
        public void RangeMatch()
        {
            Range pattern = new Range('a', 'z');

            TextToParse text = new TextToParse("text");

            var match = pattern.Match(ref text).Item1;

            TextToParse expectedRemainingText = new TextToParse("text");
            expectedRemainingText.CurrentIndex++;

            Assert.Equal((new Match("t"), expectedRemainingText), (match, text));
        }

        [Fact]
        public void TextMatch()
        {
            Text pattern = new Text("Ana are mere");

            TextToParse text = new TextToParse("Ana are mere");

            TextToParse expectedRemainingText = new TextToParse("Ana are mere");
            expectedRemainingText.CurrentIndex = 12;

            var match = pattern.Match(ref text).Item1;

            Assert.Equal((new Match("Ana are mere"), expectedRemainingText), (match, text));
        }

        [Fact]
        public void ManyMatch()
        {
            Many pattern = new Many(new Sequence(new Character('['), new List(new AnyCharacter("abcxyz")), new Character(']')));
            TextToParse text = new TextToParse("[x,y,z][a,b,c]");

            var match = pattern.Match(ref text).Item1;
            TextToParse expectedRemainingText = new TextToParse(text.Pattern, 14);

            Assert.Equal((new Match("[x,y,z][a,b,c]"), expectedRemainingText), (match, text));

            match = pattern.Match(ref text).Item1;

            Assert.Equal((new Match(""), expectedRemainingText), (match, text));
        }

        [Theory]
        [InlineData("[x,y,z][a,b,c]")]
        public void ManyNoMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            Many pattern = new Many(new Sequence(new Character('['), new List(new AnyCharacter("abcxyz")), new Character(']')));
            Many pattern2 = new Many(new Sequence(new Character('['), new List(new AnyCharacter("abcxyz")), new Character(']')), 0, 1);

            var match = pattern.Match(ref text).Item1;
            TextToParse expectedRemainingText = new TextToParse(text.Pattern, 14);

            Assert.Equal((new Match("[x,y,z][a,b,c]"), expectedRemainingText), (match, text));

            text.CurrentIndex = 0;
            match = pattern2.Match(ref text).Item1;

            Assert.Equal((new NoMatch("Wrong number of <JSONParser.Sequence> objects"), expectedRemainingText), (match, text));
        }

        [Fact]
        public void AtLeastOnceMatch()
        {
            AtLeastOnce pattern = new AtLeastOnce(new Sequence(new Character('['), new List(new AnyCharacter("abcxyz")), new Character(']')));
            AtLeastOnce pattern2 = new AtLeastOnce(new AnyCharacter(" \t"));

            TextToParse text = new TextToParse("[x,y,z]{\"text\"}");
            TextToParse text2 = new TextToParse(" \t \t           x");


            Assert.Equal((new Match("[x,y,z]"), new TextToParse(text.Pattern, 7)), pattern.Match(ref text));
            Assert.Equal((new NoMatch("{"), new TextToParse(text.Pattern, 7)), pattern.Match(ref text));
            Assert.Equal((new Match(" \t \t           "), new TextToParse(text2.Pattern, 15)), pattern2.Match(ref text2));
        }

        //[Fact]
        //public void OptionalMatch()
        //{
        //    Optional optional = new Optional(new Character('-'));
        //    string text = "-32";
        //    string text2 = "32";

        //    Assert.Equal((new Match("-"), "32"), optional.Match(text));
        //    Assert.Equal((new Match(""), "32"), optional.Match(text2));
        //}

        //[Theory]
        //[InlineData("-362")]
        //[InlineData("362")]
        //[InlineData("0")]
        //[InlineData("1")]
        //public void IntegerMatch(string text)
        //{
        //    IntegerNumber pattern = new IntegerNumber();

        //    Assert.Equal((new Match(text), ""), pattern.Match(text));

        //}

        //[Theory]
        //[InlineData("362")]
        //[InlineData("362.12")]
        //[InlineData("-362.12")]
        //public void RealNumberMatch(string text)
        //{
        //    RealNumber pattern = new RealNumber();

        //    Assert.Equal((new Match(text), ""), pattern.Match(text));

        //}

        //[Theory]
        //[InlineData("9.")]
        //[InlineData("012")]
        //public void RealNumberNoMatch(string text)
        //{
        //    RealNumber pattern = new RealNumber();

        //    Assert.NotEqual((new Match(text), ""), pattern.Match(text));

        //}

        //[Theory]
        //[InlineData("-362.12e21")]
        //[InlineData("-362.12E21")]
        //[InlineData("-362.12e+21")]
        //[InlineData("-362.12e-21")]
        //[InlineData("-362.12")]
        //public void ScientificNotationMatch(string text)
        //{
        //    ScientificNotationNumber pattern = new ScientificNotationNumber();

        //    Assert.Equal((new Match(text), ""), pattern.Match(text));

        //}

        //[Theory]
        //[InlineData("\"Text\"")]
        //[InlineData("\"Text\\nText\"")]
        //[InlineData("\"Te    xt\"")]
        //[InlineData("\"T \\r \\t \"")]
        //public void StringMatch(string text)
        //{
        //    StringPattern stringPattern = new StringPattern();

        //    Assert.Equal((new Match(text), ""), stringPattern.Match(text));
        //}

        //[Theory]
        //[InlineData("\"\t\"")]
        //[InlineData("\"\r\"")]
        //[InlineData("\" \" \"")]
        //public void StringNoMatch(string text)
        //{
        //    StringPattern stringPattern = new StringPattern();

        //    Assert.NotEqual((new Match(text), ""), stringPattern.Match(text));
        //}

        //[Theory]
        //[InlineData("[\"value1\",[13,14],\"value3\"]")]
        //[InlineData("{   \"name\"  \n :[13, \r\t    14],\"name\":15}")]
        //[InlineData("[[4,8,15,16,23,42],[2,3,[15,16,13],5]]")]
        //[InlineData("[23,123,{\"name\":[33,21]}]")]
        //public void JSONPatternMatch(string text)
        //{
        //    JSONPattern pattern = new JSONPattern();

        //    Assert.Equal((new Match(text), ""), pattern.Match(text));
        //}

        //[Theory]
        //[InlineData("[\"value1\"\"value3\"]")]
        //[InlineData("[23")]
        //public void JSONPatternNoMatch(string text)
        //{
        //    JSONPattern jSONPattern = new JSONPattern();

        //    //string text = "[23";

        //    Assert.Equal((new NoMatch(text[0].ToString()), text), jSONPattern.Match(text));
        //}
    }
}
