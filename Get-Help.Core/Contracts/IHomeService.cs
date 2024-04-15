using Get_Help.Core.Models;

namespace Get_Help.Core.Contracts
{
    public interface IHomeService
    {
        Task<List<ServiceModel>> GetAllServicesAsync();
        Task<List<TopicModel>> GetAllTopicsByServiceIdAsync(int serviceId);
    }
}
