using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class ForumPostReplyConfiguration : IEntityTypeConfiguration<ForumPostReply>
    {
        public void Configure(EntityTypeBuilder<ForumPostReply> builder)
        {
            builder.HasMany(e => e.Rating)
                .WithOne(r => r.ForumPostReply)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
