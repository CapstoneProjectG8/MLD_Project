using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_MLD.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document2_Grade_Document 21",
                table: "Document2_Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Document3_CurriculumDistribution_Document 31",
                table: "Document3_CurriculumDistribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Document3_SelectedTopics_Document 31",
                table: "Document3_SelectedTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_Periodic Assessment_Document 1",
                table: "Periodic Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_Periodic Assessment_Form Category",
                table: "Periodic Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_Periodic Assessment_Testing Category",
                table: "Periodic Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_User",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Doc_Category",
                table: "Scorm");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Specialized Department",
                table: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_User_specialized_department_id",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Scorm_category_id",
                table: "Scorm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.DropIndex(
                name: "IX_Report_user_id",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document2_Grade",
                table: "Document2_Grade");

            migrationBuilder.DropColumn(
                name: "active",
                table: "User");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "User");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "User");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "User");

            migrationBuilder.DropColumn(
                name: "modified_date",
                table: "User");

            migrationBuilder.DropColumn(
                name: "specialized_department_id",
                table: "User");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Scorm");

            migrationBuilder.DropColumn(
                name: "active",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Periodic Assessment",
                newName: "Document1_Periodic Assessment");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Report",
                newName: "message");

            migrationBuilder.RenameIndex(
                name: "IX_Periodic Assessment_form_category_id",
                table: "Document1_Periodic Assessment",
                newName: "IX_Document1_Periodic Assessment_form_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Periodic Assessment_document1_id",
                table: "Document1_Periodic Assessment",
                newName: "IX_Document1_Periodic Assessment_document1_id");

            migrationBuilder.AlterColumn<string>(
                name: "photo",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Testing Category",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Subject",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Report",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "doc_id",
                table: "Report",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "doc_type",
                table: "Report",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "read",
                table: "Report",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "docId",
                table: "Notification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "doc_type",
                table: "Notification",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Grade",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Evaluate",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "host_by",
                table: "Document2_Grade",
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

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Document2_Grade",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "isApprove",
                table: "Document 4",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Class",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Account",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                table: "Report",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document2_Grade",
                table: "Document2_Grade",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Department_Subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: true),
                    subject_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_Subject", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IsApprove",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsApprove", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User_Department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    department_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Department", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Department_Specialized Department",
                        column: x => x.department_id,
                        principalTable: "Specialized Department",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_User_Department_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document2_Grade_document2_id",
                table: "Document2_Grade",
                column: "document2_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 4_isApprove",
                table: "Document 4",
                column: "isApprove");

            migrationBuilder.CreateIndex(
                name: "IX_Document 3_isApprove",
                table: "Document 3",
                column: "isApprove");

            migrationBuilder.CreateIndex(
                name: "IX_Document 2_isApprove",
                table: "Document 2",
                column: "isApprove");

            migrationBuilder.CreateIndex(
                name: "IX_Document 1_isApprove",
                table: "Document 1",
                column: "isApprove");

            migrationBuilder.CreateIndex(
                name: "IX_User_Department_department_id",
                table: "User_Department",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Department_user_id",
                table: "User_Department",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 1_IsApprove",
                table: "Document 1",
                column: "isApprove",
                principalTable: "IsApprove",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 2_IsApprove",
                table: "Document 2",
                column: "isApprove",
                principalTable: "IsApprove",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 3_IsApprove",
                table: "Document 3",
                column: "isApprove",
                principalTable: "IsApprove",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 4_IsApprove",
                table: "Document 4",
                column: "isApprove",
                principalTable: "IsApprove",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document1_Periodic Assessment_Form Category",
                table: "Document1_Periodic Assessment",
                column: "form_category_id",
                principalTable: "Form Category",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document1_Periodic Assessment_Testing Category",
                table: "Document1_Periodic Assessment",
                column: "testing_category_id",
                principalTable: "Testing Category",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Periodic Assessment_Document 1",
                table: "Document1_Periodic Assessment",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document2_Grade_Document 2",
                table: "Document2_Grade",
                column: "document2_id",
                principalTable: "Document 2",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document3_CurriculumDistribution_Document 3",
                table: "Document3_CurriculumDistribution",
                column: "document3_id",
                principalTable: "Document 3",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document3_SelectedTopics_Document 3",
                table: "Document3_SelectedTopics",
                column: "document3_id",
                principalTable: "Document 3",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_User",
                table: "Report",
                column: "id",
                principalTable: "User",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document 1_IsApprove",
                table: "Document 1");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 2_IsApprove",
                table: "Document 2");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 3_IsApprove",
                table: "Document 3");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 4_IsApprove",
                table: "Document 4");

            migrationBuilder.DropForeignKey(
                name: "FK_Document1_Periodic Assessment_Form Category",
                table: "Document1_Periodic Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_Document1_Periodic Assessment_Testing Category",
                table: "Document1_Periodic Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_Periodic Assessment_Document 1",
                table: "Document1_Periodic Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_Document2_Grade_Document 2",
                table: "Document2_Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Document3_CurriculumDistribution_Document 3",
                table: "Document3_CurriculumDistribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Document3_SelectedTopics_Document 3",
                table: "Document3_SelectedTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_User",
                table: "Report");

            migrationBuilder.DropTable(
                name: "Department_Subject");

            migrationBuilder.DropTable(
                name: "IsApprove");

            migrationBuilder.DropTable(
                name: "User_Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document2_Grade",
                table: "Document2_Grade");

            migrationBuilder.DropIndex(
                name: "IX_Document2_Grade_document2_id",
                table: "Document2_Grade");

            migrationBuilder.DropIndex(
                name: "IX_Document 4_isApprove",
                table: "Document 4");

            migrationBuilder.DropIndex(
                name: "IX_Document 3_isApprove",
                table: "Document 3");

            migrationBuilder.DropIndex(
                name: "IX_Document 2_isApprove",
                table: "Document 2");

            migrationBuilder.DropIndex(
                name: "IX_Document 1_isApprove",
                table: "Document 1");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "doc_id",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "doc_type",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "read",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "docId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "doc_type",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Document2_Grade");

            migrationBuilder.DropColumn(
                name: "isApprove",
                table: "Document 4");

            migrationBuilder.RenameTable(
                name: "Document1_Periodic Assessment",
                newName: "Periodic Assessment");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "Report",
                newName: "content");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_Periodic Assessment_form_category_id",
                table: "Periodic Assessment",
                newName: "IX_Periodic Assessment_form_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_Periodic Assessment_document1_id",
                table: "Periodic Assessment",
                newName: "IX_Periodic Assessment_document1_id");

            migrationBuilder.AlterColumn<byte[]>(
                name: "photo",
                table: "User",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "User",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "created_date",
                table: "User",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "modified_by",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "modified_date",
                table: "User",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "specialized_department_id",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Testing Category",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Subject",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "category_id",
                table: "Scorm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "Role",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Grade",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Evaluate",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "host_by",
                table: "Document2_Grade",
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

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Class",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "created_by",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document2_Grade",
                table: "Document2_Grade",
                columns: new[] { "document2_id", "grade_id" });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_specialized_department_id",
                table: "User",
                column: "specialized_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Scorm_category_id",
                table: "Scorm",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Report_user_id",
                table: "Report",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document2_Grade_Document 21",
                table: "Document2_Grade",
                column: "document2_id",
                principalTable: "Document 2",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document3_CurriculumDistribution_Document 31",
                table: "Document3_CurriculumDistribution",
                column: "document3_id",
                principalTable: "Document 3",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document3_SelectedTopics_Document 31",
                table: "Document3_SelectedTopics",
                column: "document3_id",
                principalTable: "Document 3",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Periodic Assessment_Document 1",
                table: "Periodic Assessment",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Periodic Assessment_Form Category",
                table: "Periodic Assessment",
                column: "form_category_id",
                principalTable: "Form Category",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Periodic Assessment_Testing Category",
                table: "Periodic Assessment",
                column: "testing_category_id",
                principalTable: "Testing Category",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_User",
                table: "Report",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doc_Category",
                table: "Scorm",
                column: "category_id",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Specialized Department",
                table: "User",
                column: "specialized_department_id",
                principalTable: "Specialized Department",
                principalColumn: "id");
        }
    }
}
