using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpBoardUA.Controllers
{
	public class OrganizationPageController : Controller
	{
		private readonly AppDbContext _appDbContext;
		private readonly UserManager<IdentityUser> _userManager;

		public OrganizationPageController(
			AppDbContext appDbContext,
			UserManager<IdentityUser> userManager)
		{
			_appDbContext = appDbContext;
			_userManager = userManager;
		}
		public async Task<IActionResult> Index(Guid id)
		{
			string orgId = id.ToString();

			Organization organization = (Organization)await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == orgId);

			var newsList = await _appDbContext.News.Where(n => n.OrganizationId == orgId).ToListAsync();
			var offerList = await _appDbContext.Offers.Where(n => n.OrganizationId == orgId).ToListAsync();

			var model = new OrganizationProfileViewModel()
			{
				Organization = organization,
				NewsList = newsList,
				OfferList = offerList
			};



			return View(model);
		}
	}
}
