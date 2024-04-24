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
        Task<AgentViewModel> GetAgentById(int id);
        Task<IdentityResult> DeleteAgentById(int id);
        Task<IdentityResult> ChangeAgentPasswordById(int id, string newPass);
        Task<List<ServiceModel>> GetAllServices();
        Task AddNewService(AddServiceModel service);
        Task<EditServiceModel> GetServiceById(int id);
        Task EditService(EditServiceModel model);
        Task<TopicsListViewModel> GetTopics(int serviceId);
        Task AddTopic(AddTopicModel input);
        Task DeleteServiceById(int Id);
        Task Logout();
        Task<List<AgentListViewModel>> GerAgents();
    }
}
