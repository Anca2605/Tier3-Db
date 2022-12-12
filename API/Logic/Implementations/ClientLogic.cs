using System.Runtime.CompilerServices;
using Db3.Models.Client;
using Microsoft.EntityFrameworkCore;
using Tier3___Server.Logic;
using Tier3_Db.Models.Bill;

namespace Tier3___Server.Implementations;

public class ClientLogic : IClientLogic
{
    private readonly DataContext context;
    
    
    public async Task<Client?> getClientByUsername(string content)
    {

        Client client = await context.Clients.FindAsync(content);
        return client;
    }

    public async Task<Client> createClientAccount(Client c)
    {
        await context.Clients.AddAsync(c);
        return c;
    }

    public async Task<Client?> getClientById(int id)
    {
        Client c = await context.Clients.FindAsync(id);
        return c;
    }

    public async Task<Client> registerClient(Client client)
    {
        await context.AddAsync(client);
        return client;
    }


    public async Task<Client> deleteClientAccount(Client client)
    {

        Client? existing = await getClientById(client.Id);
        if (existing == null)
        {
            //nothing
        }
        context.Remove(client);
        return client;


    }
    
    public async Task<List<Bill>> getBillsElectricity(int Id)
    {
        List<Bill> list = new List<Bill>();
        Client client = await context.Clients.FindAsync(Id);
        IQueryable<Bill> query = context.Electricity.AsQueryable();
        query = query.Where(b=> b.Name.Equals(client.Name));
        list = await query.ToListAsync();
        return list;
    }
    
    public async Task<List<Bill>> getBillsWater(int Id)
    {
        List<Bill> list = new List<Bill>();
        Client client = await context.Clients.FindAsync(Id);
        IQueryable<Bill> query = context.Water.AsQueryable();
        query = query.Where(b=> b.Name.Equals(client.Name));
        list = await query.ToListAsync();
        return list;
    }
    
    public async Task<List<Bill>> getBillsHeating(int Id)
    {
        List<Bill> list = new List<Bill>();
        Client client = await context.Clients.FindAsync(Id);
        IQueryable<Bill> query = context.Heating.AsQueryable();
        query = query.Where(b=> b.Name.Equals(client.Name));
        list = await query.ToListAsync();
        return list;
    }
    
    public async Task<List<Bill>> getBillsRent(int Id)
    {
        List<Bill> list = new List<Bill>();
        Client client = await context.Clients.FindAsync(Id);
        IQueryable<Bill> query = context.Rent.AsQueryable();
        query = query.Where(b=> b.Name.Equals(client.Name));
        list = await query.ToListAsync();
        return list;
    }
    
    public async Task<List<Bill>> getBills(int Id)
    {
        List<Bill> list = new List<Bill>();
        list.AddRange(getBillsRent(Id).Result);
        list.AddRange(getBillsElectricity(Id).Result);
        list.AddRange(getBillsHeating(Id).Result);
        list.AddRange(getBillsWater(Id).Result);
        
        return list;

    }
    public Task<Bill> getBillById(string content)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> verifyUser(string username, string passowrd)
    {
        bool verified = false;
        Client c = await context.Clients.FindAsync(username);
        if (c.Username == username && c.Password == passowrd)
        {
            verified = true;
        }

        return verified;
    }
}