using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MorgenBuffet.Data.Migrations
{
    public partial class _221120205 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<bool>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Adults = table.Column<int>(nullable: false),
                    Kids = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntities");
        }
    }
}
