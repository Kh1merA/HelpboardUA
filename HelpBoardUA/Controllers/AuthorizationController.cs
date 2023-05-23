using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
