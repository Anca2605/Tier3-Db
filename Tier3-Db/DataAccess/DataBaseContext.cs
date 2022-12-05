using Db3.Models.Client;
using Db3.Models.Manager;
using Microsoft.EntityFrameworkCore;
using Tier3.Models;
using Tier3.Models.Burial;
using Tier3.Models.Client;
using Tier3.Models.Employee;
using Tier3.Models.Preference;

namespace Tier3.DataAccess
{
    public class DataBaseContext : DbContext
    {

        public DbSet<Manager> Manager{ get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                @"Data Source = C:\Users\abadoi\Documents\GitHub\SEP3\Tier3\Tier3\Tier3.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasKey(cb => new
                {
                    cb.ClientId
                });

            modelBuilder.Entity<Client>()
                .HasOne(cb => cb.Client)
                .WithMany(cb => cb.Bills)
                .HasForeignKey(cb => cb.ClientId);
            
            modelBuilder.Entity<Manager>()
                .HasOne<Manager>(b => b.Username)
                .WithMany(b => b.clients)
                .HasForeignKey(b => b.ManagerId);

        }
    }
}