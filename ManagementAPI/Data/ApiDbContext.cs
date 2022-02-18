using Microsoft.EntityFrameworkCore;
using BusinessLogic.Models;

namespace ManagementAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> option) : base(option)
        {

        }

        public DbSet<BusinessLogic.Models.Product> Product { get; set; }
    }
}
