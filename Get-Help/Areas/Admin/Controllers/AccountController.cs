using Get_Help.Attributes.ActionFilterAttributes;
using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Admin;
using Get_Help.Core.Models.Agent;
using Get_Help.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Get_Help.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAdmin]
    public class AccountController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IAgentService agentService;

        public AccountController(
            IAdminService _adminService,
            IAgentService _agentService)
        {
            adminService = _adminService;
            agentService = _agentService;
        }

        public async Task<IActionResult> LoginAgent()
        {
            AgentLoginModel model = new();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAgent(AgentLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var createdResult = await agentService.SignInClientAsync(model);

            if (!createdResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Service", "Home", new {area = ""});
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Agents()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddTopic()
        {
            return RedirectToAction("Index");
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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

    }
}
