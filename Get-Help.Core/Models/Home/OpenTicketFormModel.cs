using System.ComponentModel.DataAnnotations;
using static Get_Help.Core.Constants.FieldConstants;
using static Get_Help.Infrastructure.Constants.DataConstants;
using static Get_Help.Core.Constants.ErrorMessages;


namespace Get_Help.Core.Models.Home
{
    public class OpenTicketFormModel
    {
        [Display(Name = "Title")]
        [StringLength(TicketTitleMaxLength,
            ErrorMessage = stringLengthErrorMessage,
            MinimumLength = ticketTitleMinLength)]
        public required string Title { get; set; }
    }
}
