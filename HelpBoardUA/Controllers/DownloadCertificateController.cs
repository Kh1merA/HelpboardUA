using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
	public class DownloadCertificateController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
