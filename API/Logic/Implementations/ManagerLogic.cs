using Db3.Models.Client;
using Db3.Models.Manager;
using Microsoft.EntityFrameworkCore;
using Tier3___Server.Logic;

namespace Tier3___Server.Implementations;

public class ManagerLogic : IManagerLogic
{
    private readonly DataContext context;
    
    public async Task<Manager> getManagerById(int id)
    {
        Manager manager = await context.Managers.FindAsync(id);
        return manager;
    }

    public async Task<Manager>? getManagerByUsername(string content)
    {
        Manager manager = await context.Managers.FindAsync(content);
        return manager;
    }

    public async Task<Client> addClient(Client client)
    {
        await context.Clients.AddAsync(client);
        return client;
    }

    public async Task<Client> deleteClient(int id)
    {
        Client c = await context.Clients.FindAsync(id);
        
        return c;
    }

    public async Task<Client> editClient(Client client)
    {
        Client c = await context.Clients.FindAsync(client.Id);
        context.Clients.Remove(c);
        context.Clients.AddAsync(client);
        return client;
    }

    public Task<Manager> deleteManager(int id)
    {
        throw new NotImplementedException();
    }
}