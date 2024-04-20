using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Get_Help_Infrastructure.Constants.DataConstants;

namespace Get_Help_Infrastructure.Data.Models
{
    [Comment("Application Agent")]
    public class Agent : ApplicationUser
    {
        [Required]
        [MaxLength(AgentNameMaxLength)]
        [Comment("Agent Name")]
        public required string Name { get; set; }

        public List<Ticket> Tickets { get; set; } = new();

        public List<Message> Messages { get; set; } = new();
    }
}
