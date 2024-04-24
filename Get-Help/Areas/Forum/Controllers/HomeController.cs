using Microsoft.AspNetCore.Mvc;

namespace Get_Help.Areas.Forum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
