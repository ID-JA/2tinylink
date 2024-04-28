using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class ProjectInviteEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_AppUserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AppUserId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e938925c-0039-4dda-8cbd-a4a8fbbf8f76"));

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "InviteCode",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProjectInvitations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectInvitations",
                table: "ProjectInvitations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectUsers",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AppUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUsers", x => new { x.AppUserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastModified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("80313d43-5e80-4611-98e8-dfa4d20b3a47"), 0, "4116dc76-959d-45c7-a19c-277b30177583", new DateTime(2024, 4, 28, 10, 40, 2, 863, DateTimeKind.Local).AddTicks(2166), "user.demo@2tinylink.com", true, "User", true, new DateTime(2024, 4, 28, 10, 40, 2, 863, DateTimeKind.Local).AddTicks(2247), "Demo", false, null, "USER.DEMO@2TINYLINK.COM", "DEMO", "AQAAAAIAAYagAAAAEMztjScCDiLZIFvza46C09rGMA/qysPLbpCKkUsquHU4wapNMfpgFnyDfBbtflQ8Lw==", null, false, null, false, "Demo" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_ProjectId",
                table: "ProjectUsers",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectInvitations",
                table: "ProjectInvitations");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80313d43-5e80-4611-98e8-dfa4d20b3a47"));

            migrationBuilder.DropColumn(
                name: "InviteCode",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectInvitations");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastModified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e938925c-0039-4dda-8cbd-a4a8fbbf8f76"), 0, "029035ba-07fc-44c3-8d14-e337f0392f86", new DateTime(2024, 4, 27, 1, 3, 19, 432, DateTimeKind.Local).AddTicks(2300), "user.demo@2tinylink.com", true, "User", true, new DateTime(2024, 4, 27, 1, 3, 19, 432, DateTimeKind.Local).AddTicks(2383), "Demo", false, null, "USER.DEMO@2TINYLINK.COM", "DEMO", "AQAAAAIAAYagAAAAEPO2uRDhBX3ySEPtdgdP7h/CSQYGkDMc6cmQgi1qv7Q9f3Hpp5rLtkW4pVE9ysATqw==", null, false, null, false, "Demo" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AppUserId",
                table: "Projects",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_AppUserId",
                table: "Projects",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
