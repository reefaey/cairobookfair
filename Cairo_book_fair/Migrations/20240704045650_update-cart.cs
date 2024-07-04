using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cairo_book_fair.Migrations
{
    /// <inheritdoc />
    public partial class updatecart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "UsedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonatedBookId",
                table: "BooksCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTakedBooks",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsedBooks_CartId",
                table: "UsedBooks",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksCarts_DonatedBookId",
                table: "BooksCarts",
                column: "DonatedBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCarts_UsedBooks_DonatedBookId",
                table: "BooksCarts",
                column: "DonatedBookId",
                principalTable: "UsedBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UsedBooks_Carts_CartId",
                table: "UsedBooks",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCarts_UsedBooks_DonatedBookId",
                table: "BooksCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_UsedBooks_Carts_CartId",
                table: "UsedBooks");

            migrationBuilder.DropIndex(
                name: "IX_UsedBooks_CartId",
                table: "UsedBooks");

            migrationBuilder.DropIndex(
                name: "IX_BooksCarts_DonatedBookId",
                table: "BooksCarts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "UsedBooks");

            migrationBuilder.DropColumn(
                name: "DonatedBookId",
                table: "BooksCarts");

            migrationBuilder.DropColumn(
                name: "NumberOfTakedBooks",
                table: "AspNetUsers");
        }
    }
}
