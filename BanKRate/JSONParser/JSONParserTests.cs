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

    }
}
