using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Agent;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Get_Help.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class ManageController : Controller
    {
        private IAccountService accountService;

        public ManageController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangePassword()
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

            var result = await accountService.ChangePassword(userId, model.CurrentPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            await accountService.Logout();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult DeleteAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(bool confirm)
        {
            if (!confirm)
            {
                return RedirectToAction("Index");
            }

            var userId = GetUserId();

            var result = await accountService.DeleteAccount(userId);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            await accountService.Logout();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public async Task<IActionResult> Logout()
        {
            await accountService.Logout();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
