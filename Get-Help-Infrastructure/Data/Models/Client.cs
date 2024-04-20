using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Get_Help_Infrastructure.Data.Models
{
    [Comment("Application Client")]
    public class Client : ApplicationUser
    {
        public List<Ticket> Tickets { get; set; } = new();

        public List<Message> Messages { get; set; } = new();
    }
}
