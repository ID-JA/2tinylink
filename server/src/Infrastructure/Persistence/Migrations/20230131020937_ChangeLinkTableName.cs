using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLinkTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ExpiredAt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "LockHash",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "LockSalt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "OriginalUrl",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "URI",
                table: "BaseEntity");

            migrationBuilder.CreateTable(
                name: "LINKS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OriginalUrl = table.Column<string>(type: "TEXT", nullable: false),
                    URI = table.Column<string>(type: "TEXT", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LockHash = table.Column<string>(type: "TEXT", nullable: true),
                    LockSalt = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LINKS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LINKS_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LINKS");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredAt",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LockHash",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LockSalt",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalUrl",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URI",
                table: "BaseEntity",
                type: "TEXT",
                nullable: true);
        }
    }
}
