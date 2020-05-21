using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Data.EntityConfigurations;
using SampleApp.Core.Entities;

namespace SampleApp.Core.Data
{
    public class AccountContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientsConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
