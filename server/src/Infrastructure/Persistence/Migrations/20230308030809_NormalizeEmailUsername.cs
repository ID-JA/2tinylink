using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NormalizeEmailUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d720370a-844a-40c2-9142-f16d9acfa631"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastModified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b7e9cda2-9a3a-49bf-b924-0eadce58a948"), 0, "32177dd5-becc-4a9a-afb1-f613dab03bdc", new DateTime(2023, 3, 8, 4, 8, 8, 993, DateTimeKind.Local).AddTicks(9604), "user.demo@2tinylink.com", true, "User", true, new DateTime(2023, 3, 8, 4, 8, 8, 993, DateTimeKind.Local).AddTicks(9661), "Demo", false, null, "USER.DEMO@2TINYLINK.COM", "DEMO", "AQAAAAIAAYagAAAAENu6zGuaVw7ezRCkT8uBr7eshUMjjuD62RdTaG9nBbdim2wwmHQROOZZnze6T1nSbQ==", null, false, null, false, "Demo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b7e9cda2-9a3a-49bf-b924-0eadce58a948"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastModified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d720370a-844a-40c2-9142-f16d9acfa631"), 0, "296aef19-d17d-4929-9379-537d4579ffae", new DateTime(2023, 3, 8, 3, 28, 26, 597, DateTimeKind.Local).AddTicks(376), "user.demo@2tinylink.com", true, "User", true, new DateTime(2023, 3, 8, 3, 28, 26, 597, DateTimeKind.Local).AddTicks(424), "Demo", false, null, null, null, "AQAAAAIAAYagAAAAECzjJKSxrhKSwscrhfNSl1sgZW+cKr0V9aslvD830UQvtFmmDboaKLk8PkwJyUDp9g==", null, false, null, false, "Demo" });
        }
    }
}
