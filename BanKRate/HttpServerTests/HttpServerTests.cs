using System;
using Xunit;
using SocketExample;
using System.IO;

namespace HttpServerTests
{
    public class HttpServerTests
    {
        [Fact]
        public void ReceiveRequestTests()
        {
            //FileStream fs = new FileStream(@"C:\Users\dev\Desktop\JuniorMind\BanKRate\SocketExample\SiteFolder\Request.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            FileStream fs = File.Open(@"C:\Users\dev\Desktop\JuniorMind\BanKRate\SocketExample\SiteFolder\Request.txt", FileMode.Open);

            byte[] bytes = new byte[1024];

            HttpServer.ReceiveRequest(bytes, fs);

            string data = HttpServer.data;

            Assert.Equal("GET /cozonac.jpg HTTP/1.1\\r\\nHost: 127.0.0.1:13000\\r\\nConnection: keep-alive\\r\\nCache-Control: max-age=0\\r\\nUpgrade-Insecure-Requests: 1\\r\\nUser-Agent: Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36\\r\\nAccept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8\\r\\nAccept-Encoding: gzip, deflate, br\\r\\nAccept-Language: en-US,en;q=0.9\\r\\n\\r\\n", data);
            
        }


    }
}
