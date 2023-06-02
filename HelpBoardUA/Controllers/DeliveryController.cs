using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DeliveryController(
            AppDbContext appDbContext,
            UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(Guid offerId)
        {
            var clientId = _userManager.GetUserId(User);

            ViewBag.ClientId = clientId;
            ViewBag.OfferId = offerId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delivery(OfferClient deliveryInfo)
        {
            OfferClient offerClient = new OfferClient()
            {
                OfferId = deliveryInfo.OfferId,

            };

            return View();
        }
    }
}
