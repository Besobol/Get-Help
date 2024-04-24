using Get_Help.Attributes.ActionFilterAttributes;
using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Admin;
using Get_Help.Core.Models.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Get_Help.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAdminService adminService;

        public AccountController(
            IAdminService _adminService)
        {
            adminService = _adminService;
        }

        public IActionResult Login()
        {
            var model = new LoginAdminModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAdminModel input)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var loginResult = await adminService.LoginAdmin(input);

            if (!loginResult.Succeeded)
            {
                return RedirectToAction("Login");
            }

            return RedirectToAction("Index", "Home", new { area = "Admin"});
        }

        public async Task<IActionResult> Logout()
        {
            await adminService.Logout();

            return RedirectToAction("Index", "Home", new { area = ""});
        }
    }
}
