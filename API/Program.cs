using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Db3.Client;
using Db3.Networking.Manager;
using Db3.Utility;

namespace Tier3___Server;

public class Program
{
    private List<TcpClient> _clients;
    private ServerClient _client;
    private ServerManager _manager;

    
    static void Main(string[] args)
    {
        Program p = new Program();
        p._clients = new List<TcpClient>();
        p._client = new ServerClient();
        p._manager = new ServerManager();
        
        p.ExecuteServer();
    }

    public void ExecuteServer()
    {
        Console.WriteLine("Starting server ...");
        //TcpListener tcpListener = new TcpListener(IPAddress.Any, 8090);
        //tcpListener.Start();
        

        IPHostEntry host = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8090);
        Console.WriteLine("Server started ...");

        try
        {
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for connection");
            Socket handler = listener.Accept();

            string data = null;
            byte[] bytes = null;

            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }

            }

            Console.WriteLine("Text received: {0}", data);
            byte[] msg = Encoding.ASCII.GetBytes(data);
            handler.Send(msg);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        catch
        {
            
        }

        while (true)
        {
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            _clients.Add(tcpClient);
            Console.WriteLine("Client connected");
            new Thread(() => Handle(tcpClient)).Start();
        }

    }

    private void Handle(TcpClient tcpClient)
    {
        NetworkStream stream = tcpClient.GetStream();

        while (true)
        {
            try
            {
                byte[] data = new byte[1024 * 1024];
                int bytesToRead = stream.Read(data, 0, data.Length);
                string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
                NetworkPackage req1 = JsonSerializer.Deserialize<NetworkPackage>(req);
                Console.WriteLine(req1.Content);

                switch (req1.Content)
                {
                    case "REGISTER":
                        _client.Register(stream, req1.Content);
                        break;
                    case "LOGIN":
                        _client.GetClientByUsername(stream, req1.Content);
                        break;
                    case "DELETEACCOUNT":
                        _client.DeleteAccount(req1.Content);
                        break;
                    case "DELETECLIENT":
                        _manager.DeleteClient(stream, req1.Content);
                        break;
                    case "GETCLIENTBYUSERNAME":
                        _client.GetClientByUsername(stream, req1.Content);
                        break;
                    case "GETCLIENTBYID":
                        _client.GetClientById(stream, req1.Content);
                        break;
                    case "EDITCLIENT":
                        _manager.EditClient(stream, req1.Content);
                        break;
                    case "ADDCLIENT":
                        _manager.AddClient(stream, req1.Content);
                        break;
                    case "VERIFY":
                        _client.VerifyUser(stream, req1.Content);
                        break;
                    default:
                        string reply = JsonSerializer.Serialize("Domain");
                        Console.WriteLine(reply);
                        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
                        stream.Write(bytesWrite, 0, bytesWrite.Length);
                        break;

                }

                stream.Close();
                break;
            }
            catch (IOException ioe)
            {
                _clients.Remove(tcpClient);
            }
        }
    }
}