using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Home;
using Get_Help.Infrastructure.Data.Common;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Get_Help.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repository;
        private readonly SignInManager<Client> signInManager;

        public HomeService(
            IRepository _repository,
            SignInManager<Client> _signInManager)
        {
            repository = _repository;
            signInManager = _signInManager;
        }

        public async Task<List<ServiceModel>> GetAllServicesAsync()
        {
            var result = await repository
                .AllReadOnly<Service>()
                .Select(s => new ServiceModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImgUrl = s.ImgUrl,
                    TopicCount = s.Topics.Count
                })
                .ToListAsync();

            return result;
        }

        public async Task<List<TopicModel>> GetAllTopicsByServiceIdAsync(int serviceId, bool signedIn, int userId)
        {
            List<TopicModel> result;
            if (!signedIn)
            {
                result = await repository
                    .AllReadOnly<Topic>()
                    .Where(t => t.ServiceId == serviceId)
                    .Select(t => new TopicModel()
                    {
                        Id= t.Id,
                        Name = t.Name
                    })
                    .ToListAsync();
            }
            else
            {
                result = await repository
                    .AllReadOnly<Topic>()
                    .Where(t => t.ServiceId == serviceId)
                    .Select(t => new TopicModel()
                    {
                        Id = t.Id,
                        Name = t.Name,
                        TicketId = t.Tickets.FirstOrDefault(ti => ti.ClientId == userId && ti.TimeClosed == null).Id
                    })
                    .ToListAsync();
            }

            return result;
        }

        public async Task OpenNewTicket(int topicId, int userId)
        {
            var model = new Ticket()
            {
                ClientId = userId,
                TopicId = topicId,
                TimeOpened = DateTime.Now,
            };

            await repository.AddAsync(model);
            await repository.SaveChangesAsync();
        }

        public async Task<int> GetTicketIdByTopicId(int userId ,int topicId)
        {
            var model = await repository.AllReadOnly<Ticket>()
                .Where(t => 
                    t.TopicId == topicId && 
                    t.ClientId == userId && 
                    t.TimeClosed == null)
                .Select(t => t.Id)
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<TicketModel> GetTicketById(int ticketId)
        {
            var result = await repository
                .AllReadOnly<Ticket>()
                .Where(t => t.Id == ticketId)
                .Select(t => new TicketModel()
                {
                    Id = t.Id,
                    Topic = t.Topic.Name,
                    Messages = t.Messages.Select(m => new MessageModel()
                    {
                        Content = m.Content,
                        SenderName = m.Agent == null ? m.Client.UserName : m.Agent.Name,
                        SentTime = TimeOnly.FromDateTime(m.SentTime),
                        Sender = m.Agent == null ? Enums.MessageSender.client : Enums.MessageSender.agent
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
                ClientId = userId
            };

            await repository.AddAsync(model);
            await repository.SaveChangesAsync();
        }

        public async Task CloseTicket(int ticketId, int userId)
        {
            var ticket = await repository.All<Ticket>()
                .Where(t => t.Id == ticketId && t.ClientId == userId)
                .FirstOrDefaultAsync();

            if (ticket == null)
            {
                return;
            }

            ticket.TimeClosed = DateTime.Now;

            await repository.SaveChangesAsync();
        }
    }
}
