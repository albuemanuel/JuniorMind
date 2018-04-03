using System;

namespace SocketExample
{
    interface IRepository
    {
        byte[] GetData(Uri uri);
    }
}