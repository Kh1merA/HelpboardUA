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
        [Http]
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

        [Authorize]
        public async Task<IActionResult> Login(string username, string password)
        {
            bool IsValidUser(string username, string password) {
                var client = appDbContext.Clients.FirstOrDefault(u => u.Username == username && u.Password == password);
                var org = appDbContext.Organizations.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (client != null) return true;
                if (org != null) return true;

                return false;
            }

            if (IsValidUser(username, password)) {
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
                return View("Index");
            }
        }
    }
}
