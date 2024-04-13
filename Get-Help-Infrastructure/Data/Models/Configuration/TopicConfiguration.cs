using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help_Infrastructure.Data.Models.Configuration
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasOne(t => t.Service)
                .WithMany(s => s.Topics)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
