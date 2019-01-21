using Domain.Entities;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class MobiERPDbContext : DbContext
    {
        public MobiERPDbContext()
            : base("DefaultConnection")
        {

        }
      
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UOM> UOM { get; set; }
        public DbSet<ProducsCategory> ProducsCategory { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesOrderLine> SalesOrderLine { get; set; }
        public DbSet<Partner> Partners { get; set; }
    }
}
