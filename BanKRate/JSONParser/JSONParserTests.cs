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
            string text = "abcd";

            Assert.True(pattern.Match(text).Item1.Success);
            Assert.Equal((new Match("a"), "bcd"), pattern.Match(text));
        }

        [Fact]
        public void AnyCharacterMatchOrNot()
        {
            AnyCharacter pattern = new AnyCharacter("abc");
            string text = "abcd";
            string text2 = "efgh";

            Assert.True(pattern.Match(text).Item1.Success);
            Assert.Equal((new Match("a"), "bcd"), pattern.Match(text));
            Assert.False(pattern.Match(text2).Item1.Success);
            Assert.Equal((new NoMatch("e"), "efgh"), pattern.Match(text2));
        }

        [Fact]
        public void CharacterNoMatch()
        {
            Character pattern = new Character('c');
            string text = "abcd";

            Assert.False(pattern.Match(text).Item1.Success);
            Assert.Equal((new NoMatch("a"), "abcd"), pattern.Match(text));
        }

        [Fact]
        public void CharacterNoMoreText()
        {
            Character pattern = new Character('c');
            string text = "";

            Assert.False(pattern.Match(text).Item1.Success);
            Assert.Equal((new NoMoreText(), ""), pattern.Match(text));
        }

        [Fact]
        public void SequenceMatch()
        {
            Sequence pattern = new Sequence(new Character('a'), new Character('b'), new Character('c'));
            Sequence pattern2 = new Sequence(new AnyCharacter("xz"), new AnyCharacter("xz"), new Character('c'));
            Sequence pattern3 = new Sequence(new Character('['), new List(new Character(','), new AnyCharacter("xyz")), new Character(']'));
            string text = "abcd";
            string text2 = "xzcdef";
            string text3 = "[z,x,y]";


            Assert.Equal((new Match("abc"), "d"), pattern.Match(text));
            Assert.Equal((new Match("xzc"), "def"), pattern2.Match(text2));
            Assert.Equal((new Match("[z,x,y]"), ""), pattern3.Match(text3));
        }

        [Fact]
        public void ListMatch()
        {
            List listPattern = new List(new Character(','), new AnyCharacter("xyz"));

            Assert.Equal((new Match("x,y,z"), "]"), listPattern.Match("x,y,z]"));
        }

        [Fact]
        public void ChoiceMatch()
        {
            Choice pattern = new Choice(new Character('a'), new Character('b'), new Character('c'));
            string text = "bef";

            Assert.Equal((new Match("b"), "ef"), pattern.Match(text));
       
        }

        [Fact]
        public void RangeMatch()
        {
            Range pattern = new Range('a', 'z');

            Assert.Equal((new Match("t"), "ext"), pattern.Match("text"));
        }

        [Fact]
        public void TextMatch()
        {
            Text pattern = new Text("Ana are mere");

            Assert.Equal((new Match("Ana are mere"), ""), pattern.Match("Ana are mere"));
        }

        [Fact]
        public void ManyMatch()
        {
            Many pattern = new Many(new Sequence(new Character('['), new List(new Character(','), new AnyCharacter("abcxyz")), new Character(']')));
            string text = "[x,y,z][a,b,c]";

            var (match, remainingText) = pattern.Match(text);

            Assert.Equal((new Match("[x,y,z][a,b,c]"), ""), (match, remainingText));
            Assert.Equal((new Match(""), ""), pattern.Match(remainingText));
        }

        [Fact]
        public void AtLeastOnceMatch()
        {
            AtLeastOnce pattern = new AtLeastOnce(new Sequence(new Character('['), new List(new Character(','), new AnyCharacter("abcxyz")), new Character(']')));
            AtLeastOnce pattern2 = new AtLeastOnce(new AnyCharacter(" \t"));

            string text = "[x,y,z]{\"text\"}";
            string text2 = " \t \t           x";

            var (match, remainingText) = pattern.Match(text);

            Assert.Equal((new Match("[x,y,z]"), "{\"text\"}"), (match, remainingText));
            Assert.Equal((new NoMatch("{"), "{\"text\"}"), pattern.Match(remainingText));
            Assert.Equal((new Match(" \t \t           "), "x"), pattern2.Match(text2));
        }

        [Fact]
        public void OptionalMatch()
        {
            Optional optional = new Optional(new Character('-'));
            string text = "-32";
            string text2 = "32";

            Assert.Equal((new Match("-"), "32"), optional.Match(text));
            Assert.Equal((new Match(""), "32"), optional.Match(text2));
        }

        [Theory]
        [InlineData("-362")]
        [InlineData("362")]
        [InlineData("0")]
        [InlineData("1")]
        public void IntegerMatch(string text)
        {
            IntegerNumber pattern = new IntegerNumber();

            Assert.Equal((new Match(text), ""), pattern.Match(text));

        }

        [Theory]
        [InlineData("362")]
        [InlineData("362.12")]
        [InlineData("-362.12")]
        public void RealNumberMatch(string text)
        {
            RealNumber pattern = new RealNumber();

            Assert.Equal((new Match(text), ""), pattern.Match(text));

        }

        [Theory]
        [InlineData("9.")]
        [InlineData("012")]
        public void RealNumberNoMatch(string text)
        {
            RealNumber pattern = new RealNumber();

            Assert.NotEqual((new Match(text), ""), pattern.Match(text));

        }

        [Theory]
        [InlineData("-362.12e21")]
        [InlineData("-362.12E21")]
        [InlineData("-362.12e+21")]
        [InlineData("-362.12e-21")]
        [InlineData("-362.12")]
        public void ScientificNotationMatch(string text)
        {
            ScientificNotationNumber pattern = new ScientificNotationNumber();

            Assert.Equal((new Match(text), ""), pattern.Match(text));

        }

        [Theory]
        [InlineData("\"Text\"")]
        [InlineData("\"Text\\nText\"")]
        public void StringMatch(string text)
        {
            StringPattern stringPattern = new StringPattern();

            Assert.Equal((new Match(text), ""), stringPattern.Match(text));
        }

    }
}
