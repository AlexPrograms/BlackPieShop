using Microsoft.EntityFrameworkCore;

namespace BlackPieShop.Models
{
    public class BlackPieDbContext : DbContext
    {
        public BlackPieDbContext()
        {
        }
        public BlackPieDbContext(DbContextOptions<BlackPieDbContext> options) : base(options)
        {           
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }

    }
}
