using Get_Help.Core.Contracts;
using Get_Help.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public async Task<IActionResult> Index()
        {
            var model = await service.GetAllServicesAsync();

            return View(model);
        }

        public async Task<IActionResult> Service(int id)
        {
            var model = await service.GetAllTopicsByServiceIdAsync(id);

            return View(model);
        }

        public async Task<IActionResult> Chat(int id)
        {
            var model = await service.GetTicketById(id);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
