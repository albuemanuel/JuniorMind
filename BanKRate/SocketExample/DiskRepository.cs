using System;
using System.IO;

namespace SocketExample
{
    public class DiskRepository : IRepository
    {
        string baseUri = "C:/Users/dev/Desktop/JuniorMind/BanKRate/SocketExample/SiteFolder/";

        public byte[] GetData(Uri relativeUri)
        {
            //if (IsDirectory(relativeUri))
                //return File.ReadAllBytes(FullPath(relativeUri) + "/index.htm");

            return File.ReadAllBytes(FullPath(relativeUri));
        }

        private string FullPath(Uri relativeUri)
        {
            return Path.Combine(baseUri, relativeUri.ToString().TrimStart('/'));
        }

        public bool IsDirectory(Uri uri)
        {
            return Directory.Exists(FullPath(uri));
        }
    }
}
