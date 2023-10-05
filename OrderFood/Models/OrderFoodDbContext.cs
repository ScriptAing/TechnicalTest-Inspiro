using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OrderFood.Models
{
    public class OrderFoodDbContext : DbContext
    {
        public OrderFoodDbContext(DbContextOptions<OrderFoodDbContext> options) : base(options)
        { }

        public DbSet<Food> Foods { get; set; }

        public DbSet<TempOrderTransaction> TempOrderTrx { get; set; }
        
        public DbSet<OrderTransaction> OrderTrx { get; set; }
    }
}
