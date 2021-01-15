using Microsoft.EntityFrameworkCore.Migrations;

namespace EnhanceInterview.DAL.Migrations
{
    public partial class Authentication2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Interviwers");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Interviwers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
