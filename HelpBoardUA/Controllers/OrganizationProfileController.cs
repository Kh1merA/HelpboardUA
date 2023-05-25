using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
	public class OrganizationProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
