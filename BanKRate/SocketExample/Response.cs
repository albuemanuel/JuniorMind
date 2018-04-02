using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketExample
{
    public class Response
    {
        private string statusCode;
        private Dictionary<string, string> httpHeaderFields = new Dictionary<string, string>();
        private byte[] payload;

        public Response(int statusCode)
        {
            SetStatusCode(statusCode);
        }

        public void AddHeaderField(string key, string value)
        {
            if (httpHeaderFields.ContainsKey(key))
                httpHeaderFields[key] = value;
            else
                httpHeaderFields.Add(key, value);
        }

        public string StatusCode => statusCode;

        public int ContentLength => Convert.ToInt32(httpHeaderFields["Content-Length"]);

        public byte[] Payload { get => payload; set => payload = value; }

        public void SetContentLength(int length)
        {
            if (httpHeaderFields.ContainsKey("Content-Length"))
                httpHeaderFields["Content-Length"] = length.ToString();
            else
                httpHeaderFields.Add("Content-Length", length.ToString());
        }

        public void SetStatusCode(int statusCode)
        {
            this.statusCode = GetCodeMessage(statusCode);
        }

        private string GetCodeMessage(int statusCode)
        {
            switch(statusCode)
            {
                case 200:
                    return "200 OK";
                case 404:
                    return "404 Not Found";
                default:
                    return "400 Bad Request";
            }
        }

        private string HeaderAsString => httpHeaderFields.Aggregate("", (result, next) => result + next.Key + ':' + next.Value + "\r\n");

        public byte[] ToBytesArray()
        {
            byte[] httpVersion = Encoding.ASCII.GetBytes("HTTP/1.1");
            byte[] statusCode = Encoding.ASCII.GetBytes(this.statusCode);

            byte[] statusLine = new byte[statusCode.Length + httpVersion.Length];

            Array.Copy(httpVersion, statusLine, httpVersion.Length);
            Array.Copy(statusCode, 0, statusLine, httpVersion.Length, statusCode.Length);

            byte[] response = new byte[statusLine.Length + HeaderAsString.Length + 2];
            byte[] headerAsBytes = Encoding.ASCII.GetBytes(HeaderAsString);

            Array.Copy(statusLine, response, statusLine.Length);
            Array.Copy(headerAsBytes, 0, response, statusLine.Length, headerAsBytes.Length);

            byte[] endHeader = Encoding.ASCII.GetBytes("\r\n");

            Array.Copy(endHeader, 0, response, headerAsBytes.Length, 2);

            return response;
        }
    }
}
