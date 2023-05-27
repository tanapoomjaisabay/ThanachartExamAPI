using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.DataAccess.Interfaces;

namespace ShoppingCartAPI.DataAccess
{
    public class ProductContext : DbContext, IShoppingCartDataSet
    {
        public DbSet<ProductMasterEntity> productMasterEntity => Set<ProductMasterEntity>();

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var customeAuthenBuilder = builder.Entity<ProductMasterEntity>();
            customeAuthenBuilder.ToTable("productMaster", "dbo");
            customeAuthenBuilder.HasKey(x => new { x.idKey, x.productCode });
            customeAuthenBuilder.Property(x => x.idKey).ValueGeneratedOnAdd();

        }
    }
}
