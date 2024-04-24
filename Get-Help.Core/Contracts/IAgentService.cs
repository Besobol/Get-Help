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
        Task<List<AgentTopicModel>> GetUnclaimedTopics(int serviceId);
    }
}
