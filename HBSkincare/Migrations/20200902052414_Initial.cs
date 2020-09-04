using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HBSkincare.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(nullable: true),
                    ValueInCad = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterialItem",
                columns: table => new
                {
                    RawMaterialItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inci = table.Column<string>(nullable: true),
                    CurrentInventory = table.Column<int>(nullable: false),
                    UnitOfMeasure = table.Column<string>(nullable: true),
                    CostPerUnit = table.Column<double>(nullable: false),
                    LandedCostPerUnit = table.Column<double>(nullable: false),
                    YearEndInventoryWithScrap = table.Column<double>(nullable: false),
                    YearEndInventoryNoScrap = table.Column<double>(nullable: false),
                    LandedCost = table.Column<double>(nullable: false),
                    ScrapValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialItem", x => x.RawMaterialItemId);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterialPurchase",
                columns: table => new
                {
                    RawMaterialPurchaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseSize = table.Column<double>(nullable: false),
                    CurrentInventory = table.Column<double>(nullable: false),
                    CostPerUnit = table.Column<double>(nullable: false),
                    LandedCostPerUnit = table.Column<double>(nullable: false),
                    UnitOfMeasure = table.Column<string>(nullable: true),
                    Gst = table.Column<double>(nullable: false),
                    Pst = table.Column<double>(nullable: false),
                    DateRecieved = table.Column<DateTime>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true),
                    SupplierSku = table.Column<string>(nullable: true),
                    LotNumber = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: true),
                    OrderNum = table.Column<string>(nullable: true),
                    Shipping = table.Column<double>(nullable: false),
                    LandedCost = table.Column<double>(nullable: false),
                    BrokerageFees = table.Column<double>(nullable: false),
                    ForexRate = table.Column<double>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    CashOutDate = table.Column<DateTime>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: true),
                    RawMaterialItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialPurchase", x => x.RawMaterialPurchaseId);
                    table.ForeignKey(
                        name: "FK_RawMaterialPurchase_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RawMaterialPurchase_RawMaterialItem_RawMaterialItemId",
                        column: x => x.RawMaterialItemId,
                        principalTable: "RawMaterialItem",
                        principalColumn: "RawMaterialItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialPurchase_CurrencyId",
                table: "RawMaterialPurchase",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialPurchase_RawMaterialItemId",
                table: "RawMaterialPurchase",
                column: "RawMaterialItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawMaterialPurchase");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "RawMaterialItem");
        }
    }
}
