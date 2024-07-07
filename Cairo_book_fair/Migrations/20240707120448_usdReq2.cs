using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cairo_book_fair.Migrations
{
    /// <inheritdoc />
    public partial class usdReq2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "31c9ea10-72a4-4c14-84fd-b67a120a937e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31c9ea10-72a4-4c14-84fd-b67a120a937e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDate", "Location", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "NumberOfDonatedBooks", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImage", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "58248eed-4550-421f-b942-9472a0a8402c", 0, "Hello", "e26fd438-4ff9-49fc-b2bc-7c1c16867a29", "admin@example.com", true, new DateTime(2024, 7, 7, 15, 4, 46, 999, DateTimeKind.Local).AddTicks(2872), "", false, null, "", "ADMIN@EXAMPLE.COM", "ADMIN", 0, "AQAAAAIAAYagAAAAELysLCXztRJ2/ri5/evFnivND+TAmGbhIOn7b8caapOOspgkwgHoI4RDF4YKGC7HNQ==", null, false, "default", "5b5007c3-8952-40ed-90e9-02b8b4fb4290", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "58248eed-4550-421f-b942-9472a0a8402c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "58248eed-4550-421f-b942-9472a0a8402c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "58248eed-4550-421f-b942-9472a0a8402c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDate", "Location", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "NumberOfDonatedBooks", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImage", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "31c9ea10-72a4-4c14-84fd-b67a120a937e", 0, "Hello", "34db1ef9-6d08-44f7-999b-af256b0a12e0", "admin@example.com", true, new DateTime(2024, 7, 7, 15, 0, 33, 128, DateTimeKind.Local).AddTicks(1141), "", false, null, "", "ADMIN@EXAMPLE.COM", "ADMIN", 0, "AQAAAAIAAYagAAAAEDNqNXWfOff+4HCkLGIc1hUjpUOCekZbI/6W+D2u0G2Q5RgDClnzSFp2EiBc1EDoFA==", null, false, "default", "aa56dbe8-e32f-4e18-814c-d396c2b956cf", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "31c9ea10-72a4-4c14-84fd-b67a120a937e" });
        }
    }
}
