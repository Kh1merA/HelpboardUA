using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class RegistrationOrganisation : Controller
    {
        public IActionResult regOrganisationPage()
        {
            return View();
        }
    }
}
