using Get_Help.Core.Contracts;
using Get_Help.Core.Helper;
using Get_Help.Core.Models.Home;
using Get_Help.Infrastructure.Data.Common;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Get_Help.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repository;

        public HomeService(
            IRepository _repository)
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
    }
}
