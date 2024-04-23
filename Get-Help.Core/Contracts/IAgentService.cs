using Get_Help.Core.Models.Agent;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Contracts
{
    public interface IAgentService
    {
        Task<SignInResult> SignInClientAsync(LoginAgentModel input);
        Task Logout();
    }
}
