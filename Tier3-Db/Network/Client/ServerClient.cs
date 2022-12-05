using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Db3.Repositories.Client;

namespace Db3.Client;

public class ServerClient
{
    private Models.Client.Client client;
        private IClientRepo clientRepo;

        public ServerClient()
        {
            client = new Models.Client.Client();
            clientRepo = new ClientRepo();
        }

        public async void GetClientByUsername(NetworkStream stream, string content)
        {
            Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
            string username = test.Username;
            string password = test.Password;
            client = await clientRepo.GetClient(username, password);
            string reply = JsonSerializer.Serialize(client);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
        
        public async void Register(NetworkStream stream, string content)
        {
            Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
            string input = await clientRepo.CreateClientAccount(test);
            string reply = JsonSerializer.Serialize(input);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void DeleteClient(string content)
        {
            await clientRepo.DeleteClient(Int32.Parse(content));
        }
        
        public async void GetClientById(NetworkStream stream, string content)
        {
            Models.Client.Client client1 = await clientRepo.GetClientById(Int32.Parse(content));
            string reply = JsonSerializer.Serialize(client1);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
}