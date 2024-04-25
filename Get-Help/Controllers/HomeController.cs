using Get_Help.Core.Contracts;
using Get_Help.Core.Models;
using Get_Help.Core.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Get_Help.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService service;

        public HomeController(
            IHomeService _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Services()
        {
            var model = await service.GetAllServicesAsync();

            return View(model);
        }

        public async Task<IActionResult> Topics(int id)
        {
            var model = await service.GetAllTopicsByServiceIdAsync(id, false);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
