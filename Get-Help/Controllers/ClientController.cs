using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Get_Help.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService service;

        public ClientController(
            IClientService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> Services()
        {
            var model = await service.GetAllServicesAsync();

            return View(model);
        }

        public async Task<IActionResult> Topics(int id)
        {
            var model = await service.GetAllTopicsByServiceIdAsync(id, true, GetUserId());

            return View(model);
        }

        public IActionResult OpenTicket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OpenTicket(int id, [FromForm] OpenTicketFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userId = GetUserId();

            var ticketId = await service.OpenNewTicket(id, userId, model);

            return RedirectToAction("Chat", new { id = ticketId });
        }

        public async Task<IActionResult> Chat(int id)
        {
            var ticket = await service.GetTicketById(GetUserId(), id);

            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> SendTicketMessage([FromForm] TicketMessageFormModel message)
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

            return RedirectToAction("Services");
        }

        public async Task<IActionResult> MyTickets(int page = 1, bool isClosed = false)
        {
            var userId = GetUserId();

            var model = await service.GetTicketsByUserIdPaged(userId, page, isClosed);

            return View(model);
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

    }
}
