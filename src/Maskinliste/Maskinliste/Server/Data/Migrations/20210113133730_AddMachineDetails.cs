using Microsoft.EntityFrameworkCore.Migrations;

namespace Maskinliste.Server.Data.Migrations
{
    public partial class AddMachineDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Machines");
        }
    }
}
