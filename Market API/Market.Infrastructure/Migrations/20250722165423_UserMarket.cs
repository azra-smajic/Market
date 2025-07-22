using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserMarket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MarketId",
                table: "Person",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedAt", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("bd355245-000f-48cf-bfdb-46d26d637320"), 0, "9547f983-1707-49d3-9390-5ec84ec35dca", new DateTime(2025, 4, 13, 1, 22, 18, 866, DateTimeKind.Utc), "market1.admin@gmail.ba", true, false, false, null, null, "MARKET1.ADMIN@GMAIL.BA", "MARKET1.ADMIN@GMAIL.BA", "AQAAAAIAAYagAAAAEDVUQ30YB5tOClcClcXQ7w8G7NyIXwX7ZkjOzVxN4pjHu8/ixuLSExS7Oqd7f+fosg==", null, false, null, false, "market1.admin@gmail.ba" });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "ApplicationUserId",
                keyValue: new Guid("1a3d9445-b3bb-45af-923e-6c9a60897a4c"),
                column: "MarketId",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "ModifiedAt", "RoleId", "UserId" },
                values: new object[] { new Guid("699d3d05-e038-49bf-8c54-0509372a6e6c"), new DateTime(2025, 4, 13, 1, 22, 18, 866, DateTimeKind.Utc), false, null, new Guid("894f6287-bb05-455e-839e-b9674a9f367c"), new Guid("bd355245-000f-48cf-bfdb-46d26d637320") });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "ApplicationUserId", "Address", "AlternativePhoneNumber", "CreatedAt", "DateOfBirth", "FirstName", "Gender", "IsDeleted", "LastName", "MarketId", "ModifiedAt", "ProfilePhoto", "ProfilePhotoThumbnail" },
                values: new object[] { new Guid("bd355245-000f-48cf-bfdb-46d26d637320"), "Mostar 19", null, new DateTime(2025, 4, 13, 1, 22, 18, 866, DateTimeKind.Utc), null, "Azra", "F", false, "Smajic", null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Person_MarketId",
                table: "Person",
                column: "MarketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Markets_MarketId",
                table: "Person",
                column: "MarketId",
                principalTable: "Markets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Markets_MarketId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_MarketId",
                table: "Person");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("699d3d05-e038-49bf-8c54-0509372a6e6c"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "ApplicationUserId",
                keyValue: new Guid("bd355245-000f-48cf-bfdb-46d26d637320"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd355245-000f-48cf-bfdb-46d26d637320"));

            migrationBuilder.DropColumn(
                name: "MarketId",
                table: "Person");
        }
    }
}
