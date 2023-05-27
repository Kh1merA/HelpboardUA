
using HelpBoardUA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClientEntityConfiguration());
        }
    }

    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.LastName).HasMaxLength(40);
            builder.Property(c => c.FirstName).HasMaxLength(40);
            builder.Property(c => c.Patronymic).HasMaxLength(40);
            builder.Property(c => c.Sex);
            builder.Property(c => c.Birth);
        }
    }
}
