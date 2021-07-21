using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item = table.Column<string>(type: "TEXT", nullable: true),
                    ProductType = table.Column<string>(type: "TEXT", nullable: true),
                    NumItems = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSold = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPurchaseOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItemSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AvgPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumItems = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductPurchaseOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItemSummaries_ProductPurchaseOrders_ProductPurchaseOrderId",
                        column: x => x.ProductPurchaseOrderId,
                        principalTable: "ProductPurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductPurchaseOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrices_ProductPurchaseOrders_ProductPurchaseOrderId",
                        column: x => x.ProductPurchaseOrderId,
                        principalTable: "ProductPurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsSellOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemSold = table.Column<string>(type: "TEXT", nullable: true),
                    NumItems = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductPurchaseOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSellOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsSellOrders_ProductPurchaseOrders_ProductPurchaseOrderId",
                        column: x => x.ProductPurchaseOrderId,
                        principalTable: "ProductPurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventorySummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductPurchaseOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsSellOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventorySummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventorySummaries_ProductPurchaseOrders_ProductPurchaseOrderId",
                        column: x => x.ProductPurchaseOrderId,
                        principalTable: "ProductPurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventorySummaries_ProductsSellOrders_ProductsSellOrderId",
                        column: x => x.ProductsSellOrderId,
                        principalTable: "ProductsSellOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItemSummaries_ProductPurchaseOrderId",
                table: "InventoryItemSummaries",
                column: "ProductPurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventorySummaries_ProductPurchaseOrderId",
                table: "InventorySummaries",
                column: "ProductPurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventorySummaries_ProductsSellOrderId",
                table: "InventorySummaries",
                column: "ProductsSellOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductPurchaseOrderId",
                table: "ProductPrices",
                column: "ProductPurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSellOrders_ProductPurchaseOrderId",
                table: "ProductsSellOrders",
                column: "ProductPurchaseOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItemSummaries");

            migrationBuilder.DropTable(
                name: "InventorySummaries");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "ProductsSellOrders");

            migrationBuilder.DropTable(
                name: "ProductPurchaseOrders");
        }
    }
}
