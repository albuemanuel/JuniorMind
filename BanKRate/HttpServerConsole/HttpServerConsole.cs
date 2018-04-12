using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HttpServerConsole
{
    class HttpServerConsole
    {
        static void Main(string[] args)
        {
            HttpServer httpServer = new HttpServer();
            Thread thread = new Thread(httpServer.StartHttpServer);
        }
    }
}
