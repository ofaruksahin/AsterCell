using Microsoft.EntityFrameworkCore.Migrations;

namespace AsterCell.AuthorizationServer.Infrastructure.Migrations
{
    public partial class UserTableIsMasterColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMaster",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMaster",
                table: "AspNetUsers");
        }
    }
}
