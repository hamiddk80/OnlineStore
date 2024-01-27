using Domain.ProductCategories.Entities;
using Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


    }
}
