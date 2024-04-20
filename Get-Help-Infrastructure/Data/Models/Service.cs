using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Get_Help.Infrastructure.Constants.DataConstants;

namespace Get_Help.Infrastructure.Data.Models
{
    [Comment("Service")]
    public class Service
    {
        [Key]
        [Comment("Service Identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(ServiceNameMaxLength)]
        [Comment("Service Name")]
        public required string Name { get; set; }

        [Required]
        [Comment("Service title Image Url")]
        public required string ImgUrl { get; set; }

        [Comment("Delete Type Identifier")]
        public int? DeleteTypeId { get; set; }
        [ForeignKey(nameof(DeleteTypeId))]
        public DeleteType? DeleteType { get; set; }

        public List<Topic> Topics { get; set; } = new();
    }
}
