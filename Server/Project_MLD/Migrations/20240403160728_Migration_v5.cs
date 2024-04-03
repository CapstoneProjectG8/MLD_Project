using System;
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
            migrationBuilder.DropTable(
                name: "Document3_CurriculumDistribution");

            migrationBuilder.RenameColumn(
                name: "specialized_team_id",
                table: "User",
                newName: "specialized_department_id");

            migrationBuilder.RenameIndex(
                name: "IX_User_specialized_team_id",
                table: "User",
                newName: "IX_User_specialized_department_id");

            migrationBuilder.RenameColumn(
                name: "curruculum_id",
                table: "Document1_CurriculumDistribution",
                newName: "curriculum_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_CurriculumDistribution_curruculum_id",
                table: "Document1_CurriculumDistribution",
                newName: "IX_Document1_CurriculumDistribution_curriculum_id");

            migrationBuilder.AlterColumn<string>(
                name: "created_by",
                table: "Account",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "specialized_department_id",
                table: "User",
                newName: "specialized_team_id");

            migrationBuilder.RenameIndex(
                name: "IX_User_specialized_department_id",
                table: "User",
                newName: "IX_User_specialized_team_id");

            migrationBuilder.RenameColumn(
                name: "curriculum_id",
                table: "Document1_CurriculumDistribution",
                newName: "curruculum_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_CurriculumDistribution_curriculum_id",
                table: "Document1_CurriculumDistribution",
                newName: "IX_Document1_CurriculumDistribution_curruculum_id");

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Account",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Document3_CurriculumDistribution",
                columns: table => new
                {
                    curriculum_id = table.Column<int>(type: "int", nullable: true),
                    document3_id = table.Column<int>(type: "int", nullable: true),
                    teaching_equipment_id = table.Column<int>(type: "int", nullable: false),
                    place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_khgdGV - ppct_Kế hoạch giáo dục của GV",
                        column: x => x.document3_id,
                        principalTable: "Document 3",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_khgdGV - ppct_Phân phối chương trình",
                        column: x => x.curriculum_id,
                        principalTable: "Curriculum Distribution",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_khgdGV - ppct_Thiết bị dậy học",
                        column: x => x.teaching_equipment_id,
                        principalTable: "Teaching Equipment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document3_CurriculumDistribution_curriculum_id",
                table: "Document3_CurriculumDistribution",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document3_CurriculumDistribution_document3_id",
                table: "Document3_CurriculumDistribution",
                column: "document3_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document3_CurriculumDistribution_teaching_equipment_id",
                table: "Document3_CurriculumDistribution",
                column: "teaching_equipment_id");
        }
    }
}
