using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateInitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetworkEvents",
                columns: table => new
                {
                    Event_id = table.Column<int>(nullable: false),
                    Switch_Ip = table.Column<string>(nullable: true),
                    Port_id = table.Column<int>(nullable: false),
                    Device_Mac = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkEvents");
        }
    }
}
