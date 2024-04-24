using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                return View(model);
            }

            var loginResult = await agentService.SignInClientAsync(model);

            if (!loginResult.Succeeded)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return RedirectToAction("Index", "Home", new { area = "Agent" });
        }

        public async Task<IActionResult> ChangePassword()
        {
            var model = new ChangePasswordModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = GetUserId();

            var result = await agentService.ChangePassword(userId, model.CurrentPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return RedirectToAction("Index", "Home", new { area = "Agent" });
        }

        public async Task<IActionResult> Logout()
        {
            await agentService.Logout();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
