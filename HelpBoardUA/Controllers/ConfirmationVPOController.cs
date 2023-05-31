using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpBoardUA.Controllers
{
	public class ConfirmationVPOController : Controller
	{
		private readonly AppDbContext appDbContext;

		public ConfirmationVPOController (AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			
			var users = await appDbContext.Clients.ToListAsync();
			return View(users);
		}

        [HttpPost]
        public async Task<IActionResult> Confirm(string userName)
        {
            var client = await appDbContext.Clients.FirstOrDefaultAsync(c => c.UserName == userName);
			if (client != null) 
			{
                client.VPO_Status = 2;
                await appDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(string userName)
        {
            var client = await appDbContext.Clients.FirstOrDefaultAsync(c => c.UserName == userName);
            if (client != null)
            {
                client.VPO_Status = 0;
                await appDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }



    }
}
