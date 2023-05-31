using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpBoardUA.Controllers
{
	public class DBforAdmin : Controller
	{
		private readonly AppDbContext _appDbContext;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ILogger<AddNewsController> _logger;

		public DBforAdmin(
			AppDbContext appDbContext,
			UserManager<IdentityUser> userManager,
			ILogger<AddNewsController> logger)
		{
			_appDbContext = appDbContext;
			_userManager = userManager;
			_logger = logger;
		}
		public async Task<IActionResult> UsersDB()
		{
			var list = await _appDbContext.Clients.ToListAsync();

			var model = new ClientViewModel()
			{
				ClientsList = list
			};

			return View(model);
		}

		public async Task<IActionResult> OrganizationsDB()
		{
			var list = await _appDbContext.Organizations.ToListAsync();

			var model = new OrganizationViewModel()
			{
				OrganizationList = list
			};

			return View(model);
		}
	}
}
