using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cairo_book_fair.Migrations
{
    /// <inheritdoc />
    public partial class Ticket2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "cf6d8646-227e-43a3-a097-f6c02c2fda41" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf6d8646-227e-43a3-a097-f6c02c2fda41");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Tickets",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Nid",
                table: "Tickets",
                newName: "NID");

            migrationBuilder.AlterColumn<string>(
                name: "NID",
                table: "Tickets",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDate", "Location", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "NumberOfDonatedBooks", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImage", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa518795-6e6b-4228-8be7-19ded644cec0", 0, "Hello", "a12a1b60-884b-47c8-833a-7a17d5a4eb9b", "admin@example.com", true, new DateTime(2024, 7, 5, 11, 53, 44, 638, DateTimeKind.Local).AddTicks(9916), "", false, null, "", "ADMIN@EXAMPLE.COM", "ADMIN", 0, "AQAAAAIAAYagAAAAEA3LXIcqscH/D9CTu3Ei5Z1VceHj7M9vxmBAyvoTG2S1wYHi9GJuLn6OwF3nG++HEQ==", null, false, "default", "09e7a237-8c20-489f-a37d-7db7b5d440f5", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "fa518795-6e6b-4228-8be7-19ded644cec0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "fa518795-6e6b-4228-8be7-19ded644cec0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa518795-6e6b-4228-8be7-19ded644cec0");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Tickets",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "NID",
                table: "Tickets",
                newName: "Nid");

            migrationBuilder.AlterColumn<string>(
                name: "Nid",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "JoinDate", "Location", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "NumberOfDonatedBooks", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImage", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cf6d8646-227e-43a3-a097-f6c02c2fda41", 0, "Hello", "96452f6c-9524-4d65-adbd-f6f5ca30a40b", "admin@example.com", true, new DateTime(2024, 7, 5, 11, 34, 37, 539, DateTimeKind.Local).AddTicks(116), "", false, null, "", "ADMIN@EXAMPLE.COM", "ADMIN", 0, "AQAAAAIAAYagAAAAECGPih7gOsGrCLCMfGKUYZfG+M3y/+XoGtNLx/0tHad0M4/j2xuPQIj9fBRBrULrIA==", null, false, "default", "c0d0abce-a9ce-4bf2-8787-55d1350c7c8d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "cf6d8646-227e-43a3-a097-f6c02c2fda41" });
        }
    }
}
