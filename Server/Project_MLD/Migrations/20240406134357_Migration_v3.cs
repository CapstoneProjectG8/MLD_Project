using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_MLD.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Lớp_Khối Lớp",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Category",
                table: "Doc");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Phu Luc 4",
                table: "Doc");

            migrationBuilder.DropForeignKey(
                name: "FK_Kế Hoạch Dạy Học_Khối Lớp",
                table: "Document 1");

            migrationBuilder.DropForeignKey(
                name: "FK_Kế Hoạch Dạy Học_Môn học",
                table: "Document 1");

            migrationBuilder.DropForeignKey(
                name: "FK_Kế hoạch giáo dục của GV_Kế Hoạch Dạy Học",
                table: "Document 3");

            migrationBuilder.DropForeignKey(
                name: "FK_Kế hoạch giáo dục của GV_User",
                table: "Document 3");

            migrationBuilder.DropForeignKey(
                name: "FK_Phu Luc 4_User - Lớp - Mon",
                table: "Document 4");

            migrationBuilder.DropForeignKey(
                name: "FK_Phu Luc 5_Phu Luc 4",
                table: "Document 5");

            migrationBuilder.DropForeignKey(
                name: "FK_khdh-pptc_Kế Hoạch Dạy Học",
                table: "Document1_CurriculumDistribution");

            migrationBuilder.DropForeignKey(
                name: "FK_khdh-pptc_Phân phối chương trình",
                table: "Document1_CurriculumDistribution");

            migrationBuilder.DropForeignKey(
                name: "FK_khdh _ CD / BH_Chuyên đề / Bài Học",
                table: "Document1_SelectedTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_khdh _ CD / BH_Kế Hoạch Dạy Học",
                table: "Document1_SelectedTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_khdh - Phòng bộ môn_Kế Hoạch Dạy Học",
                table: "Document1_Subject Room");

            migrationBuilder.DropForeignKey(
                name: "FK_khdh - Phòng bộ môn_Phòng Bộ Môn",
                table: "Document1_Subject Room");

            migrationBuilder.DropForeignKey(
                name: "FK_KHDH_TBDH_Kế Hoạch Dạy Học",
                table: "Document1_TeachingEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_KHDH_TBDH_Thiết bị dậy học",
                table: "Document1_TeachingEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_KHTCHDGD - KHỐI LỚP_Khối Lớp",
                table: "Document2_Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_KHTCHDGD - KHỐI LỚP_Kế hoạch Tổ chức Hoạt Động Giáo Dục",
                table: "Document2_Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Kiểm tra, đánh giá định kỳ_Hình thức thi",
                table: "Periodic Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_Kiểm tra, đánh giá định kỳ_Kế Hoạch Dạy Học",
                table: "Periodic Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_Kiểm tra, đánh giá định kỳ_Loại Bài kiểm tra",
                table: "Periodic Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_GV - Lớp_Lớp",
                table: "Teaching Planner");

            migrationBuilder.DropForeignKey(
                name: "FK_GV - Lớp_User",
                table: "Teaching Planner");

            migrationBuilder.DropForeignKey(
                name: "FK_User - Lớp - Mon_Môn học1",
                table: "Teaching Planner");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Account1",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_LevelOfTrainning",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Tổ chuyên Môn",
                table: "User");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "modified_date",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "role_note",
                table: "Role");

            migrationBuilder.AlterDatabase(
                collation: "Latin1_General_100_CI_AS_SC_UTF8");

            migrationBuilder.AlterColumn<string>(
                name: "place_of_birth",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "full_name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "created_by",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Testing Category",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Teaching Equipment",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Subject Room",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Subject",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Specialized Department",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Selected Topics",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "role_name",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Professional Standards",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Periodic Assessment",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Level Of Trainning",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Grade",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Form Category",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "title_name",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "place",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "host_by",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "condition",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "collaborate_with",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "Document1_TeachingEquipment",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Document1_TeachingEquipment",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "Document1_Subject Room",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Document1_Subject Room",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Document1_SelectedTopics",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Document1_CurriculumDistribution",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Document 5",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "total",
                table: "Document 5",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Document 4",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Document 3",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "approve_by",
                table: "Document 3",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isApprove",
                table: "Document 3",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Document 2",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "approve_by",
                table: "Document 2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isApprove",
                table: "Document 2",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "Document 1",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Document 1",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isApprove",
                table: "Document 1",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Doc",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Curriculum Distribution",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Class",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Class",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "created_by",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK_Feedback_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_user_id",
                table: "Feedback",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role1",
                table: "Account",
                column: "role_id",
                principalTable: "Role",
                principalColumn: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Grade",
                table: "Class",
                column: "grade_ id",
                principalTable: "Grade",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doc_Category",
                table: "Doc",
                column: "category_id",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doc_Document 4",
                table: "Doc",
                column: "document4_id",
                principalTable: "Document 4",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 1_Grade",
                table: "Document 1",
                column: "grade_id",
                principalTable: "Grade",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 1_Subject",
                table: "Document 1",
                column: "subject_id",
                principalTable: "Subject",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 3_Document 1",
                table: "Document 3",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 3_User",
                table: "Document 3",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 4_Teaching Planner",
                table: "Document 4",
                column: "teaching_planner_id",
                principalTable: "Teaching Planner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 5_Document 4",
                table: "Document 5",
                column: "document4_id",
                principalTable: "Document 4",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document1_CurriculumDistribution_Curriculum Distribution",
                table: "Document1_CurriculumDistribution",
                column: "curriculum_id",
                principalTable: "Curriculum Distribution",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document1_CurriculumDistribution_Document 1",
                table: "Document1_CurriculumDistribution",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document1_SelectedTopics_Document 1",
                table: "Document1_SelectedTopics",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document1_SelectedTopics_Selected Topics",
                table: "Document1_SelectedTopics",
                column: "selected_topics_id",
                principalTable: "Selected Topics",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document1_Subject Room_Document 1",
                table: "Document1_Subject Room",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document1_Subject Room_Subject Room",
                table: "Document1_Subject Room",
                column: "subject_room_id",
                principalTable: "Subject Room",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document1_TeachingEquipment_Document 1",
                table: "Document1_TeachingEquipment",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document1_TeachingEquipment_Teaching Equipment",
                table: "Document1_TeachingEquipment",
                column: "teaching_equipment_id",
                principalTable: "Teaching Equipment",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document2_Grade_Document 2",
                table: "Document2_Grade",
                column: "document2_id",
                principalTable: "Document 2",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document2_Grade_Grade",
                table: "Document2_Grade",
                column: "grade_id",
                principalTable: "Grade",
                principalColumn: "id");

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
                name: "FK_Teaching Planner_Class",
                table: "Teaching Planner",
                column: "class_id",
                principalTable: "Class",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teaching Planner_Subject",
                table: "Teaching Planner",
                column: "subject_id",
                principalTable: "Subject",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teaching Planner_User",
                table: "Teaching Planner",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Account",
                table: "User",
                column: "account_id",
                principalTable: "Account",
                principalColumn: "account_id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Level Of Trainning",
                table: "User",
                column: "level_of_trainning_id",
                principalTable: "Level Of Trainning",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Specialized Department",
                table: "User",
                column: "specialized_department_id",
                principalTable: "Specialized Department",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role1",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_Grade",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Doc_Category",
                table: "Doc");

            migrationBuilder.DropForeignKey(
                name: "FK_Doc_Document 4",
                table: "Doc");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 1_Grade",
                table: "Document 1");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 1_Subject",
                table: "Document 1");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 3_Document 1",
                table: "Document 3");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 3_User",
                table: "Document 3");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 4_Teaching Planner",
                table: "Document 4");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 5_Document 4",
                table: "Document 5");

            migrationBuilder.DropForeignKey(
                name: "FK_Document1_CurriculumDistribution_Curriculum Distribution",
                table: "Document1_CurriculumDistribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Document1_CurriculumDistribution_Document 1",
                table: "Document1_CurriculumDistribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Document1_SelectedTopics_Document 1",
                table: "Document1_SelectedTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_Document1_SelectedTopics_Selected Topics",
                table: "Document1_SelectedTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_Document1_Subject Room_Document 1",
                table: "Document1_Subject Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Document1_Subject Room_Subject Room",
                table: "Document1_Subject Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Document1_TeachingEquipment_Document 1",
                table: "Document1_TeachingEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Document1_TeachingEquipment_Teaching Equipment",
                table: "Document1_TeachingEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Document2_Grade_Document 2",
                table: "Document2_Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Document2_Grade_Grade",
                table: "Document2_Grade");

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
                name: "FK_Teaching Planner_Class",
                table: "Teaching Planner");

            migrationBuilder.DropForeignKey(
                name: "FK_Teaching Planner_Subject",
                table: "Teaching Planner");

            migrationBuilder.DropForeignKey(
                name: "FK_Teaching Planner_User",
                table: "Teaching Planner");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Account",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Level Of Trainning",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Specialized Department",
                table: "User");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropColumn(
                name: "total",
                table: "Document 5");

            migrationBuilder.DropColumn(
                name: "approve_by",
                table: "Document 3");

            migrationBuilder.DropColumn(
                name: "isApprove",
                table: "Document 3");

            migrationBuilder.DropColumn(
                name: "approve_by",
                table: "Document 2");

            migrationBuilder.DropColumn(
                name: "isApprove",
                table: "Document 2");

            migrationBuilder.DropColumn(
                name: "isApprove",
                table: "Document 1");

            migrationBuilder.AlterDatabase(
                oldCollation: "Latin1_General_100_CI_AS_SC_UTF8");

            migrationBuilder.AlterColumn<string>(
                name: "place_of_birth",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "full_name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "created_by",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Testing Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Teaching Equipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Subject Room",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Subject",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Specialized Department",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Selected Topics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "role_name",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "created_date",
                table: "Role",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "modified_by",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "modified_date",
                table: "Role",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role_note",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Professional Standards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Periodic Assessment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Level Of Trainning",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Grade",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Form Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "title_name",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "place",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "host_by",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "condition",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "collaborate_with",
                table: "Document2_Grade",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "Document1_TeachingEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Document1_TeachingEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "Document1_Subject Room",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Document1_Subject Room",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Document1_SelectedTopics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Document1_CurriculumDistribution",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Document 5",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Document 4",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Document 3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Document 2",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "Document 1",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Document 1",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Doc",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Curriculum Distribution",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Class",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Class",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "created_by",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role",
                table: "Account",
                column: "role_id",
                principalTable: "Role",
                principalColumn: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lớp_Khối Lớp",
                table: "Class",
                column: "grade_ id",
                principalTable: "Grade",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Category",
                table: "Doc",
                column: "category_id",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Phu Luc 4",
                table: "Doc",
                column: "document4_id",
                principalTable: "Document 4",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kế Hoạch Dạy Học_Khối Lớp",
                table: "Document 1",
                column: "grade_id",
                principalTable: "Grade",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kế Hoạch Dạy Học_Môn học",
                table: "Document 1",
                column: "subject_id",
                principalTable: "Subject",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kế hoạch giáo dục của GV_Kế Hoạch Dạy Học",
                table: "Document 3",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kế hoạch giáo dục của GV_User",
                table: "Document 3",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phu Luc 4_User - Lớp - Mon",
                table: "Document 4",
                column: "teaching_planner_id",
                principalTable: "Teaching Planner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phu Luc 5_Phu Luc 4",
                table: "Document 5",
                column: "document4_id",
                principalTable: "Document 4",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_khdh-pptc_Kế Hoạch Dạy Học",
                table: "Document1_CurriculumDistribution",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_khdh-pptc_Phân phối chương trình",
                table: "Document1_CurriculumDistribution",
                column: "curriculum_id",
                principalTable: "Curriculum Distribution",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_khdh _ CD / BH_Chuyên đề / Bài Học",
                table: "Document1_SelectedTopics",
                column: "selected_topics_id",
                principalTable: "Selected Topics",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_khdh _ CD / BH_Kế Hoạch Dạy Học",
                table: "Document1_SelectedTopics",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_khdh - Phòng bộ môn_Kế Hoạch Dạy Học",
                table: "Document1_Subject Room",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_khdh - Phòng bộ môn_Phòng Bộ Môn",
                table: "Document1_Subject Room",
                column: "subject_room_id",
                principalTable: "Subject Room",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_KHDH_TBDH_Kế Hoạch Dạy Học",
                table: "Document1_TeachingEquipment",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_KHDH_TBDH_Thiết bị dậy học",
                table: "Document1_TeachingEquipment",
                column: "teaching_equipment_id",
                principalTable: "Teaching Equipment",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_KHTCHDGD - KHỐI LỚP_Khối Lớp",
                table: "Document2_Grade",
                column: "grade_id",
                principalTable: "Grade",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_KHTCHDGD - KHỐI LỚP_Kế hoạch Tổ chức Hoạt Động Giáo Dục",
                table: "Document2_Grade",
                column: "document2_id",
                principalTable: "Document 2",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kiểm tra, đánh giá định kỳ_Hình thức thi",
                table: "Periodic Assessment",
                column: "testing_category_id",
                principalTable: "Form Category",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kiểm tra, đánh giá định kỳ_Kế Hoạch Dạy Học",
                table: "Periodic Assessment",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kiểm tra, đánh giá định kỳ_Loại Bài kiểm tra",
                table: "Periodic Assessment",
                column: "form_category_id",
                principalTable: "Testing Category",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_GV - Lớp_Lớp",
                table: "Teaching Planner",
                column: "class_id",
                principalTable: "Class",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_GV - Lớp_User",
                table: "Teaching Planner",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_User - Lớp - Mon_Môn học1",
                table: "Teaching Planner",
                column: "subject_id",
                principalTable: "Subject",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Account1",
                table: "User",
                column: "account_id",
                principalTable: "Account",
                principalColumn: "account_id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_LevelOfTrainning",
                table: "User",
                column: "level_of_trainning_id",
                principalTable: "Level Of Trainning",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Tổ chuyên Môn",
                table: "User",
                column: "specialized_department_id",
                principalTable: "Specialized Department",
                principalColumn: "id");
        }
    }
}
