using Get_Help.Core.Models;
using Get_Help.Core.Models.Admin;
using Get_Help.Core.Models.Home;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Contracts
{
    public interface IAdminService
    {
        Task<SignInResult> LoginAdmin(LoginAdminModel input);
        Task<IdentityResult> RegisterAgent(RegisterAgentModel input);
        Task<IdentityResult> DeleteAgentById(int id);
        Task<IdentityResult> ChangeAgentPasswordById(int id, string newPass);
        Task<AgentViewModel> GetAgentById(int id);
        Task<EditServiceModel> GetServiceById(int id);
        Task<TopicsListViewModel> GetTopics(int serviceId);
        Task<List<ServiceModel>> GetAllServices();
        Task<List<AgentListViewModel>> GerAgents();
        Task AddNewService(AddServiceModel service);
        Task EditService(EditServiceModel model);
        Task AddTopic(AddTopicModel input);
        Task DeleteServiceById(int Id);
        Task Logout();
    }
}
