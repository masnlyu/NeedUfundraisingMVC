using Microsoft.AspNetCore.Mvc;

namespace NeedUfundraising.Controllers
{
	public class EmployeeController : Controller
	{
		public IActionResult Employee()
		{
			return View();
		}
	}
}
