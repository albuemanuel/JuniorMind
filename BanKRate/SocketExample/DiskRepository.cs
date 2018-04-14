using System;
using System.IO;

namespace SocketExample
{
    public class DiskRepository : IRepository
    {
        string baseURI;

        public DiskRepository(string baseURI)
        {
            this.baseURI = baseURI;
        }

        public byte[] GetData(Uri relativeUri)
        {
            //if (IsDirectory(relativeUri))
                //return File.ReadAllBytes(FullPath(relativeUri) + "/index.htm");

            return File.ReadAllBytes(FullPath(relativeUri));
        }

        private string FullPath(Uri relativeUri)
        {
            return Path.Combine(baseURI, relativeUri.ToString().TrimStart('/'));
        }

        public bool IsDirectory(Uri uri)
        {
            return Directory.Exists(FullPath(uri));
        }
    }
}
