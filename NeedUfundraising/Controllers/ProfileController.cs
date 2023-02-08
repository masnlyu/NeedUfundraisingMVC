using Microsoft.AspNetCore.Mvc;

namespace NeedUfundraising.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Profile()
		{
			return View();
		}
	}
}
