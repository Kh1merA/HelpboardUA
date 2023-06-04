using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

		public async Task<IActionResult> OrganizationsDB(OrganizationViewModel model)
		{
			var list = await _appDbContext.Organizations.ToListAsync();

				model = new OrganizationViewModel()
				{
					OrganizationList = list
				};
			
			return View(model);
		}

		/*public async Task<IActionResult> OrgFilter()
		{
            var list = await _appDbContext.Organizations.ToListAsync();

            var model = new OrganizationViewModel()
            {
                OrganizationList = list
            };

            return View(model);
        }*/

		public async Task<IActionResult> OrgSearch(OrganizationViewModel organization)
		{
			var list = await _appDbContext.Organizations.Where(org => (org.Name == organization.Name)).ToListAsync();

			var model = new OrganizationViewModel()
			{
				OrganizationList = list
			};

			return RedirectToAction("OrganizationsDB", model);
		}
	}
}
