using System.ComponentModel.DataAnnotations;

namespace Get_Help.Core.Models.Login
{
    public class LoginInputModel
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
