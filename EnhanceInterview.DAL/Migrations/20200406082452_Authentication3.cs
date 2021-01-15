using Microsoft.EntityFrameworkCore.Migrations;

namespace EnhanceInterview.DAL.Migrations
{
    public partial class Authentication3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewProcesses_Interviwers_InterviewId",
                table: "InterviewProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviwers_Users_UserId",
                table: "Interviwers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviwers",
                table: "Interviwers");

            migrationBuilder.RenameTable(
                name: "Interviwers",
                newName: "Interviewers");

            migrationBuilder.RenameIndex(
                name: "IX_Interviwers_UserId",
                table: "Interviewers",
                newName: "IX_Interviewers_UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Applicants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Interviewers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviewers",
                table: "Interviewers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                table: "Companies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviewers_Users_UserId",
                table: "Interviewers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewProcesses_Interviewers_InterviewId",
                table: "InterviewProcesses",
                column: "InterviewId",
                principalTable: "Interviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviewers_Users_UserId",
                table: "Interviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewProcesses_Interviewers_InterviewId",
                table: "InterviewProcesses");

            migrationBuilder.DropIndex(
                name: "IX_Companies_UserId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviewers",
                table: "Interviewers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Interviewers");

            migrationBuilder.RenameTable(
                name: "Interviewers",
                newName: "Interviwers");

            migrationBuilder.RenameIndex(
                name: "IX_Interviewers_UserId",
                table: "Interviwers",
                newName: "IX_Interviwers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviwers",
                table: "Interviwers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewProcesses_Interviwers_InterviewId",
                table: "InterviewProcesses",
                column: "InterviewId",
                principalTable: "Interviwers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviwers_Users_UserId",
                table: "Interviwers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
