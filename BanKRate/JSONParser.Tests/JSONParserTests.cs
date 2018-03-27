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

            var (match, remainingText) = pattern.Match(text);

            Assert.Equal((new Match("a"), new TextToParse(text.Pattern, 1)), (match, remainingText));
        }

        [Fact]
        public void AnyCharacterMatchOrNot()
        {
            AnyCharacter pattern = new AnyCharacter("abc");
            TextToParse text = new TextToParse("abcd");
            TextToParse text2 = new TextToParse("efgh");

            var (match, remainingText) = pattern.Match(text);

            Assert.Equal((new Match("a"), new TextToParse(text.Pattern, 1)), (match, remainingText));


            (match, remainingText) = pattern.Match(text2);

            Assert.Equal((new NoMatch("(e)"), text2), (match, remainingText));
        }

        [Fact]
        public void CharacterNoMatch()
        {
            Character pattern = new Character('c');
            TextToParse text = new TextToParse("abcd");

            var (match, remainingText) = pattern.Match(text);

            Assert.Equal((new NoMatch("(a)"), new TextToParse("abcd")), (match, remainingText));
        }

        [Fact]
        public void CharacterNoMoreText()
        {
            Character pattern = new Character('c');
            TextToParse text = new TextToParse("");

            var (match, remainingText) = pattern.Match(text);

            Assert.Equal((new NoMoreText(), remainingText), (match, remainingText));
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


            Assert.Equal((new NoMatch("ab(x)", 2), new TextToParse("abxx")), pattern.Match(new TextToParse("abxx")));

            Assert.Equal((new Match("abc"), new TextToParse(text.Pattern, 3)), pattern.Match(text));

            Assert.Equal((new Match("xzc"), new TextToParse(text2.Pattern, 3)), pattern2.Match(text2));

            Assert.Equal((new Match("[z,x,y]"), new TextToParse(text3.Pattern, 7)), pattern3.Match(text3));
        }

        [Fact]
        public void ListMatch()
        {
            List listPattern = new List(new AnyCharacter("xyz"));

            TextToParse text = new TextToParse("x,y,z]");


            Assert.Equal((new Match("x,y,z"), new TextToParse(text.Pattern, 5)), listPattern.Match(text));
        }

        [Fact]
        public void ArrayPatternMatch()
        {

            Many whitespace = new Many
             (
            new Choice
            (
                new Character(' '),
                new Character('\n'),
                new Character('\t'),
                new Character('\r')
            )
                );

            Sequence arrayPattern = new Sequence
            (
                new Character('['),
                whitespace,
                new List
                (
                    new Sequence
                    (
                        whitespace,
                        new StringPattern(),
                        whitespace
                    )
                ),
                whitespace,
                new Character(']')
            );

            TextToParse text = new TextToParse("[\"value1\",\"value2\"]");
            TextToParse text2 = new TextToParse("[\"value1\"   \"value2\"]");
            

            Assert.Equal((new Match(text.Pattern), new TextToParse(text.Pattern, text.Pattern.Length)), arrayPattern.Match(text));
            Assert.NotEqual((new Match(text2.Pattern), new TextToParse(text2.Pattern, text2.Pattern.Length)), arrayPattern.Match(text2));
        }

        [Fact]
        public void ListMatch2()
        {
            List listPattern = new List(new AnyCharacter("123456"));

            TextToParse text = new TextToParse("2,");

            Assert.Equal((new Match("2"), new TextToParse(text.Pattern, 1)), listPattern.Match(text));
        }

        [Fact]
        public void ListMatchEmpty()
        {
            List listPattern = new List(new AnyCharacter("123456"));

            TextToParse text = new TextToParse("");

            Assert.Equal((new Match(""), text), listPattern.Match(text));
        }

        [Fact]
        public void ChoiceMatch()
        {
            Choice pattern = new Choice(new Character('a'), new Character('b'), new Character('c'));
            TextToParse text = new TextToParse("bef");
            
            var (match, remainingText) = pattern.Match(text);

            Assert.Equal((new Match("b"), new TextToParse("bef", 1)), (match, remainingText));

            (match, remainingText) = pattern.Match(remainingText);

            Assert.Equal((new NoMatch("(e)", 1), new TextToParse("bef", 1)), (match, remainingText));

            Choice pattern2 = new Choice(new Text("Emao"), new Text("Emanuel"));
            TextToParse text2 = new TextToParse("Emanuetete");

            Assert.Equal((new NoMatch("Emanue(t)", 6), text2), pattern2.Match(text2));
        }

        [Fact]
        public void RangeMatch()
        {
            Range pattern = new Range('a', 'z');

            TextToParse text = new TextToParse("text");

            Assert.Equal((new Match("t"), new TextToParse("text", 1)), pattern.Match(text));
        }

        [Fact]
        public void TextMatch()
        {
            Text pattern = new Text("Ana are mere");

            TextToParse text = new TextToParse("Ana are mere");

            TextToParse expectedRemainingText = new TextToParse("Ana are mere", 12);

            Assert.Equal((new Match("Ana are mere"), expectedRemainingText), pattern.Match(text));
        }

        [Fact]
        public void ManyMatch()
        {
            Many pattern = new Many(new Sequence(new Character('['), new List(new AnyCharacter("abcxyz")), new Character(']')));
            TextToParse text = new TextToParse("[x,y,z][a,b,c]");

            TextToParse remainingText = new TextToParse(text.Pattern, 14);

            Assert.Equal((new Match("[x,y,z][a,b,c]"), remainingText), pattern.Match(text));

            Assert.Equal((new Match(""), remainingText), pattern.Match(remainingText));
        }

        [Theory]
        [InlineData("[x,y,z][a,b,c]")]
        public void ManyNoMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            Many pattern = new Many(new Sequence(new Character('['), new List(new AnyCharacter("abcxyz")), new Character(']')));
            Many pattern2 = new Many(new Sequence(new Character('['), new List(new AnyCharacter("abcxyz")), new Character(']')), 0, 1);

            TextToParse expectedRemainingText = new TextToParse(text.Pattern, 14);

            Assert.Equal((new Match("[x,y,z][a,b,c]"), expectedRemainingText), pattern.Match(text));

            Assert.Equal((new NoMatch("Wrong number of <JSONParser.Sequence> objects"), expectedRemainingText), pattern2.Match(text));
        }

        [Fact]
        public void AtLeastOnceMatch()
        {
            AtLeastOnce pattern = new AtLeastOnce(new Sequence(new Character('['), new List(new AnyCharacter("abcxyz")), new Character(']')));
            AtLeastOnce pattern2 = new AtLeastOnce(new AnyCharacter(" \t"));

            TextToParse text = new TextToParse("[x,y,z]{\"text\"}");
            TextToParse text2 = new TextToParse(" \t \t           x");


            Assert.Equal((new Match("[x,y,z]"), new TextToParse(text.Pattern, 7)), pattern.Match(text));
            Assert.Equal((new NoMatch("({)"), new TextToParse(text.Pattern, 7)), pattern.Match(new TextToParse(text.Pattern, 7)));
            Assert.Equal((new Match(" \t \t           "), new TextToParse(text2.Pattern, 15)), pattern2.Match(text2));
        }

        [Fact]
        public void OptionalMatch()
        {
            Optional optional = new Optional(new Character('-'));
            TextToParse text = new TextToParse("-32");
            TextToParse text2 = new TextToParse("32");

            Assert.Equal((new Match("-"), new TextToParse(text.Pattern, 1)), optional.Match(text));
            Assert.Equal((new Match(""), new TextToParse(text2.Pattern)), optional.Match(text2));
        }

        [Theory]
        [InlineData("-362")]
        [InlineData("362")]
        [InlineData("0")]
        [InlineData("1")]
        public void IntegerMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            IntegerNumber pattern = new IntegerNumber();

            Assert.Equal((new Match(textS), new TextToParse(textS, textS.Length)), pattern.Match(text));

        }

        [Theory]
        [InlineData("362")]
        [InlineData("362.12")]
        [InlineData("-362.12")]
        public void RealNumberMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            RealNumber pattern = new RealNumber();

            Assert.Equal((new Match(textS), new TextToParse(textS, textS.Length)), pattern.Match(text));

        }

        [Theory]
        [InlineData("9.")]
        [InlineData("012")]
        public void RealNumberNoMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            RealNumber pattern = new RealNumber();

            Assert.NotEqual((new Match(textS), new TextToParse(textS, textS.Length)), pattern.Match(text));

        }

        [Theory]
        [InlineData("-362.12e21")]
        [InlineData("-362.12E21")]
        [InlineData("-362.12e+21")]
        [InlineData("-362.12e-21")]
        [InlineData("-362.12")]
        public void ScientificNotationMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            ScientificNotationNumber pattern = new ScientificNotationNumber();

            Assert.Equal((new Match(textS), new TextToParse(textS, textS.Length)), pattern.Match(text));

        }

        [Theory]
        [InlineData("\"Text\"")]
        [InlineData("\"Text\\nText\"")]
        [InlineData("\"Te    xt\"")]
        [InlineData("\"T \\r \\t \"")]
        public void StringMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);

            StringPattern stringPattern = new StringPattern();

            Assert.Equal((new Match(textS), new TextToParse(textS, textS.Length)), stringPattern.Match(text));
        }

        [Theory]
        [InlineData("\"\t\"")]
        [InlineData("\"\r\"")]
        [InlineData("\" \" \"")]
        public void StringNoMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            StringPattern stringPattern = new StringPattern();

            Assert.NotEqual((new Match(text.Pattern), new TextToParse(text.Pattern, text.Pattern.Length)), stringPattern.Match(text));
        }

        [Theory]
        [InlineData("[\"value1\",[13,14],\"value3\"]")]
        [InlineData("{   \"name\"  \n :[13, \r\t    14],\"name\":15}")]
        [InlineData("[[4,8,15,16,23,42],[2,3,[15,16,13],5]]")]
        [InlineData("[23,123,{\"name\":[33,21]}]")]
        [InlineData("[23,42]")]
        public void JSONPatternMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            JSONPattern pattern = new JSONPattern();

            Assert.Equal((new Match(textS), new TextToParse(textS, textS.Length)), pattern.Match(text));
        }

        [Fact]
        public void ListMatch3()
        {
            TextToParse text = new TextToParse("76,32,222\"]");
            List listPattern = new List(new ScientificNotationNumber());

            Assert.Equal((new Match("76,32,222"), new TextToParse(text.Pattern, 9)), listPattern.Match(text));
        }

        [Theory]
        [InlineData("[\"v\"\"value3\"]")]
        public void JSONPatternNoMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            JSONPattern jSONPattern = new JSONPattern();

            Assert.Equal((new NoMatch("[\"v\"(\")", 4), text), jSONPattern.Match(text));
        }

        [Theory]
        [InlineData("23,")]
        [InlineData("42, 3")]
        [InlineData("76,32,222, value\"")]
        public void JSONPatternPartialMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            JSONPattern jSONPattern = new JSONPattern();

            Assert.Equal((new NoMatch($"{textS.Substring(0,2)}(,)", 2), new TextToParse(text.Pattern, 2)), jSONPattern.Match(text));
        }

        [Fact]
        public void JSONPatternTest()
        {
            TextToParse text = new TextToParse("[76,32,222, value\"]");
            JSONPattern jSONPattern = new JSONPattern();

            Assert.Equal((new NoMatch($"[76,32,222(,)", 10), new TextToParse(text.Pattern)), jSONPattern.Match(text));

        }

        [Theory]
        [InlineData("GET")]
        [InlineData("POST")]
        public void MethodPatternMatch(string textS)
        {
            TextToParse text = new TextToParse(textS);
            MethodPattern methodPattern = new MethodPattern();

            Assert.Equal((new Match(textS), new TextToParse(textS, textS.Length)), methodPattern.Match(text));
        }

        [Theory]
        [InlineData("GETO")]
        public void MethodPatternNoMatch1(string textS)
        {
            TextToParse text = new TextToParse(textS);
            MethodPattern methodPattern = new MethodPattern();

            Assert.Equal((new Match($"{textS.Substring(0, textS.Length-1)}"), new TextToParse(textS, textS.Length-1)), methodPattern.Match(text));
        }

        [Fact]
        public void MethodPatternNoMoreText()
        {
            TextToParse text = new TextToParse("GE");
            MethodPattern methodPattern = new MethodPattern();

            Assert.Equal((new NoMatch("GE(T)", 3), text), methodPattern.Match(text));
        }

        [Fact]
        public void MethodPatternNoMatch2()
        {
            TextToParse text = new TextToParse("SDSDS");
            MethodPattern methodPattern = new MethodPattern();

            Assert.Equal((new NoMatch("(S)"), text), methodPattern.Match(text));
        }

        [Theory]
        [InlineData("kdskdbsjk\rbdksjd")]
        public void URIPatternTest(string textS)
        {
            TextToParse text = new TextToParse(textS);
            URIPattern uriPattern = new URIPattern();

            Assert.Equal((new Match(textS.Substring(0, 9)), new TextToParse(textS, 9)), uriPattern.Match(text));
        }

        [Theory]
        [InlineData("HTTP/12.32")]
        public void HTTPVersionPatternTest(string textS)
        {
            TextToParse text = new TextToParse(textS);
            HTTPVersionPattern uriPattern = new HTTPVersionPattern();

            Assert.Equal((new Match(textS), new TextToParse(textS, textS.Length)), uriPattern.Match(text));
        }

        [Theory]
        [InlineData("GET /pub/WWW/TheProject.html HTTP/1.1\r\n")]
        public void RequestLinePatternTest(string textS)
        {
            TextToParse text = new TextToParse(textS);
            RequestLinePattern requestLine = new RequestLinePattern();

            Assert.Equal((new Match(textS), new TextToParse(textS, textS.Length)), requestLine.Match(text));
        }



    }
}
