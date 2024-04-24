namespace Get_Help.Core.Models.Home
{
    public class TicketMessageFormModel
    {
        public int TicketId { get; set; }
        public string MessageContent { get; set; } = string.Empty;
        public DateTime SentTime { get; set; }
    }
}
