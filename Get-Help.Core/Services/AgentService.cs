using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Agent;
using Get_Help.Infrastructure.Data.Common;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly SignInManager<Agent> signInManager;
        private readonly UserManager<Agent> userManager;
        private readonly IRepository repository;

        public AgentService(
            SignInManager<Agent> _signInManager,
            UserManager<Agent> _userManager,
            IRepository _repository)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            repository = _repository;
        }

        public async Task<SignInResult> SignInClientAsync(LoginAgentModel input)
        {
            return await signInManager.PasswordSignInAsync(input.Email, input.Password, false, lockoutOnFailure: false);
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
