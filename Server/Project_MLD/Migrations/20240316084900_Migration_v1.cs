using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_MLD.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.account_id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    total_student = table.Column<int>(type: "int", nullable: true),
                    total_student_selected_topics = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khối Lớp", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LevelOfTrainning",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelOfTrainning", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Login Attempt",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    success = table.Column<bool>(type: "bit", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login Attempt", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Professional Standards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    role_note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                name: "Scorm",
                columns: table => new
                {
                    id = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    content = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scorm", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Selected Topics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chuyên đề / Bài Học", x => x.id);
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
                name: "Subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                name: "Account Role",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Account Role_Account",
                        column: x => x.account_id,
                        principalTable: "Account",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_Account Role_Role",
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
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    photo = table.Column<byte[]>(type: "varbinary(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gender = table.Column<bool>(type: "bit", nullable: true),
                    place_of_birth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    age = table.Column<int>(type: "int", nullable: true),
                    level_of_trainning_id = table.Column<int>(type: "int", nullable: true),
                    specialized_team_id = table.Column<int>(type: "int", nullable: true),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    professional_standards_id = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
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
                        principalTable: "LevelOfTrainning",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_User_Professional Standards",
                        column: x => x.professional_standards_id,
                        principalTable: "Professional Standards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_User_Tổ chuyên Môn",
                        column: x => x.specialized_team_id,
                        principalTable: "Specialized Team",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Phu Luc 1",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    subject_id = table.Column<int>(type: "int", nullable: true),
                    grade_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
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
                name: "Phu luc 2",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
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
                name: "Periodic Assessment",
                columns: table => new
                {
                    testing_category_id = table.Column<int>(type: "int", nullable: true),
                    form_category_id = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pl1_id = table.Column<int>(type: "int", nullable: true)
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
                        column: x => x.pl1_id,
                        principalTable: "Phu Luc 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Kiểm tra, đánh giá định kỳ_Loại Bài kiểm tra",
                        column: x => x.form_category_id,
                        principalTable: "Testing Category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Phu Luc 3",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pl1_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kế hoạch giáo dục của GV", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kế hoạch giáo dục của GV_Kế Hoạch Dạy Học",
                        column: x => x.pl1_id,
                        principalTable: "Phu Luc 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Kế hoạch giáo dục của GV_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PL1_CurriculumDistribution",
                columns: table => new
                {
                    pl1_id = table.Column<int>(type: "int", nullable: false),
                    curruculum_id = table.Column<int>(type: "int", nullable: false),
                    slot = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_khdh-pptc_Kế Hoạch Dạy Học",
                        column: x => x.pl1_id,
                        principalTable: "Phu Luc 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_khdh-pptc_Phân phối chương trình",
                        column: x => x.curruculum_id,
                        principalTable: "Curriculum Distribution",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PL1_SelectedTopics",
                columns: table => new
                {
                    pl1_id = table.Column<int>(type: "int", nullable: true),
                    selected_topics_id = table.Column<int>(type: "int", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                        column: x => x.pl1_id,
                        principalTable: "Phu Luc 1",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PL1_Subject Room",
                columns: table => new
                {
                    subject_room_id = table.Column<int>(type: "int", nullable: true),
                    pl1_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_khdh - Phòng bộ môn_Kế Hoạch Dạy Học",
                        column: x => x.pl1_id,
                        principalTable: "Phu Luc 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_khdh - Phòng bộ môn_Phòng Bộ Môn",
                        column: x => x.subject_room_id,
                        principalTable: "Subject Room",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PL1_TeachingEquipment",
                columns: table => new
                {
                    pl1_id = table.Column<int>(type: "int", nullable: true),
                    teaching_equipment_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_KHDH_TBDH_Kế Hoạch Dạy Học",
                        column: x => x.pl1_id,
                        principalTable: "Phu Luc 1",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_KHDH_TBDH_Thiết bị dậy học",
                        column: x => x.teaching_equipment_id,
                        principalTable: "Teaching Equipment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PhuLuc2_Grade",
                columns: table => new
                {
                    pl2_id = table.Column<int>(type: "int", nullable: true),
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
                        column: x => x.pl2_id,
                        principalTable: "Phu luc 2",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Phu Luc 4",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    teaching_planner_id = table.Column<int>(type: "int", nullable: true)
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
                name: "PL3_CurriculumDistribution",
                columns: table => new
                {
                    pl3_id = table.Column<int>(type: "int", nullable: true),
                    curriculum_id = table.Column<int>(type: "int", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateOnly>(type: "date", nullable: true),
                    teaching_equipment_ID = table.Column<int>(type: "int", nullable: false),
                    place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    pl4_id = table.Column<int>(type: "int", nullable: false)
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
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pl4_id = table.Column<int>(type: "int", nullable: false),
                    evaluate_by = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Account Role_account_id",
                table: "Account Role",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Account Role_role_id",
                table: "Account Role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Class_grade_ id",
                table: "Class",
                column: "grade_ id");

            migrationBuilder.CreateIndex(
                name: "IX_Document_category_id",
                table: "Document",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document_pl4_id",
                table: "Document",
                column: "pl4_id");

            migrationBuilder.CreateIndex(
                name: "IX_Periodic Assessment_form_category_id",
                table: "Periodic Assessment",
                column: "form_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Periodic Assessment_pl1_id",
                table: "Periodic Assessment",
                column: "pl1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Periodic Assessment_testing_category_id",
                table: "Periodic Assessment",
                column: "testing_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Phu Luc 1_grade_id",
                table: "Phu Luc 1",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Phu Luc 1_subject_id",
                table: "Phu Luc 1",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_Phu Luc 1_user_id",
                table: "Phu Luc 1",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Phu luc 2_user_id",
                table: "Phu luc 2",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Phu Luc 3_pl1_id",
                table: "Phu Luc 3",
                column: "pl1_id");

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
                name: "IX_PhuLuc2_Grade_grade_id",
                table: "PhuLuc2_Grade",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_PhuLuc2_Grade_pl2_id",
                table: "PhuLuc2_Grade",
                column: "pl2_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL1_CurriculumDistribution_curruculum_id",
                table: "PL1_CurriculumDistribution",
                column: "curruculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL1_CurriculumDistribution_pl1_id",
                table: "PL1_CurriculumDistribution",
                column: "pl1_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL1_SelectedTopics_pl1_id",
                table: "PL1_SelectedTopics",
                column: "pl1_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL1_SelectedTopics_selected_topics_id",
                table: "PL1_SelectedTopics",
                column: "selected_topics_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL1_Subject Room_pl1_id",
                table: "PL1_Subject Room",
                column: "pl1_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL1_Subject Room_subject_room_id",
                table: "PL1_Subject Room",
                column: "subject_room_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL1_TeachingEquipment_pl1_id",
                table: "PL1_TeachingEquipment",
                column: "pl1_id");

            migrationBuilder.CreateIndex(
                name: "IX_PL1_TeachingEquipment_teaching_equipment_id",
                table: "PL1_TeachingEquipment",
                column: "teaching_equipment_id");

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
                name: "IX_User_specialized_team_id",
                table: "User",
                column: "specialized_team_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account Role");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Login Attempt");

            migrationBuilder.DropTable(
                name: "Periodic Assessment");

            migrationBuilder.DropTable(
                name: "Phu Luc 5");

            migrationBuilder.DropTable(
                name: "PhuLuc2_Grade");

            migrationBuilder.DropTable(
                name: "PL1_CurriculumDistribution");

            migrationBuilder.DropTable(
                name: "PL1_SelectedTopics");

            migrationBuilder.DropTable(
                name: "PL1_Subject Room");

            migrationBuilder.DropTable(
                name: "PL1_TeachingEquipment");

            migrationBuilder.DropTable(
                name: "PL3_CurriculumDistribution");

            migrationBuilder.DropTable(
                name: "Scorm");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Form Category");

            migrationBuilder.DropTable(
                name: "Testing Category");

            migrationBuilder.DropTable(
                name: "Phu Luc 4");

            migrationBuilder.DropTable(
                name: "Phu luc 2");

            migrationBuilder.DropTable(
                name: "Selected Topics");

            migrationBuilder.DropTable(
                name: "Subject Room");

            migrationBuilder.DropTable(
                name: "Phu Luc 3");

            migrationBuilder.DropTable(
                name: "Curriculum Distribution");

            migrationBuilder.DropTable(
                name: "Teaching Equipment");

            migrationBuilder.DropTable(
                name: "Teaching Planner");

            migrationBuilder.DropTable(
                name: "Phu Luc 1");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "LevelOfTrainning");

            migrationBuilder.DropTable(
                name: "Professional Standards");

            migrationBuilder.DropTable(
                name: "Specialized Team");
        }
    }
}
