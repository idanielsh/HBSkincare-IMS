using Microsoft.EntityFrameworkCore.Migrations;

namespace HBSkincare.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CurrentInventory",
                table: "RawMaterialItem",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CurrentInventory",
                table: "RawMaterialItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
