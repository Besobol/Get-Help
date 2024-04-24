using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Agent;
using Get_Help.Core.Models.Home;
using Get_Help.Infrastructure.Data.Common;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<ServiceModel>> GetServices()
        {
            var model = await repository.AllReadOnly<Service>()
                .Select(s => new ServiceModel()
                {
                    Id = s.Id,
                    ImgUrl = s.ImgUrl,
                    Name = s.Name,
                    TopicCount = s.Topics.Count
                })
                .ToListAsync();

            return model;
        }

        public async Task<List<AgentTopicModel>> GetUnclaimedTopics(int serviceId)
        {
            var model = await repository.AllReadOnly<Topic>()
                .Where(t => t.ServiceId == serviceId && t.Tickets.Where(ti => ti.TimeClosed != null).Count() > 0)
                .Select(t => new AgentTopicModel()
                {
                    Id=t.Id,
                    Name=t.Name,
                    UnclaimedTickets = t.Tickets.Where(ti => ti.TimeClosed != null).Count()
                })
                .ToListAsync();

            return model;
        }
    }
}
