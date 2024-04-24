using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class ForumUserConfiguration : IEntityTypeConfiguration<ForumUser>
    {
        public void Configure(EntityTypeBuilder<ForumUser> builder)
        {
            builder.HasMany(e => e.Ratings)
                .WithOne(r => r.ForumUser)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
