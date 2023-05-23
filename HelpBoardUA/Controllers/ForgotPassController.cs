using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class ForgotPassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
