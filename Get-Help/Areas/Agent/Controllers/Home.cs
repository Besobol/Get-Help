using Microsoft.AspNetCore.Mvc;

namespace Get_Help.Areas.Agent.Controllers
{
    [Area("Agent")]
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
