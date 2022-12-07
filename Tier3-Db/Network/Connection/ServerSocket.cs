using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Db3.Client;
using Db3.Networking.Manager;
using Db3.Utility;
using static Db3.Utility.Network;

namespace Tier3_Db.Network.Connection
{

    public class ServerSocket
    {
        private static List<TcpClient> _clients;
        private ServerClient _client;
        private ServerManager _manager;

        public ServerSocket()
        {
            _clients = new List<TcpClient>();
            _client = new ServerClient();
            _manager = new ServerManager();
        }

        public void StartServer()
        {
            Console.WriteLine("Starting server ...");
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 8090);
            tcpListener.Start();
            Console.WriteLine("Server started ...");

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
                    Network req1 = JsonSerializer.Deserialize<Network>(req);
                    Console.WriteLine(req1.Content);

                    switch (req1.Content)
                    {
                        case "REGISTER":
                            _client.Register(stream, req1.Content);
                            break;
                        case "LOGIN":
                            _client.GetClient(stream, req1.Content);
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
                        case "GETBILLBYID":
                            _client.GetBill(stream, req1.Content);
                            break;
                        case "VIEWBILLS":
                            _client.ViewBills(stream, req1.Content);
                            break;
                        case "ADDCLIENT":
                            _manager.AddClient(stream, req1.Content);
                            break;
                        default:
                            string reply = JsonSerializer.Serialize("Tier3-Db");
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
}
