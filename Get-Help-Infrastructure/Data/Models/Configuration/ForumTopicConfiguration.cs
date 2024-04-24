using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class ForumTopicConfiguration : IEntityTypeConfiguration<ForumTopic>
    {
        public void Configure(EntityTypeBuilder<ForumTopic> builder)
        {

        }
    }
}
