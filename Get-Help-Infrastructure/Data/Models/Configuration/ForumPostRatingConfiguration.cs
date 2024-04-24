using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class ForumPostRatingConfiguration : IEntityTypeConfiguration<ForumPostRating>
    {
        public void Configure(EntityTypeBuilder<ForumPostRating> builder)
        {
            builder.HasOne(e => e.ForumUser)
                .WithMany(fu => fu.Ratings)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ForumPostReply)
                .WithMany(fpr => fpr.Rating)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
