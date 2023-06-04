using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
			string id = Id.ToString();
			var clientIds = await appDbContext.OfferClients.Where(oc => oc.OfferId == id).Select(oc => oc.ClientId).ToListAsync();

			var userData = await appDbContext.Users.Join(clientIds,user => user.Id,clientId => clientId,(user, clientId) => new { User = user, ClientId = clientId }).Select(data => new { data.User, data.ClientId }).ToListAsync();

			//var clientDates = await appDbContext.OfferClients.Where(oc => oc.OfferId == id).Select(oc => oc.Date).ToListAsync();

			//var clients = await appDbContext.Users.Where(u => clientIds.Contains(u.Id)).ToListAsync();

			//List<User> users = new List<User>();
			//foreach(var offerClient in offerClients)
			//{
			//	var client = appDbContext.Users.Where(c => c.Id == offerClient.ToString());
			//	users.Add((User)client);
			//}


			return View(userData);
		}
	}
}
