using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
	public class OnlineQueueController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
