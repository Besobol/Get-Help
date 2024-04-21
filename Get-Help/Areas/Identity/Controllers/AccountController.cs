using Get_Help.Attributes.ActionFilterAttributes;
using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Login;
using Get_Help.Core.Models.Register;
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
        [AnonymousOnly]
        public IActionResult Login()
        {
            var model = new LoginInputModel();

            return View(model);
        }

        [HttpPost]
        [AnonymousOnly]
        public async Task<IActionResult> Login(LoginInputModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var result = await accountService.SignInClientAsync(model);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        [AnonymousOnly]
        public IActionResult Register()
        {
            var model = new RegisterInputModel();

            return View(model);
        }

        [HttpPost]
        [AnonymousOnly]
        public async Task<IActionResult> Register(RegisterInputModel model)
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

            return RedirectToAction("Index", "Home");
        }
    }
}
