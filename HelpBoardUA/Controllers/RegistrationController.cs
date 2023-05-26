using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;

namespace HelpBoardUA.Controllers
{
        public class RegistrationController : Controller
        {
            private readonly AppDbContext appDbContext;
            public RegistrationController(AppDbContext appDbContext) 
            { 
                this.appDbContext = appDbContext;
            }
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
            public async Task<IActionResult> RegisterUser(Client client)
            {
            if (client.PassConfirmation == client.Password && !client.FirstName.Any(char.IsDigit) &&  !client.LastName.Any(char.IsDigit) && !client.SurName.Any(char.IsDigit))/*
            {
                    if(client.FirstName.Any(char.IsDigit) || client.LastName.Any(char.IsDigit)  || client.SurName.Any(char.IsDigit))
                    {
                        //ModelState.AddModelError("FirstName", "Ім'я, прізвище та по батькові не повинні мати в собі цифри");
                    }     
          
            if (ModelState.IsValid) */
            {

                        var cl = new Client()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = client.FirstName,
                            LastName = client.LastName,
                            SurName = client.SurName,
                            Sex = client.Sex,
                            Birth = client.Birth,
                            RegistrationDate = DateTime.Now,
                            Email = client.Email,
                            Tel = client.Tel,
                            Username = client.Email,
                            Password = client.Password,
                            Location = "Не вказано"

                        };

                        await appDbContext.Clients.AddAsync(cl);
                        await appDbContext.SaveChangesAsync();
                        return RedirectToAction("Index", "Authorization");
                    }

            /*  
             }

          {
          ModelState.AddModelError(string.Empty, "Підтверження пароля не співпадає.");
          } */
            return View("RegUser"); 
            }

            public async Task<IActionResult> RegisterOrg(Organization organization)
            {
                if (organization.PassConfirmation == organization.Password ) 
                {
                    var org = new Organization()
                    {
                        Id = Guid.NewGuid(),
                        Email = organization.Email,
                        Name = organization.Name,
                        Location = organization.Location,
                        Tel = organization.Tel,
                        Username=organization.Email,
                        Password = organization.Password,
                    };

                    await appDbContext.Organizations.AddAsync(org);
                    await appDbContext.SaveChangesAsync();
                    return RedirectToAction("Index", "Authorization");
                    
                }
                return View("RegOrganization");
            }
        }
}
