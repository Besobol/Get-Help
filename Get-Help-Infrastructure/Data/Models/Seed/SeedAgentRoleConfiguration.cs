using Get_Help.Infrastructure.Data.Models.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class SeedAgentRoleConfiguration : IEntityTypeConfiguration<AgentRole>
    {
        public void Configure(EntityTypeBuilder<AgentRole> builder)
        {

            var data = new SeedDb();

            builder.HasData(data.AgentRole);
        }
    }
}
