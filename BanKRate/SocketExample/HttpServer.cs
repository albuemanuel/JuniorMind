using System;
using System.Net;
using System.Net.Sockets;
using JSONParser;
using SocketExample;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

public delegate void ConsoleTextChangedDelegate(string text);

public class HttpServer
{
    CancellationTokenSource cts = new CancellationTokenSource();

    int i = 0;
    // Incoming data from the client.  
    public event ConsoleTextChangedDelegate ConsoleTextChanged;
    private volatile bool shouldStop = false;
    Int32 port;
    string ipAddress;
    string baseURI;
    private TcpListener listener;
    public HttpServer(Int32 port = 13000, string ipAddress = "127.0.0.1", string baseURI = "C:/Users/albue.DESKTOP-7NLSNIJ/Desktop/JM/JuniorMind/BanKRate/SocketExample/SiteFolder")
    {
        this.port = port;
        this.ipAddress = ipAddress;
        this.baseURI = baseURI;
    }
    public bool ShouldStop { get => shouldStop; }

    public async void RunServerAsync()
    {

        listener = null;

        IPAddress localAddr = IPAddress.Parse(ipAddress);

        // TcpListener server = new TcpListener(port);
        listener = new TcpListener(localAddr, port);

        listener.Start();
        try
        {
            await AcceptClientAsync();
        }
        catch (Exception e)
        {
            OnConsoleTextChanged($"\r\nSocket exception:\n {e}");
            Console.WriteLine("Socket exception: {0}", e);
        }
        {
            //finally
            //{
            //    OnConsoleTextChanged("\r\nServerStopped");
            //    Console.WriteLine("\nPress ENTER to continue...");
            //    Console.Read();
            //}
        }

        {
            //Byte[] bytes = new Byte[1024];

            //// Start listening for connections.  
            //while (!shouldStop)
            //{
            //    OnConsoleTextChanged("Waiting for a connection...");
            //    Console.WriteLine("Waiting for a connection...");

            //    // Program is suspended while waiting for an incoming connection.  

            //    TcpClient client = listener.AcceptTcpClientAsync().ContinueWith(task => { });
            //    string data = null;

            //    NetworkStream stream = client.GetStream();

            //    data = ReceiveRequest(bytes, stream);

            //    if(data != null)
            //    {
            //        Request request = FormRequest(data);

            //        Response response = GenerateResponse(request, baseURI);

            //        Respond(stream, response);

            //        OnConsoleTextChanged($"Sent: {response.ResponseAsString()}");
            //        Console.WriteLine("Sent: {0}", response.ResponseAsString()); 
            //    }

            //    client.Close();
            //}
            //listener.Stop();
            //    }
            //catch (Exception e)
            //{
            //    OnConsoleTextChanged($"\r\nSocket exception:\n {e}");
            //    Console.WriteLine("Socket exception: {0}", e);
            //}
            //finally
            //{
            //    OnConsoleTextChanged("\r\nServerStopped");
            //    Console.WriteLine("\nPress ENTER to continue...");
            //    Console.Read();
            //}
        }
        
    }

    private async Task AcceptClientAsync()
    {
        OnConsoleTextChanged("Waiting for a connection...");
        TcpClient client = null;

        try
        {
            client = await listener.AcceptTcpClientAsync(); 
        }
        catch(Exception e)
        {
            OnConsoleTextChanged($"{e.Message}, ID: unIDed");
            throw new Exception($"{e.Message}, ID: unIDed");
        }

        IDAndProcessClient(client);
    }

