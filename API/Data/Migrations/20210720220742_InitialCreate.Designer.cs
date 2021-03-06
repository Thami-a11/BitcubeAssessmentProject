// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210720220742_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("API.Controllers.Entities.InventoryItemSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("AvgPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumItems")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductPurchaseOrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductPurchaseOrderId");

                    b.ToTable("InventoryItemSummaries");
                });

            modelBuilder.Entity("API.Controllers.Entities.InventorySummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductPurchaseOrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductsSellOrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductPurchaseOrderId");

                    b.HasIndex("ProductsSellOrderId");

                    b.ToTable("InventorySummaries");
                });

            modelBuilder.Entity("API.Controllers.Entities.ProductPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductPurchaseOrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductPurchaseOrderId");

                    b.ToTable("ProductPrices");
                });

            modelBuilder.Entity("API.Controllers.Entities.ProductPurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSold")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Item")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumItems")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductPurchaseOrders");
                });

            modelBuilder.Entity("API.Controllers.Entities.ProductsSellOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemSold")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumItems")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductPurchaseOrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductPurchaseOrderId");

                    b.ToTable("ProductsSellOrders");
                });

            modelBuilder.Entity("API.Controllers.Entities.InventoryItemSummary", b =>
                {
                    b.HasOne("API.Controllers.Entities.ProductPurchaseOrder", "Products")
                        .WithMany("ItemSummaries")
                        .HasForeignKey("ProductPurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Controllers.Entities.InventorySummary", b =>
                {
                    b.HasOne("API.Controllers.Entities.ProductPurchaseOrder", "Products")
                        .WithMany("InventorySummaries")
                        .HasForeignKey("ProductPurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Controllers.Entities.ProductsSellOrder", "ProductsSold")
                        .WithMany()
                        .HasForeignKey("ProductsSellOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("ProductsSold");
                });

            modelBuilder.Entity("API.Controllers.Entities.ProductPrice", b =>
                {
                    b.HasOne("API.Controllers.Entities.ProductPurchaseOrder", "Products")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductPurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Controllers.Entities.ProductsSellOrder", b =>
                {
                    b.HasOne("API.Controllers.Entities.ProductPurchaseOrder", "Products")
                        .WithMany("productsSellOrders")
                        .HasForeignKey("ProductPurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Controllers.Entities.ProductPurchaseOrder", b =>
                {
                    b.Navigation("InventorySummaries");

                    b.Navigation("ItemSummaries");

                    b.Navigation("ProductPrices");

                    b.Navigation("productsSellOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
