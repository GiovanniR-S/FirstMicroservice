using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Model.Context {
    public class MySqlContext: DbContext {
        public MySqlContext () {}
        public MySqlContext (DbContextOptions<MySqlContext> options) : base(options) {}
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Product>().HasData(new Product {
                Id = 2,
                Name = "Name",
                Price = new decimal(69.9),
                Description = "Description",
                ImageUrl   = "",
                Category_Name = "Category"
            }) ;


        }
    }
}
