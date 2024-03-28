using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TINY_LINKS_AspNetUsers_AppUserId",
                table: "TINY_LINKS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TINY_LINKS",
                table: "TINY_LINKS");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b7e9cda2-9a3a-49bf-b924-0eadce58a948"));

            migrationBuilder.RenameTable(
                name: "TINY_LINKS",
                newName: "Links");

            migrationBuilder.RenameIndex(
                name: "IX_TINY_LINKS_AppUserId",
                table: "Links",
                newName: "IX_Links_AppUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Links",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Links",
                table: "Links",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastModified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("17c3cad7-fc6c-4a27-8ce3-81407f20c62a"), 0, "2ee66bcc-2145-465e-99e4-f5945974cefd", new DateTime(2024, 3, 28, 17, 33, 40, 39, DateTimeKind.Local).AddTicks(599), "user.demo@2tinylink.com", true, "User", true, new DateTime(2024, 3, 28, 17, 33, 40, 39, DateTimeKind.Local).AddTicks(652), "Demo", false, null, "USER.DEMO@2TINYLINK.COM", "DEMO", "AQAAAAIAAYagAAAAELqCMXZ1YEEiB8ElwhDjtUowuMTIli+Y7QDWnXRIkNo2vb9VCA0VdTObaH2NavYvQw==", null, false, null, false, "Demo" });

            migrationBuilder.CreateIndex(
                name: "IX_Links_ProjectId",
                table: "Links",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_AspNetUsers_AppUserId",
                table: "Links",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Projects_ProjectId",
                table: "Links",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_AspNetUsers_AppUserId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Projects_ProjectId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Links",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_ProjectId",
                table: "Links");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("17c3cad7-fc6c-4a27-8ce3-81407f20c62a"));

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Links");

            migrationBuilder.RenameTable(
                name: "Links",
                newName: "TINY_LINKS");

            migrationBuilder.RenameIndex(
                name: "IX_Links_AppUserId",
                table: "TINY_LINKS",
                newName: "IX_TINY_LINKS_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TINY_LINKS",
                table: "TINY_LINKS",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastModified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b7e9cda2-9a3a-49bf-b924-0eadce58a948"), 0, "32177dd5-becc-4a9a-afb1-f613dab03bdc", new DateTime(2023, 3, 8, 4, 8, 8, 993, DateTimeKind.Local).AddTicks(9604), "user.demo@2tinylink.com", true, "User", true, new DateTime(2023, 3, 8, 4, 8, 8, 993, DateTimeKind.Local).AddTicks(9661), "Demo", false, null, "USER.DEMO@2TINYLINK.COM", "DEMO", "AQAAAAIAAYagAAAAENu6zGuaVw7ezRCkT8uBr7eshUMjjuD62RdTaG9nBbdim2wwmHQROOZZnze6T1nSbQ==", null, false, null, false, "Demo" });

            migrationBuilder.AddForeignKey(
                name: "FK_TINY_LINKS_AspNetUsers_AppUserId",
                table: "TINY_LINKS",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
