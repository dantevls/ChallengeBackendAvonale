using Microsoft.EntityFrameworkCore;
using Produtos_Data.Mapping;
using Produtos_Domain.Entities;

namespace Produtos_Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductEntity>(new ProductMap().Configure);
        }
    }

}
