using Get_Help.Core.Contracts;
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

        public async Task<IActionResult> Index()
        {
            var model = await service.GetAllServicesAsync();

            return View(model);
        }

        public async Task<IActionResult> Topics(int id)
        {
            List<TopicModel> model;

            var isLoggedIn = service.IsLoggedIn(User);

            if (isLoggedIn == true)
            {
                var userId = GetUserId();
                model = await service.GetAllTopicsByServiceIdAsync(id, true, userId);
            }
            else
            {
                model = await service.GetAllTopicsByServiceIdAsync(id, false);
            }

            return View(model);
        }


        public async Task<IActionResult> OpenTicket(int id)
        {
            var userId = GetUserId();

            await service.OpenNewTicket(id, userId);

            var ticket = await service.GetTicketIdByTopicId(userId, id);

            return RedirectToAction("Chat", new { id = ticket });
        }

        public async Task<IActionResult> Chat(int id)
        {
            var ticket = await service.GetTicketById(id);

            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> SendTicketMessage([FromForm]TicketMessageFormModel message)
        {
            var userId = GetUserId();

            await service.SendMessage(message, userId);

            return RedirectToAction("Chat", new { id = message.TicketId });
        }

        [HttpGet]
        public async Task<IActionResult> CloseTicket(int id)
        {
            var userId = GetUserId();

            await service.CloseTicket(id, userId);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

    }
}
