using System.Text.Json.Serialization;

namespace API.Controllers.Entities
{
    public class InventoryItemSummary
    {
        public int Id { get; set; }
        public decimal AvgPrice { get; set; }
        public int NumItems { get; set; }
        public int ProductPurchaseOrderId { get; set; }   
        [JsonIgnore]
        public ProductPurchaseOrder Products { get; set; }
    }
}