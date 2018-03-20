using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SynchronousSocketListener
{

    // Incoming data from the client.  
    public static string data = null;

    public static void Main()
    {
        TcpListener listener = null;
        try
        {
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            listener = new TcpListener(localAddr, port);

            listener.Start();
            Byte[] bytes = new Byte[256];

            // Start listening for connections.  
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                // Program is suspended while waiting for an incoming connection.  
                TcpClient client = listener.AcceptTcpClient();
                data = null;

                NetworkStream stream = client.GetStream();

                int i;
                // An incoming connection needs to be processed.  
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);

                }

                client.Close();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Socket exception: {0}", e);
        }
        finally
        {
            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

    }

    
}