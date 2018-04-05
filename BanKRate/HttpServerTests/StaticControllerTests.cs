using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SocketExample;
using JSONParser;

namespace HttpServerTests
{
    public class StaticControllerTests
    {
        [Fact]
        public void StaticControllerTest()
        {
            StaticController staticController = new StaticController(new FakeRepository());
            RequestPattern requestPattern = new RequestPattern();

            IMatch match = requestPattern.Match(new TextToParse("GET /pub/WWW/TheProject.html HTTP/1.1\r\nHost: trlalal\r\nAlt-camp: dsdsdsds\r\n\r\n")).Item1;
            Request request = new Request(match as MatchesArray);

            Response response = staticController.GenerateResponse(request);

            Assert.Equal("Poza unui cozonac cu mac", Encoding.ASCII.GetString(response.Payload));
            Assert.Equal("HTTP/1.1 200 OK\r\ntralala:cozonac\r\n\r\nPoza unui cozonac cu mac", Encoding.ASCII.GetString(response.ToBytesArray()));
        }
    }
}
