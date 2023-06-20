using Microsoft.EntityFrameworkCore;
using NAGP_ASP_Microservice.Model;


namespace NAGP_ASP_Microservice.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}