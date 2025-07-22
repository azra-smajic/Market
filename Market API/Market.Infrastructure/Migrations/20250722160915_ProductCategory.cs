using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MarketId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "MarketId", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("07c3ed5a-b793-47e2-a692-aad7a32fa0f6"), new DateTime(2025, 4, 13, 1, 22, 18, 866, DateTimeKind.Utc), false, new Guid("c2f491f6-6789-4f28-b5aa-3fbbd9e3bfb4"), null, "Računar" },
                    { new Guid("d72c9db6-8a88-4247-a22d-e24d2509e457"), new DateTime(2025, 4, 13, 1, 22, 18, 866, DateTimeKind.Utc), false, new Guid("c2f491f6-6789-4f28-b5aa-3fbbd9e3bfb4"), null, "Telefon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_MarketId",
                table: "ProductCategories",
                column: "MarketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
