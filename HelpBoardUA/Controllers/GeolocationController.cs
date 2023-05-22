using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class GeolocationController : Controller
    {
        public IActionResult geolocationPage()
        {
            return View();
        }
    }
}
