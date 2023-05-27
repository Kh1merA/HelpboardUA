using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class RegistrationGumPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
