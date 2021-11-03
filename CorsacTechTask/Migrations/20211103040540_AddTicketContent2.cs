using Microsoft.EntityFrameworkCore.Migrations;

namespace CorsacTechTask.Migrations
{
    public partial class AddTicketContent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketContent_AspNetUsers_IdentityUserId",
                table: "TicketContent");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketContent_Tickets_TicketId",
                table: "TicketContent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketContent",
                table: "TicketContent");

            migrationBuilder.RenameTable(
                name: "TicketContent",
                newName: "TicketContents");

            migrationBuilder.RenameIndex(
                name: "IX_TicketContent_TicketId",
                table: "TicketContents",
                newName: "IX_TicketContents_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketContent_IdentityUserId",
                table: "TicketContents",
                newName: "IX_TicketContents_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketContents",
                table: "TicketContents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketContents_AspNetUsers_IdentityUserId",
                table: "TicketContents",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketContents_Tickets_TicketId",
                table: "TicketContents",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketContents_AspNetUsers_IdentityUserId",
                table: "TicketContents");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketContents_Tickets_TicketId",
                table: "TicketContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketContents",
                table: "TicketContents");

            migrationBuilder.RenameTable(
                name: "TicketContents",
                newName: "TicketContent");

            migrationBuilder.RenameIndex(
                name: "IX_TicketContents_TicketId",
                table: "TicketContent",
                newName: "IX_TicketContent_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketContents_IdentityUserId",
                table: "TicketContent",
                newName: "IX_TicketContent_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketContent",
                table: "TicketContent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketContent_AspNetUsers_IdentityUserId",
                table: "TicketContent",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketContent_Tickets_TicketId",
                table: "TicketContent",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
