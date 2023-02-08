using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NeedUfundraising.Models;
using System.Linq;

namespace NeedUfundraising.Controllers
{
    public class LoginController : Controller
    {
		private readonly FundraisingDbContext _context;

		public LoginController(FundraisingDbContext context)
		{
			_context = context;
		}
		public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var loginResult =  _context.Employees.Where(x=>x.Account == username && x.Password == password).SingleOrDefault();
            if (loginResult == null)
            {
                ViewData["loginResult"] = "error";
                return View("Login");
            }
            else { 
                
                return View(loginResult);
            }
   //        ViewData["error"] = {
			//	"username" username

			//};
        }
    }
}
