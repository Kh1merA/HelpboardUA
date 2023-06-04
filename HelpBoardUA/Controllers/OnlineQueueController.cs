using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpBoardUA.Controllers
{
	public class OnlineQueueController : Controller
	{
		public readonly AppDbContext appDbContext;
		private readonly UserManager<IdentityUser> userManager;
		public OnlineQueueController(AppDbContext appDbContext, UserManager<IdentityUser> userManager) 
		{
			this.appDbContext = appDbContext;
			this.userManager = userManager;
		}
		public async Task<IActionResult> Index(Guid Id)
		{
			OfferClient model = new OfferClient();
			var offer = await appDbContext.Offers.FirstOrDefaultAsync(x => x.Id == Id);
			if (offer != null) 
			{ 
				ViewBag.OfferId = offer.Id; 
			}
			
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> PickDateTime(OfferClient offerClient) 
		{
			TimeSpan offerTime = offerClient.Time.TimeOfDay; 
			Guid clientId = Guid.Parse(userManager.GetUserId(User));

			OfferClient offerCl = new OfferClient()
			{
				OfferId = offerClient.OfferId,
				ClientId = clientId,
				Date = offerClient.Date.Add(offerTime),
				
			};
			
			await appDbContext.OfferClients.AddAsync(offerCl);
			await appDbContext.SaveChangesAsync();
			return RedirectToAction("Index","Humanitarian");
		}
	}
}
