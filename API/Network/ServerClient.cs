using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Tier3___Server.Implementations;
using Tier3_Db.Models.Bill;

namespace Db3.Client;

public class ServerClient
{
        private Models.Client.Client client;
        private ClientLogic _clientLogic;
        private Bill bill;
        private List<Bill> BillList;

        public ServerClient()
        {
            client = new Models.Client.Client();
            _clientLogic = new ClientLogic();
        }

        public async void GetClientByUsername(NetworkStream stream, string content)
        {
            Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
            string username = test.Username;
            string password = test.Password;
            client = await _clientLogic.getClientByUsername(username);
            string reply = JsonSerializer.Serialize(client);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async Task<Models.Client.Client> CreateClientAccount(NetworkStream stream, string content)
        {
            Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
            string username = test.Username;
            string password = test.Password;
            string name = test.Name;
            string dob = test.dob;
            int id = test.Id;
            string email = test.Email;
            string phonenumber = test.phonenumber;
            Models.Client.Client c = new Models.Client.Client(id, username, name, password, email, dob, phonenumber);
            client = await _clientLogic.createClientAccount(c);
            string reply = JsonSerializer.Serialize(client);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
            return client;
        }
        
       
        
        public async Task<Models.Client.Client> Register(NetworkStream stream, string content)
        {
            Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
            client = await _clientLogic.registerClient(test);
            string reply = JsonSerializer.Serialize(client);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
            return client;
        }

        public async void DeleteAccount(string content)
        {
            Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
            await DeleteAccount(test);
        }

        private async Task DeleteAccount(Models.Client.Client c)
        {
            client = await _clientLogic.deleteClientAccount(c);
        }

        public async void GetClientById(NetworkStream stream, string content)
        {
            Models.Client.Client client1 = await _clientLogic.getClientById(Int32.Parse(content));
            string reply = JsonSerializer.Serialize(client1);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
        
        
        
        public async void ViewBills(NetworkStream stream, string content)
        {
            List<Bill> Viewbills = await client.ViewBills(Int32.Parse(content));
            string reply = JsonSerializer.Serialize(Viewbills);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }

        public async void getBillsForClient(NetworkStream stream, string content)
        {
            
        }
        
        public async void VerifyUser(NetworkStream stream, string content)
        {
            Models.Client.Client c = JsonSerializer.Deserialize<Models.Client.Client>(content);
            string username = c.Username;
            string password = c.Password;
            bool verified = await _clientLogic.verifyUser(username, password);
            string reply = JsonSerializer.Serialize(verified);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite,0,bytesWrite.Length);

        }
        
}