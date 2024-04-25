using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class AgentRoleConfiguration : IEntityTypeConfiguration<AgentRole>
    {
        public void Configure(EntityTypeBuilder<AgentRole> builder)
        {

        }
    }
}
