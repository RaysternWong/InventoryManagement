using InventoryManagementPage.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Models;

namespace InventoryManagementPage.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<InventoryManagementPage.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<InventoryManagementPage.Models.ProductType> ProductType { get; set; }

        public DbSet<InventoryManagementPage.Models.UnitOfMeasure> UnitOfMeasure { get; set; }

        public DbSet<InventoryManagementPage.Models.UserProfile> UserProfile { get; set; }
    }
}
