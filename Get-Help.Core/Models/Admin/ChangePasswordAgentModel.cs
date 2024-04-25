using System.ComponentModel.DataAnnotations;
using static Get_Help.Core.Constants.FieldConstants;
using static Get_Help.Core.Constants.ErrorMessages;

namespace Get_Help.Core.Models.Admin
{
    public class ChangePasswordAgentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(
            100,
            ErrorMessage = stringLengthErrorMessage,
            MinimumLength = passwordMinLength)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(
    nameof(Password),
    ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
