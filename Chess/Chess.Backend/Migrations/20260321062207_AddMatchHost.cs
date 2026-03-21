using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthSample.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchHost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HostId",
                table: "Matches",
                type: "uuid",
                nullable: false);
                //defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HostId",
                table: "Matches",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_HostId",
                table: "Matches",
                column: "HostId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_HostId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_HostId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HostId",
                table: "Matches");
        }
    }
}
