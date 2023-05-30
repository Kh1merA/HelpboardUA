using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class DownloadVPOCertificateController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public DownloadVPOCertificateController(AppDbContext appDbContext, UserManager<IdentityUser> userManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] Client client)
        {
            
            Client user = (Client)await userManager.GetUserAsync(User);
            string clientId = user.Id.ToString();

            if (client.file == null || client.file.Length == 0)
            {
				return View("Index");
			}

            // Находим клиента по идентификатору
            
            if (user == null)
            {
				return View("Index");
			}

            user.VPO_Status = 1;

            using (var memoryStream = new MemoryStream())
            {
                await client.file.CopyToAsync(memoryStream);

                // Обновляем поля для фотографии клиента
                user.ImageFileName = client.file.FileName;
                user.ImageExtension = Path.GetExtension(client.file.FileName);
                user.ImageData = memoryStream.ToArray();

                // Сохраняем изменения в базе данных
                await appDbContext.SaveChangesAsync();

                return RedirectToAction("Index","UserProfile");
            }
        }

    }
}
