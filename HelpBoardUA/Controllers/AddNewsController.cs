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

        //[BindProperty] <<<--- ?????
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Required]
            [Display(Name = "SubTitle")]
            public string SubTitle { get; set; }

            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; }

            //[Required]
            [Display(Name = "Location")]
            public string Location { get; set; }

            [Display(Name = "Date")]
            public string Date { get; set; }
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //get this org obj
            Organization org = (Organization) await _userManager.GetUserAsync(User);

            _logger.LogInformation("User created a new account with password.");


            var news = new News()
            {
                Title = Input.Title,
                SubTitle = Input.SubTitle, 
                Description = Input.Description,
                Location = Input.Location,
                PublicationDate = DateTime.Now,
                Organization = org
            };

            using (var context = _appDbContext)
            {

            }
            return View();
        }
    }
}
