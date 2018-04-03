using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SocketExample;

namespace HttpServerTests
{
    public class DiskRepositoryTests
    {
        [Fact]
        public void DiskRepositoryInit()
        {
            FakeRepository diskRepository = new FakeRepository();
            byte[] data = diskRepository.GetData(new Uri("ooo", UriKind.Relative));

            string dataS = Encoding.ASCII.GetString(data);

            Assert.Equal("Poza unui cozonac cu mac", dataS);
        }
    }
}
