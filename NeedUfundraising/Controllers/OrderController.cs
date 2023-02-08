using Microsoft.AspNetCore.Mvc;

namespace NeedUfundraising.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Order()
		{
			return View();
		}
	}
}
