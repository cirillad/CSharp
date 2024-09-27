using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Books_PreviousBookId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PreviousBookId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsContinuation",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PreviousBookId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "ReservedFor",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReservedFor",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsContinuation",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PreviousBookId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PreviousBookId",
                table: "Books",
                column: "PreviousBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Books_PreviousBookId",
                table: "Books",
                column: "PreviousBookId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
