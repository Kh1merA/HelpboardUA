﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    [Authorize(Roles = "Client")]
    [Authorize(Roles = "Admin")]
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
