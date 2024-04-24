using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Get_Help.Infrastructure.Constants.DataConstants;

namespace Get_Help.Infrastructure.Data.Models
{
    [Comment("Forum Topic")]
    public class ForumTopic
    {
        [Key]
        [Comment("Forum Topic identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ForumTopicTitleLength)]
        [Comment("Forum Topic Title")]
        public required string Title { get; set; }

        [Comment("Forum User Id that created the topic")]
        public int? TopicCreatorId { get; set; }
        [ForeignKey(nameof(TopicCreatorId))]
        public ForumUser? TopicCreator { get; set; }

        public List<ForumPost> Posts { get; set; } = new();
    }
}
