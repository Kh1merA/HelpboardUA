using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
	[Authorize]
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
