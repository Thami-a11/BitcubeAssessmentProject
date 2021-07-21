using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Entities;
using API.DTOs;
using API.interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class OnlineStore : IOnlineStore
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public OnlineStore(DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _dataContext = dataContext;

        }
        public void AddProductsToInventory(ProductPurchaseOrder purchaseOrder)
        {
            purchaseOrder.Item = purchaseOrder.Item.ToLower();
            _dataContext.ProductPurchaseOrders.Add(purchaseOrder);
        }

        public InventoryItemSummary GetInventoryItemSummary(ProductType StockType)
        {
            StockType.ProductItemType = StockType.ProductItemType.ToLower();
            // var Summary = _dataContext.InventoryItemSummaries.
            // Include(p => p.Products).AsQueryable();

            var product = _dataContext.ProductPurchaseOrders
                .SingleOrDefault(x => x.Item == StockType.ProductItemType);

            var Prices = _dataContext.ProductPrices
             .Where(x => x.Products == product)
             .FirstOrDefault();

            var Count = _dataContext.ProductPrices
            .Where(x => x.Products == product).AsQueryable();

            var AvgPrice = Prices.Price / Count.Count();

            var item = new InventoryItemSummary
            {
                AvgPrice = AvgPrice,
                NumItems = product.NumItems,
                ProductPurchaseOrderId = product.Id,
                Products = product
            };
            _dataContext.InventoryItemSummaries.Add(item);

            return item;
        }

        public InventorySummary GetInventorySummary()
        {
            var Products = _dataContext.ProductPurchaseOrders.ToList();
            var Summary = new InventorySummary
            {
                Products = Products
            };

            _dataContext.InventorySummaries.Add(Summary);
            return Summary;
        }

        public ProductSoldResults SellProductFromInventory(ProductsSellOrder itemsSoldOrder)
        {
            itemsSoldOrder.Item = itemsSoldOrder.Item.ToLower();
            var product = new ProductPurchaseOrder();
            if (itemsSoldOrder.Item == "laptops" || itemsSoldOrder.Item == "tablets" || itemsSoldOrder.Item == "phones")
            {
                product = _dataContext.ProductPurchaseOrders
                    .SingleOrDefault(x => x.Item == itemsSoldOrder.Item);
            }
            else
            {
                return new ProductSoldResults { Message = "this product is invalid" };
            }

            if (product.Item == null)
            {
                return new ProductSoldResults { Message = "this product is not found" };
            }

            if (product.NumItems < itemsSoldOrder.NumItems)
            {
                return new ProductSoldResults { Message = "this product is not enough in inventory" };
            }


            var ItemInInventory = _dataContext.ProductPurchaseOrders
                .Where(x => x.Item == itemsSoldOrder.Item).FirstOrDefault();

            var price = _dataContext.ProductPrices
            .Where(x => x.ProductPurchaseOrderId == ItemInInventory.Id &&
            x.Products == ItemInInventory).FirstOrDefault();

            ItemInInventory.NumItems = ItemInInventory.NumItems - itemsSoldOrder.NumItems;

            var sold = _dataContext.ProductsSellOrders.Add(itemsSoldOrder);
            Update(ItemInInventory);



            var results = _mapper.Map<ProductsSellOrder, ProductSoldResults>(itemsSoldOrder);
            results.Message = "Sold!!";
            results.ProductType = ItemInInventory.ProductType;
            results.TotalPrice = (price.QuantityPrice / itemsSoldOrder.NumItems) * price.Price;
            return results;
        }
        public void AddPrice(ProductPrice productPrice)
        {
            var product = _dataContext.ProductPurchaseOrders
                .SingleOrDefault(x => x.Id == productPrice.ProductPurchaseOrderId);
            productPrice.Products = product;

            _dataContext.ProductPrices.Add(productPrice);
        }

        private void Update(ProductPurchaseOrder productPurchaseOrder)
        {
            _dataContext.Entry(productPurchaseOrder).State = EntityState.Modified;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }


    }
}