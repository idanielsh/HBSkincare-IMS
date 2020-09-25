using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HBSkincare.Migrations
{
    public partial class M8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPerUnit",
                table: "RawMaterialItem");

            migrationBuilder.DropColumn(
                name: "CurrentInventory",
                table: "RawMaterialItem");

            migrationBuilder.DropColumn(
                name: "LandedCost",
                table: "RawMaterialItem");

            migrationBuilder.DropColumn(
                name: "LandedCostPerUnit",
                table: "RawMaterialItem");

            migrationBuilder.DropColumn(
                name: "ScrapValue",
                table: "RawMaterialItem");

            migrationBuilder.DropColumn(
                name: "YearEndInventoryNoScrap",
                table: "RawMaterialItem");

            migrationBuilder.DropColumn(
                name: "YearEndInventoryWithScrap",
                table: "RawMaterialItem");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "RawMaterialPurchase",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScrapDate",
                table: "RawMaterialPurchase",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ScrapValue",
                table: "RawMaterialPurchase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "RawMaterialPurchase");

            migrationBuilder.DropColumn(
                name: "ScrapDate",
                table: "RawMaterialPurchase");

            migrationBuilder.DropColumn(
                name: "ScrapValue",
                table: "RawMaterialPurchase");

            migrationBuilder.AddColumn<double>(
                name: "CostPerUnit",
                table: "RawMaterialItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CurrentInventory",
                table: "RawMaterialItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LandedCost",
                table: "RawMaterialItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LandedCostPerUnit",
                table: "RawMaterialItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ScrapValue",
                table: "RawMaterialItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "YearEndInventoryNoScrap",
                table: "RawMaterialItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "YearEndInventoryWithScrap",
                table: "RawMaterialItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
