using Get_Help.Core.Contracts;
using Get_Help_Infrastructure.Data.Common;

namespace Get_Help.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repository;

        public HomeService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task GetAllServices()
        {
            throw new NotImplementedException();
        }
    }
}
