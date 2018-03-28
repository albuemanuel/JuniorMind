using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketExample
{

    public class Request
    {
        Uri uri;
        
        float httpVersion;
        Dictionary<string, string> httpHeaderFields;

        public Request()
        {

        }
    }
}
