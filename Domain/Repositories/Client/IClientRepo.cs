using Tier3_Db.Models.Bill;

namespace Db3.Repositories.Client;

public interface IClientRepo
{
    Task<string> CreateClientAccount(Models.Client.Client client);
    Task<Models.Client.Client> GetClient(string username, string password);
    Task DeleteClient(int clientId);
    Task<Models.Client.Client> GetClientByUsername(string username);
    Task<Models.Client.Client> GetClientById(int clientId);
    Task<Bill> GetBillById(int parse);
}
