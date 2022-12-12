using Db3.Models.Client;
using Db3.Models.Manager;
using Microsoft.EntityFrameworkCore;
using Tier3_Db.Models.Bill;

namespace Tier3___Server;

public class DataContext:DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Bill> Electricity { get; set; }
    public DbSet<Bill> Heating { get; set; }
    public DbSet<Bill> Rent { get; set; }
    public DbSet<Bill> Water { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Data.db");
    }
}