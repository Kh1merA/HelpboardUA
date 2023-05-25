using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
	public class UserProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult EditUserProfile()
        {
            return View();
        }
    }
}
