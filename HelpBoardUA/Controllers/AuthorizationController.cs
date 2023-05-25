using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace HelpBoardUA.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly AppDbContext appDbContext;
        public AuthorizationController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        /*
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
             var client = appDbContext.Clients.FirstOrDefault(c => c.Username == username && c.Password == password);
             var org = appDbContext.Organizations.FirstOrDefault(c => c.Username == username && c.Password == password);

             if (client != null)
             {
                 // Авторизація користувача
                FormsAuthentication.SetAuthCookie(username, false);

                 return RedirectToAction("Index", "Home"); 
             }
            if (org != null)
            {
                // Авторизація користувача
                FormsAuthentication.SetAuthCookie(username, false);

                return RedirectToAction("Index", "Home"); 
            }
            else
             {
                 ViewBag.ErrorMessage = "Невірне ім'я користувача або пароль";
             }
            
            return RedirectToAction("Index", "Authorization");
        }
        */

        [HttpPost]
        //[Authorize]
        //[Route("/Controllers/AuthorizationController/Login")]
        public async Task<IActionResult> Login(string username, string password) {

            bool IsValidUser(string username, string password) {
                var client = appDbContext.Clients.FirstOrDefault(u => u.Username == username && u.Password == password);
                var org = appDbContext.Organizations.FirstOrDefault(o => o.Username == username && o.Password == password);

                if (client != null) return true;
                if (org != null) return true;

                return false;
            }
            bool isValidUser = (appDbContext.Clients.Any(user => user.Username == username && user.Password == password)) 
                || (appDbContext.Organizations.Any(org => org.Username == username && org.Password == password));

            if (isValidUser) {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username) 
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false // Чи зберігати авторизацію після закриття браузера
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home"); // Перенаправлення на головну сторінку
            }
            else
            {
                ViewBag.ErrorMessage = "Невірне ім'я користувача або пароль";
                //return View("Index");
                return RedirectToAction("Index", "News");
            }
        }
    }
}
