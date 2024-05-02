using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_MLD.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Department_Subject_department_id",
                table: "Department_Subject",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Subject_subject_id",
                table: "Department_Subject",
                column: "subject_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Subject_Specialized Department",
                table: "Department_Subject",
                column: "department_id",
                principalTable: "Specialized Department",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Subject_Subject",
                table: "Department_Subject",
                column: "subject_id",
                principalTable: "Subject",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Subject_Specialized Department",
                table: "Department_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Subject_Subject",
                table: "Department_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Department_Subject_department_id",
                table: "Department_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Department_Subject_subject_id",
                table: "Department_Subject");
        }
    }
}
