using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FromAddressToAlias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b7e9cda2-9a3a-49bf-b924-0eadce58a948"));

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "TINY_LINKS",
                newName: "Alias");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastModified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7233db47-e963-4af4-b352-0c036782f238"), 0, "7b625d8d-20b0-4dce-983b-df707b8cdbd5", new DateTime(2023, 3, 27, 22, 35, 52, 469, DateTimeKind.Local).AddTicks(6178), "user.demo@2tinylink.com", true, "User", true, new DateTime(2023, 3, 27, 22, 35, 52, 469, DateTimeKind.Local).AddTicks(6337), "Demo", false, null, "USER.DEMO@2TINYLINK.COM", "DEMO", "AQAAAAIAAYagAAAAENl/0yBNDRZOQh9+myE/kKmPJBFe8dVBbUrjqznrTWjcS52WAqUXDo6R+pIi/bYUSg==", null, false, null, false, "Demo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7233db47-e963-4af4-b352-0c036782f238"));

            migrationBuilder.RenameColumn(
                name: "Alias",
                table: "TINY_LINKS",
                newName: "Address");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastModified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b7e9cda2-9a3a-49bf-b924-0eadce58a948"), 0, "32177dd5-becc-4a9a-afb1-f613dab03bdc", new DateTime(2023, 3, 8, 4, 8, 8, 993, DateTimeKind.Local).AddTicks(9604), "user.demo@2tinylink.com", true, "User", true, new DateTime(2023, 3, 8, 4, 8, 8, 993, DateTimeKind.Local).AddTicks(9661), "Demo", false, null, "USER.DEMO@2TINYLINK.COM", "DEMO", "AQAAAAIAAYagAAAAENu6zGuaVw7ezRCkT8uBr7eshUMjjuD62RdTaG9nBbdim2wwmHQROOZZnze6T1nSbQ==", null, false, null, false, "Demo" });
        }
    }
}
