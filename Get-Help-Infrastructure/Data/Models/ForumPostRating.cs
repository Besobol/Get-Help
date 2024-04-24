using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Get_Help.Infrastructure.Data.Models
{
    [PrimaryKey(nameof(ForumPostReplyId), nameof(ForumUserId))]
    public class ForumPostRating
    {
        public int ForumPostReplyId { get; set; }
        [ForeignKey(nameof(ForumPostReplyId))]
        public required ForumPostReply ForumPostReply { get; set; }

        public int ForumUserId { get; set; }
        [ForeignKey(nameof(ForumUserId))]
        public required ForumUser ForumUser { get; set; }
    }
}
