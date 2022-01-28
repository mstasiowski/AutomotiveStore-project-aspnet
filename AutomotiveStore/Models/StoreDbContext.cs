using Microsoft.EntityFrameworkCore;


namespace AutomotiveStore.Models
{
  public class StoreDbContext : DbContext
    {
        public StoreDbContext (DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> shoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
