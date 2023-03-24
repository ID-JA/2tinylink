using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LinkToTinyLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LINKS");

            migrationBuilder.CreateTable(
                name: "TINY_LINKS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tiny = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LockHash = table.Column<string>(type: "TEXT", nullable: true),
                    LockSalt = table.Column<string>(type: "TEXT", nullable: true),
                    AppUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TINY_LINKS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TINY_LINKS_APP_USERS_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "APP_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TINY_LINKS_AppUserId",
                table: "TINY_LINKS",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TINY_LINKS");

            migrationBuilder.CreateTable(
                name: "LINKS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AppUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ExpiredAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LockHash = table.Column<string>(type: "TEXT", nullable: true),
                    LockSalt = table.Column<string>(type: "TEXT", nullable: true),
                    OriginalUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Uri = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LINKS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LINKS_APP_USERS_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "APP_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LINKS_AppUserId",
                table: "LINKS",
                column: "AppUserId");
        }
    }
}
