using Microsoft.AspNetCore.Mvc;

namespace NeedUfundraising.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Message()
		{
			return View();
		}
	}
}
