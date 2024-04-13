using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Get_Help_Infrastructure.Constants.DataConstants;

namespace Get_Help_Infrastructure.Data.Models
{
    [Comment("Application Agent")]
    public class Agent
    {
        [Key]
        [Comment("Agent Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(AgentFirstNameMaxLength)]
        [Comment("Agent First Name")]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(AgentLastNameMaxLength)]
        [Comment("Agent Last Name")]
        public required string LastName { get; set; }

        [Required]
        [Comment("Agent User Id")]
        public required int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public List<Ticket> Tickets { get; set; } = new();

        public List<Message> Messages { get; set; } = new();
    }
}
