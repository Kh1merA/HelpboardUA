using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HelpBoardUA.Controllers
{
	public class HumanitarianController : Controller
	{
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public HumanitarianController(
            AppDbContext appDbContext,
            UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        [HttpGet]
		public async Task<IActionResult> Index(string? HelpType)
		{
			var offers = await _appDbContext.Offers.ToListAsync();

			if (HelpType == "kitchenHelp")		{ ViewBag.HelpType = "kitchenHelp"; }
			if (HelpType == "childrenHelp")		{ ViewBag.HelpType = "childrenHelp"; }
			if (HelpType == "bedLinen")			{ ViewBag.HelpType = "bedLinen"; }
			if (HelpType == "animalsHelp")		{ ViewBag.HelpType = "animalsHelp"; }
			if (HelpType == "medicalHelp")		{ ViewBag.HelpType = "medicalHelp"; }
			if (HelpType == "foodHelp")			{ ViewBag.HelpType = "foodHelp"; }
			if (HelpType == "informationHelp")	{ ViewBag.HelpType = "informationHelp"; }
			if (HelpType == "hygieneHelp")		{ ViewBag.HelpType = "hygieneHelp"; }
			if (HelpType == "moneyHelp")		{ ViewBag.HelpType = "moneyHelp"; }

			return View(offers);
		}

		[HttpGet]
		public async Task<IActionResult> HumanitarianPage(Guid offerId)
		{
			Offer offer = await _appDbContext.Offers.FirstOrDefaultAsync(o => o.Id == offerId);

			//преобразования строки в Guid для последующего поиска
			//Guid orgId;
			//Guid.TryParse(offer.OrganizationId, out orgId);

			var user = await _appDbContext.Users.FirstOrDefaultAsync(o => o.Id == offer.OrganizationId);
			Organization organization = await _appDbContext.Organizations.FirstOrDefaultAsync(org => org.UserName == user.UserName);

			ViewBag.Id = offerId;
			ViewBag.Title = offer.Title;
			ViewBag.Description = offer.Description;
			ViewBag.OfferId = offerId;
			ViewBag.Subtitle = offer.Subtitle;
			ViewBag.OfferType = offer.OfferType;
			ViewBag.HelpType = offer.HelpType;
			ViewBag.NumberOfAid = offer.NumberOfAid;
			ViewBag.Area = offer.Area;
			ViewBag.City = offer.City;
			ViewBag.Address = offer.Address;
			ViewBag.StartDateTime = offer.StartDateTime.Date;
			ViewBag.FinishDateTime = offer.FinishDateTime.Date;
			ViewBag.OrganizationId = offer.OrganizationId;
			ViewBag.OrganizationName = organization.Name;
			ViewBag.CreatingDate = offer.CreatingDate;

			//var offerModel = new Offer()
			//{
			//	Id = offerId,
			//};
			return View(offer);
		}

		public IActionResult DeliveryPage(Guid id)
		{
			ViewBag.OfferId = id;

            return View();
		}

		[HttpPost]
        public async Task<IActionResult> AddToDelivery(OfferClient offerClientModel)
        {
			var clientId = _userManager.GetUserId(User);

			OfferClient offerClient = new OfferClient()
			{
				ClientId = clientId,
				OfferId = offerClientModel.OfferId,
				Area = offerClientModel.Area,
				City = offerClientModel.City,
				Office = offerClientModel.Office,
				PhoneNumber = offerClientModel.PhoneNumber,
			};

			await _appDbContext.OfferClients.AddAsync(offerClient);
			await _appDbContext.SaveChangesAsync();
            return LocalRedirect("~/Humanitarian/Index");
        }

        public IActionResult HumanPageForOrg()
		{
			return View();
		}

		public async Task<IActionResult> HumanPageForAdmin(Guid Id)
		{
			var offer = await _appDbContext.Offers.FirstOrDefaultAsync(o  => o.Id == Id);
			var user = await _appDbContext.Users.FirstOrDefaultAsync(o => o.Id == offer.OrganizationId);
			Organization organization = await _appDbContext.Organizations.FirstOrDefaultAsync(org => org.UserName == user.UserName);

			ViewBag.OrganizationName = organization.Name;
			//ViewBag.OrganizationId = organization.Id;
			return View(offer);
		}

		[HttpPost]
		public async Task<IActionResult> ConfirmOffer(Guid Id)
		{
			var ofr = await _appDbContext.Offers.FirstOrDefaultAsync(o => o.Id == Id);

			ofr.IsConfirmed= true;

			await _appDbContext.SaveChangesAsync();

			return RedirectToAction("Index","ConfirmationAd");
		}

		[HttpPost]
		public async Task<IActionResult> CancelOffer(Guid Id)
		{
			var ofr = await _appDbContext.Offers.FirstOrDefaultAsync(o => o.Id == Id);

			_appDbContext.Offers.Remove(ofr);
			await _appDbContext.SaveChangesAsync();

			return RedirectToAction("Index", "ConfirmationAd");
		}
	}
	
}
