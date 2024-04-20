using Get_Help.Core.Models.Login;
using Get_Help.Core.Models.Register;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Contracts
{
    public interface IAccountService
    {
        Task<SignInResult> SignInClientAsync(LoginInputModel input);
        Task<IdentityResult> RegisterClientUser(RegisterInputModel input);
    }
}
