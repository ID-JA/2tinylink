using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipLinkAppUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "LINKS",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LINKS_AppUserId",
                table: "LINKS",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LINKS_APP_USERS_AppUserId",
                table: "LINKS",
                column: "AppUserId",
                principalTable: "APP_USERS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LINKS_APP_USERS_AppUserId",
                table: "LINKS");

            migrationBuilder.DropIndex(
                name: "IX_LINKS_AppUserId",
                table: "LINKS");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "LINKS");
        }
    }
}
