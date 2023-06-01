using HelpBoardUA.Data;
using HelpBoardUA.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        string connection = builder.Configuration.GetConnectionString("HelpboardUAConnectionString");

        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));


        //added automaticaly with area....
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        builder.Services.Configure<IdentityOptions>(opts =>
        {
            opts.Password.RequiredLength = 8;
            opts.Password.RequireLowercase = false;
            opts.Password.RequireUppercase = false;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequireDigit = false;
        });
        /*
         * log in doesnt work with this code(
         * 
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "MyCookie";
                options.LoginPath = "/Authorization/Login"; //login method path
            });
        */

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.MapRazorPages();

        app.UseAuthentication();
        app.UseAuthorization();
        

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");


        //adding roles
        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "Organization", "Client" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        //adding admin
        
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string email = "admin@admin.ua";
            string password = "Admin1$";
            
            if(await userManager.FindByEmailAsync(email) == null)
            {
                var user = new Client();

                user.UserName = email;
                user.Email = email;

                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, "Admin");

            }
        }
        

        app.Run();
    }
}