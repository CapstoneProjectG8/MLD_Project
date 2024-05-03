using System;
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
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khối Lớp", x => x.id);
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
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "s3_file_metadata",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    presigned_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expiration_datetime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_s3_file_metadata", x => x.id);
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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_student = table.Column<int>(type: "int", nullable: true),
                    total_student_selected_topics = table.Column<int>(type: "int", nullable: true),
                    grade_id = table.Column<int>(name: "grade_ id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lớp", x => x.id);
                    table.ForeignKey(
                        name: "FK_Class_Grade",
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
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    login_attempt = table.Column<int>(type: "int", nullable: true),
                    login_last = table.Column<DateTime>(type: "datetime", nullable: true)
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
                name: "Department_Subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_id = table.Column<int>(type: "int", nullable: true),
                    subject_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_Subject", x => x.id);
                    table.ForeignKey(
                        name: "FK_Department_Subject_Specialized Department",
                        column: x => x.department_id,
                        principalTable: "Specialized Department",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Department_Subject_Subject",
                        column: x => x.subject_id,
                        principalTable: "Subject",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<bool>(type: "bit", nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    age = table.Column<int>(type: "int", nullable: true),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level_of_trainning_id = table.Column<int>(type: "int", nullable: true),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    professional_standards_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Account",
                        column: x => x.account_id,
                        principalTable: "Account",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_User_Level Of Trainning",
                        column: x => x.level_of_trainning_id,
                        principalTable: "Level Of Trainning",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_User_Professional Standards",
                        column: x => x.professional_standards_id,
                        principalTable: "Professional Standards",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document 1",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject_id = table.Column<int>(type: "int", nullable: false),
                    grade_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    approve_by = table.Column<int>(type: "int", nullable: true),
                    isApprove = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true),
                    link_file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    other_tasks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kế Hoạch Dạy Học", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document 1_Grade",
                        column: x => x.grade_id,
                        principalTable: "Grade",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document 1_IsApprove",
                        column: x => x.isApprove,
                        principalTable: "IsApprove",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document 1_Subject",
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
                    user_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    approve_by = table.Column<int>(type: "int", nullable: true),
                    isApprove = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true),
                    link_file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kế hoạch Tổ chức Hoạt Động Giáo Dục", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document 2_IsApprove",
                        column: x => x.isApprove,
                        principalTable: "IsApprove",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Kế hoạch Tổ chức Hoạt Động Giáo Dục_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sent_by = table.Column<int>(type: "int", nullable: false),
                    receive_by = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_type = table.Column<int>(type: "int", nullable: true),
                    docId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notification_User",
                        column: x => x.sent_by,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_type = table.Column<int>(type: "int", nullable: true),
                    doc_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    read = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK_Report_User",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Teaching Planner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    class_id = table.Column<int>(type: "int", nullable: false),
                    subject_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User - Lớp - Mon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teaching Planner_Class",
                        column: x => x.class_id,
                        principalTable: "Class",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Teaching Planner_Subject",
                        column: x => x.subject_id,
                        principalTable: "Subject",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Teaching Planner_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
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

            migrationBuilder.CreateTable(
                name: "Document 3",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    document1_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    claas_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    isApprove = table.Column<int>(type: "int", nullable: true),
                    approve_by = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true),
                    link_file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    other_tasks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kế hoạch giáo dục của GV", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document 3_Document 1",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document 3_IsApprove",
                        column: x => x.isApprove,
                        principalTable: "IsApprove",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document 3_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document1_CurriculumDistribution",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document1_id = table.Column<int>(type: "int", nullable: false),
                    curriculum_id = table.Column<int>(type: "int", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document1_CurriculumDistribution_1", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document1_CurriculumDistribution_Curriculum Distribution",
                        column: x => x.curriculum_id,
                        principalTable: "Curriculum Distribution",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document1_CurriculumDistribution_Document 11",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document1_Periodic Assessment",
                columns: table => new
                {
                    testing_category_id = table.Column<int>(type: "int", nullable: false),
                    form_category_id = table.Column<int>(type: "int", nullable: false),
                    document1_id = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodic Assessment", x => new { x.testing_category_id, x.form_category_id, x.document1_id });
                    table.ForeignKey(
                        name: "FK_Document1_Periodic Assessment_Form Category",
                        column: x => x.form_category_id,
                        principalTable: "Form Category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document1_Periodic Assessment_Testing Category",
                        column: x => x.testing_category_id,
                        principalTable: "Testing Category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Periodic Assessment_Document 1",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document1_SelectedTopics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document1_id = table.Column<int>(type: "int", nullable: false),
                    selected_topics_id = table.Column<int>(type: "int", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document1_SelectedTopics_1", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document1_SelectedTopics_Document 11",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document1_SelectedTopics_Selected Topics",
                        column: x => x.selected_topics_id,
                        principalTable: "Selected Topics",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document1_Subject Room",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_room_id = table.Column<int>(type: "int", nullable: true),
                    document1_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document1_Subject Room", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document1_Subject Room_Document 11",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document1_Subject Room_Subject Room",
                        column: x => x.subject_room_id,
                        principalTable: "Subject Room",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document1_TeachingEquipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document1_id = table.Column<int>(type: "int", nullable: false),
                    teaching_equipment_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document1_TeachingEquipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document1_TeachingEquipment_Document 11",
                        column: x => x.document1_id,
                        principalTable: "Document 1",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document1_TeachingEquipment_Teaching Equipment",
                        column: x => x.teaching_equipment_id,
                        principalTable: "Teaching Equipment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document2_Grade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document2_id = table.Column<int>(type: "int", nullable: true),
                    grade_id = table.Column<int>(type: "int", nullable: true),
                    title_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateOnly>(type: "date", nullable: true),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    host_by = table.Column<int>(type: "int", nullable: true),
                    collaborate_with = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document2_Grade", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document2_Grade_Document 2",
                        column: x => x.document2_id,
                        principalTable: "Document 2",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document2_Grade_Grade",
                        column: x => x.grade_id,
                        principalTable: "Grade",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document2_Grade_User",
                        column: x => x.host_by,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document 4",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teaching_planner_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true),
                    link_file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isApprove = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phu Luc 4", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document 4_IsApprove",
                        column: x => x.isApprove,
                        principalTable: "IsApprove",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document 4_Teaching Planner",
                        column: x => x.teaching_planner_id,
                        principalTable: "Teaching Planner",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Scorm",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    teaching_planner_id = table.Column<int>(type: "int", nullable: false),
                    isAprrove = table.Column<bool>(type: "bit", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    link_file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.id);
                    table.ForeignKey(
                        name: "FK_Scorm_Teaching Planner",
                        column: x => x.teaching_planner_id,
                        principalTable: "Teaching Planner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document3_CurriculumDistribution",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document3_id = table.Column<int>(type: "int", nullable: false),
                    curriculum_id = table.Column<int>(type: "int", nullable: true),
                    equipment_id = table.Column<int>(type: "int", nullable: true),
                    subject_room_id = table.Column<int>(type: "int", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document3_CurriculumDistribution_1", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document3_CurriculumDistribution_Curriculum Distribution",
                        column: x => x.curriculum_id,
                        principalTable: "Curriculum Distribution",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document3_CurriculumDistribution_Document 3",
                        column: x => x.document3_id,
                        principalTable: "Document 3",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document3_CurriculumDistribution_Subject Room",
                        column: x => x.subject_room_id,
                        principalTable: "Subject Room",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document3_CurriculumDistribution_Teaching Equipment",
                        column: x => x.equipment_id,
                        principalTable: "Teaching Equipment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Document3_SelectedTopics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document3_id = table.Column<int>(type: "int", nullable: false),
                    selectedTopics_id = table.Column<int>(type: "int", nullable: true),
                    equipment_id = table.Column<int>(type: "int", nullable: true),
                    subject_room_id = table.Column<int>(type: "int", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document3_SelectedTopics", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document3_SelectedTopics_Document 3",
                        column: x => x.document3_id,
                        principalTable: "Document 3",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document3_SelectedTopics_Selected Topics",
                        column: x => x.selectedTopics_id,
                        principalTable: "Selected Topics",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document3_SelectedTopics_Subject Room",
                        column: x => x.subject_room_id,
                        principalTable: "Subject Room",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Document3_SelectedTopics_Teaching Equipment",
                        column: x => x.equipment_id,
                        principalTable: "Teaching Equipment",
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
                    user_id = table.Column<int>(type: "int", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    total = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateOnly>(type: "date", nullable: true),
                    link_file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phu Luc 5", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document 5_Document 4",
                        column: x => x.document4_id,
                        principalTable: "Document 4",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document 5_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Evaluate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document5_id = table.Column<int>(type: "int", nullable: false),
                    evaluate_1_1 = table.Column<int>(type: "int", nullable: true),
                    evaluate_1_2 = table.Column<int>(type: "int", nullable: true),
                    evaluate_1_3 = table.Column<int>(type: "int", nullable: true),
                    evaluate_1_4 = table.Column<int>(type: "int", nullable: true),
                    evaluate_2_1 = table.Column<int>(type: "int", nullable: true),
                    evaluate_2_2 = table.Column<int>(type: "int", nullable: true),
                    evaluate_2_3 = table.Column<int>(type: "int", nullable: true),
                    evaluate_2_4 = table.Column<int>(type: "int", nullable: true),
                    evaluate_3_1 = table.Column<int>(type: "int", nullable: true),
                    evaluate_3_2 = table.Column<int>(type: "int", nullable: true),
                    evaluate_3_3 = table.Column<int>(type: "int", nullable: true),
                    evaluate_3_4 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluate", x => x.id);
                    table.ForeignKey(
                        name: "FK_Evaluate_Document 5",
                        column: x => x.document5_id,
                        principalTable: "Document 5",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Department_Subject_department_id",
                table: "Department_Subject",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Subject_subject_id",
                table: "Department_Subject",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 1_grade_id",
                table: "Document 1",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 1_isApprove",
                table: "Document 1",
                column: "isApprove");

            migrationBuilder.CreateIndex(
                name: "IX_Document 1_subject_id",
                table: "Document 1",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 1_user_id",
                table: "Document 1",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 2_isApprove",
                table: "Document 2",
                column: "isApprove");

            migrationBuilder.CreateIndex(
                name: "IX_Document 2_user_id",
                table: "Document 2",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 3_document1_id",
                table: "Document 3",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 3_isApprove",
                table: "Document 3",
                column: "isApprove");

            migrationBuilder.CreateIndex(
                name: "IX_Document 3_user_id",
                table: "Document 3",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 4_isApprove",
                table: "Document 4",
                column: "isApprove");

            migrationBuilder.CreateIndex(
                name: "IX_Document 4_teaching_planner_id",
                table: "Document 4",
                column: "teaching_planner_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 5_document4_id",
                table: "Document 5",
                column: "document4_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document 5_user_id",
                table: "Document 5",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_CurriculumDistribution_curriculum_id",
                table: "Document1_CurriculumDistribution",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_CurriculumDistribution_document1_id",
                table: "Document1_CurriculumDistribution",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_Periodic Assessment_document1_id",
                table: "Document1_Periodic Assessment",
                column: "document1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1_Periodic Assessment_form_category_id",
                table: "Document1_Periodic Assessment",
                column: "form_category_id");

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
                name: "IX_Document2_Grade_host_by",
                table: "Document2_Grade",
                column: "host_by");

            migrationBuilder.CreateIndex(
                name: "IX_Document3_CurriculumDistribution_curriculum_id",
                table: "Document3_CurriculumDistribution",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document3_CurriculumDistribution_document3_id",
                table: "Document3_CurriculumDistribution",
                column: "document3_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document3_CurriculumDistribution_equipment_id",
                table: "Document3_CurriculumDistribution",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document3_CurriculumDistribution_subject_room_id",
                table: "Document3_CurriculumDistribution",
                column: "subject_room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document3_SelectedTopics_document3_id",
                table: "Document3_SelectedTopics",
                column: "document3_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document3_SelectedTopics_equipment_id",
                table: "Document3_SelectedTopics",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document3_SelectedTopics_selectedTopics_id",
                table: "Document3_SelectedTopics",
                column: "selectedTopics_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document3_SelectedTopics_subject_room_id",
                table: "Document3_SelectedTopics",
                column: "subject_room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluate_document5_id",
                table: "Evaluate",
                column: "document5_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_sent_by",
                table: "Notification",
                column: "sent_by");

            migrationBuilder.CreateIndex(
                name: "IX_Scorm_teaching_planner_id",
                table: "Scorm",
                column: "teaching_planner_id");

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
                name: "IX_User_Department_department_id",
                table: "User_Department",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Department_user_id",
                table: "User_Department",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department_Subject");

            migrationBuilder.DropTable(
                name: "Document1_CurriculumDistribution");

            migrationBuilder.DropTable(
                name: "Document1_Periodic Assessment");

            migrationBuilder.DropTable(
                name: "Document1_SelectedTopics");

            migrationBuilder.DropTable(
                name: "Document1_Subject Room");

            migrationBuilder.DropTable(
                name: "Document1_TeachingEquipment");

            migrationBuilder.DropTable(
                name: "Document2_Grade");

            migrationBuilder.DropTable(
                name: "Document3_CurriculumDistribution");

            migrationBuilder.DropTable(
                name: "Document3_SelectedTopics");

            migrationBuilder.DropTable(
                name: "Evaluate");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "s3_file_metadata");

            migrationBuilder.DropTable(
                name: "Scorm");

            migrationBuilder.DropTable(
                name: "User_Department");

            migrationBuilder.DropTable(
                name: "Form Category");

            migrationBuilder.DropTable(
                name: "Testing Category");

            migrationBuilder.DropTable(
                name: "Document 2");

            migrationBuilder.DropTable(
                name: "Curriculum Distribution");

            migrationBuilder.DropTable(
                name: "Document 3");

            migrationBuilder.DropTable(
                name: "Selected Topics");

            migrationBuilder.DropTable(
                name: "Subject Room");

            migrationBuilder.DropTable(
                name: "Teaching Equipment");

            migrationBuilder.DropTable(
                name: "Document 5");

            migrationBuilder.DropTable(
                name: "Specialized Department");

            migrationBuilder.DropTable(
                name: "Document 1");

            migrationBuilder.DropTable(
                name: "Document 4");

            migrationBuilder.DropTable(
                name: "IsApprove");

            migrationBuilder.DropTable(
                name: "Teaching Planner");

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
                name: "Level Of Trainning");

            migrationBuilder.DropTable(
                name: "Professional Standards");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
