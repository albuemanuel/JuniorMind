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

        //[Fact]
        //public void SequenceMatch()
        //{
        //    Sequence pattern = new Sequence(new Character('a'), new Character('b'), new Character('c'));
        //    Sequence pattern2 = new Sequence(new AnyCharacter(), new AnyCharacter(), new Character('c'));
        //    string text = "abcd";
        //    string text2 = "xxcdef";
            

        //    Assert.Equal((new Match("abc"), "d"), pattern.Match(text));
        //    Assert.Equal((new Match("xxc"), "def"), pattern2.Match(text2));
        //}

        //[Fact]
        //public void ListMatch()
        //{
        //    List listPattern = new List(new Character(','), new AnyCharacter());

        //    Assert.Equal((new Match("x,x,x"), "]"), listPattern.Match("x,x,x]"));
        //}
    }
}
