using Get_Help.Attributes.ActionFilterAttributes;
using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Admin;
using Get_Help.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Get_Help.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAdmin]
    public class HomeController : Controller
    {
        private readonly IAdminService adminService;

        public HomeController(
            IAdminService _adminService)
        {
            adminService = _adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Agents()
        {
            var model = await adminService.GerAgents();

            return View(model);
        }

        public async Task<IActionResult> Agent(int id)
        {
            var model = await adminService.GetAgentById(id);

            if (model == null)
            {
                ModelState.AddModelError(string.Empty, "Agent failed to load!");
                RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Services()
        {
            var model = await adminService.GetAllServices();

            return View(model);
        }

        public IActionResult AddService()
        {
            var service = new AddServiceModel();

            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> AddService([FromForm] AddServiceModel service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            await adminService.AddNewService(service);

            return RedirectToAction("Services");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteService(int id)
        {
            await adminService.DeleteServiceById(id);

            return RedirectToAction("Services");
        }

        public async Task<IActionResult> EditService(int id)
        {
            var service = await adminService.GetServiceById(id);

            if (service != null)
            {
                RedirectToAction("Services");
            }

            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> EditService(EditServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await adminService.EditService(model);

            return RedirectToAction("Services");
        }

        public async Task<IActionResult> Topics(int id)
        {
            var model = await adminService.GetTopics(id);

            return View(model);
        }

        [HttpGet]
        public IActionResult AddTopic(int id)
        {
            var model = new AddTopicModel()
            {
                ServiceId = id,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTopic([FromForm]AddTopicModel model)
        {
            await adminService.AddTopic(model);

            return RedirectToAction("Topics", new { id = model.ServiceId });
        }

        [HttpGet]
        public IActionResult RegisterAgent()
        {
            var model = new RegisterAgentModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAgent(RegisterAgentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var createdResult = await adminService.RegisterAgent(model);

            if (!createdResult.Succeeded)
            {
                foreach (var error in createdResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAgentById(int id)
        {
            var result = await adminService.DeleteAgentById(id);



            return RedirectToAction("Agents");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeAgentPassword(int id)
        {
            var agent = await adminService.GetAgentById(id);

            var model = new ChangePasswordAgentModel()
            {
                Id = id,
                Name = agent.Name,
                Email = agent.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeAgentPassword([FromForm]AgentNewPasswordForm form)
        {
            var result = await adminService.ChangeAgentPasswordById(form.Id, form.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return RedirectToAction("Agents");
        }
    }
}
