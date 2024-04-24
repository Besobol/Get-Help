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
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new TopicConfiguration());
            builder.ApplyConfiguration(new ForumPostConfiguration());
            builder.ApplyConfiguration(new ForumTopicConfiguration());
            builder.ApplyConfiguration(new ForumUserConfiguration());
            builder.ApplyConfiguration(new ForumPostReplyConfiguration());
            builder.ApplyConfiguration(new ForumPostRatingConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<DeleteType> DeleteTypes { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ForumUser> ForumUsers { get; set; }
        public DbSet<ForumTopic> ForumTopics { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<ForumPostReply> ForumPostReplies { get; set; }
        public DbSet<ForumPostRating> ForumPostRatings { get; set; }

    }
}
