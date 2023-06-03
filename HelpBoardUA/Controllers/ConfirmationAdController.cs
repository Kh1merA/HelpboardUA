using HelpBoardUA.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpBoardUA.Controllers
{
    public class ConfirmationAdController : Controller
    {   
        private readonly AppDbContext appDbContext;
        public ConfirmationAdController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var offers = await appDbContext.Offers.ToListAsync();
            return View(offers);
        }
    }
}
