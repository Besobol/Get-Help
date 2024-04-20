using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasOne(t => t.Client)
                .WithMany(c => c.Tickets)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Agent)
                .WithMany(a => a.Tickets)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ti => ti.Topic)
                .WithMany(to => to.Tickets)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
