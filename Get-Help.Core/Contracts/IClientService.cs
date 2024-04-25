using Get_Help.Core.Helper;
using Get_Help.Core.Models.Home;
using System.Security.Claims;

namespace Get_Help.Core.Contracts
{
    public interface IClientService
    {
        Task<List<ServiceModel>> GetAllServicesAsync();
        Task<List<TopicModel>> GetAllTopicsByServiceIdAsync(int serviceId, bool signedIn, int userId = 0);
        Task<int> OpenNewTicket(int topicId, int userId, OpenTicketFormModel input);
        Task<int> GetTicketIdByTopicId(int userId, int topicId);
        Task<TicketModel?> GetTicketById(int userId, int ticketId);
        Task SendMessage(TicketMessageFormModel message, int userId);
        Task CloseTicket(int ticketId, int userId);
        Task<PagedList<TicketViewModel>> GetTicketsByUserIdPaged(int userId, int page, bool isClosed);
        bool IsLoggedIn(ClaimsPrincipal user);
        
    }
}
