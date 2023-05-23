using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class DeliveryPageController : Controller
    {
        public IActionResult index()
        {
            return View();
        }
    }
}
