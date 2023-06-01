using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace HelpBoardUA.Controllers
{
    public class EditOrganizationProfileController : Controller
    {
		private readonly UserManager<IdentityUser> _userManager;
		private readonly AppDbContext _appDbContext;
        private readonly ILogger<AddNewsController> _logger;


        public EditOrganizationProfileController(
			UserManager<IdentityUser> userManager,
            AppDbContext appDbContext,
            ILogger<AddNewsController> logger)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
			Organization organization = (Organization)await _userManager.GetUserAsync(User);
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

			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditOrganizationViewModel model)
		{
            Organization organization = (Organization)await _userManager.GetUserAsync(User);
            var orgId = _userManager.GetUserId(User);

			var name = model.Name;
			var location = model.Location;
			var phone = model.PhoneNumber;
			var email = model.Email;
			IFormFile avatar = model.AvatarImage;
            IFormFile banner = model.BannerImage;
			IFormFile certificate = model.Certificate;

			using (var memoryStream = new MemoryStream())
            {
                if(avatar != null)
                {
                    await avatar.CopyToAsync(memoryStream);
					organization.AvatarImage = memoryStream.ToArray();
				}							
			}
            using (var memoryStream1 = new MemoryStream())
            {
				if (banner != null)
				{
					await banner.CopyToAsync(memoryStream1);
					organization.BannerImage = memoryStream1.ToArray();
				}
			}
			using (var memoryStream2 = new MemoryStream())
			{
				if (certificate != null)
				{
					await certificate.CopyToAsync(memoryStream2);
					organization.СertificateImage = memoryStream2.ToArray();
				}
			}
			/*
			string sql = "UPDATE AspNetUsers " +
				"SET Name = @name, Location = @location, PhoneNumber = @phone, Email = @email" +
				"WHERE Id = @orgId"				;

			await _appDbContext.Database.ExecuteSqlAsync(sql,
                new SqlParameter("@name", name),
                new SqlParameter("@location", location),
                new SqlParameter("@phone", phone),
                new SqlParameter("@email", email),
                new SqlParameter("@orgId", orgId));
			*/
			await _appDbContext.Database.ExecuteSqlInterpolatedAsync(
				$"UPDATE AspNetUsers SET Name = {name}, Location = {location}, PhoneNumber = {phone}, Email = {email} WHERE Id = {orgId}");
			await _appDbContext.SaveChangesAsync();

            _logger.LogInformation("news created");


            return LocalRedirect("~/OrganizationProfile/Index");
        }
    }
}
