using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_MLD.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Document1_TeachingEquipment_document1_id",
                table: "Document1_TeachingEquipment");

            migrationBuilder.DropIndex(
                name: "IX_Document1_Subject Room_subject_room_id",
                table: "Document1_Subject Room");

            migrationBuilder.DropIndex(
                name: "IX_Document1_SelectedTopics_document1_id",
                table: "Document1_SelectedTopics");

            migrationBuilder.DropIndex(
                name: "IX_Document1_CurriculumDistribution_document1_id",
                table: "Document1_CurriculumDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "teaching_equipment_id",
                table: "Document1_TeachingEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "document1_id",
                table: "Document1_TeachingEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "subject_room_id",
                table: "Document1_Subject Room",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "document1_id",
                table: "Document1_Subject Room",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "selected_topics_id",
                table: "Document1_SelectedTopics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "document1_id",
                table: "Document1_SelectedTopics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document1_TeachingEquipment",
                table: "Document1_TeachingEquipment",
                columns: new[] { "document1_id", "teaching_equipment_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document1_Subject Room",
                table: "Document1_Subject Room",
                columns: new[] { "subject_room_id", "document1_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document1_SelectedTopics",
                table: "Document1_SelectedTopics",
                columns: new[] { "document1_id", "selected_topics_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document1_CurriculumDistribution",
                table: "Document1_CurriculumDistribution",
                columns: new[] { "document1_id", "curriculum_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Document1_TeachingEquipment",
                table: "Document1_TeachingEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document1_Subject Room",
                table: "Document1_Subject Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document1_SelectedTopics",
                table: "Document1_SelectedTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document1_CurriculumDistribution",
                table: "Document1_CurriculumDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "teaching_equipment_id",
                table: "Document1_TeachingEquipment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "document1_id",
                table: "Document1_TeachingEquipment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "document1_id",
                table: "Document1_Subject Room",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "subject_room_id",
                table: "Document1_Subject Room",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "selected_topics_id",
                table: "Document1_SelectedTopics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "document1_id",
                table: "Document1_SelectedTopics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_TeachingEquipment_document1_id",
                table: "Document1_TeachingEquipment",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_Subject Room_subject_room_id",
                table: "Document1_Subject Room",
                column: "subject_room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_SelectedTopics_document1_id",
                table: "Document1_SelectedTopics",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_CurriculumDistribution_document1_id",
                table: "Document1_CurriculumDistribution",
                column: "document1_id");
        }
    }
}
