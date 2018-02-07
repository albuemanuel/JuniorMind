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

            Assert.Equal((new Match("a"), "bcd"), pattern.Match(text));
        }

        [Fact]
        public void CharacterNoMatch()
        {
            Character pattern = new Character('c');
            string text = "abcd";

            Exception ex = Assert.Throws<Exception>(() => pattern.Match(text));

            Assert.Equal("\"a\" does not match the pattern", ex.Message);
        }

        [Fact]
        public void CharacterNoMoreText()
        {
            Character pattern = new Character('c');
            string text = "";

            Exception ex = Assert.Throws<Exception>(() => pattern.Match(text));

            Assert.Equal("There's no more text to be parsed", ex.Message);
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
