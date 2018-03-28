using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParser;

namespace SocketExample
{

    public class Request
    {
        Uri uri;
        Method method;
        float httpVersion;
        Dictionary<string, string> httpHeaderFields;

        public Request()
        {

        }
    }
}
