using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Tier3___Server.Implementations;

namespace Db3.Networking.Manager;

public class ServerManager
{
    private Models.Manager.Manager manager;
    private Models.Client.Client client;
    private ManagerLogic _managerLogic;

    public ServerManager()
    {
        manager = new Models.Manager.Manager();
        _managerLogic = new ManagerLogic();
    }

    public async void GetManagerById(NetworkStream stream, string content)
    {
        Models.Manager.Manager test = JsonSerializer.Deserialize<Models.Manager.Manager>(content);
        string username = test.Username;
        string password = test.Password;

        manager = await _managerLogic.getManagerById(int.Parse(content));
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
        client =  await _managerLogic.addClient(cl);
        string reply = JsonSerializer.Serialize(client);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }
    
    public async void DeleteClient(NetworkStream stream, string content)
    {
        Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
        client = await _managerLogic.deleteClient(int.Parse(content));
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
        client = await _managerLogic.editClient(c);
        string reply = JsonSerializer.Serialize(client);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }

    public async void DeleteManager(NetworkStream stream, string content)
    {
        await _managerLogic.deleteManager(Int32.Parse(content));
    }
        
    public async void GetManagerByUsername(NetworkStream stream, string content)
    {
        Models.Manager.Manager manager1 = JsonSerializer.Deserialize<Models.Manager.Manager>(content);
        string username = manager1.Username;
        manager = await _managerLogic.getManagerByUsername(username);
        string reply = JsonSerializer.Serialize(manager);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }

    public async void Login(NetworkStream stream, string content)
    {
        Models.Manager.Manager m = JsonSerializer.Deserialize<Models.Manager.Manager>(content);
        manager = await _managerLogic.getManagerById(m.Id);
        string reply = JsonSerializer.Serialize(manager);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }

    
}
