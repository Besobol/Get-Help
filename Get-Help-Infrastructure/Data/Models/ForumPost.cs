using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Get_Help.Infrastructure.Constants.DataConstants;

namespace Get_Help.Infrastructure.Data.Models
{
    [Comment("Forum Post")]
    public class ForumPost
    {
        [Key]
        [Comment("Forum Post identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ForumPostContentLength)]
        [Column(TypeName = "text")]
        public required string PostContent { get; set; }

        [Comment("Forum post creator")]
        public int? ForumUserId { get; set; }
        [ForeignKey(nameof(ForumUserId))]
        public ForumUser? Poster { get; set; } = null!;

        [Required]
        [Comment("Post rating")]
        public int Rating { get; set; }

        [Comment("Post is a reply to post with Id")]
        public int? ReplyToPostId { get; set; }
        public ForumPost? PostReply { get; set; }

        public List<ForumPostReply> Replies { get; set; } = new();
    }
}
