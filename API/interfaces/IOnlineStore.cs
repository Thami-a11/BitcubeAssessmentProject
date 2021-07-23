using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers.Entities;
using API.DTOs;

namespace API.interfaces
{
    public interface IOnlineStore
    {
        void AddProductsToInventory(ProductPurchaseOrder purchaseOrder);
        void AddPrice(ProductPrice productPrice);
        ProductSoldResults SellProductFromInventory(ProductsSellOrder itemsSoldOrder);
        InventoryItemSummary GetInventoryItemSummary(ProductType StockType);
        InventorySummary GetInventorySummary();
        
        Task<bool> SaveAllAsync();
    }
}