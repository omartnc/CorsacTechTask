using Microsoft.EntityFrameworkCore.Migrations;

namespace CorsacTechTask.Migrations
{
    public partial class AddTicketContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_IdentityUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_IdentityUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Tickets");

            migrationBuilder.CreateTable(
                name: "TicketContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketContent_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketContent_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketContent_IdentityUserId",
                table: "TicketContent",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketContent_TicketId",
                table: "TicketContent",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketContent");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
