using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Db3.Utility;
using Tier3_Db.Models.Bill;

class Program
{
    static void Main(string[] args)
    {

        TcpClient clientSocket = new TcpClient();
        clientSocket.Connect("127.0.0.1", 8091);
        NetworkStream serverStream = clientSocket.GetStream();
        
        
        

        


        while (true)
        {
            Console.WriteLine("Write to server: ");
            string s = Console.ReadLine();
            NetworkPackage p = new NetworkPackage(NetworkType.GETCLIENTBYID, s);
            
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(p));
            serverStream.Write(outStream, 0, outStream.Length);

            Console.WriteLine();
            
            
            byte[] data = new byte[1024 * 1024];
            int bytesToRead = serverStream.Read(data, 0, data.Length);
            string req = Encoding.ASCII.GetString(data, 0, bytesToRead);
            Console.WriteLine("request: " + req);
            //List<Bill> list = JsonSerializer.Deserialize<List<Bill>>(req); 
            //Console.WriteLine("List to string: " + list.ToString());
            
        }
    }

}