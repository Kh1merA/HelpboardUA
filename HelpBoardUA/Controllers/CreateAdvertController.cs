using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace HelpBoardUA.Controllers
{
    public class CreateAdvertController : Controller
    {
		private readonly AppDbContext _appDbContext;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ILogger<AddNewsController> _logger;

        public CreateAdvertController(
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
			var model = new AddNewOfferModel() { OfferImage = null };
            return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Add(AddNewOfferModel addNewOfferModel)
		{
			//get this org obj
			Organization org = (Organization) await _userManager.GetUserAsync(User);
			var orgId = _userManager.GetUserId(User);

            var offer = new Offer()
			{
				Title = addNewOfferModel.Title,
				Subtitle = addNewOfferModel.Subtitle,
				Description = addNewOfferModel.Description,
				OfferType = addNewOfferModel.OfferType,
				HelpType = addNewOfferModel.HelpType,
				NumberOfAid = addNewOfferModel.NumberOfAid,
				Area = addNewOfferModel.Area,
				City = addNewOfferModel.City,
				Address = addNewOfferModel.Address,
				StartDateTime = addNewOfferModel.StartDateTime,   //always 00
				FinishDateTime = addNewOfferModel.FinishDateTime, //always 00
				OrganizationId = orgId,
				CreatingDate = DateTime.Now,
				IsConfirmed = false,
			};

            if (addNewOfferModel.OfferImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await addNewOfferModel.OfferImage.CopyToAsync(memoryStream);
                    offer.OfferImage = memoryStream.ToArray();
                }
            }


            await _appDbContext.Offers.AddAsync(offer);
			await _appDbContext.SaveChangesAsync();

			_logger.LogInformation("offer created");

            return LocalRedirect("~/OrganizationProfile/Index");
        }
    }
}
