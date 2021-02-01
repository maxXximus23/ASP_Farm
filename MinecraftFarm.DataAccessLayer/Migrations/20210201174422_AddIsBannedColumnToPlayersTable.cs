using Microsoft.EntityFrameworkCore.Migrations;

namespace MinecraftFarm.DataAccessLayer.Migrations
{
    public partial class AddIsBannedColumnToPlayersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBanned",
                table: "Players");
        }
    }
}
