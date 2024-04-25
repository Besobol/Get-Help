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

        public async Task<IdentityResult> ChangePassword(int userId, string currPass, string newPass)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                return await userManager.ChangePasswordAsync(user, currPass, newPass);
            }

            return IdentityResult.Failed(new IdentityError() { Code = "", Description = $"Failed to find user with Id '{userId}'" });
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

        public async Task<List<AgentTopicModel>> GetUnclaimedTopics(int serviceId, int agentId)
        {
            var model = await repository.AllReadOnly<Topic>()
                .Where(t =>
                    t.ServiceId == serviceId &&
                    t.Tickets.Where(ti => ti.TimeClosed != null).Count() > 0 &&
                    t.Tickets.Any(ti => ti.AgentId != null) == false)
                .Select(t => new AgentTopicModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    UnclaimedTickets = t.Tickets.Where(ti => ti.TimeClosed != null).Count()
                })
                .ToListAsync();

            return model;
        }

        public async Task<int> ClaimByTopicId(int topicId, int userId)
        {
            var model = await repository.All<Ticket>()
                .Where(t =>
                    t.TimeClosed == null &&
                    t.AgentId == null)
                .FirstOrDefaultAsync();

            if (model != null)
            {
                model.AgentId = userId;
                await repository.SaveChangesAsync();
                return model.Id;
            }

            return 0;
        }

        public async Task<TicketModel?> GetTicketById(int ticketId)
        {
            var result = await repository
                .AllReadOnly<Ticket>()
                .Where(t => t.Id == ticketId)
                .Select(t => new TicketModel()
                {
                    Id = t.Id,
                    Topic = t.Topic.Name,
                    Title = t.Title,
                    Messages = t.Messages.Select(m => new MessageModel()
                    {
                        Content = m.Content,
                        SentTime = m.SentTime,
                        AgentName = m.Agent != null ? m.Agent.Name : null,
                        ClientName = m.Client != null ? m.Client.UserName : null

                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task SendMessage(TicketMessageFormModel message, int userId)
        {
            var model = new Message()
            {
                Content = message.MessageContent,
                SentTime = DateTime.Now,
                TicketId = message.TicketId,
                AgentId = userId
            };

            await repository.AddAsync(model);
            await repository.SaveChangesAsync();


        }

        public async Task<List<OpenTicketViewModel>> GetOpenTickets(int userId)
        {
            var model = await repository.AllReadOnly<Ticket>()
                .Where(t => t.AgentId == userId)
                .Select(t => new OpenTicketViewModel()
                {
                    TicketId = t.Id,
                    TopicName = t.Topic.Name,
                    ClientUserName = t.Client.UserName,
                    LastMessageTime = t.Messages.OrderByDescending(m => m.Id).FirstOrDefault().SentTime,
                })
                .ToListAsync();

            foreach (var t in model)
            {
                t.TimeSinceLastMessage = DateTime.Now.Subtract(t.LastMessageTime);
            };

            return model;
        }

    }
}
