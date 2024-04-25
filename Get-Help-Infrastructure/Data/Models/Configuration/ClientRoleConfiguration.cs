using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class ClientRoleConfiguration : IEntityTypeConfiguration<ClientRole>
    {
        public void Configure(EntityTypeBuilder<ClientRole> builder)
        {
        }
    }
}
