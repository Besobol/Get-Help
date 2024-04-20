using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Get_Help.Infrastructure.Constants.DataConstants;

namespace Get_Help.Infrastructure.Data.Models
{
    [Comment("Delete Type")]
    public class DeleteType
    {
        [Key]
        [Comment("Delete Type Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DeleteTypeNameMaxLength)]
        [Comment("Delete Type Name")]
        public required string Name { get; set; }
    }
}
