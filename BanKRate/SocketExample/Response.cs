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

        public byte[] Payload
        {
            get => payload;
            set => payload = value;
        }

        public void SetContentLength(int length)
        {
            AddHeaderField("Content-Length", length.ToString());
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

        private string HeaderAsString => httpHeaderFields.Aggregate("", (result, next) => result + next.Key + ": " + next.Value + "\r\n");

        public string ResponseAsString()
        {
            string httpVersion = "HTTP/1.1";
            string statusCode = this.statusCode;

            string statusLine = httpVersion + " " + statusCode + "\r\n";

            string response = statusLine + HeaderAsString;

            return response;
        }


        public byte[] ToBytesArray()
        {
            string httpVersion = "HTTP/1.1";
            string statusCode = this.statusCode;

            string statusLine = httpVersion + " " + statusCode + "\r\n";


            string headers = statusLine + HeaderAsString + "\r\n" ;
            byte[] headersAsBytes = Encoding.ASCII.GetBytes(headers);

            byte[] responseAsBytes = new byte[headersAsBytes.Length + payload.Length];

            Array.Copy(headersAsBytes, responseAsBytes, headersAsBytes.Length);
            Array.Copy(payload, 0, responseAsBytes, headersAsBytes.Length, payload.Length);

            return responseAsBytes;
        }
    }
}