    private void IDAndProcessClient(TcpClient client)
    {
        i++;
        OnConsoleTextChanged($"Client connected, ID: {i}");
        ProcessClientAsync(client, i);
    }
    private async Task ProcessClientAsync(TcpClient client, int ID)
    {
        CancellationToken ct = cts.Token;
        string data = null;
        NetworkStream stream = null;

        try
        {
            stream = client.GetStream();
        }
        catch(Exception e)
        {
            OnConsoleTextChanged($"{e.Message}, ID: {ID}");
            throw new Exception($"{e.Message}, ID: {ID}");
        }

        var bytes = new Byte[1024];

        AcceptClientAsync();

        OnConsoleTextChanged($"Processing client: {ID}");
        data = await ProcessDataAsync(stream, bytes, data, client, ID, ct);
        OnConsoleTextChanged($"Responding to client: {ID}");
        await RespondToClientAsync(stream, bytes, data, client, ID, ct);

        {//stream.ReadAsync(bytes, 0, bytes.Length)
         //    .ContinueWith(readTask =>
         //    {
         //        var count = readTask.Result;
         //        data += Encoding.ASCII.GetString(bytes, 0, count);

            //        if (!data.Contains("\r\n\r\n"))
            //            stream.ReadAsync(bytes, 0, bytes.Length);


            //    }).ContinueWith(readComplete =>
            //    {
            //        var request = FormRequest(data);
            //        var response = GenerateResponse(request, baseURI);

            //        var responseAsBytes = response.ToBytesArray();

            //        OnConsoleTextChanged($"Sent: {response.ResponseAsString()}");
            //        stream.WriteAsync(responseAsBytes, 0, responseAsBytes.Length)
            //            .ContinueWith(writeAsync => client.Close());
            //    });
        }
    }

    private async Task RespondToClientAsync(NetworkStream stream, byte[] bytes, string data, TcpClient client, int ID, CancellationToken ct)
    {
        var request = FormRequest(data);
        var response = GenerateResponse(request, baseURI);

        var responseAsBytes = response.ToBytesArray();

        OnConsoleTextChanged($"Sent: {response.ResponseAsString()}ID: {ID}");
        await stream.WriteAsync(responseAsBytes, 0, responseAsBytes.Length, ct);
        client.Close();
    }

    private async Task<string> ProcessDataAsync(NetworkStream stream, byte[] bytes, string data, TcpClient client, int ID, CancellationToken ct)
    {
        OnConsoleTextChanged($"Reading data for client: {ID}");
        int count = await stream.ReadAsync(bytes, 0, bytes.Length, ct);
        OnConsoleTextChanged($"Read complete: {count}, ID: {ID}");

        if (count == 0)
        {
            OnConsoleTextChanged($"Connection closed, ID: {ID}");
            throw new Exception("Connection closed");
        }

        data += Encoding.ASCII.GetString(bytes, 0, count);

        if (!data.Contains("\r\n\r\n"))
            await ProcessDataAsync(stream, bytes, data, client, ID, ct);

        return data;

        {
            //.ContinueWith(complete =>
            //{

            //    if (complete.Status == TaskStatus.RanToCompletion)
            //    {
            //        var request = FormRequest(data);
            //        var response = GenerateResponse(request, baseURI);

            //        var responseAsBytes = response.ToBytesArray();

            //        OnConsoleTextChanged($"Sent: {response.ResponseAsString()}");
            //        stream.WriteAsync(responseAsBytes, 0, responseAsBytes.Length)
            //        .ContinueWith(writeComplete => client.Close());
            //    }
            //});
        }
    }

    public void RequestStop()
    {
        OnConsoleTextChanged("Stopping...");
        if (cts != null)
            cts.Cancel();
        //shouldStop = true;
        listener.Stop();
    }

    //public static string ReceiveRequest(byte[] bytes, System.IO.Stream stream)
    //{
    //    string data = null;
    //    int i;
    //    // An incoming connection needs to be processed.  
    //    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
    //    {

    //        data += Encoding.ASCII.GetString(bytes, 0, i);
    //        Console.WriteLine("Received: {0}", data);

    //        if (data.Contains("\r\n\r\n"))
    //            break;

    //    }
    //    return data;
    //}

    protected virtual void OnConsoleTextChanged(string text)
    {
        ConsoleTextChanged?.Invoke(text);
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