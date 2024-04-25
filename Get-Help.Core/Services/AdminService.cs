using Get_Help.Core.Contracts;
using Get_Help.Core.Models;
using Get_Help.Core.Models.Admin;
using Get_Help.Core.Models.Home;
using Get_Help.Infrastructure.Data.Common;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Get_Help.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly SignInManager<Agent> agentSignInManager;
        private readonly UserManager<Agent> agentUserManager;
        private readonly IRepository repository;
        private readonly SignInManager<ApplicationUser> userManager;

        public AdminService(
            SignInManager<Agent> _agentSignInManager,
            UserManager<Agent> _agentUserManager,
            IRepository _repository,
            SignInManager<ApplicationUser> _signInManager)
        {
            agentSignInManager = _agentSignInManager;
            agentUserManager = _agentUserManager;
            repository = _repository;
            userManager = _signInManager;
        }

        public async Task<SignInResult> LoginAdmin(LoginAdminModel input)
        {
            return await userManager.PasswordSignInAsync(input.Email, input.Password, false, lockoutOnFailure: false);
        }

        public async Task<IdentityResult> RegisterAgent(RegisterAgentModel input)
        {
            var user = CreateUser<Agent>();

            user.Name = input.Name;

            await agentUserManager.SetUserNameAsync(user, input.Email);

            user.Id = int.MaxValue;

            await agentUserManager.SetEmailAsync(user, input.Email);

            user.Id = 0;

            var result = await agentUserManager.CreateAsync(user, input.Password);
            await agentUserManager.AddToRoleAsync(user, "Agent");

            return result;
        }

        public async Task<IdentityResult> DeleteAgentById(int id)
        {
            var user = await agentUserManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError() { Code = "", Description = $"Unable to load user with ID '{id}'" });
            }

            return await agentUserManager.DeleteAsync(user);
        }
        
        public async Task<IdentityResult> ChangeAgentPasswordById(int id, string newPass)
        {
            Agent agent = await agentUserManager.FindByIdAsync(id.ToString());

            if (agent == null)
            {
                return IdentityResult.Failed(
                    new IdentityError()
                    {
                        Description = $"Failed to find Agent with Id = {id}"
                    });
            }

            var hasher = new PasswordHasher<Agent>();

            agent.PasswordHash = hasher.HashPassword(agent, newPass);
            
            return await agentUserManager.UpdateSecurityStampAsync(agent);
        }
        
        public async Task<AgentViewModel> GetAgentById(int id)
        {
            var result = await repository.AllReadOnly<Agent>()
                .Where(a => a.Id == id)
                .Select(a => new AgentViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Email = a.Email,
                    OpenTickets = a.Tickets.Where(t => t.TimeClosed != null).Count()
                })
                .FirstOrDefaultAsync();

            return result;
        }
        
        public async Task<EditServiceModel> GetServiceById(int id)
        {
            var model = await repository.AllReadOnly<Service>()
                .Where(s => s.Id == id)
                .Select(s => new EditServiceModel()
                {
                    Name = s.Name,
                    ImgUrl = s.ImgUrl,
                })
                .FirstOrDefaultAsync();

            return model;
        }
        
        public async Task<TopicsListViewModel> GetTopics(int serviceId)
        {
            var model = new TopicsListViewModel();
            model.Id = serviceId;

            model.Topics = await repository.AllReadOnly<Topic>()
                .Where(t => t.ServiceId == serviceId)
                .Select(t => new TopicListViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            return model;
        }

        public async Task<List<AgentListViewModel>> GerAgents()
        {
            var result = await repository.AllReadOnly<Agent>()
                .Where(a => a.Id != 1)
                .Select(a => new AgentListViewModel()
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync();

            return result;
        }

        public async Task<List<ServiceModel>> GetAllServices()
        {
            var model = await repository.AllReadOnly<Service>()
                .Select(s => new ServiceModel()
                {
                    Id=s.Id,
                    Name = s.Name,
                    ImgUrl = s.ImgUrl,
                    TopicCount = s.Topics.Count
                })
                .ToListAsync();

            return model;
        }

        public async Task AddNewService(AddServiceModel model)
        {
            var service = new Service()
            {
                Name = model.Name,
                ImgUrl = model.ImgUrl,
            };

            await repository.AddAsync(service);
            await repository.SaveChangesAsync();
        }

        public async Task EditService(EditServiceModel model)
        {
            var service = await repository.All<Service>()
                .Where(s => s.Id == model.Id)
                .FirstOrDefaultAsync();

            service.Name = model.Name;
            service.ImgUrl = model.ImgUrl;

            await repository.SaveChangesAsync();
        }

        public async Task AddTopic(AddTopicModel input)
        {
            var model = new Topic() 
            { 
                ServiceId = input.ServiceId,
                Name = input.Name
            };

            await repository.AddAsync(model);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteServiceById(int Id)
        {
            await repository.DeleteAsync<Service>(Id);
            await repository.SaveChangesAsync();
        }

        public async Task Logout()
        {
            await userManager.SignOutAsync();
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
