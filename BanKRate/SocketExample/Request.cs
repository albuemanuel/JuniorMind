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
        string httpVersion;
        Dictionary<string, string> httpHeaderFields;

        public Request(MatchesArray requestPattern)
        {
            MatchesArray requestLine = requestPattern[0] as MatchesArray;

            method = (requestLine[0] as MethodMatch).Method;
            uri = (requestLine[1] as URIPatternMatch).Uri;
            httpVersion = (requestLine[2] as HTTPVersionPatternMatch).HTTPVersion;
            


        }
    }
}
