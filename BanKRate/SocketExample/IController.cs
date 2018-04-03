using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketExample
{
    interface IController
    {
        Response GenerateResponse(Request request);
    }
}
