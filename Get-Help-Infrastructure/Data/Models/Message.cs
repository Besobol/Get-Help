using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Get_Help_Infrastructure.Constants.DataConstants;

namespace Get_Help_Infrastructure.Data.Models
{
    [Comment("Ticket Message")]
    public class Message
    {
        [Key]
        [Comment("Message Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MessageContentMaxLength)]
        [Comment("Message Content")]
        public required string Content { get; set; }

        [Required]
        [Comment("Ticket Identifier")]
        public int TicketId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; } = null!;

        [Required]
        [Comment("Identifier for User sending the Message")]
        public int UserId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public ApplicationUser User { get; set; } = null!;
    }
}
