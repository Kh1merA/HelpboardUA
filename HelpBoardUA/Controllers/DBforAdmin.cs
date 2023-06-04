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
		public async Task<IActionResult> UsersDB(ClientViewModel? searchModel)
		{
			var list = await _appDbContext.Clients.ToListAsync();
			

			if (searchModel != null && !string.IsNullOrEmpty(searchModel.LastName))
			{
				// Если указано имя в поисковой модели, фильтруем список организаций по имени
				list = await _appDbContext.Clients
		.Where(u =>
			(string.IsNullOrEmpty(searchModel.LastName) || u.FirstName.Contains(searchModel.LastName)) ||
			(string.IsNullOrEmpty(searchModel.LastName) || u.LastName.Contains(searchModel.LastName)) ||
			(string.IsNullOrEmpty(searchModel.LastName) || u.Patronymic.Contains(searchModel.LastName)))
		.ToListAsync();
			}

			var model = new ClientViewModel()
			{
				ClientsList = list
			};

			return View(model);
		}

		public async Task<IActionResult> OrganizationsDB(OrganizationViewModel searchModel)
		{
			var list = await _appDbContext.Organizations.ToListAsync();

			if (searchModel != null)
			{
				// Фильтруем список организаций по имени
				if (!string.IsNullOrEmpty(searchModel.Name))
				{
					list = list.Where(org => org.Name.Contains(searchModel.Name)).ToList();
				}		
			}

			var model = new OrganizationViewModel()
			{
				OrganizationList = list
			};

			return View(model);
		}

		public async Task<IActionResult> OrgSearch(OrganizationViewModel organization)
		{			
			return RedirectToAction("OrganizationsDB", organization);
		}

		public async Task<IActionResult> OrgFilter(OrganizationViewModel organization)
		{
					
			return RedirectToAction("OrganizationsDB", organization);
		}

		public async Task<IActionResult> UserSearch(ClientViewModel client)
		{
			return RedirectToAction("UsersDB", client);
		}
	}
}
