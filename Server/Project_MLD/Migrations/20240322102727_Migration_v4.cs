using System;
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
            migrationBuilder.DropForeignKey(
                name: "FK_User_Tổ chuyên Môn",
                table: "User");

            migrationBuilder.DropTable(
                name: "Docuemnt2_Grade");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Phu Luc 5");

            migrationBuilder.DropTable(
                name: "PL3_CurriculumDistribution");

            migrationBuilder.DropTable(
                name: "Specialized Team");

            migrationBuilder.DropTable(
                name: "Phu luc 2");

            migrationBuilder.DropTable(
                name: "Phu Luc 4");

            migrationBuilder.DropTable(
                name: "Phu Luc 3");

            migrationBuilder.RenameTable(
                name: "document1_TeachingEquipment",
                newName: "Document1_TeachingEquipment");

            migrationBuilder.RenameTable(
                name: "document1_Subject Room",
                newName: "Document1_Subject Room");

            migrationBuilder.RenameTable(
                name: "document1_SelectedTopics",
                newName: "Document1_SelectedTopics");

            migrationBuilder.RenameTable(
                name: "document1_CurriculumDistribution",
                newName: "Document1_CurriculumDistribution");

            migrationBuilder.RenameTable(
                name: "Phu Luc 1",
                newName: "Document 1");

            migrationBuilder.RenameTable(
                name: "LevelOfTrainning",
                newName: "Level Of Trainning");

            migrationBuilder.RenameIndex(
                name: "IX_document1_TeachingEquipment_teaching_equipment_id",
                table: "Document1_TeachingEquipment",
                newName: "IX_Document1_TeachingEquipment_teaching_equipment_id");

            migrationBuilder.RenameIndex(
                name: "IX_document1_TeachingEquipment_document1_id",
                table: "Document1_TeachingEquipment",
                newName: "IX_Document1_TeachingEquipment_document1_id");

            migrationBuilder.RenameIndex(
                name: "IX_document1_Subject Room_subject_room_id",
                table: "Document1_Subject Room",
                newName: "IX_Document1_Subject Room_subject_room_id");

            migrationBuilder.RenameIndex(
                name: "IX_document1_Subject Room_document1_id",
                table: "Document1_Subject Room",
                newName: "IX_Document1_Subject Room_document1_id");

            migrationBuilder.RenameIndex(
                name: "IX_document1_SelectedTopics_selected_topics_id",
                table: "Document1_SelectedTopics",
                newName: "IX_Document1_SelectedTopics_selected_topics_id");

            migrationBuilder.RenameIndex(
                name: "IX_document1_SelectedTopics_document1_id",
                table: "Document1_SelectedTopics",
                newName: "IX_Document1_SelectedTopics_document1_id");

            migrationBuilder.RenameIndex(
                name: "IX_document1_CurriculumDistribution_document1_id",
                table: "Document1_CurriculumDistribution",
                newName: "IX_Document1_CurriculumDistribution_document1_id");

            migrationBuilder.RenameIndex(
                name: "IX_document1_CurriculumDistribution_curruculum_id",
                table: "Document1_CurriculumDistribution",
                newName: "IX_Document1_CurriculumDistribution_curruculum_id");

            migrationBuilder.RenameIndex(
                name: "IX_Phu Luc 1_user_id",
                table: "Document 1",
                newName: "IX_Document 1_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Phu Luc 1_subject_id",
                table: "Document 1",
                newName: "IX_Document 1_subject_id");

            migrationBuilder.RenameIndex(
                name: "IX_Phu Luc 1_grade_id",
                table: "Document 1",
                newName: "IX_Document 1_grade_id");

            migrationBuilder.CreateTable(
                name: "Document 2",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kế hoạch Tổ chức Hoạt Động Giáo Dục", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kế hoạch Tổ chức Hoạt Động Giáo Dục_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document 3",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document1_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kế hoạch giáo dục của GV", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kế hoạch giáo dục của GV_Kế Hoạch Dạy Học",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Kế hoạch giáo dục của GV_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document 4",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    teaching_planner_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phu Luc 4", x => x.id);
                    table.ForeignKey(
                        name: "FK_Phu Luc 4_User - Lớp - Mon",
                        column: x => x.teaching_planner_id,
                        principalTable: "Teaching Planner",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specialized Department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tổ chuyên Môn", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Document2_Grade",
                columns: table => new
                {
                    document2_id = table.Column<int>(type: "int", nullable: true),
                    grade_id = table.Column<int>(type: "int", nullable: true),
                    title_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateOnly>(type: "date", nullable: true),
                    place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    host_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    collaborate_with = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    condition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_KHTCHDGD - KHỐI LỚP_Khối Lớp",
                        column: x => x.grade_id,
                        principalTable: "Grade",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_KHTCHDGD - KHỐI LỚP_Kế hoạch Tổ chức Hoạt Động Giáo Dục",
                        column: x => x.document2_id,
                        principalTable: "Document 2",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document3_CurriculumDistribution",
                columns: table => new
                {
                    document3_id = table.Column<int>(type: "int", nullable: true),
                    curriculum_id = table.Column<int>(type: "int", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateOnly>(type: "date", nullable: true),
                    teaching_equipment_id = table.Column<int>(type: "int", nullable: false),
                    place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Doc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    document4_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document_Category",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Document_Phu Luc 4",
                        column: x => x.document4_id,
                        principalTable: "Document 4",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document 5",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    document4_id = table.Column<int>(type: "int", nullable: false),
                    evaluate_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phu Luc 5", x => x.id);
                    table.ForeignKey(
                        name: "FK_Phu Luc 5_Phu Luc 4",
                        column: x => x.document4_id,
                        principalTable: "Document 4",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Phu Luc 5_User",
                        column: x => x.evaluate_by,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doc_category_id",
                table: "Doc",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Doc_document4_id",
                table: "Doc",
                column: "document4_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 2_user_id",
                table: "Document 2",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 3_document1_id",
                table: "Document 3",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 3_user_id",
                table: "Document 3",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 4_teaching_planner_id",
                table: "Document 4",
                column: "teaching_planner_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 5_document4_id",
                table: "Document 5",
                column: "document4_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 5_evaluate_by",
                table: "Document 5",
                column: "evaluate_by");

            migrationBuilder.CreateIndex(
                name: "IX_Document2_Grade_document2_id",
                table: "Document2_Grade",
                column: "document2_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document2_Grade_grade_id",
                table: "Document2_Grade",
                column: "grade_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_User_Tổ chuyên Môn",
                table: "User",
                column: "specialized_team_id",
                principalTable: "Specialized Department",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Tổ chuyên Môn",
                table: "User");

            migrationBuilder.DropTable(
                name: "Doc");

            migrationBuilder.DropTable(
                name: "Document 5");

            migrationBuilder.DropTable(
                name: "Document2_Grade");

            migrationBuilder.DropTable(
                name: "Document3_CurriculumDistribution");

            migrationBuilder.DropTable(
                name: "Specialized Department");

            migrationBuilder.DropTable(
                name: "Document 4");

            migrationBuilder.DropTable(
                name: "Document 2");

            migrationBuilder.DropTable(
                name: "Document 3");

            migrationBuilder.RenameTable(
                name: "Document1_TeachingEquipment",
                newName: "document1_TeachingEquipment");

            migrationBuilder.RenameTable(
                name: "Document1_Subject Room",
                newName: "document1_Subject Room");

            migrationBuilder.RenameTable(
                name: "Document1_SelectedTopics",
                newName: "document1_SelectedTopics");

            migrationBuilder.RenameTable(
                name: "Document1_CurriculumDistribution",
                newName: "document1_CurriculumDistribution");

            migrationBuilder.RenameTable(
                name: "Level Of Trainning",
                newName: "LevelOfTrainning");

            migrationBuilder.RenameTable(
                name: "Document 1",
                newName: "Phu Luc 1");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_TeachingEquipment_teaching_equipment_id",
                table: "document1_TeachingEquipment",
                newName: "IX_document1_TeachingEquipment_teaching_equipment_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_TeachingEquipment_document1_id",
                table: "document1_TeachingEquipment",
                newName: "IX_document1_TeachingEquipment_document1_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_Subject Room_subject_room_id",
                table: "document1_Subject Room",
                newName: "IX_document1_Subject Room_subject_room_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_Subject Room_document1_id",
                table: "document1_Subject Room",
                newName: "IX_document1_Subject Room_document1_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_SelectedTopics_selected_topics_id",
                table: "document1_SelectedTopics",
                newName: "IX_document1_SelectedTopics_selected_topics_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_SelectedTopics_document1_id",
                table: "document1_SelectedTopics",
                newName: "IX_document1_SelectedTopics_document1_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_CurriculumDistribution_document1_id",
                table: "document1_CurriculumDistribution",
                newName: "IX_document1_CurriculumDistribution_document1_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document1_CurriculumDistribution_curruculum_id",
                table: "document1_CurriculumDistribution",
                newName: "IX_document1_CurriculumDistribution_curruculum_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document 1_user_id",
                table: "Phu Luc 1",
                newName: "IX_Phu Luc 1_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document 1_subject_id",
                table: "Phu Luc 1",
                newName: "IX_Phu Luc 1_subject_id");

            migrationBuilder.RenameIndex(
                name: "IX_Document 1_grade_id",
                table: "Phu Luc 1",
                newName: "IX_Phu Luc 1_grade_id");

            migrationBuilder.CreateTable(
                name: "Phu luc 2",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kế hoạch Tổ chức Hoạt Động Giáo Dục", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kế hoạch Tổ chức Hoạt Động Giáo Dục_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Phu Luc 3",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document1_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kế hoạch giáo dục của GV", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kế hoạch giáo dục của GV_Kế Hoạch Dạy Học",
                        column: x => x.document1_id,
                        principalTable: "Phu Luc 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Kế hoạch giáo dục của GV_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Phu Luc 4",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teaching_planner_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phu Luc 4", x => x.id);
                    table.ForeignKey(
                        name: "FK_Phu Luc 4_User - Lớp - Mon",
                        column: x => x.teaching_planner_id,
                        principalTable: "Teaching Planner",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specialized Team",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tổ chuyên Môn", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Docuemnt2_Grade",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "int", nullable: true),
                    pl2_id = table.Column<int>(type: "int", nullable: true),
                    collaborate_with = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    condition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    host_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateOnly>(type: "date", nullable: true),
                    title_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_KHTCHDGD - KHỐI LỚP_Khối Lớp",
                        column: x => x.grade_id,
                        principalTable: "Grade",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_KHTCHDGD - KHỐI LỚP_Kế hoạch Tổ chức Hoạt Động Giáo Dục",
                        column: x => x.pl2_id,
                        principalTable: "Phu luc 2",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PL3_CurriculumDistribution",
                columns: table => new
                {
                    curriculum_id = table.Column<int>(type: "int", nullable: true),
                    pl3_id = table.Column<int>(type: "int", nullable: true),
                    teaching_equipment_ID = table.Column<int>(type: "int", nullable: false),
                    place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_khgdGV - ppct_Kế hoạch giáo dục của GV",
                        column: x => x.pl3_id,
                        principalTable: "Phu Luc 3",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_khgdGV - ppct_Phân phối chương trình",
                        column: x => x.curriculum_id,
                        principalTable: "Curriculum Distribution",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_khgdGV - ppct_Thiết bị dậy học",
                        column: x => x.teaching_equipment_ID,
                        principalTable: "Teaching Equipment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    pl4_id = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document_Category",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Document_Phu Luc 4",
                        column: x => x.pl4_id,
                        principalTable: "Phu Luc 4",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Phu Luc 5",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evaluate_by = table.Column<int>(type: "int", nullable: true),
                    pl4_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phu Luc 5", x => x.id);
                    table.ForeignKey(
                        name: "FK_Phu Luc 5_Phu Luc 4",
                        column: x => x.pl4_id,
                        principalTable: "Phu Luc 4",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Phu Luc 5_User",
                        column: x => x.evaluate_by,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docuemnt2_Grade_grade_id",
                table: "Docuemnt2_Grade",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Docuemnt2_Grade_pl2_id",
                table: "Docuemnt2_Grade",
                column: "pl2_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document_category_id",
                table: "Document",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document_pl4_id",
                table: "Document",
                column: "pl4_id");

            migrationBuilder.CreateIndex(
                name: "IX_Phu luc 2_user_id",
                table: "Phu luc 2",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Phu Luc 3_document1_id",
                table: "Phu Luc 3",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Phu Luc 3_user_id",
                table: "Phu Luc 3",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Phu Luc 4_teaching_planner_id",
                table: "Phu Luc 4",
                column: "teaching_planner_id");

            migrationBuilder.CreateIndex(
                name: "IX_Phu Luc 5_evaluate_by",
                table: "Phu Luc 5",
                column: "evaluate_by");

            migrationBuilder.CreateIndex(
                name: "IX_Phu Luc 5_pl4_id",
                table: "Phu Luc 5",
                column: "pl4_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL3_CurriculumDistribution_curriculum_id",
                table: "PL3_CurriculumDistribution",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL3_CurriculumDistribution_pl3_id",
                table: "PL3_CurriculumDistribution",
                column: "pl3_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL3_CurriculumDistribution_teaching_equipment_ID",
                table: "PL3_CurriculumDistribution",
                column: "teaching_equipment_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Tổ chuyên Môn",
                table: "User",
                column: "specialized_team_id",
                principalTable: "Specialized Team",
                principalColumn: "id");
        }
    }
}
