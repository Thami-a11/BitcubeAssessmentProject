using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class PropAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsSellOrders_ProductPurchaseOrders_ProductPurchaseOrderId",
                table: "ProductsSellOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductsSellOrders_ProductPurchaseOrderId",
                table: "ProductsSellOrders");

            migrationBuilder.RenameColumn(
                name: "ProductPurchaseOrderId",
                table: "ProductsSellOrders",
                newName: "IsSold");

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "ProductsSellOrders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductPurchaseOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item",
                table: "ProductsSellOrders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductPurchaseOrders");

            migrationBuilder.RenameColumn(
                name: "IsSold",
                table: "ProductsSellOrders",
                newName: "ProductPurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSellOrders_ProductPurchaseOrderId",
                table: "ProductsSellOrders",
                column: "ProductPurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsSellOrders_ProductPurchaseOrders_ProductPurchaseOrderId",
                table: "ProductsSellOrders",
                column: "ProductPurchaseOrderId",
                principalTable: "ProductPurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
