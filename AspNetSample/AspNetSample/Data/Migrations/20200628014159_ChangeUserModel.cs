using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetSample.Data.Migrations
{
    public partial class ChangeUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecommendTravelDestination",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TravelDestinations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(nullable: true),
                    MyApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelDestinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelDestinations_AspNetUsers_MyApplicationUserId",
                        column: x => x.MyApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelDestinations_MyApplicationUserId",
                table: "TravelDestinations",
                column: "MyApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelDestinations");

            migrationBuilder.DropColumn(
                name: "RecommendTravelDestination",
                table: "AspNetUsers");
        }
    }
}
