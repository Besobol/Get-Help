using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Get_Help.Infrastructure.Constants.DataConstants;

namespace Get_Help.Infrastructure.Data.Models
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
        [Comment("Time of sending the message")]
        public required DateTime SentTime { get; set; }

        [Required]
        [Comment("Ticket Identifier")]
        public int TicketId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; } = null!;

        [Comment("Agent Identifier")]
        public int? AgentId { get; set; }
        [ForeignKey(nameof(AgentId))]
        public Agent? Agent { get; set; }

        [Comment("Client Identifier")]
        public int? ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client? Client { get; set; }

        [Comment("Delete Type Identifier")]
        public int? DeleteTypeId { get; set; }
        [ForeignKey(nameof(DeleteTypeId))]
        public DeleteType? DeleteType { get; set; }
    }
}
