using Get_Help.Core.Enums;

namespace Get_Help.Core.Models
{
    public class MessageModel
    {
        public required string Content { get; set; }
        public required string SenderName { get; set; }
        public required TimeOnly SentTime { get; set; }
        public required MessageSender Sender { get; set; }
    }
}
