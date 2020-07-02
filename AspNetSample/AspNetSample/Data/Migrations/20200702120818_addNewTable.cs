using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetSample.Data.Migrations
{
    public partial class addNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelMemories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TravelDestinationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelMemories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelMemories_TravelDestinations_TravelDestinationId",
                        column: x => x.TravelDestinationId,
                        principalTable: "TravelDestinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelMemories_TravelDestinationId",
                table: "TravelMemories",
                column: "TravelDestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelMemories");
        }
    }
}
