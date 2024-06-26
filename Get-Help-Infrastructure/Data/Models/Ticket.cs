﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Get_Help.Infrastructure.Constants.DataConstants;

namespace Get_Help.Infrastructure.Data.Models
{
    [Comment("Ticket")]
    public class Ticket
    {
        [Key]
        [Comment("Ticket Identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(TicketTitleMaxLength)]
        public required string Title { get; set; }

        [Comment("Agent Identifier")]
        public int? AgentId { get; set; }
        [ForeignKey(nameof(AgentId))]
        public Agent? Agent { get; set; }

        [Required]
        [Comment("Client Identifier")]
        public required int? ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client? Client { get; set; } = null!;

        [Required]
        [Comment("Time of opening the Ticket")]
        public required DateTime TimeOpened { get; set; }

        [Comment("Time of closing the Ticket")]
        public DateTime? TimeClosed { get; set; }

        [Required]
        [Comment("Topic Identifier")]
        public required int TopicId { get; set; }
        public Topic Topic { get; set; } = null!;

        public List<Message> Messages { get; set; } = new();
    }
}
