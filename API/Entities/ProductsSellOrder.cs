using System.Collections.Generic;

namespace API.Controllers.Entities
{
    public class ProductsSellOrder
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string ItemSold { get; set; }
        public int NumItems { get; set; }
        public bool IsSold { get; set; } 
        public ICollection<InventoryItemSummary> ItemSummaries { get; set; }

    }
}