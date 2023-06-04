using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpBoardUA.Controllers
{
	public class DBforOrganizationController : Controller
	{
		private readonly AppDbContext appDbContext;
		public DBforOrganizationController(AppDbContext appDbContext) 
		{
			this.appDbContext = appDbContext;
		}
		public async Task<IActionResult> Index(Guid Id)
		{
			var offerClients = await appDbContext.OfferClients.Where(oc => oc.OfferId == Id.ToString()).ToListAsync();

			var model = new OfferQueueModel()
			{
								

			};
			return View(model);
		}
	}
}
