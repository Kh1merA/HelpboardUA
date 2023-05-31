using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HelpBoardUA.Controllers
{

    public class HomeController : Controller
    {
		private readonly UserManager<IdentityUser> _userManager;
		private readonly AppDbContext _appDbContext;
		private readonly ILogger<HomeController> _logger;
        public HomeController(
            ILogger<HomeController> logger, 
            UserManager<IdentityUser> userManager, 
            AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
			var newsList = await _appDbContext.News.ToListAsync();

			var model = new NewsViewModel { NewsList = newsList, };

			return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

		public IActionResult Contacts()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}