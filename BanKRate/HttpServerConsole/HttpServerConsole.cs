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
            Int32.TryParse(args[0], out int port);
            HttpServer httpServer = new HttpServer(port, args[1], args[2]);
            Thread thread = new Thread(httpServer.RunServerAsync);
            thread.Start();
        }
    }
}
