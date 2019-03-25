using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApi.Migrations
{
    public partial class AddUserIdToAuthorBook2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Users_userId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_userId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Books",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_userId",
                table: "Books",
                newName: "IX_Books_UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Authors",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_userId",
                table: "Authors",
                newName: "IX_Authors_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Users_UserId",
                table: "Authors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_UserId",
                table: "Books",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Users_UserId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_UserId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Books",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_UserId",
                table: "Books",
                newName: "IX_Books_userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Authors",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_UserId",
                table: "Authors",
                newName: "IX_Authors_userId");

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
    }
}
