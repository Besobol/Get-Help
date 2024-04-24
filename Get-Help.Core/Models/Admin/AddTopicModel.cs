using System.ComponentModel.DataAnnotations;

namespace Get_Help.Core.Models.Admin
{
    public class AddTopicModel
    {
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
