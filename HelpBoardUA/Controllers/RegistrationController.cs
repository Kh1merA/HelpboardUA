using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpBoardUA.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AppDbContext appDbContext;
        public RegistrationController(AppDbContext appDbContext) { }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegOrganization()
        {
            return View();
        }

        public IActionResult RegUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Client client)
        {
            Client cl = new Client()
            { 
                Id = Guid.NewGuid(),
                FullName = client.FullName,
                Sex = client.Sex,
                Birth = client.Birth,
                RegistrationDate = DateTime.Now,
                Email = client.Email,
                Tel = client.Tel,
                Username = client.Email,
                Password = client.Password

            };

            await appDbContext.Clients.AddAsync(cl);
            await appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }
    }
}
