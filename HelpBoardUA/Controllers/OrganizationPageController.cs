using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
	public class OrganizationPageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
