using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cairo_book_fair.Migrations
{
    /// <inheritdoc />
    public partial class usdReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "396e948d-0649-4629-a441-7b6d8ab54cfc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "396e948d-0649-4629-a441-7b6d8ab54cfc");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "UsedBookRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedAt",
                table: "UsedBookRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDate", "Location", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "NumberOfDonatedBooks", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImage", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "31c9ea10-72a4-4c14-84fd-b67a120a937e", 0, "Hello", "34db1ef9-6d08-44f7-999b-af256b0a12e0", "admin@example.com", true, new DateTime(2024, 7, 7, 15, 0, 33, 128, DateTimeKind.Local).AddTicks(1141), "", false, null, "", "ADMIN@EXAMPLE.COM", "ADMIN", 0, "AQAAAAIAAYagAAAAEDNqNXWfOff+4HCkLGIc1hUjpUOCekZbI/6W+D2u0G2Q5RgDClnzSFp2EiBc1EDoFA==", null, false, "default", "aa56dbe8-e32f-4e18-814c-d396c2b956cf", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "31c9ea10-72a4-4c14-84fd-b67a120a937e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "31c9ea10-72a4-4c14-84fd-b67a120a937e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31c9ea10-72a4-4c14-84fd-b67a120a937e");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "UsedBookRequests");

            migrationBuilder.DropColumn(
                name: "ReviewedAt",
                table: "UsedBookRequests");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDate", "Location", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "NumberOfDonatedBooks", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImage", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "396e948d-0649-4629-a441-7b6d8ab54cfc", 0, "Hello", "158cd2f6-d1b1-4580-9769-0e0633931975", "admin@example.com", true, new DateTime(2024, 7, 6, 16, 5, 15, 662, DateTimeKind.Local).AddTicks(9609), "", false, null, "", "ADMIN@EXAMPLE.COM", "ADMIN", 0, "AQAAAAIAAYagAAAAEH63cePYXptht5KeFY+lYJO+AN7jji+i4Ng/04PcwQSfVpmacICMV2ozHYhoL58S1g==", null, false, "default", "557bd8e4-8155-4e75-8d6b-74e003fe8717", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "396e948d-0649-4629-a441-7b6d8ab54cfc" });
        }
    }
}
