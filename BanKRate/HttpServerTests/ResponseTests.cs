using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SocketExample;

namespace HttpServerTests
{
    public class ResponseTests
    {
        [Fact]
        public void ResponseInitTest()
        {
            Response response = new Response(400);
            response.SetContentLength(21);

            Assert.Equal("400 Bad Request", response.StatusCode);
            Assert.Equal(21, response.ContentLength);

            response.AddHeaderField("Content-Length", "72");

            Assert.Equal(72, response.ContentLength);

            response.Payload = new byte[] { 255, 255, 1, 1 };

            Assert.Equal(new byte[] { 255, 255, 1, 1 }, response.Payload);
        }

        [Fact]
        public void ResponseComposeTest()
        {
            Response response = new Response(200);
            response.SetContentLength(13);

            response.Payload = Encoding.ASCII.GetBytes("<h1>Test</h1>");

            Assert.Equal("<h1>Test</h1>", Encoding.ASCII.GetString(response.Payload));
        }
    }
}
