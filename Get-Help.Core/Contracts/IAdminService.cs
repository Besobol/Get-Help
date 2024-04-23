using Get_Help.Core.Models.Admin;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Contracts
{
    public interface IAdminService
    {
        Task<SignInResult> LoginAdmin(LoginAdminModel input);
        Task<IdentityResult> RegisterAgent(RegisterAgentModel input); 
    }
}
