namespace Get_Help.Core.Models.Agent
{
    public class AgentTopicModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UnclaimedTickets { get; set; }
    }
}
