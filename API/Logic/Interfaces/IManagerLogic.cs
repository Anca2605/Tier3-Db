using Db3.Models.Client;
using Db3.Models.Manager;

namespace Tier3___Server.Logic;

public interface IManagerLogic
{
    Task<Manager> getManagerById(int id);
    Task<Manager>? getManagerByUsername(string content);
    Task<Client> addClient(Client client);
    Task<Client> deleteClient(int id);
    Task<Client> editClient(Client client);
    Task<Manager> deleteManager(int id);
    
}