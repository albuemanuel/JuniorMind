using System;

namespace SocketExample
{
    public interface IRepository
    {
        byte[] GetData(Uri uri);
        bool IsDirectory(Uri uri);
    }
}