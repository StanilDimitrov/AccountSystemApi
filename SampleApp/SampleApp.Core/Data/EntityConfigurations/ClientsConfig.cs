using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleApp.Core.Entities;

namespace SampleApp.Core.Data.EntityConfigurations
{
    public class ClientsConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
