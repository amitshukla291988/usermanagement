using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagement.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeededa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07876eba-50d4-4906-a610-ee46a391ae43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a2b04be-67a8-4975-9909-23170846961f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e57c810-60ff-47c0-9ecd-1b051ef6a98f", "2", "HR", "HR" },
                    { "86c053ad-5391-4d22-ac42-37a9974d12f6", "2", "User", "User" },
                    { "a60ff2c2-7851-4a1c-b9ea-12e0c5d1e918", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e57c810-60ff-47c0-9ecd-1b051ef6a98f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86c053ad-5391-4d22-ac42-37a9974d12f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a60ff2c2-7851-4a1c-b9ea-12e0c5d1e918");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07876eba-50d4-4906-a610-ee46a391ae43", "2", "User", "User" },
                    { "6a2b04be-67a8-4975-9909-23170846961f", "1", "Admin", "Admin" }
                });
        }
    }
}
