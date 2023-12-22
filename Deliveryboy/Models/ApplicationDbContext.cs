using Microsoft.EntityFrameworkCore.Tools;
using Deliveryboy.Models;

namespace Deliveryboy.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
    }
}
