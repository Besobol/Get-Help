﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Get_Help.Infrastructure.Data.Models.Configuration
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.HasMany(a => a.Tickets)
                .WithOne(t => t.Agent)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
