using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace HelpBoardUA.Controllers
{
	[Authorize]
	public class UserProfileController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly AppDbContext _appDbContext;

		public UserProfileController(UserManager<IdentityUser> userManager, AppDbContext appDbContext)
		{
			_userManager = userManager;
			_appDbContext = appDbContext;
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
			byte[]? imageVPO = user.ImageData;

			ViewBag.FirstName = firstName;
			ViewBag.LastName = lastName;
			ViewBag.Patronymic = patronymic;
			ViewBag.Sex = sex;
			ViewBag.Birth= birth;
			ViewBag.Phone = phoneNumber;
			ViewBag.Email = email;
			ViewBag.VPO_Status = vpoStatus;
			ViewBag.ImageVPO = imageVPO;
			

			return View();
		}

        public IActionResult EditUserProfile()
        {
			var id = _userManager.GetUserId(User);
			var client = _appDbContext.Users.FirstOrDefault(u => u.Id == id);

            return View(client);
        }

		public async Task<IActionResult> EditAsync(Client client)
        {
            var id = _userManager.GetUserId(User);

            await _appDbContext.Database.ExecuteSqlInterpolatedAsync(
                $"UPDATE AspNetUsers SET Lastname = {client.LastName}, FirstName = {client.FirstName}, Patronymic = {client.Patronymic}, Sex = {client.Sex}, Birth = {client.Birth},  PhoneNumber = {client.PhoneNumber}, Email = {client.Email} WHERE Id = {id}");
            await _appDbContext.SaveChangesAsync();

            return LocalRedirect("~/UserProfile/Index");
        }
    }
}
