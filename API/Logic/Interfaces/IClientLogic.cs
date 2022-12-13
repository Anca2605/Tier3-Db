using Db3.Models.Client;
using Tier3_Db.Models.Bill;

namespace Tier3___Server.Logic;

public interface IClientLogic
{
    Task<Client?> getClientByUsername(string content);
    Task<Client> createClientAccount(Client c);
    Task<Client?> getClientById(int id);
    Task<Client> registerClient(Client client);
    Task<Client> deleteClientAccount(Client client);
    Task<List<Bill>> getBills(int Id);
    Task<Bill> getBillById(string content);
    Task<bool> verifyUser(string username, string password);

    Task<bool> subToWater(Client client);
    Task<bool> subToHeating(Client client);
    Task<bool> subToElectricity(Client client);
    Task<bool> subToRent(Client client);
}