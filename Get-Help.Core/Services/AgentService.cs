using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Agent;
using Get_Help.Infrastructure.Data.Common;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly SignInManager<Agent> agentSignInManager;
        private readonly UserManager<Agent> agentUserManager;
        private readonly IRepository repository;

        public AgentService(
            SignInManager<Agent> _agentSignInManager,
            UserManager<Agent> _agentUserManager,
            IRepository _repository)
        {
            agentSignInManager = _agentSignInManager;
            agentUserManager = _agentUserManager;
            repository = _repository;
        }

        public async Task<SignInResult> SignInClientAsync(AgentLoginModel input)
        {
            return await agentSignInManager.PasswordSignInAsync(input.Email, input.Password, false, lockoutOnFailure: false);
        }
    }
}
