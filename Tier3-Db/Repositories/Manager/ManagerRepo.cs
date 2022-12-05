
using Db3.Repositories.Manager;

public class ManagerRepo : IManagerRepo
{
    private DatabaseContext dbCtx;

        public async Task<Models.Manager.Manager> GetManager(string username, string password)
        {
            try
            {
                await using (dbCtx = new DatabaseContext())
                {
                    return dbCtx.manager
                        .First(c => c.Username.Equals(username) && c.Password.Equals(password));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Manager doesn't exist");
            }

            return null;
        }

        public async Task DeleteManager(int managerId)
        {
            await using (dbCtx = new DatabaseContext())
            {
                Models.Manager.Manager manager = await dbCtx.manager
                    .Include(e => e.Username)
                    .Include(e => e.Password)
                    .FirstAsync(em => em.Id == managerId);

                dbCtx.manager.Remove(manager);
                await dbCtx.SaveChangesAsync();
            }
        }

        public async Task<Models.Manager.Manager> GetManagerByUsername(string username)
        {
            await using (dbCtx = new DatabaseContext())
            {
                Models.Manager.Manager manager = await dbCtx.manager
                    .FirstAsync(c => c.Username.Equals(username));

                return manager;
            }
            
        }

        public async Task<Models.Manager.Manager> GetManagerById(int managerId)
        {
            await using (dbCtx = new DatabaseContext())
            {
                Models.Manager.Manager manager = await dbCtx.manager
                    .FirstAsync(em => em.Id == managerId);

                return manager;
            }
            
        }
        public async Task DeleteClient(int clientId)
        {
            await using (dbCtx = new DatabaseContext())
            {
                Models.Client.Client client = await dbCtx.Clients
                    .Include(b => b.Id)
                    .Include(b => b.Username)
                    .Include(b => b.Password)
                    .Include(b => b.dob)
                    .Include(b => b.Email)
                    .Include(b => b.phonenumber)
                    .FirstAsync(client => client.Id == clientId);
                
                dbCtx.Delete(client);
                Console.WriteLine("client deleted");
                await dbCtx.SaveChangesAsync();
            }
        }

        public async Task<Models.Manager.Manager> GetManager(int managerId)
        {
            await using (dbCtx = new DatabaseContext())
            {
                Models.Manager.Manager manager = await dbCtx.manager
                    .Include(b => b.Id)
                    .Include(b => b.Username)
                    .Include(b => b.Password)
                    .FirstAsync(manager => manager.Id == managerId);

                return manager;
            }
            
        }
        
    }
