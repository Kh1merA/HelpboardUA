 using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HelpBoardUA.Controllers
{
    public class EditAdvertController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _appDbContext;

        public EditAdvertController(
            UserManager<IdentityUser> userManager,
            AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var thisOffer = await _appDbContext.Offers.FirstOrDefaultAsync(x => x.Id == id);

            if (thisOffer != null)
            {
                var viewModel = new EditAdvertViewModel()
                {
                    Id = id,
                    Title = thisOffer.Title,
                    Subtitle = thisOffer.Subtitle,
                    Description = thisOffer.Description,
                    OfferType = thisOffer.OfferType,
                    HelpType = thisOffer.HelpType,
                    NumberOfAid = thisOffer.NumberOfAid,
                    Area = thisOffer.Area,
                    City = thisOffer.City,
                    Address = thisOffer.Address,
                    StartDateTime = thisOffer.StartDateTime,
                    FinishDateTime = thisOffer.FinishDateTime
                };

                ViewBag.OfferImage = thisOffer.OfferImage;

                return await Task.Run(() => View(viewModel));
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditAdvertViewModel model)
        {
            var offer = await _appDbContext.Offers.FindAsync(model.Id);

            if (offer != null)
            {
                offer.Title = model.Title;
                offer.Subtitle = model.Subtitle;
                offer.Description = model.Description;
                offer.OfferType = model.OfferType;  
                offer.HelpType = model.HelpType;
                offer.NumberOfAid = model.NumberOfAid;
                offer.Area = model.Area;
                offer.City = model.City;
                offer.Address = model.Address;
                offer.StartDateTime = model.StartDateTime;
                offer.FinishDateTime = model.FinishDateTime;

                if (model.OfferImage != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.OfferImage.CopyToAsync(memoryStream);
                        offer.OfferImage = memoryStream.ToArray();                   
                    }
                }

                await _appDbContext.SaveChangesAsync();

                return LocalRedirect("~/OrganizationProfile/Index");
            }

            return LocalRedirect("~/OrganizationProfile/Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _appDbContext.Offers.Where(i => i.Id == id).ExecuteDeleteAsync();
                        
            return LocalRedirect("~/OrganizationProfile/Index");
        }
    }
}
