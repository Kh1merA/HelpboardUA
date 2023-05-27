
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HelpBoardUA.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //all db tables
        public DbSet<Client> Clients{ get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}
