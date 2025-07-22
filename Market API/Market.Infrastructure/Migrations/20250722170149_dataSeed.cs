using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "ApplicationUserId",
                keyValue: new Guid("bd355245-000f-48cf-bfdb-46d26d637320"),
                column: "MarketId",
                value: new Guid("c2f491f6-6789-4f28-b5aa-3fbbd9e3bfb4"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "ApplicationUserId",
                keyValue: new Guid("bd355245-000f-48cf-bfdb-46d26d637320"),
                column: "MarketId",
                value: null);
        }
    }
}
