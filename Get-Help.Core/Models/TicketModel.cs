namespace Get_Help.Core.Models
{
    public class TicketModel
    {
        public required int Id { get; set; }
        public required string Topic { get; set; }
        public required List<MessageModel> Messages { get; set; }
    }
}
