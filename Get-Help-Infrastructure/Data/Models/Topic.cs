using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Get_Help_Infrastructure.Constants.DataConstants;

namespace Get_Help_Infrastructure.Data.Models
{
    [Comment("Service Topic")]
    public class Topic
    {
        [Key]
        [Comment("Topic Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TopicNameMaxLength)]
        [Comment("Topic Title")]
        public required string Name { get; set; }

        [Required]
        [Comment("Service Identifier")]
        public int ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; } = null!;

        [Comment("Delete Type Identifier")]
        public int DeleteTypeId { get; set; }
        [ForeignKey(nameof(DeleteTypeId))]
        public DeleteType? DeleteType { get; set; }

        public List<Ticket> Tickets { get; set; } = new();
    }
}
