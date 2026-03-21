using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthSample.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddMoveCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Move_Matches_MatchId",
                table: "Move");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Move",
                table: "Move");

            migrationBuilder.RenameTable(
                name: "Move",
                newName: "Moves");

            migrationBuilder.RenameIndex(
                name: "IX_Move_MatchId",
                table: "Moves",
                newName: "IX_Moves_MatchId");

            migrationBuilder.AddColumn<int>(
                name: "MoveCount",
                table: "Moves",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moves",
                table: "Moves",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Matches_MatchId",
                table: "Moves",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Matches_MatchId",
                table: "Moves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Moves",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "MoveCount",
                table: "Moves");

            migrationBuilder.RenameTable(
                name: "Moves",
                newName: "Move");

            migrationBuilder.RenameIndex(
                name: "IX_Moves_MatchId",
                table: "Move",
                newName: "IX_Move_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Move",
                table: "Move",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Move_Matches_MatchId",
                table: "Move",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
