using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Get_Help_Infrastructure.Data.Models
{
    [Comment("Application Client")]
    public class Client
    {
        [Key]
        [Comment("Client Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Client User Identifier")]
        public required int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public List<Ticket> Tickets { get; set; } = new();
    }
}
