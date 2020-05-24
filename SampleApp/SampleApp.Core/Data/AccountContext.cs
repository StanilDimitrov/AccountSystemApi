using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Entities;

namespace SampleApp.Core.Data
{
    public class AccountContext: DbContext
    {
        public AccountContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
