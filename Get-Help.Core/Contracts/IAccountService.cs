using Get_Help.Core.Models.Client;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Contracts
{
    public interface IAccountService
    {
        Task<SignInResult> SignInClientAsync(LoginClientModel input);
        Task<IdentityResult> RegisterClientUser(RegisterClientModel input);
    }
}
