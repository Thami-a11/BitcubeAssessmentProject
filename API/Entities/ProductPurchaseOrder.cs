using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Controllers.Entities
{
    public class ProductPurchaseOrder
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string ProductType { get; set; }
        public int NumItems { get; set; }
        public ICollection<ProductPrice> ProductPrices { get; set; }

        [JsonIgnore]
        public InventorySummary InventorySummary { get; set; }    
        public ICollection<InventoryItemSummary> ItemSummaries { get; set; }

    }
}