using Get_Help.Core.Models.Admin;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Contracts
{
    public interface IAdminService
    {
        Task<IdentityResult> RegisterAgent(RegisterAgentModel input); 
    }
}
