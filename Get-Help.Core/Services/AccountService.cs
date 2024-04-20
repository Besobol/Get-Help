using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Login;
using Get_Help.Core.Models.Register;
using Get_Help.Infrastructure.Data.Common;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<Agent> agentSignInManager;
        private readonly SignInManager<Client> clientSignInManager;
        private readonly UserManager<Agent> agentUserManager;
        private readonly UserManager<Client> clientUserManager;
        private readonly IRepository repository;

        public AccountService(
            SignInManager<Agent> _agentSignInManager,
            SignInManager<Client> _clientSignInManager,
            UserManager<Agent> _agentUserManager,
            UserManager<Client> _clientUserManager,
            IRepository _repository)
        {
            agentSignInManager = _agentSignInManager;
            clientSignInManager = _clientSignInManager;
            agentUserManager = _agentUserManager;
            clientUserManager = _clientUserManager;
            repository = _repository;
        }

        public async Task<SignInResult> SignInClientAsync(LoginInputModel input)
        {
            return await clientSignInManager.PasswordSignInAsync(input.Username, input.Password, input.RememberMe, lockoutOnFailure: false);
        }

        public async Task<IdentityResult> RegisterClientUser(RegisterInputModel input)
        {
            var user = CreateUser<Client>();

            await clientUserManager.SetUserNameAsync(user, input.Username);
            await clientUserManager.SetEmailAsync(user, input.Email);
            return await clientUserManager.CreateAsync(user, input.Password);
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
