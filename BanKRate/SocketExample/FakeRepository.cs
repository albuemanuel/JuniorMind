using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketExample
{
    public class FakeRepository : IRepository
    {
        string baseUri;

        public FakeRepository() 
            : this("")
        {
        }

        public FakeRepository(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public byte[] GetData()
        {
            Uri fakeUri = new Uri("dsdsds", UriKind.RelativeOrAbsolute);
            return GetData(fakeUri);
        }

        public byte[] GetData(Uri uri)
        {
            if (uri.ToString().Split('/').Last() == "index.htm")
                return Encoding.ASCII.GetBytes("index.htm");

            return Encoding.ASCII.GetBytes("Poza unui cozonac cu mac");
        }

        private string FullPath(Uri relativeUri)
        {
            return Path.Combine(baseUri, relativeUri.ToString().TrimStart('/'));
        }

        public bool IsDirectory(Uri uri)
        {
            string uriS = uri.ToString();

            return (uriS[uriS.Length - 1] == '/');

        }
    }
}
