using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Db3.Repositories.Manager;

namespace Db3.Networking.Manager;

public class ServerManager
{
    private Models.Manager.Manager manager;
    private IManagerRepo managerRepo;

    public ServerManager()
    {
        manager = new Models.Manager.Manager();
        managerRepo = new ManagerRepo();
    }

    public async void GetManagerById(NetworkStream stream, string content)
    {
        Models.Manager.Manager test = JsonSerializer.Deserialize<Models.Manager.Manager>(content);
        string username = test.Username;
        string password = test.Password;

        manager = await managerRepo.GetManagerById(int.Parse(content));
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
        await managerRepo.AddClient(cl);
        string reply = JsonSerializer.Serialize(manager);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }
    
    public async void DeleteClient(NetworkStream stream, string content)
    {
        Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
        string username = test.Username;
        string password = test.Password;

        await managerRepo.DeleteClient(int.Parse(content));

        string reply = JsonSerializer.Serialize(manager);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }
    
    public async void EditClient(NetworkStream stream, string content)
    {
        Models.Client.Client test = JsonSerializer.Deserialize<Models.Client.Client>(content);
        string username = test.Username;
        string password = test.Password;
        string dob = test.dob;
        string email = test.Email;
        string phonenumber = test.phonenumber;
        int Id = test.Id;
        await managerRepo.GetClient(Id);
        string reply = JsonSerializer.Serialize(manager);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }

    public async void DeleteManager(string content)
    {
        await managerRepo.DeleteManager(Int32.Parse(content));
    }
        
    public async void GetManagerByUsername(NetworkStream stream, string content)
    {
        Models.Manager.Manager manager1 = JsonSerializer.Deserialize<Models.Manager.Manager>(content);
        string username = manager1.Username;
        manager = await managerRepo.GetManagerByUsername(username);
        string reply = JsonSerializer.Serialize(manager);
        byte[] bytesWrite = Encoding.ASCII.GetBytes(reply);
        stream.Write(bytesWrite, 0, bytesWrite.Length);
    }
}
