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
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Phu Luc 4",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Phu Luc 3",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Phu luc 2",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "Phu Luc 1",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Phu Luc 4");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Phu Luc 3");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Phu luc 2");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Phu Luc 1",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
