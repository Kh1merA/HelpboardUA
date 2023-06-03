using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace HelpBoardUA.Controllers
{
	public class DBforOrganizationController : Controller
	{
		private readonly AppDbContext _appDbContext;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ILogger<AddNewsController> _logger;

		public DBforOrganizationController(
			AppDbContext appDbContext,
			UserManager<IdentityUser> userManager,
			ILogger<AddNewsController> logger)
		{
			_appDbContext = appDbContext;
			_userManager = userManager;
			_logger = logger;
		}

		public async Task<IActionResult> Index(Guid id)
		{
			string strId = id.ToString();

			//string sql = $"SELECT * FROM AspNetUsers WHERE id IN (SELECT ClientId FROM OfferClients WHERE OfferId = {id})";
			//var list = await _appDbContext.Clients.FromSqlRaw(sql).ToListAsync();

			var list =  _appDbContext.Clients
				.Where(user => _appDbContext.OfferClients.Any(oc => (oc.ClientId == user.Id && oc.OfferId == id)))
				.ToList();

			var model = new ClientViewModel()
			{
				ClientsList = list,
			};

			return View(model);
		}
	}
}
