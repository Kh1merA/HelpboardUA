using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace HelpBoardUA.Controllers
{

    //[Authorize(Roles = "Admin,Client")]
    public class NewsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _appDbContext;

        public NewsController(
            UserManager<IdentityUser> userManager,
            AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var newsList = await _appDbContext.News.ToListAsync();
            var model = new NewsViewModel
            {
                NewsList = newsList,
            };
            return View(model);
        }


        public async Task<IActionResult> ArticlePage(Guid id)
		{
			var newsList = await _appDbContext.News.ToListAsync();
            
            var model = new NewsViewModel { NewsList = newsList, };

			var thisNews = await _appDbContext.News.FirstOrDefaultAsync(x => x.Id == id);

            string title = thisNews.Title;
            string subTitle = thisNews.SubTitle;
            string description = thisNews.Description;
            DateTime date = thisNews.PublicationDate;

            ViewBag.TitleNotArticle = title;
            ViewBag.SubTitle = subTitle;
            ViewBag.Description = description;
            ViewBag.Date = date.ToString("dd.MM.yyyy");
            
            return View(model);
		}
	}
}
