using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace QuickstartWebClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Sign-out roundtrip to IdentityServer that clear central single sign-on session
        public async Task Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            await HttpContext.Authentication.SignOutAsync("oidc");
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
