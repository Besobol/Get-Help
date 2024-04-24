using Get_Help.Core.Models.Home;
using System.Security.Claims;

namespace Get_Help.Core.Contracts
{
    public interface IHomeService
    {
        Task<List<ServiceModel>> GetAllServicesAsync();
        Task<List<TopicModel>> GetAllTopicsByServiceIdAsync(int serviceId, bool signedIn, int userId = 0);
        Task OpenNewTicket(int topicId, int userId);
        Task<int> GetTicketIdByTopicId(int userId, int topicId);
        Task<TicketModel> GetTicketById(int ticketId);
        Task SendMessage(TicketMessageFormModel message, int userId);
        Task CloseTicket(int ticketId, int userId);
        bool IsLoggedIn(ClaimsPrincipal user);
    }
}
