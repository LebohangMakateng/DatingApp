using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AssignmentPARTB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    SourceeUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    VisitedUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => new { x.SourceeUserId, x.VisitedUserId });
                    table.ForeignKey(
                        name: "FK_Visits_AspNetUsers_SourceeUserId",
                        column: x => x.SourceeUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_AspNetUsers_VisitedUserId",
                        column: x => x.VisitedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitedUserId",
                table: "Visits",
                column: "VisitedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");
        }
    }
}
