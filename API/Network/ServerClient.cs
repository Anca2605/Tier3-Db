using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Db3.Models.Manager;
using Tier3___Server.Implementations;
using Tier3_Db.Models.Bill;

namespace Db3.Client;

public class ServerClient
{
        private Models.Client.Client client;
        private Manager manager;
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
            Console.WriteLine("ServerClient get client by username: " + content);
            string username = JsonSerializer.Deserialize<string>(content);
            client = await _clientLogic.getClientByUsername(content);
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
        
       
        
        public async Task<string> Register(NetworkStream stream, string content)
        {
            Console.WriteLine("Serverclient register method");
            Models.Client.Client c = JsonSerializer.Deserialize<Models.Client.Client>(content);
            client = await _clientLogic.registerClient(c);
            Console.WriteLine("Client: " + client.ToString());
            string reply = JsonSerializer.Serialize(client);
            byte[] bytesWrite = Encoding.ASCII.GetBytes("OK");
            Console.WriteLine("Byteswrite: " + bytesWrite.ToString());
            stream.Write(bytesWrite, 0, bytesWrite.Length);
            return "OK";
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



        public async void CreateBill(NetworkStream stream, string content)
        {
            Bill bill = JsonSerializer.Deserialize<Bill>(content);
            await _clientLogic.createBill(bill);
        }

        public async void DeleteBill(NetworkStream stream, string content)
        {
            Bill bill = JsonSerializer.Deserialize<Bill>(content);
            await _clientLogic.deleteBill(bill);
        }
        
        public async void DeleteBillById(NetworkStream stream, string content)
        {
            int id = JsonSerializer.Deserialize<int>(content);
            await _clientLogic.deleteBillById(id);
        }

        public async void getBillsForClient(NetworkStream stream, string content)
        {
            Console.WriteLine("method in server client called");
            int c = JsonSerializer.Deserialize<int>(content);
            int clientId = c;
            Console.WriteLine("Got: " + c);
            BillList = await _clientLogic.getBills(clientId);
            string reply = JsonSerializer.Serialize(BillList);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            Console.WriteLine("Back: " + reply.ToString());
            stream.Write(bytesWrite,0,bytesWrite.Length);
        }
        
        public async void VerifyUser(NetworkStream stream, string content)
        {
            Models.Client.Client c = JsonSerializer.Deserialize<Models.Client.Client>(content);
            string username = c.Username;
            string password = c.Password;
            Models.Client.Client client1 = await _clientLogic.verifyUser(username, password);
            string reply = JsonSerializer.Serialize(client1);
            byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
            stream.Write(bytesWrite,0,bytesWrite.Length);

        }

        public async void SubToRent(NetworkStream stream, string content)
        {
            int c = JsonSerializer.Deserialize<int>(int.Parse(content));
            bool success = await _clientLogic.subToRent(c);
            string reply = JsonSerializer.Serialize(success);
            byte[] bytesWrite = Encoding.ASCII.GetBytes((reply));
            stream.Write(bytesWrite,0,bytesWrite.Length);
        }
        public async void SubToWater(NetworkStream stream, string content)
        {
            int c = JsonSerializer.Deserialize<int>(int.Parse(content));
            bool success = await _clientLogic.subToWater(c);
            string reply = JsonSerializer.Serialize(success);
            byte[] bytesWrite = Encoding.ASCII.GetBytes((reply));
            stream.Write(bytesWrite,0,bytesWrite.Length);
        }
        public async void SubToHeating(NetworkStream stream, string content)
        {
            int c = JsonSerializer.Deserialize<int>(int.Parse(content));
            bool success = await _clientLogic.subToHeating(c);
            string reply = JsonSerializer.Serialize(success);
            byte[] bytesWrite = Encoding.ASCII.GetBytes((reply));
            stream.Write(bytesWrite,0,bytesWrite.Length);
        }
        public async void SubToElectricity(NetworkStream stream, string content)
        {
            int c = JsonSerializer.Deserialize<int>(int.Parse(content));
            bool success = await _clientLogic.subToElectricity(c);
            string reply = JsonSerializer.Serialize(success);
            byte[] bytesWrite = Encoding.ASCII.GetBytes((reply));
            stream.Write(bytesWrite,0,bytesWrite.Length);
        }
        
        public async void GetManagerById(NetworkStream stream, string content)
    {
        Models.Manager.Manager test = JsonSerializer.Deserialize<Models.Manager.Manager>(content);
        string username = test.Username;
        string password = test.Password;

        manager = await _clientLogic.getManagerById(int.Parse(content));
        string reply = JsonSerializer.Serialize(manager);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }
    
    public async void AddClient(NetworkStream stream, string content)
    {
        Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
        string username = test.Username;
        string password = test.Password;
        string name = test.Name;
        string dob = test.dob;
        string email = test.Email;
        string phonenumber = test.phonenumber;
        int Id = test.Id;
        Models.Client.Client cl = new Models.Client.Client(Id,username,name,password,email,dob,phonenumber);
        client =  await _clientLogic.addClient(cl);
        string reply = JsonSerializer.Serialize(client);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }
    
    public async void DeleteClient(NetworkStream stream, string content)
    {
        
        client = await _clientLogic.deleteClient(int.Parse(content));
        string reply = JsonSerializer.Serialize(client);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }
    
    public async void EditClient(NetworkStream stream, string content)
    {
        Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
        string username = test.Username;
        string password = test.Password;
        string name = test.Name;
        string dob = test.dob;
        string email = test.Email;
        string phonenumber = test.phonenumber;
        int Id = test.Id;
        Models.Client.Client c = new Models.Client.Client(Id, username, name, password, email, dob, phonenumber);
        client = await _clientLogic.editClient(c);
        string reply = JsonSerializer.Serialize(client);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }

    public async void DeleteManager(NetworkStream stream, string content)
    {
        await _clientLogic.deleteManager(Int32.Parse(content));
    }
        
    public async void GetManagerByUsername(NetworkStream stream, string content)
    {
        Models.Manager.Manager manager1 = JsonSerializer.Deserialize<Models.Manager.Manager>(content);
        string username = manager1.Username;
        manager = await _clientLogic.getManagerByUsername(username);
        string reply = JsonSerializer.Serialize(manager);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }

    public async void Login(NetworkStream stream, string content)
    {
        Models.Manager.Manager m = JsonSerializer.Deserialize<Models.Manager.Manager>(content);
        manager = await _clientLogic.getManagerById(m.Id);
        string reply = JsonSerializer.Serialize(manager);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }
        
}