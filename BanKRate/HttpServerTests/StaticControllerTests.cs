﻿using System;
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
            Assert.Equal("HTTP/1.1 200 OK\r\nContent-Length: 24\r\ntralala: cozonac\r\nConnection: close\r\n\r\nPoza unui cozonac cu mac", Encoding.ASCII.GetString(response.ToBytesArray()));
        }

        [Fact]
        public void StaticControllerTestIsDirectory()
        {
            StaticController staticController = new StaticController(new FakeRepository());
            RequestPattern requestPattern = new RequestPattern();

            IMatch match = requestPattern.Match(new TextToParse("GET /pub/WWW HTTP/1.1\r\nHost: trlalal\r\nAlt-camp: dsdsdsds\r\n\r\n")).Item1;
            Request request = new Request(match as MatchesArray);

            Response response = staticController.GenerateResponse(request);

            Assert.Equal("Poza unui cozonac cu mac", Encoding.ASCII.GetString(response.Payload));
            Assert.Equal("HTTP/1.1 200 OK\r\nContent-Length: 24\r\ntralala: cozonac\r\nConnection: close\r\n\r\nPoza unui cozonac cu mac", Encoding.ASCII.GetString(response.ToBytesArray()));
        }
    }
}
