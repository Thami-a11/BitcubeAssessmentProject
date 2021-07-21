

using API.Controllers.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductPurchaseOrder> ProductPurchaseOrders { get; set; }
        public DbSet<ProductsSellOrder> ProductsSellOrders { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<InventorySummary> InventorySummaries { get; set; }
        public DbSet<InventoryItemSummary> InventoryItemSummaries { get; set; }



    }
}