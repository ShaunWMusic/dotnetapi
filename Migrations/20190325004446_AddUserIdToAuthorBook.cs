using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApi.Migrations
{
    public partial class AddUserIdToAuthorBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Books",
                nullable: false,
                defaultValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Authors",
                nullable: false,
                defaultValue: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Books_userId",
                table: "Books",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_userId",
                table: "Authors",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Users_userId",
                table: "Authors",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_userId",
                table: "Books",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Users_userId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_userId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_userId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_userId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
