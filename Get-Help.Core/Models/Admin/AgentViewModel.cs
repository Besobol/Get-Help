namespace Get_Help.Core.Models.Admin
{
    public class AgentViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int OpenTickets { get; set; }
    }
}
