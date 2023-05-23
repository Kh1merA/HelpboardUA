using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class ForgotPass : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
