using HelpBoardUA.Data;
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

		public IActionResult HumanitarianPage()
		{
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
