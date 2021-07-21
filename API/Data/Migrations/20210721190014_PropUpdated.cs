using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class PropUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventorySummaries_ProductPurchaseOrders_ProductPurchaseOrderId",
                table: "InventorySummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_InventorySummaries_ProductsSellOrders_ProductsSellOrderId",
                table: "InventorySummaries");

            migrationBuilder.DropIndex(
                name: "IX_InventorySummaries_ProductPurchaseOrderId",
                table: "InventorySummaries");

            migrationBuilder.DropIndex(
                name: "IX_InventorySummaries_ProductsSellOrderId",
                table: "InventorySummaries");

            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "ProductPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ProductPurchaseOrderId",
                table: "InventorySummaries");

            migrationBuilder.DropColumn(
                name: "ProductsSellOrderId",
                table: "InventorySummaries");

            migrationBuilder.AddColumn<int>(
                name: "InventorySummaryId",
                table: "ProductPurchaseOrders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityPrice",
                table: "ProductPrices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsSellOrderId",
                table: "InventoryItemSummaries",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchaseOrders_InventorySummaryId",
                table: "ProductPurchaseOrders",
                column: "InventorySummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItemSummaries_ProductsSellOrderId",
                table: "InventoryItemSummaries",
                column: "ProductsSellOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItemSummaries_ProductsSellOrders_ProductsSellOrderId",
                table: "InventoryItemSummaries",
                column: "ProductsSellOrderId",
                principalTable: "ProductsSellOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPurchaseOrders_InventorySummaries_InventorySummaryId",
                table: "ProductPurchaseOrders",
                column: "InventorySummaryId",
                principalTable: "InventorySummaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItemSummaries_ProductsSellOrders_ProductsSellOrderId",
                table: "InventoryItemSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchaseOrders_InventorySummaries_InventorySummaryId",
                table: "ProductPurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductPurchaseOrders_InventorySummaryId",
                table: "ProductPurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItemSummaries_ProductsSellOrderId",
                table: "InventoryItemSummaries");

            migrationBuilder.DropColumn(
                name: "InventorySummaryId",
                table: "ProductPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "QuantityPrice",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "ProductsSellOrderId",
                table: "InventoryItemSummaries");

            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "ProductPurchaseOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductPurchaseOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductPurchaseOrderId",
                table: "InventorySummaries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsSellOrderId",
                table: "InventorySummaries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InventorySummaries_ProductPurchaseOrderId",
                table: "InventorySummaries",
                column: "ProductPurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventorySummaries_ProductsSellOrderId",
                table: "InventorySummaries",
                column: "ProductsSellOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventorySummaries_ProductPurchaseOrders_ProductPurchaseOrderId",
                table: "InventorySummaries",
                column: "ProductPurchaseOrderId",
                principalTable: "ProductPurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventorySummaries_ProductsSellOrders_ProductsSellOrderId",
                table: "InventorySummaries",
                column: "ProductsSellOrderId",
                principalTable: "ProductsSellOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
