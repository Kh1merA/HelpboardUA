using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class RegistrationUser : Controller
    {
        public IActionResult regUserPage()
        {
            return View();
        }
    }
}
