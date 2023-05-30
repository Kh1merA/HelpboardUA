using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpBoardUA.Controllers
{
    public class EditNewsPageController : Controller
    {
		private readonly UserManager<IdentityUser> _userManager;
		private readonly AppDbContext _appDbContext;

        public EditNewsPageController(
            UserManager<IdentityUser> userManager,
            AppDbContext appDbContext)
		{
			_userManager = userManager;
			_appDbContext = appDbContext;
		}



		[HttpGet]
        public async Task<IActionResult> Index(Guid id)
        { 
            var thisNews = await _appDbContext.News.FirstOrDefaultAsync(x => x.Id == id);

            if(thisNews != null)
			{
				var viewModel = new EditNewsPageModel()
				{
					Id = id,
					Title = thisNews.Title,
					Subtitle = thisNews.SubTitle,
					Description = thisNews.Description
				};
				return await Task.Run(() => View(viewModel));
				//return View(viewModel);
			}

            return View(); 
        }

		
		[HttpPost]
		public async Task<IActionResult> Edit(EditNewsPageModel model)
		{
			var news = await _appDbContext.News.FindAsync(model.Id);

			if (news != null)
			{
				news.Title = model.Title;
				news.SubTitle = model.Subtitle;
				news.Description = model.Description;

				await _appDbContext.SaveChangesAsync();

				return LocalRedirect("~/OrganizationProfile/Index");
			}

            return LocalRedirect("~/OrganizationProfile/Index");
        }

    }
}
