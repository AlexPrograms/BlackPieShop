using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlackPieShop.Models
{
    public class BlackPieDbContext : IdentityDbContext
    {
        public BlackPieDbContext()
        {
        }
        public BlackPieDbContext(DbContextOptions<BlackPieDbContext> options) : base(options)
        {           
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

	}
}
