using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HelpBoardUA.Controllers
{
	public class OrganizationProfileController : Controller
	{
        private readonly UserManager<IdentityUser> _userManager;
		private readonly AppDbContext _appDbContext;

        public OrganizationProfileController(
            UserManager<IdentityUser> userManager,
            AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
		{

			Organization organization = (Organization) await _userManager.GetUserAsync(User);
            var orgId = _userManager.GetUserId(User);

            var name = organization.Name;
            var location = organization.Location;
            var phone = organization.PhoneNumber;
            var email = organization.Email;

            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Phone = phone;
            ViewBag.Email = email;
            ViewBag.AvatarImage = organization.AvatarImage;
            ViewBag.BannerImage = organization.BannerImage;
            ViewBag.СertificateImage = organization.СertificateImage;



			var newsList = await _appDbContext.News.Where(n => n.OrganizationId == orgId).ToListAsync();
            var offerList = await _appDbContext.Offers.Where(n => n.OrganizationId == orgId).ToListAsync();


			var model = new OrganizationProfileViewModel
			{
				//Organization = organization,
				NewsList = newsList,
				OfferList = offerList
			};

			return View(model);
		}
	}
}
