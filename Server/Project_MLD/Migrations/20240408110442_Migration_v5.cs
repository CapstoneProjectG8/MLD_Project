using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_MLD.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Periodic Assessment_testing_category_id",
                table: "Periodic Assessment");

            migrationBuilder.DropIndex(
                name: "IX_Document2_Grade_document2_id",
                table: "Document2_Grade");

            migrationBuilder.AlterColumn<int>(
                name: "testing_category_id",
                table: "Periodic Assessment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "form_category_id",
                table: "Periodic Assessment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "document1_id",
                table: "Periodic Assessment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "grade_id",
                table: "Document2_Grade",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "document2_id",
                table: "Document2_Grade",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Periodic Assessment",
                table: "Periodic Assessment",
                columns: new[] { "testing_category_id", "form_category_id", "document1_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document2_Grade",
                table: "Document2_Grade",
                columns: new[] { "document2_id", "grade_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Periodic Assessment",
                table: "Periodic Assessment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document2_Grade",
                table: "Document2_Grade");

            migrationBuilder.AlterColumn<int>(
                name: "document1_id",
                table: "Periodic Assessment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "form_category_id",
                table: "Periodic Assessment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "testing_category_id",
                table: "Periodic Assessment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "grade_id",
                table: "Document2_Grade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "document2_id",
                table: "Document2_Grade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Periodic Assessment_testing_category_id",
                table: "Periodic Assessment",
                column: "testing_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document2_Grade_document2_id",
                table: "Document2_Grade",
                column: "document2_id");
        }
    }
}
