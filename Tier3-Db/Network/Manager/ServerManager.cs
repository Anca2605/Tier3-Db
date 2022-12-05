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
        manager = await managerRepo.GetManagerById(username, password);
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
