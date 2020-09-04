using Microsoft.EntityFrameworkCore.Migrations;

namespace HBSkincare.Migrations
{
    public partial class AddedMaterialName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaterialName",
                table: "RawMaterialItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialName",
                table: "RawMaterialItem");
        }
    }
}
