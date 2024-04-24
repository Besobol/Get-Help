using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Get_Help.Infrastructure.Constants.DataConstants;

namespace Get_Help.Infrastructure.Data.Models
{
    public class ForumPostReply
    {
        [Key]
        [Comment("Forum Post Reply identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ForumPostContentLength)]
        [Column(TypeName = "text")]
        public required string Content { get; set; }

        [Required]
        [Comment("Reply to post with Id")]
        public required int ForumPostId { get; set; }
        public required ForumPost ForumPost { get; set; }

        public List<ForumPostRating> Rating { get; set; } = new();
    }
}
