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
            migrationBuilder.DropPrimaryKey(
                name: "PK_Document1_Subject Room",
                table: "Document1_Subject Room");

            migrationBuilder.DropColumn(
                name: "place_of_birth",
                table: "User");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Notification",
                newName: "sent_by");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_user_id",
                table: "Notification",
                newName: "IX_Notification_sent_by");

            migrationBuilder.AddColumn<DateOnly>(
                name: "date_of_birth",
                table: "User",
                type: "date",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Notification",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "receive_by",
                table: "Notification",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document1_Subject Room_1",
                table: "Document1_Subject Room",
                columns: new[] { "subject_room_id", "document1_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Document1_Subject Room_1",
                table: "Document1_Subject Room");

            migrationBuilder.DropColumn(
                name: "date_of_birth",
                table: "User");

            migrationBuilder.DropColumn(
                name: "receive_by",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "sent_by",
                table: "Notification",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_sent_by",
                table: "Notification",
                newName: "IX_Notification_user_id");

            migrationBuilder.AddColumn<string>(
                name: "place_of_birth",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Notification",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document1_Subject Room",
                table: "Document1_Subject Room",
                columns: new[] { "subject_room_id", "document1_id" });
        }
    }
}
