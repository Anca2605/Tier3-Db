using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Db3.Repositories.Client;
using Microsoft.EntityFrameworkCore;
using Tier3_Db.Models;
using Tier3_Db.Models.Bill;

namespace Db3.Client;

public class ServerClient
{
    private Models.Client.Client client;
        private IClientRepo clientRepo;
        private Bill bill;
        private List<Bill> BillList;

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

        public async void CreateClientAccount(NetworkStream stream, string content)
        {
            Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
            string username = test.Username;
            string password = test.Password;
            string name = test.Name;
            string dob = test.dob;
            int id = test.Id;
            string email = test.Email;
            string phonenumber = test.phonenumber;
            client = await clientRepo.GetClient(username, password);
            string reply = JsonSerializer.Serialize(client);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
        
        public async void GetClient(NetworkStream stream, string content)
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

        public async void DeleteAccount(string content)
        {
            await DeleteAccount();
        }

        private async Task DeleteAccount()
        {
            throw new NotImplementedException();
        }

        public async void GetClientById(NetworkStream stream, string content)
        {
            Models.Client.Client client1 = await clientRepo.GetClientById(Int32.Parse(content));
            string reply = JsonSerializer.Serialize(client1);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
        }
        
        public async void GetBillById(NetworkStream stream, string content)
        {
            Bill bill = await clientRepo.GetBillById(Int32.Parse(content));
            string reply = JsonSerializer.Serialize(bill);
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
        
}