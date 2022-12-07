using System.Collections.ObjectModel;
using Db3.Models.Client;
using Db3.Repositories.Client;
using Microsoft.EntityFrameworkCore;

namespace Tier3_Db.Models
{

    public class ClientRepo : IClientRepo
    {
        private DbContext dbCtx;
        private Client _client;

        async Task<string> IClientRepo.CreateClientAccount(Client _client)
        {
            await using (dbCtx = new DbContext())
            {
                foreach (var variable in dbCtx.)
                {
                    if (variable.Username.Equals(client.Username))
                    {
                        Console.WriteLine("Account already exists");
                        return "Account already exists";
                    }
                }

                client.Client = new List<Models.Client.Client>();
                await dbCtx.Clients.AddAsync(client);
                Console.WriteLine("Account created");
                await dbCtx.SaveChangesAsync();
            }

            return "Account created";
        }

        public Task<string> CreateClientAccount(Client client)
        {
            throw new NotImplementedException();
        }

        Task<Client> IClientRepo.GetClient(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.Client.Client> GetClient(string username, string password)
        {
            try
            {
                await using (dbCtx = new DbContext())
                {
                    return dbCtx.Clients
                        .First(c => c.Username.Equals(username) && c.Password.Equals(password));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Account with username " + username + " not found");
            }
        }

        public async Task DeleteClient(int clientId)
        {
            await using (dbCtx = new DbContext())
            {
                Models.Client.Client client = await dbCtx.Clients
                    .Include(c => c.Burials)
                    .ThenInclude(c => c.BurialPreferences)
                    .Include(c => c.Email)
                    .Include(c => c.Name)
                    .Include(c => c.Username)
                    .Include(c => c.Password)
                    .FirstAsync(cl => cl.Id == clientId);

                client.Client = new Collection<Models.Client.Client>();
                dbCtx.Clients.Remove(client);
                await dbCtx.SaveChangesAsync();
            }
        }

        Task<Client> IClientRepo.GetClientByUsername(string username)
        {
            throw new NotImplementedException();
        }

        Task<Client> IClientRepo.GetClientById(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Bill.Bill> GetBillById(int parse)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.Client.Client> GetClientByUsername(string username)
        {
            await using (dbCtx = new DbContext())
            {
                Models.Client.Client client;

                try
                {
                    client = await dbCtx.Clients
                        .Include(cl => cl.Burials)
                        .FirstAsync(c => c.Username.Equals(username));
                }
                catch (Exception e)
                {
                    throw new Exception("Not found, check credentials");
                }

                return client;
            }
        }

        public async Task<Models.Client.Client> GetClientById(int clientId)
        {
            await using (dbCtx = new DbContext())
            {
                Models.Client.Client client;

                try
                {
                    client = await dbCtx.Clients
                        .Include(cl => cl.Burials)
                        .ThenInclude(c => c.BurialPreferences)
                        .FirstAsync(cl => cl.Id == clientId);
                }
                catch (Exception e)
                {
                    throw new Exception("Not found, check credentials");
                }

                return client;
            }
        }
    }
}
