using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
	public class DBforAdmin : Controller
	{
		public IActionResult UsersDB()
		{
			return View();
		}

		public IActionResult OrganizationsDB()
		{
			return View();
		}
	}
}
