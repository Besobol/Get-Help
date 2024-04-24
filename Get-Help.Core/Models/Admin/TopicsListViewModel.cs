namespace Get_Help.Core.Models.Admin
{
    public class TopicsListViewModel
    {
        public int Id { get; set; }
        public List<TopicListViewModel> Topics { get; set; } = new();
    }
}
