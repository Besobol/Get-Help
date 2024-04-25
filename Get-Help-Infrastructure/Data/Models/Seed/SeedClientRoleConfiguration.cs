using Get_Help.Infrastructure.Data.Models.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class SeedClientRoleConfiguration : IEntityTypeConfiguration<ClientRole>
    {
        public void Configure(EntityTypeBuilder<ClientRole> builder)
        {
            var data = new SeedDb();

            builder.HasData(data.ClientRole);
        }
    }
}
