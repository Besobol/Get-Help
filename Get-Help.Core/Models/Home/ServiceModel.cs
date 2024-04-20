namespace Get_Help.Core.Models.Home
{
    public class ServiceModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string ImgUrl { get; set; }

        public int TopicCount { get; set; }
    }
}
