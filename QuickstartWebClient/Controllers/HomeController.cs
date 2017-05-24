using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace QuickstartWebClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult AuthorizedTest()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
