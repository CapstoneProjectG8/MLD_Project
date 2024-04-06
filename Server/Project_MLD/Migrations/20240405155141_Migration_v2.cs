using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_MLD.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phu Luc 5_User",
                table: "Document 5");

            migrationBuilder.RenameColumn(
                name: "evaluate_by",
                table: "Document 5",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document 5_evaluate_by",
                table: "Document 5",
                newName: "IX_Document 5_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 5_User",
                table: "Document 5",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document 5_User",
                table: "Document 5");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Document 5",
                newName: "evaluate_by");

            migrationBuilder.RenameIndex(
                name: "IX_Document 5_user_id",
                table: "Document 5",
                newName: "IX_Document 5_evaluate_by");

            migrationBuilder.AddForeignKey(
                name: "FK_Phu Luc 5_User",
                table: "Document 5",
                column: "evaluate_by",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
