namespace Db3.Repositories.Manager;

public interface IManagerRepo
{
    Task<Models.Manager.Manager> GetManager(string username, string password);
    Task DeleteManager(int managerId);
    Task<Models.Manager.Manager> GetManagerByUsername(string username);
    Task<Models.Manager.Manager> GetManagerById(int managerId);
     void DeleteClient(int clientId);
    Task<Models.Client.Client> GetClient(int clientId);
    Task AddClient(string username, string password, string name, string dob, string email, string phonenumber, int Id);
}