using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Markets",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Location", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("c2f491f6-6789-4f28-b5aa-3fbbd9e3bfb4"), new DateTime(2025, 4, 13, 1, 22, 18, 866, DateTimeKind.Utc), false, "Hercegovina", null, "Market 1" },
                    { new Guid("dddd8eaf-6d12-4d53-8315-902f50c65ae1"), new DateTime(2025, 4, 13, 1, 22, 18, 866, DateTimeKind.Utc), false, "Bosna", null, "Market 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Markets");
        }
    }
}