using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthSample.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AllowForMatchesWithOnePlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Users_BlackId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Users_WhiteId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Move_Match_MatchId",
                table: "Move");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.RenameTable(
                name: "Match",
                newName: "Matches");

            migrationBuilder.RenameIndex(
                name: "IX_Match_WhiteId",
                table: "Matches",
                newName: "IX_Matches_WhiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_BlackId",
                table: "Matches",
                newName: "IX_Matches_BlackId");

            migrationBuilder.AlterColumn<Guid>(
                name: "WhiteId",
                table: "Matches",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "BlackId",
                table: "Matches",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_BlackId",
                table: "Matches",
                column: "BlackId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_WhiteId",
                table: "Matches",
                column: "WhiteId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Move_Matches_MatchId",
                table: "Move",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_BlackId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_WhiteId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Move_Matches_MatchId",
                table: "Move");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Match");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_WhiteId",
                table: "Match",
                newName: "IX_Match_WhiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_BlackId",
                table: "Match",
                newName: "IX_Match_BlackId");

            migrationBuilder.AlterColumn<Guid>(
                name: "WhiteId",
                table: "Match",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BlackId",
                table: "Match",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Users_BlackId",
                table: "Match",
                column: "BlackId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Users_WhiteId",
                table: "Match",
                column: "WhiteId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Move_Match_MatchId",
                table: "Move",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
