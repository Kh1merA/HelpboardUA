using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HelpBoardUA.Controllers
{
    public class AddNewsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AddNewsController> _logger;

        public AddNewsController(
            AppDbContext appDbContext,
            UserManager<IdentityUser> userManager,
            ILogger<AddNewsController> logger)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewNewsModel addNewNewsModel)
        {
            //get this org obj
            Organization org = (Organization) await _userManager.GetUserAsync(User);
            var orgId = _userManager.GetUserId(User);

            //_logger.LogInformation("get org object.");
            _logger.LogInformation(orgId);

            var news = new News()
            {
                Title = addNewNewsModel.Title,
                SubTitle = addNewNewsModel.SubTitle,
                Description = addNewNewsModel.Description,
                Location = org.Location,
                PublicationDate = DateTime.Now,
                OrganizationId = orgId
            };

            //_logger.LogInformation("created news obj.");

            await _appDbContext.News.AddAsync(news);
            await _appDbContext.SaveChangesAsync();
            
            _logger.LogInformation("news created");

            return LocalRedirect("~/OrganizationProfile/Index");
        }
    }
}
