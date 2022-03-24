using Microsoft.EntityFrameworkCore.Migrations;

namespace VendingMachineApplication.Migrations
{
    public partial class addAdressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "VendingMachines",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "VendingMachines");
        }
    }
}
