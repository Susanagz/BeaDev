using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class KNN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AxisY",
                table: "Statistics");

            migrationBuilder.AddColumn<int>(
                name: "MonthID",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammLangID",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthID",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "ProgrammLangID",
                table: "Statistics");

            migrationBuilder.AddColumn<string>(
                name: "AxisY",
                table: "Statistics",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
