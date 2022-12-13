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
        context.SaveChanges();
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
        context.SaveChanges();
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
        context.SaveChanges();
        return client;


    }
    
    public async Task<List<Bill>> getBillsElectricity(int Id)
    {
        List<Bill> list = new List<Bill>();
        Client client = await context.Clients.FindAsync(Id);
        IQueryable<Bill> query = context.Electricity.AsQueryable();
        query = query.Where(b=> b.clientid.Equals(client.Id));
        list = await query.ToListAsync();
        return list;
    }
    
    public async Task<List<Bill>> getBillsWater(int Id)
    {
        List<Bill> list = new List<Bill>();
        Client client = await context.Clients.FindAsync(Id);
        IQueryable<Bill> query = context.Water.AsQueryable();
        query = query.Where(b=> b.clientid.Equals(client.Id));
        list = await query.ToListAsync();
        return list;
    }
    
    public async Task<List<Bill>> getBillsHeating(int Id)
    {
        List<Bill> list = new List<Bill>();
        Client client = await context.Clients.FindAsync(Id);
        IQueryable<Bill> query = context.Heating.AsQueryable();
        query = query.Where(b=> b.clientid.Equals(client.Id));
        list = await query.ToListAsync();
        return list;
    }
    
    public async Task<List<Bill>> getBillsRent(int Id)
    {
        List<Bill> list = new List<Bill>();
        Client client = await context.Clients.FindAsync(Id);
        IQueryable<Bill> query = context.Rent.AsQueryable();
        query = query.Where(b=> b.clientid.Equals(client.Id));
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

    public async Task<bool> verifyUser(string username, string password)
    {
        bool verified = false;
        Client c = await context.Clients.FindAsync(username);
        if (c.Username == username && c.Password == password)
        {
            verified = true;
        }

        return verified;
    }

    public async Task<bool> subToWater(Client client)
    {
        Client c = await context.Clients.FindAsync(client.Id);
        c.IsSubToWater = true;
        context.Clients.Remove(client);
        context.SaveChanges();
        await context.Clients.AddAsync(c);
        context.SaveChanges();
        return true;
    }

    public async Task<bool> subToHeating(Client client)
    {
        Client c = await context.Clients.FindAsync(client.Id);
        c.IsSubToHeating = true;
        context.Clients.Remove(client);
        context.SaveChanges();
        await context.Clients.AddAsync(c);
        context.SaveChanges();
        return true;
    }

    public async Task<bool> subToElectricity(Client client)
    {
        Client c = await context.Clients.FindAsync(client.Id);
        c.IsSubToElectricity = true;
        context.Clients.Remove(client);
        context.SaveChanges();
        await context.Clients.AddAsync(c);
        context.SaveChanges();
        return true;
    }

    public async Task<bool> subToRent(Client client)
    {
        Client c = await context.Clients.FindAsync(client.Id);
        c.IsSubToRent = true;
        context.Clients.Remove(client);
        context.SaveChanges();
        await context.Clients.AddAsync(c);
        context.SaveChanges();
        return true;
    }
}