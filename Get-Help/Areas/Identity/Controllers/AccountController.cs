using Get_Help.Attributes.ActionFilterAttributes;
using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Client;
using Get_Help.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Get_Help.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginClientModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginClientModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var result = await accountService.SignInClientAsync(model);

            return RedirectToAction("Services","Client", new { area = "" });
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterClientModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterClientModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var createdResult = await accountService.RegisterClientUser(model);

            if (!createdResult.Succeeded)
            {
                foreach (var error in createdResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return RedirectToAction("Services", "Home", new { area = "" });
        }
    }
}
