﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class HumanitarianController : Controller
    {    
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult HumanitarianPage()
		{
			return View();
		}


	}
}
