using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Get_Help.Areas.Agent.Controllers
{
    [Area("Agent")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAgentService agentService;

        public AccountController(
            IAgentService _agentService)
        {
            agentService = _agentService;
        }

        public IActionResult Login()
        {
            LoginAgentModel model = new();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAgentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var loginResult = await agentService.SignInClientAsync(model);

            if (!loginResult.Succeeded)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return RedirectToAction("Index", "Home", new { area = "Agent" });
        }

        public async Task<IActionResult> Logout()
        {
            await agentService.Logout();

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
