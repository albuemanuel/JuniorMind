using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SocketExample;

namespace HttpServerTests
{
    public class StaticControllerTests
    {
        [Fact]
        public void StaticControllerTest()
        {
            FakeRepository fakeRepository = new FakeRepository();
            Response response = new Response(200);
            response.Payload = fakeRepository.GetData();

            string text = Encoding.ASCII.GetString(response.Payload);

            Assert.Equal("Poza unui cozonac cu mac", text);
        }
    }
}
