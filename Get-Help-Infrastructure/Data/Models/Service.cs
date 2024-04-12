using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Get_Help_Infrastructure.Constants.DataConstants;

namespace Get_Help_Infrastructure.Data.Models
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

        public List<Topic> Topics { get; set; } = new();
    }
}
