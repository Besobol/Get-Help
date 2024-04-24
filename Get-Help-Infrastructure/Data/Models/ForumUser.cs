using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Get_Help.Infrastructure.Data.Models
{
    [Comment("Forum User extension")]
    public class ForumUser
    {
        [Key]
        [Comment("Forum User identifier")]
        public int Id { get; set; }
        
        [Required]
        [Comment("Client user Id owner of forum user")]
        public required int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public required Client ClientUser { get; set; }

        public List<ForumPost> Posts { get; set; } = new();

        public List<ForumTopic> Topics { get; set; } = new();

        public List<ForumPostRating> Ratings { get; set; } = new();
    }
}
