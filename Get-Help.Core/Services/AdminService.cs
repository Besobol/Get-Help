using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Admin;
using Get_Help.Infrastructure.Data.Common;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly SignInManager<Agent> agentSignInManager;
        private readonly UserManager<Agent> agentUserManager;
        private readonly IRepository repository;

        public AdminService(
            SignInManager<Agent> _agentSignInManager,
            UserManager<Agent> _agentUserManager,
            IRepository _repository)
        {
            agentSignInManager = _agentSignInManager;
            agentUserManager = _agentUserManager;
            repository = _repository;
        }

        public async Task<IdentityResult> RegisterAgent(RegisterAgentModel input)
        {
            var user = CreateUser<Agent>();

            user.Name = input.Name;

            await agentUserManager.SetUserNameAsync(user, input.Email);

            user.Id = int.MaxValue;

            await agentUserManager.SetEmailAsync(user, input.Email);

            user.Id = 0;

            return await agentUserManager.CreateAsync(user, input.Password);
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
