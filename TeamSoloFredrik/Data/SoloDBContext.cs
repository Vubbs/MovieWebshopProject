using Microsoft.EntityFrameworkCore;
using TeamSoloFredrik.Models.Db;

namespace TeamSoloFredrik.Data
{
    public class SoloDBContext : DbContext
    {
        public SoloDBContext(DbContextOptions options) :base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
    }
}
