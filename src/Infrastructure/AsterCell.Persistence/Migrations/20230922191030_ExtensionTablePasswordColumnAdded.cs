using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsterCell.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExtensionTablePasswordColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "extensions",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "extensions");
        }
    }
}
