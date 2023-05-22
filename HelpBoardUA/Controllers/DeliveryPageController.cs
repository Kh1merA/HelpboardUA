using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class DeliveryPageController : Controller
    {
        public IActionResult deliveryPage()
        {
            return View();
        }
    }
}
