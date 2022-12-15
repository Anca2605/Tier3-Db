using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Db3.Models.Client;
using Db3.Utility;
using Tier3_Db.Models.Bill;

class Program
{
    static void Main(string[] args)
    {

        TcpClient clientSocket = new TcpClient();
        clientSocket.Connect("127.0.0.1", 8091);
        NetworkStream serverStream = clientSocket.GetStream();
        Client testClient = new Client(18, "test", "alpha", "beta", "kurva@gmail.com",
            "05/25/25 12:25:00", "00000000");
        Bill testBill = new Bill(22,3,344, "rent");

        Console.WriteLine("Get client by username: a -->");
        try
        {
            
            //fail
            //createClientAccount(testClient); 
            //getClientByUsername("Lolek");
            //deleteClientAccount(10);
            //registerClient(testClient);
            
            //pass
            //deleteBillById(21);  
            //createBill(testBill); 
            //getBills(3); pass
            //deleteBill(testBill);
            //getClientAccount(3); 
            //getClientById(10); 
            //verifyUser("Lolek","lolek"); 
            //subToHeating(10); 
            //subToElectricity(10); 
            //subToRent(10); 
            //subToWater(10); 
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


        void getClientById(int id)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.GETCLIENTBYID, JsonSerializer.Serialize<int>(id));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Get client by id: " + req);
        }



        void getClientByUsername(string username)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.GETCLIENTBYUSERNAME, JsonSerializer.Serialize<string>(username));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Get client by username: " + req);
        }

        void createClientAccount(Client c)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.CREATECLIENTACCOUNT, JsonSerializer.Serialize<Client>(c));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Create client account: " + req);
        }

        void getClientAccount(int id)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.GETCLIENTBYID, JsonSerializer.Serialize<int>(id));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Get client by id: " + req);
        }

        void registerClient(Client client)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.REGISTER, JsonSerializer.Serialize<Client>(client));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Register client: " + req);
        }

        void deleteClientAccount(int id)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.DELETECLIENT, JsonSerializer.Serialize<int>(id));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Delete client: " + req);
        }

        void getBills(int id)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.BILLS, JsonSerializer.Serialize<int>(id));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Get bills by id: " + req);
        }

        void createBill(Bill bill)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.ADDBILL, JsonSerializer.Serialize<Bill>(bill));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Create bill: " + req);
        }

        void deleteBill(Bill bill)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.DELETEBILL, JsonSerializer.Serialize<Bill>(bill));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Delete bill: " + req);
        }

        void deleteBillById(int id)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.DELETEBILLBYID, JsonSerializer.Serialize<int>(id));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Delete bill by id: " + req);
        }

        void verifyUser(string username, string password)
        {
            Client testClient1 = new Client(10, username, "alpha", password, "kurva@gmail.com",
                "05/25/25 12:25:00", "00000000");
            
            NetworkPackage p = new NetworkPackage(NetworkType.LOGIN, JsonSerializer.Serialize<Client>(testClient1));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Verify client account " + req);
            
        }

        void subToWater(int id)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.SUBTOWATER, JsonSerializer.Serialize<int>(id));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Sub to water: " + req);
        }
        void subToRent(int id)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.SUBTORENT, JsonSerializer.Serialize<int>(id));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Sub to rent: " + req);
        }
        void subToElectricity(int id)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.SUBTOELECTRICITY, JsonSerializer.Serialize<int>(id));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Sub to electricity: " + req);
        }
        void subToHeating(int id)
        {
            NetworkPackage p = new NetworkPackage(NetworkType.SUBTOHEATING, JsonSerializer.Serialize<int>(id));
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("Sub to heating: " + req);
        }
    }

}