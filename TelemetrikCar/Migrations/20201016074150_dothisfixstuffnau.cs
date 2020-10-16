using Microsoft.EntityFrameworkCore.Migrations;

namespace TelemetrikCar.Migrations
{
    public partial class dothisfixstuffnau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCar",
                table: "Telemetrik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idCar",
                table: "Telemetrik");
        }
    }
}
