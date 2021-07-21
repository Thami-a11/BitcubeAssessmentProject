using System.Collections.Generic;

namespace API.Controllers.Entities
{
    public class InventorySummary
    {
        public int Id { get; set; }
        public ICollection<ProductPurchaseOrder> Products { get; set; }

    }
}