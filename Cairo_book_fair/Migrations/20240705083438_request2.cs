using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cairo_book_fair.Migrations
{
    /// <inheritdoc />
    public partial class request2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "eb762213-1d37-49d2-b2ba-db9770352bd8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb762213-1d37-49d2-b2ba-db9770352bd8");

            migrationBuilder.AddColumn<int>(
                name: "UsedBookId",
                table: "UsedBookRequests",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDate", "Location", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "NumberOfDonatedBooks", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImage", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cf6d8646-227e-43a3-a097-f6c02c2fda41", 0, "Hello", "96452f6c-9524-4d65-adbd-f6f5ca30a40b", "admin@example.com", true, new DateTime(2024, 7, 5, 11, 34, 37, 539, DateTimeKind.Local).AddTicks(116), "", false, null, "", "ADMIN@EXAMPLE.COM", "ADMIN", 0, "AQAAAAIAAYagAAAAECGPih7gOsGrCLCMfGKUYZfG+M3y/+XoGtNLx/0tHad0M4/j2xuPQIj9fBRBrULrIA==", null, false, "default", "c0d0abce-a9ce-4bf2-8787-55d1350c7c8d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "cf6d8646-227e-43a3-a097-f6c02c2fda41" });

            migrationBuilder.CreateIndex(
                name: "IX_UsedBookRequests_UsedBookId",
                table: "UsedBookRequests",
                column: "UsedBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsedBookRequests_UsedBooks_UsedBookId",
                table: "UsedBookRequests",
                column: "UsedBookId",
                principalTable: "UsedBooks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsedBookRequests_UsedBooks_UsedBookId",
                table: "UsedBookRequests");

            migrationBuilder.DropIndex(
                name: "IX_UsedBookRequests_UsedBookId",
                table: "UsedBookRequests");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "cf6d8646-227e-43a3-a097-f6c02c2fda41" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf6d8646-227e-43a3-a097-f6c02c2fda41");

            migrationBuilder.DropColumn(
                name: "UsedBookId",
                table: "UsedBookRequests");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDate", "Location", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "NumberOfDonatedBooks", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImage", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eb762213-1d37-49d2-b2ba-db9770352bd8", 0, "Hello", "e5737fb2-5e1f-4efd-9cc0-e3d71f58dcd1", "admin@example.com", true, new DateTime(2024, 7, 5, 10, 54, 21, 325, DateTimeKind.Local).AddTicks(2317), "", false, null, "", "ADMIN@EXAMPLE.COM", "ADMIN", 0, "AQAAAAIAAYagAAAAEDCHoGfhuZI3a2RUH15n2U2xS7xm1T7Qqf8r2CHWcHTbArP3tYy+5c41bIP3Cr3VXg==", null, false, "default", "aabd163c-6080-43fb-bdbf-7fc0dacba7db", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "eb762213-1d37-49d2-b2ba-db9770352bd8" });
        }
    }
}
