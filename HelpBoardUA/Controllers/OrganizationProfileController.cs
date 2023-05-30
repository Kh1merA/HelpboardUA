using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
	public class OrganizationProfileController : Controller
	{
        private readonly UserManager<IdentityUser> _userManager;

        public OrganizationProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
		{
            Organization organization = (Organization) await _userManager.GetUserAsync(User);
            var name = organization.Name;
            var location = organization.Location;
            var phone = organization.PhoneNumber;
            var email = organization.Email;

            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Phone = phone;
            ViewBag.Email = email;

            return View();
		}
	}
}
