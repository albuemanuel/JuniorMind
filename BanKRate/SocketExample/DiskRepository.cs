using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SocketExample
{
    public class DiskRepository : IRepository
    {
        Uri baseUri = new Uri("C:/Users/dev/Desktop/JuniorMind/BanKRate/SocketExample/SiteFolder/", UriKind.Absolute);

        public byte[] GetData(Uri relativeUri) => File.ReadAllBytes(new Uri(baseUri, relativeUri).LocalPath);
    }
}
