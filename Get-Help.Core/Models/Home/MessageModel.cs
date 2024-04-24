using Get_Help.Core.Enums;

namespace Get_Help.Core.Models.Home
{
    public class MessageModel
    {
        public required string Content { get; set; }
        public string? AgentName { get; set; }
        public string? ClientName { get; set; }
        public required DateTime SentTime { get; set; }
    }
}
