using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Agent;
using Get_Help.Core.Models.Client;
using Get_Help.Infrastructure.Data.Common;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Get_Help.Core.Services
{
    public class AccountService : IAccountService
    {

        private readonly SignInManager<Client> clientSignInManager;
        private readonly UserManager<Client> clientUserManager;
        private readonly IRepository repository;

        public AccountService(
            SignInManager<Client> _clientSignInManager,
            UserManager<Client> _clientUserManager,
            IRepository _repository)
        {
            clientSignInManager = _clientSignInManager;
            clientUserManager = _clientUserManager;
            repository = _repository;
        }

        public async Task<SignInResult> SignInClientAsync(LoginClientModel input)
        {
            return await clientSignInManager.PasswordSignInAsync(input.Username, input.Password, input.RememberMe, lockoutOnFailure: false);
        }

        public async Task<IdentityResult> RegisterClientUser(RegisterClientModel input)
        {
            var user = CreateUser<Client>();

            await clientUserManager.SetUserNameAsync(user, input.Username);

            user.Id = int.MaxValue;

            await clientUserManager.SetEmailAsync(user, input.Email);
            
            user.Id = 0;

            var result = await clientUserManager.CreateAsync(user, input.Password);
            
            await clientUserManager.AddToRoleAsync(user, "Client");

            return result;
        }

        public async Task<IdentityResult> ChangePassword(int userId, string currPass, string newPass)
        {
            var user = await clientUserManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                return await clientUserManager.ChangePasswordAsync(user, currPass, newPass);
            }

            return IdentityResult.Failed(new IdentityError() { Code = "", Description = $"Failed to find user with Id '{userId}'"});
        }

        public async Task Logout()
        {
            await clientSignInManager.SignOutAsync();
        }

        public async Task<IdentityResult> DeleteAccount(int userId)
        {
            var user = await clientUserManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError() { Code = "", Description = $"Unable to load user with ID '{userId}'" });
            }

            return await clientUserManager.DeleteAsync(user);
        }

        private T CreateUser<T>() where T : ApplicationUser
        {
            try
            {
                return Activator.CreateInstance<T>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(T)}'.");
            }
        }
    }
}
