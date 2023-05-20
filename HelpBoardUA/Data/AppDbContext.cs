
using Microsoft.EntityFrameworkCore;

namespace HelpBoardUA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        //all db tables
        //public DbSet<Entity> Entities { get; set; }
        //public DbSet<Entity> Entities { get; set; }
        //public DbSet<Entity> Entities { get; set; }
    }
}
