using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HelpBoardUA.Controllers
{
	public class HumanitarianController : Controller
	{
		private readonly AppDbContext appDbContext;
		public HumanitarianController(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		[HttpGet]
		public async Task<IActionResult> Index(string? HelpType)
		{
			var offers = await appDbContext.Offers.ToListAsync();

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
			Offer offer = await appDbContext.Offers.FirstOrDefaultAsync(o => o.Id == offerId);

			//преобразования строки в Guid для последующего поиска
			//Guid orgId;
			//Guid.TryParse(offer.OrganizationId, out orgId);

			var user = await appDbContext.Users.FirstOrDefaultAsync(o => o.Id == offer.OrganizationId);
			Organization organization = await appDbContext.Organizations.FirstOrDefaultAsync(org => org.UserName == user.UserName);

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

			return View();
		}

		public IActionResult HumanPageForOrg()
		{
			return View();
		}

		public IActionResult HumanPageForAdmin()
		{
			return View();
		}

	}
	
}
