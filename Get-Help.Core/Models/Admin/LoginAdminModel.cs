using System.ComponentModel.DataAnnotations;

namespace Get_Help.Core.Models.Admin
{
    public class LoginAdminModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
