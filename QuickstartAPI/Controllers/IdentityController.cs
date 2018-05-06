using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace QuickstartAPI.Controllers
{
	[Produces("application/json")]
	[Route("api/Identity")]
	[Authorize]
	public class IdentityController : Controller
	{
		[HttpGet]
		public IActionResult Get()
		{
			return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
		}

		[HttpGet]
		[Route("test")]
		public IActionResult Test()
		{
			return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
		}
	}
}