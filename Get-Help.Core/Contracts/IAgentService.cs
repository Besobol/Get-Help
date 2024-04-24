using Get_Help.Core.Models.Agent;
using Get_Help.Core.Models.Home;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Contracts
{
    public interface IAgentService
    {
        Task<SignInResult> SignInClientAsync(LoginAgentModel input);
        Task Logout();
        Task<List<ServiceModel>> GetServices();
        Task<List<AgentTopicModel>> GetUnclaimedTopics(int serviceId, int agentId);
        Task<int> ClaimByTopicId(int topicId, int userId);
        Task SendMessage(TicketMessageFormModel message, int userId);
        Task<TicketModel> GetTicketById(int ticketId);
        Task<List<OpenTicketViewModel>> GetOpenTickets(int userId);
        Task<IdentityResult> ChangePassword(int userId, string currPass, string newPass);
    }
}
