using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnhanceInterview.DAL.Migrations
{
    public partial class InterviewReject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RejectDate",
                table: "Interviews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "Interviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectDate",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "Interviews");
        }
    }
}
