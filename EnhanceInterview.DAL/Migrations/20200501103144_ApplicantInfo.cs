using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnhanceInterview.DAL.Migrations
{
    public partial class ApplicantInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Applicants",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Applicants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Applicants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "Applicants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Applicants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImgPath",
                table: "Applicants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Applicants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Information",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "ProfileImgPath",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Applicants");
        }
    }
}
