using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(m => m.Agent)
                .WithMany(a => a.Messages)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(m => m.Client)
                .WithMany(a => a.Messages)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(m => m.Ticket)
                .WithMany(a => a.Messages)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
