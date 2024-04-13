using Get_Help.Core.Contracts;
using Get_Help.Core.Models;
using Get_Help_Infrastructure.Data.Common;
using Get_Help_Infrastructure.Data.Models;
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

        public async Task<List<ServiceModel>> GetAllServices()
        {
            var result = await repository
                .AllReadOnly<Service>()
                .Select(s => new ServiceModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImgUrl = s.ImgUrl
                })
                .ToListAsync();

            return result;
        }
    }
}
