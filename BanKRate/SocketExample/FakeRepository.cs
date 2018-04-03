using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketExample
{
    public class FakeRepository : IRepository
    {
        

        public byte[] GetData()
        {
            Uri fakeUri = new Uri("dsdsds", UriKind.RelativeOrAbsolute);
            return GetData(fakeUri);
        }
        public byte[] GetData(Uri uri)
        {
            return Encoding.ASCII.GetBytes("Poza unui cozonac cu mac");
        }
    }
}
