using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_MLD.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Curriculum Distribution",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phân phối chương trình", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Form Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hình thức thi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_student = table.Column<int>(type: "int", nullable: true),
                    total_student_selected_topics = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khối Lớp", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Level Of Trainning",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelOfTrainning", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Professional Standards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professional Standards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    modified_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Selected Topics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chuyên đề / Bài Học", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Specialized Department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tổ chuyên Môn", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Môn học", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Subject Room",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phòng Bộ Môn", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teaching Equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thiết bị dậy học", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Testing Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loại Bài kiểm tra", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grade_id = table.Column<int>(name: "grade_ id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lớp", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lớp_Khối Lớp",
                        column: x => x.grade_id,
                        principalTable: "Grade",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_Account_Role",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<bool>(type: "bit", nullable: true),
                    place_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: true),
                    level_of_trainning_id = table.Column<int>(type: "int", nullable: true),
                    specialized_department_id = table.Column<int>(type: "int", nullable: true),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    professional_standards_id = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Account1",
                        column: x => x.account_id,
                        principalTable: "Account",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_User_LevelOfTrainning",
                        column: x => x.level_of_trainning_id,
                        principalTable: "Level Of Trainning",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_User_Professional Standards",
                        column: x => x.professional_standards_id,
                        principalTable: "Professional Standards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_User_Tổ chuyên Môn",
                        column: x => x.specialized_department_id,
                        principalTable: "Specialized Department",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document 1",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject_id = table.Column<int>(type: "int", nullable: true),
                    grade_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    approve_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kế Hoạch Dạy Học", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kế Hoạch Dạy Học_Khối Lớp",
                        column: x => x.grade_id,
                        principalTable: "Grade",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Kế Hoạch Dạy Học_Môn học",
                        column: x => x.subject_id,
                        principalTable: "Subject",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Phu Luc 1_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document 2",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Teaching Planner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    class_id = table.Column<int>(type: "int", nullable: true),
                    subject_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User - Lớp - Mon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GV - Lớp_Lớp",
                        column: x => x.class_id,
                        principalTable: "Class",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_GV - Lớp_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_User - Lớp - Mon_Môn học1",
                        column: x => x.subject_id,
                        principalTable: "Subject",
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
                name: "Document1_CurriculumDistribution",
                columns: table => new
                {
                    document1_id = table.Column<int>(type: "int", nullable: false),
                    curriculum_id = table.Column<int>(type: "int", nullable: false),
                    slot = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_khdh-pptc_Kế Hoạch Dạy Học",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_khdh-pptc_Phân phối chương trình",
                        column: x => x.curriculum_id,
                        principalTable: "Curriculum Distribution",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document1_SelectedTopics",
                columns: table => new
                {
                    document1_id = table.Column<int>(type: "int", nullable: true),
                    selected_topics_id = table.Column<int>(type: "int", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_khdh _ CD / BH_Chuyên đề / Bài Học",
                        column: x => x.selected_topics_id,
                        principalTable: "Selected Topics",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_khdh _ CD / BH_Kế Hoạch Dạy Học",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document1_Subject Room",
                columns: table => new
                {
                    subject_room_id = table.Column<int>(type: "int", nullable: true),
                    document1_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_khdh - Phòng bộ môn_Kế Hoạch Dạy Học",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_khdh - Phòng bộ môn_Phòng Bộ Môn",
                        column: x => x.subject_room_id,
                        principalTable: "Subject Room",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document1_TeachingEquipment",
                columns: table => new
                {
                    document1_id = table.Column<int>(type: "int", nullable: true),
                    teaching_equipment_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_KHDH_TBDH_Kế Hoạch Dạy Học",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_KHDH_TBDH_Thiết bị dậy học",
                        column: x => x.teaching_equipment_id,
                        principalTable: "Teaching Equipment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Periodic Assessment",
                columns: table => new
                {
                    testing_category_id = table.Column<int>(type: "int", nullable: true),
                    form_category_id = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    document1_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Kiểm tra, đánh giá định kỳ_Hình thức thi",
                        column: x => x.testing_category_id,
                        principalTable: "Form Category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Kiểm tra, đánh giá định kỳ_Kế Hoạch Dạy Học",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Kiểm tra, đánh giá định kỳ_Loại Bài kiểm tra",
                        column: x => x.form_category_id,
                        principalTable: "Testing Category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document2_Grade",
                columns: table => new
                {
                    document2_id = table.Column<int>(type: "int", nullable: true),
                    grade_id = table.Column<int>(type: "int", nullable: true),
                    title_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateOnly>(type: "date", nullable: true),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    host_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    collaborate_with = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Document 4",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Doc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "IX_Account_role_id",
                table: "Account",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Class_grade_ id",
                table: "Class",
                column: "grade_ id");

            migrationBuilder.CreateIndex(
                name: "IX_Doc_category_id",
                table: "Doc",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Doc_document4_id",
                table: "Doc",
                column: "document4_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 1_grade_id",
                table: "Document 1",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 1_subject_id",
                table: "Document 1",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 1_user_id",
                table: "Document 1",
                column: "user_id");

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
                name: "IX_Document1_CurriculumDistribution_curriculum_id",
                table: "Document1_CurriculumDistribution",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_CurriculumDistribution_document1_id",
                table: "Document1_CurriculumDistribution",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_SelectedTopics_document1_id",
                table: "Document1_SelectedTopics",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_SelectedTopics_selected_topics_id",
                table: "Document1_SelectedTopics",
                column: "selected_topics_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_Subject Room_document1_id",
                table: "Document1_Subject Room",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_Subject Room_subject_room_id",
                table: "Document1_Subject Room",
                column: "subject_room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_TeachingEquipment_document1_id",
                table: "Document1_TeachingEquipment",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_TeachingEquipment_teaching_equipment_id",
                table: "Document1_TeachingEquipment",
                column: "teaching_equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document2_Grade_document2_id",
                table: "Document2_Grade",
                column: "document2_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document2_Grade_grade_id",
                table: "Document2_Grade",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Periodic Assessment_document1_id",
                table: "Periodic Assessment",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Periodic Assessment_form_category_id",
                table: "Periodic Assessment",
                column: "form_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Periodic Assessment_testing_category_id",
                table: "Periodic Assessment",
                column: "testing_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teaching Planner_class_id",
                table: "Teaching Planner",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teaching Planner_subject_id",
                table: "Teaching Planner",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teaching Planner_user_id",
                table: "Teaching Planner",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_account_id",
                table: "User",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_level_of_trainning_id",
                table: "User",
                column: "level_of_trainning_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_professional_standards_id",
                table: "User",
                column: "professional_standards_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_specialized_department_id",
                table: "User",
                column: "specialized_department_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doc");

            migrationBuilder.DropTable(
                name: "Document 3");

            migrationBuilder.DropTable(
                name: "Document 5");

            migrationBuilder.DropTable(
                name: "Document1_CurriculumDistribution");

            migrationBuilder.DropTable(
                name: "Document1_SelectedTopics");

            migrationBuilder.DropTable(
                name: "Document1_Subject Room");

            migrationBuilder.DropTable(
                name: "Document1_TeachingEquipment");

            migrationBuilder.DropTable(
                name: "Document2_Grade");

            migrationBuilder.DropTable(
                name: "Periodic Assessment");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Document 4");

            migrationBuilder.DropTable(
                name: "Curriculum Distribution");

            migrationBuilder.DropTable(
                name: "Selected Topics");

            migrationBuilder.DropTable(
                name: "Subject Room");

            migrationBuilder.DropTable(
                name: "Teaching Equipment");

            migrationBuilder.DropTable(
                name: "Document 2");

            migrationBuilder.DropTable(
                name: "Form Category");

            migrationBuilder.DropTable(
                name: "Document 1");

            migrationBuilder.DropTable(
                name: "Testing Category");

            migrationBuilder.DropTable(
                name: "Teaching Planner");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Level Of Trainning");

            migrationBuilder.DropTable(
                name: "Professional Standards");

            migrationBuilder.DropTable(
                name: "Specialized Department");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
