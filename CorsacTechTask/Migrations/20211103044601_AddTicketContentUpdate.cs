using Microsoft.EntityFrameworkCore.Migrations;

namespace CorsacTechTask.Migrations
{
    public partial class AddTicketContentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketContents_AspNetUsers_IdentityUserId",
                table: "TicketContents");

            migrationBuilder.DropIndex(
                name: "IX_TicketContents_IdentityUserId",
                table: "TicketContents");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "TicketContents");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdentityUserId",
                table: "Tickets",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_IdentityUserId",
                table: "Tickets",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_IdentityUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_IdentityUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "TicketContents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketContents_IdentityUserId",
                table: "TicketContents",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketContents_AspNetUsers_IdentityUserId",
                table: "TicketContents",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
