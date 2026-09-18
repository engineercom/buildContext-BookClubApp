using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
