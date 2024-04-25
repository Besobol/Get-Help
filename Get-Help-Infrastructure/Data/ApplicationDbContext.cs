using Get_Help.Infrastructure.Data.Models;
using Get_Help.Infrastructure.Data.Models.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Get_Help.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AgentRoleConfiguration());
            builder.ApplyConfiguration(new ClientRoleConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
            builder.ApplyConfiguration(new TopicConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());

            builder.ApplyConfiguration(new SeedAgentRoleConfiguration());
            builder.ApplyConfiguration(new SeedClientRoleConfiguration());
            builder.ApplyConfiguration(new SeedAgentConfiguration());
            builder.ApplyConfiguration(new SeedClientConfiguration());
            builder.ApplyConfiguration(new SeedServiceConfiguration());
            builder.ApplyConfiguration(new SeedTopicConfiguration());
            builder.ApplyConfiguration(new SeedTicketConfiguration());
            builder.ApplyConfiguration(new SeedMessageConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ClientRole> ClientRoles { get; set; }
        public DbSet<AgentRole> AgentRoles { get; set; }

    }
}
