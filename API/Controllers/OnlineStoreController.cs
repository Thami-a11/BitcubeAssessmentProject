using System.Threading.Tasks;
using API.Controllers.Entities;
using API.interfaces;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    public class OnlineStoreController : BaseApiController
    {
        private readonly IOnlineStore _onlineStore;
        public OnlineStoreController(IOnlineStore onlineStore)
        {
            _onlineStore = onlineStore;

        }

        [HttpPost("AddToInventory")]
        public async Task<ActionResult<ProductPurchaseOrder>> AddProducts(ProductPurchaseOrder purchaseOrder)
        {
            _onlineStore.AddProductsToInventory(purchaseOrder);

            if (await _onlineStore.SaveAllAsync()) return Ok(purchaseOrder);

            return BadRequest("Error adding item");
        }

        [HttpPost("AddPrice")]
        public async Task<ActionResult<ProductPrice>> AddPrice(ProductPrice productPrice)
        {
            _onlineStore.AddPrice(productPrice);

            if (await _onlineStore.SaveAllAsync()) return Ok(productPrice);

            return BadRequest("Error adding item");
        }

        [HttpPost("SellItem")]
        public async Task<ActionResult<ProductSoldResults>> SellProducts(ProductsSellOrder itemSold)
        {
            var solditems = _onlineStore.SellProductFromInventory(itemSold);

            if (await _onlineStore.SaveAllAsync()) return Ok(solditems);

            return BadRequest(solditems.Message);
        }

        [HttpGet("GetItemSummary")]
        public InventoryItemSummary GetItemSummary(ProductType stockType)
        {
            return _onlineStore.GetInventoryItemSummary(stockType);
        }

        [HttpGet("GetSummary")]
        public InventorySummary GetSummary()
        {
            return _onlineStore.GetInventorySummary();
        }

    }


}