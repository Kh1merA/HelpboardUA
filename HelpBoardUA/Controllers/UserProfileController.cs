using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
	[Authorize]
	public class UserProfileController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;

		public UserProfileController(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}
		
		public async Task<IActionResult> IndexAsync()
		{
			//var users = _context.Clients.ToList();

			Client user = (Client) await _userManager.GetUserAsync(User);
			var firstName = user.FirstName;
			var lastName = user.LastName;
			var patronymic = user.Patronymic;
			var sex = user.Sex;
			var phoneNumber = user.PhoneNumber;
			var birth = user.Birth;
			var email = user.Email;
			var vpoStatus = user.VPO_Status;

			ViewBag.FirstName = firstName;
			ViewBag.LastName = lastName;
			ViewBag.Patronymic = patronymic;
			ViewBag.Sex = sex;
			ViewBag.Birth= birth;
			ViewBag.Phone = phoneNumber;
			ViewBag.Email = email;
			ViewBag.VPO_Status = vpoStatus;

			return View();
		}

        public IActionResult EditUserProfile()
        {
            return View();
        }
    }
}
