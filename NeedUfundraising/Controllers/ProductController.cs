using Microsoft.AspNetCore.Mvc;

namespace NeedUfundraising.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Product()
		{
			return View();
		}
	}
}
