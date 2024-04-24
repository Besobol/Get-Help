namespace Get_Help.Core.Models.Home
{
    public class TopicModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public int? TicketId { get; set; }
    }
}
