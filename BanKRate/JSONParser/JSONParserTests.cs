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
            string text = "abcd";

            Assert.Equal((new Match("abc"), "d"), pattern.Match(text));
        }
    }
}
