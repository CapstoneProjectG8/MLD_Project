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
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role1",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 3_Document 1",
                table: "Document 3");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Teaching Planner",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "login_last",
                table: "Account",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role",
                table: "Account",
                column: "role_id",
                principalTable: "Role",
                principalColumn: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 3_Document 1",
                table: "Document 3",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Document 3_Document 1",
                table: "Document 3");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Teaching Planner",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "login_last",
                table: "Account",
                type: "int",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role1",
                table: "Account",
                column: "role_id",
                principalTable: "Role",
                principalColumn: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document 3_Document 1",
                table: "Document 3",
                column: "document1_id",
                principalTable: "Document 1",
                principalColumn: "id");
        }
    }
}
