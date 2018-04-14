﻿using System;
using System.Net;
using System.Net.Sockets;
using JSONParser;
using SocketExample;
using System.Text;

public class HttpServer
{
    // Incoming data from the client.  

    Int32 port;
    string ipAddress;
    string baseURI;

    public HttpServer(Int32 port = 13000, string ipAddress = "127.0.0.1", string baseURI = "C:/Users/albue.DESKTOP-7NLSNIJ/Desktop/JM/JuniorMind/BanKRate/SocketExample/SiteFolder")
    {
        this.port = port;
        this.ipAddress = ipAddress;
        this.baseURI = baseURI;
    }

    public void StartHttpServer()
    {

        TcpListener listener = null;
        try
        {
            IPAddress localAddr = IPAddress.Parse(ipAddress);

            // TcpListener server = new TcpListener(port);
            listener = new TcpListener(localAddr, port);

            listener.Start();
            Byte[] bytes = new Byte[1024];

            // Start listening for connections.  
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                // Program is suspended while waiting for an incoming connection.  
                TcpClient client = listener.AcceptTcpClient();
                string data = null;

                NetworkStream stream = client.GetStream();

                data = ReceiveRequest(bytes, stream);
                Request request = FormRequest(data);

                Response response = GenerateResponse(request, baseURI);

                Respond(stream, response);
                Console.WriteLine("Sent: {0}", response.ResponseAsString());

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

    public static string ReceiveRequest(byte[] bytes, System.IO.Stream stream)
    {
        string data = null;
        int i;
        // An incoming connection needs to be processed.  
        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
        {

            data += Encoding.ASCII.GetString(bytes, 0, i);
            Console.WriteLine("Received: {0}", data);

            if (data.Contains("\r\n\r\n"))
                break;

        }
        return data;
    }

    private static void Respond(NetworkStream stream, Response response)
    {
        byte[] responseAsBytes = response.ToBytesArray();

        stream.Write(responseAsBytes, 0, responseAsBytes.Length);
    }

    private static Response GenerateResponse(Request request, string baseURI)
    {
        StaticController staticController = new StaticController(baseURI);
        Response response = staticController.GenerateResponse(request);
        return response;
    }

    private static Request FormRequest(string data)
    {
        TextToParse text = new TextToParse(data);
        RequestPattern requestPattern = new RequestPattern();

        var (match, rText) = requestPattern.Match(text);

        Request request = new Request(match as MatchesArray);
        return request;
    }

}