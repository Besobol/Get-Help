using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Home;
using Get_Help.Infrastructure.Data.Common;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Get_Help.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repository;

        public HomeService(IRepository _repository)
        {
            repository = _repository;
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

        public async Task<List<TopicModel>> GetAllTopicsByServiceIdAsync(int serviceId)
        {
            var result = await repository
                .AllReadOnly<Topic>()
                .Where(t => t.ServiceId == serviceId)
                .Select(t => new TopicModel()
                {
                    Id= t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            return result;
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
    }
}
