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

            Assert.Equal((new Match('a'), "bcd"), pattern.Match("abcd"));
        }

        [Fact]
        public void CharacterNoMatch()
        {
            Character pattern = new Character('c');

            Exception ex = Assert.Throws<Exception>(() => pattern.Match("abcd"));

            Assert.Equal("\"a\" does not match the pattern", ex.Message);
        }

        [Fact]
        public void CharacterNoMoreText()
        {
            Character pattern = new Character('c');

            Exception ex = Assert.Throws<Exception>(() => pattern.Match(""));

            Assert.Equal("There's no more text to be parsed", ex.Message);
        }
    }
}
