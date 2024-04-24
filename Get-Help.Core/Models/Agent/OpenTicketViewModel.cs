namespace Get_Help.Core.Models.Agent
{
    public class OpenTicketViewModel
    {
        public int TicketId { get; set; }
        public string TopicName { get; set; } = string.Empty;
        public string ClientUserName { get; set; } = string.Empty;
        public DateTime LastMessageTime { get; set; }
        public TimeSpan TimeSinceLastMessage { get; set; }
    }
}
