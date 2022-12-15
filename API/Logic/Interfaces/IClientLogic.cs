using Db3.Models.Client;
using Db3.Models.Manager;
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
    Task<Bill> createBill(Bill bill);
    Task<Bill> deleteBill(Bill bill);
    Task<Bill> deleteBillById(int id);
    Task<Bill> getBillById(string content);
    Task<Client> verifyUser(string username, string password);

    Task<bool> subToWater(int id);
    Task<bool> subToHeating(int id);
    Task<bool> subToElectricity(int id);
    Task<bool> subToRent(int id);

    Task<Manager> getManagerById(int id);

    Task<Manager>? getManagerByUsername(string content);

    Task<Client> addClient(Client client);

    Task<Client> deleteClient(int id);

   Task<Client> editClient(Client client);

    Task<Manager> deleteManager(int id);
}