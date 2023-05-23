using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class AuthorizationPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
