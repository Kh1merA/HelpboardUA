using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult regPage()
        {
            return View();
        }
    }
}
