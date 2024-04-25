using System.ComponentModel.DataAnnotations;
using static Get_Help.Core.Constants.FieldConstants;
using static Get_Help.Core.Constants.ErrorMessages;

namespace Get_Help.Core.Models.Agent
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [StringLength(
            100,
            ErrorMessage = stringLengthErrorMessage,
            MinimumLength = passwordMinLength)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(
            100,
            ErrorMessage = stringLengthErrorMessage,
            MinimumLength = passwordMinLength)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(
            nameof(NewPassword),
            ErrorMessage = stringLengthErrorMessage)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
