using Db3.Models.Client;
using Db3.Models.Manager;
using Microsoft.EntityFrameworkCore;

namespace Tier3___Server;

public class DataContext:DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Manager> Managers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Data.db");
    }
}