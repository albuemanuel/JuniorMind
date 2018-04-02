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
        Dictionary<string, string> httpHeaderFields = new Dictionary<string, string>();

        public Uri Uri => uri;
        public Method Method => method;
        public string HttpVersion => httpVersion;
        public Dictionary<string, string> Header => httpHeaderFields;
        public string HeaderAsString => httpHeaderFields.Aggregate("", (result, next) => result + "\n\t" + next);

        public Request(MatchesArray requestPattern)
        {
            MatchesArray requestLine = requestPattern[0] as MatchesArray;

            method = (requestLine[0] as MethodMatch).Method;
            uri = (requestLine[2] as URIPatternMatch).Uri;
            httpVersion = (requestLine[4] as HTTPVersionPatternMatch).HTTPVersion;

            MatchesArray httpHeader = requestPattern[1] as MatchesArray;

            foreach (var el in httpHeader.MatchArray)
            {
                HttpHeaderFieldMatch header = new HttpHeaderFieldMatch(el);

                string key = header.Key;
                string value = header.Value;

                httpHeaderFields.Add(key, value);
            }

        }

        public override string ToString()
        {
            return $"Method: {method}\nURI: {uri}\nHttpVersion: {httpVersion}\nHeader:{HeaderAsString}";
        }
    }
}
