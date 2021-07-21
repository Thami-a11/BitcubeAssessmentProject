using System.Text.Json.Serialization;

namespace API.Controllers.Entities
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int QuantityPrice { get; set; }
        public int ProductPurchaseOrderId  { get; set; }
        [JsonIgnore]
        public ProductPurchaseOrder Products { get; set; }
        
    }
}