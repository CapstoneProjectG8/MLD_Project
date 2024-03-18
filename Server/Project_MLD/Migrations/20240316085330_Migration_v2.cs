using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_MLD.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account Role");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_role_id",
                table: "Account",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role",
                table: "Account",
                column: "role_id",
                principalTable: "Role",
                principalColumn: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_role_id",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "Account");

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

            migrationBuilder.CreateIndex(
                name: "IX_Account Role_account_id",
                table: "Account Role",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Account Role_role_id",
                table: "Account Role",
                column: "role_id");
        }
    }
}
