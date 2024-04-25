using Get_Help.Core.Helper;
using Get_Help.Core.Models;
using Get_Help.Core.Models.Home;
using Get_Help.Infrastructure.Data.Models;
using System.Security.Claims;

namespace Get_Help.Core.Contracts
{
    public interface IHomeService
    {
        Task<List<ServiceModel>> GetAllServicesAsync();
        Task<List<TopicModel>> GetAllTopicsByServiceIdAsync(int serviceId, bool signedIn, int userId = 0);
    }
}
