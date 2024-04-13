using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_MLD.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_date",
                table: "Document 5",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_file",
                table: "Document 5",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_image",
                table: "Document 5",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_date",
                table: "Document 4",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_file",
                table: "Document 4",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_image",
                table: "Document 4",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "created_date",
                table: "Document 3",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_file",
                table: "Document 3",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_image",
                table: "Document 3",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "created_date",
                table: "Document 2",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_file",
                table: "Document 2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_image",
                table: "Document 2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "created_date",
                table: "Document 1",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_file",
                table: "Document 1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_image",
                table: "Document 1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notification_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_user_id",
                table: "Notification",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "Document 5");

            migrationBuilder.DropColumn(
                name: "link_file",
                table: "Document 5");

            migrationBuilder.DropColumn(
                name: "link_image",
                table: "Document 5");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "Document 4");

            migrationBuilder.DropColumn(
                name: "link_file",
                table: "Document 4");

            migrationBuilder.DropColumn(
                name: "link_image",
                table: "Document 4");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "Document 3");

            migrationBuilder.DropColumn(
                name: "link_file",
                table: "Document 3");

            migrationBuilder.DropColumn(
                name: "link_image",
                table: "Document 3");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "Document 2");

            migrationBuilder.DropColumn(
                name: "link_file",
                table: "Document 2");

            migrationBuilder.DropColumn(
                name: "link_image",
                table: "Document 2");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "Document 1");

            migrationBuilder.DropColumn(
                name: "link_file",
                table: "Document 1");

            migrationBuilder.DropColumn(
                name: "link_image",
                table: "Document 1");
        }
    }
}
