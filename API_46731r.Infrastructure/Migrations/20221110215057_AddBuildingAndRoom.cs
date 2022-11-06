using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_46731r.Infrastructure.Migrations
{
    public partial class AddBuildingAndRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                schema: "inventory",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Buildings",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "inventory",
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_RoomId",
                schema: "inventory",
                table: "Computers",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingId",
                schema: "inventory",
                table: "Rooms",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Rooms_RoomId",
                schema: "inventory",
                table: "Computers",
                column: "RoomId",
                principalSchema: "inventory",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Rooms_RoomId",
                schema: "inventory",
                table: "Computers");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Buildings",
                schema: "inventory");

            migrationBuilder.DropIndex(
                name: "IX_Computers_RoomId",
                schema: "inventory",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "RoomId",
                schema: "inventory",
                table: "Computers");
        }
    }
}
