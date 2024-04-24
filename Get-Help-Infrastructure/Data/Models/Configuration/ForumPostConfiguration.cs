using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class ForumPostConfiguration : IEntityTypeConfiguration<ForumPost>
    {
        public void Configure(EntityTypeBuilder<ForumPost> builder)
        {

        }
    }
}
