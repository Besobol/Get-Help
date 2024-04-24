using Get_Help.Core.Models.Client;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Contracts
{
    public interface IAccountService
    {
        Task<SignInResult> SignInClientAsync(LoginClientModel input);
        Task<IdentityResult> RegisterClientUser(RegisterClientModel input);
        Task<IdentityResult> ChangePassword(int userId, string currPass, string newPass);
        Task<IdentityResult> DeleteAccount(int userId);
        Task Logout();
    }
}
