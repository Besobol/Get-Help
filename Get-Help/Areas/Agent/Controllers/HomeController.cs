using Get_Help.Attributes.ActionFilterAttributes;
using Get_Help.Core.Contracts;
using Get_Help.Core.Models.Home;
using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Get_Help.Areas.Agent.Controllers
{
    [Area("Agent")]
    [AllowAgents]
    public class HomeController : Controller
    {
        private readonly IAgentService agentService;

        public HomeController(
            IAgentService _agentService)
        {
            agentService = _agentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Services()
        {
            var model = await agentService.GetServices();

            return View(model);
        }

        public async Task<IActionResult> Topics(int id)
        {
            var userId = GetUserId();

            var model = await agentService.GetUnclaimedTopics(id, userId);

            return View(model);
        }

        public async Task<IActionResult> ClaimTicketByTopicId(int id)
        {
            var userId = GetUserId();

            var ticketId = await agentService.ClaimByTopicId(id, userId);

            return RedirectToAction("Chat", new { id = ticketId });
        }

        public async Task<IActionResult> Chat(int id)
        {
            var ticket = await agentService.GetTicketById(id);

            return View(ticket);
        }

        public async Task<IActionResult> OpenTickets()
        {
            var userId = GetUserId();

            var tickets = await agentService.GetOpenTickets(userId);

            return View(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> SendTicketMessage([FromForm] TicketMessageFormModel message)
        {
            var userId = GetUserId();

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Chat", new { id = message.TicketId });
            }

            await agentService.SendMessage(message, userId);

            return RedirectToAction("Chat", new { id = message.TicketId });
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
