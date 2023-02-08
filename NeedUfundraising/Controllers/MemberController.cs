using Microsoft.AspNetCore.Mvc;

namespace NeedUfundraising.Controllers
{
	public class MemberController : Controller
	{
		public IActionResult Member()
		{
			return View();
		}
	}
}
