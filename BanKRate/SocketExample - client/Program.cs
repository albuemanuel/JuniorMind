using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TcpClientExample
{

    static void Connect(String server, params string[] messages)
    {
        try
        {
            // Create a TcpClient.
            // Note, for this client to work you need to have a TcpServer 
            // connected to the same address as specified by the server, port
            // combination.
            Int32 port = 13000;
            TcpClient client = new TcpClient(server, port);

            NetworkStream stream = client.GetStream();
            foreach (var message in messages)
            {
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] messageData = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();


                // Send the message to the connected TcpServer. 
                stream.Write(messageData, 0, messageData.Length);

                Console.WriteLine("Sent: {0}", message);
            }

            // Receive the TcpServer.response.

            // Buffer to store the response bytes.
            var data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            // Close everything.
            stream.Close();
            client.Close();
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        Console.WriteLine("\n Press Enter to continue...");
        Console.Read();
    }
    static void Main(string[] args)
    {
        Console.ReadLine();
        Connect("127.0.0.1",
            "GET", "/ HTTP/1.1\r\n", "Host: 127.0.0.1:13000\r\n", "Connection: keep-alive\r\n", "Accept-Language: en-US,en;q=0.9\r\n\r\n");
    }
}