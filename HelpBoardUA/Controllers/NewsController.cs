using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult ArticlePage()
		{
			return View();
		}
	}
}
