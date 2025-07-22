using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a3d9445-b3bb-45af-923e-6c9a60897a4c"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDVUQ30YB5tOClcClcXQ7w8G7NyIXwX7ZkjOzVxN4pjHu8/ixuLSExS7Oqd7f+fosg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a3d9445-b3bb-45af-923e-6c9a60897a4c"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEAGwZeqqUuR5X1kcmNbxwyTWxg2VDSnKdFTIFBQrQe5J/UTwcPlFFe6VkMa+yAmKgQ==");
        }
    }
}
