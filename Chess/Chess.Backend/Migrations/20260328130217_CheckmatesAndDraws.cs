using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthSample.Backend.Migrations
{
    /// <inheritdoc />
    public partial class CheckmatesAndDraws : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCheckmate",
                table: "Moves",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraw",
                table: "Moves",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckmate",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "IsDraw",
                table: "Moves");
        }
    }
}
