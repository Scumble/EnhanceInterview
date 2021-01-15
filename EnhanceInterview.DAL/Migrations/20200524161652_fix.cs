using Microsoft.EntityFrameworkCore.Migrations;

namespace EnhanceInterview.DAL.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Interviewers_InterviewId",
                table: "Feedback");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_InterviewerId",
                table: "Feedback",
                column: "InterviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Interviewers_InterviewerId",
                table: "Feedback",
                column: "InterviewerId",
                principalTable: "Interviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Interviewers_InterviewerId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_InterviewerId",
                table: "Feedback");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Interviewers_InterviewId",
                table: "Feedback",
                column: "InterviewId",
                principalTable: "Interviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
