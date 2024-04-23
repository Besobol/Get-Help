using System.ComponentModel.DataAnnotations;

namespace Get_Help.Core.Models.Admin
{
    public class AddServiceModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ImgUrl { get; set; } = string.Empty;
    }
}
